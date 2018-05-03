using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    interface IRW
    {
        void DataWrite(string path, ObservableCollection<Cars> obj);
        void DataRead(string path, ObservableCollection<Cars> obj);
    }
}
