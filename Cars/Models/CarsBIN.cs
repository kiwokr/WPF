using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class CarsBIN : IRW
    {
        public void DataRead(string path, ObservableCollection<Cars> obj)
        {
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    obj.Add(new Cars(br.ReadString(), br.ReadDouble(), br.ReadDouble(), br.ReadString(), br.ReadString()));
                }
            }
        }
        public void DataWrite(string path, ObservableCollection<Cars> obj)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                    foreach (var t in obj)
                    {
                        bw.Write(t.Marka);
                        bw.Write(t.Power);
                        bw.Write(t.Cost);
                        bw.Write(t.Color);
                        bw.Write(t.ChangeDate);
                    }
            }
        }
    }
}
