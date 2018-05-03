using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class CarsCSV : IRW
    {
        public void DataRead(string path, ObservableCollection<Cars> obj)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string FullCSV = sr.ReadToEnd();
                string[] OneExem = FullCSV.Split(';');
                if (OneExem == null)
                {
                    System.Windows.MessageBox.Show("Фаил пуст");
                }
                else
                {
                    foreach (var t in OneExem)
                    {
                        string[] param = t.Split(',');
                        if (param.Length == 5)
                        {
                            obj.Add(new Cars(param[0], Double.Parse(param[1]), Double.Parse(param[2]), param[3], param[4]));
                        }

                    }
                }

            }
        }
        public void DataWrite(string path, ObservableCollection<Cars> obj)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                    foreach (var Ex in obj)
                    {
                        sw.Write(Ex.Marka + ',' +
                                 Ex.Power + ',' +
                                 Ex.Cost + ',' +
                                 Ex.Color + ',' +
                                 Ex.ChangeDate + ';');
                    }
                    sw.Close();
            }
        }
    }
}

