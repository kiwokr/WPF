using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cars.Models
{
    public class Cars : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string marka;
        private double power;
        private double cost;
        private string color;
        private string changeDate;

        public string Marka
        {
            get { return marka; }
            set
            {
                marka = value;
                OnPropertyChanged("Marka");
            }
        }
        public double Power
        {
            get { return power; }
            set
            {
                power = value;
                OnPropertyChanged("Power");
            }
        }
        public double Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }
        public string ChangeDate
        {
            get { return changeDate; }
            set
            {
                changeDate = value;
                OnPropertyChanged("ChangeDate");
            }
        }

        public Cars()
        {

        }
        public Cars(string marka, double power, double cost, string color)
        {
            Marka = marka;
            Power = power;
            Cost = cost;
            Color = color;
            ChangeDate = DateTime.Now.ToString("dd.MM.yy HH:MM:ss");
        }
        public Cars(string marka, double power, double cost, string color,string ch)
        {
            Marka = marka;
            Power = power;
            Cost = cost;
            Color = color;
            ChangeDate = ch;
        }

        public void filterObj(ObservableCollection<Cars> obj, ObservableCollection<Cars> result, int Index, string filter)
        {
            result.Clear();
            foreach (var T in obj)
            {
                if (Index == 0 && (filter != "" && T.Marka.ToLower() == filter.ToLower()))
                {
                    result.Add(T);
                }
                else if (Index == 1 && (filter != "" && T.Power == Double.Parse(filter)))
                {
                    result.Add(T);
                }
                else if (Index == 2 && (filter != "" && T.Cost == Double.Parse(filter)))
                {
                    result.Add(T);
                }
                else if (Index == 3 && (filter != "" && T.Color.ToLower() == filter.ToLower()))
                {
                    result.Add(T);
                }
            }
            

        }

    }
}
