using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COUNTER.Model
{
    public class DataGrid1 : INotifyCollectionChanged, INotifyPropertyChanged
    {
        public int dato1 { get; set; }
        public string dato2 { get; set; }
        public string dato3 { get; set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
