using COUNTER.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace COUNTER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DataGrid1> dg1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Btn = (Button)sender;
            string b = Btn.Content.ToString();

            var task = new Task(() =>
            {
                this.Dispatcher.Invoke(() => {
                    BtnPrueba.IsEnabled = false;
                });

                //int i = 100;

                for (int i = 0; i < 100; i++)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        lblTexto.Content = "Porcentaje: " + i.ToString() + " %";
                        txtPorc.Text = i.ToString();
                    });

                    Thread.Sleep(10);
                }

                //MessageBox.Show("Terminó!!!....");

                this.Dispatcher.Invoke(() =>
                {
                    lblTexto.Content = "Texto";
                    BtnPrueba.IsEnabled = true;
                });
            });
            

            task.Start();
            task.Wait();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            dg1 = new List<DataGrid1>()
            {
                new DataGrid1(){ dato1 = 1, dato2 = "Segundo Registro, primera fila", dato3 = "Tercer Registro, primera fila" },
                new DataGrid1(){ dato1 = 2, dato2 = "Segundo Registro, segunda fila", dato3 = "Tercer Registro, segunda fila" }
            };
            
            //dg1.Add(new DataGrid1
            //{
            //    dato1 = "Primer Registro, primera fila",
            //    dato2 = "Segundo Registro, primera fila",
            //    dato3 = "Tercer Registro, primera fila"
            //});

            //dg1.Add(new DataGrid1
            //{
            //    dato1 = "Primer Registro, segunda fila",
            //    dato2 = "Segundo Registro, segunda fila",
            //    dato3 = "Tercer Registro, segunda fila"
            //});



            DGPrueba1.ItemsSource = dg1;
        }

        private void NuevoRegistro_Click(object sender, RoutedEventArgs e)
        {
            int reg = DGPrueba1.Items.Count + 1;

            dg1.Add(new DataGrid1() { dato1 = reg, dato2 = "Segundo Registro, tercera fila", dato3 = "Tercer Registro, tercera fila" });
            
            DGPrueba1.Items.Refresh();

            //DataGrid1 loc = (DataGrid1)DGPrueba1.ItemsSource;

            //dg1.Add(new DataGrid1
            //{
            //    dato1 = "Primer Registro, tercera fila",
            //    dato2 = "Segundo Registro, tercera fila",
            //    dato3 = "Tercer Registro, tercera fila"
            //});
        }

        private void EliminaRegistro_Click(object sender, RoutedEventArgs e)
        {
            var ItemRemove = dg1.Single(s => s.dato1 == int.Parse(txtRemove.Text));
            dg1.Remove(ItemRemove);

            DGPrueba1.Items.Refresh();
        }

        private void ActualizaRegistro_Click(object sender, RoutedEventArgs e)
        {
            int RegCount = DGPrueba1.Items.Count;

            for (int i = 0; i < RegCount; i++)
            {
                dg1[int.Parse(txtRemove.Text)].dato2 = "XXXX";
            }

            DGPrueba1.Items.Refresh();
        }
    }
}
