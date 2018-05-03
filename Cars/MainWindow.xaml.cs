using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Cars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Models.Cars> CarsDDR = new ObservableCollection<Models.Cars>();
        ObservableCollection<Models.Cars> CarsCSV = new ObservableCollection<Models.Cars>();
        ObservableCollection<Models.Cars> CarsBIN = new ObservableCollection<Models.Cars>();
        ObservableCollection<Models.Cars> Filter = new ObservableCollection<Models.Cars>();
        Models.Cars CarsFilter = new Models.Cars();
        Models.CarsBIN CarsBINmethods = new Models.CarsBIN();
        Models.CarsCSV CarsCSVmethods = new Models.CarsCSV();
        string Storage = "DDR";
        string Path;
        public MainWindow()
        {
            InitializeComponent();
            DataGrid.ItemsSource = CarsDDR;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (RBddr.IsChecked == true)
            {
                CarsDDR[e.Row.GetIndex()].ChangeDate = DateTime.Now.ToString("dd.MM.yy HH:MM:ss");
            }
            else if (RBbin.IsChecked == true)
            {
                CarsBIN[e.Row.GetIndex()].ChangeDate = DateTime.Now.ToString("dd.MM.yy HH:MM:ss");
            }
            else
            {
                CarsCSV[e.Row.GetIndex()].ChangeDate = DateTime.Now.ToString("dd.MM.yy HH:MM:ss");
            }
        }
        private void StorageChange_Click(object sender, RoutedEventArgs e)
        {
            if (RBddr.IsChecked == true)
            {
                DataGrid.ItemsSource = CarsDDR;
                Storage = "DDR";
            }
            else if (RBbin.IsChecked == true)
            {
                DataGrid.ItemsSource = CarsBIN;
                Storage = "BIN";
            }
            else
            {
                DataGrid.ItemsSource = CarsCSV;
                Storage = "CSV";
            }
        }
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Filter;
            if (CBfilter.SelectedIndex == 0)
            {
                if (RBddr.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsDDR, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else if (RBbin.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsBIN, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else if (RBcsv.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsCSV, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else
                {
                    CarsFilter.filterObj(Filter, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }

            }
            else if (CBfilter.SelectedIndex == 1)
            {
                if (RBddr.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsDDR, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else if (RBbin.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsBIN, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else
                {
                    CarsFilter.filterObj(CarsCSV, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
            }
            else if (CBfilter.SelectedIndex == 2)
            {
                if (RBddr.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsDDR, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else if (RBbin.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsBIN, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else
                {
                    CarsFilter.filterObj(CarsCSV, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
            }
            else if (CBfilter.SelectedIndex == 3)
            {
                if (RBddr.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsDDR, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else if (RBbin.IsChecked == true)
                {
                    CarsFilter.filterObj(CarsBIN, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
                else
                {
                    CarsFilter.filterObj(CarsCSV, Filter, CBfilter.SelectedIndex, TxtBoxFilter.Text);
                }
            }
        }
        private void FilterAbortButton_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxFilter.Text = "";
            if (RBddr.IsChecked == true)
            {
                DataGrid.ItemsSource = CarsDDR;
            }
            else if (RBbin.IsChecked == true)
            {
                DataGrid.ItemsSource = CarsBIN;
            }
            else
            {
                DataGrid.ItemsSource = CarsCSV;
            }
        }
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog OFD = new OpenFileDialog();
            //OFD.InitialDirectory = "\\";
            OFD.Filter = "CSV files (*.csv)|*csv| BIN files(*.bin)|*bin| All files (*.*)|*.*";
            OFD.ShowDialog();
            string path = OFD.FileName;
            string[] init = path.Split('.');
            if (init[init.Length - 1].ToLower() == "csv")
            {
                RBcsv.IsChecked = true;
                DataGrid.ItemsSource = CarsCSV;
                Path = OFD.FileName;
                CarsCSVmethods.DataRead(Path, CarsCSV);                
            }
            else if(init[init.Length - 1].ToLower() == "bin")
            {
                RBbin.IsChecked = true;
                DataGrid.ItemsSource = CarsBIN;
                Path = OFD.FileName;
                CarsBINmethods.DataRead(Path, CarsBIN);
            }
        }

        private void SaveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "CSV files (*.csv)|*csv| BIN files(*.bin)|*bin| All files (*.*)|*.*";
          //SFD.InitialDirectory = @"*\bin\Debug\";
            SFD.FilterIndex = 3;
            SFD.ShowDialog();
            string path = SFD.FileName;
            string[] init = path.Split('.');
            if (SFD.FilterIndex == 0 || init[init.Length - 1].ToLower() == "csv")
            {
                switch (Storage)
                {
                    case "DDR":
                        CarsCSVmethods.DataWrite(path, CarsDDR);
                        break;
                    case "CSV":
                        CarsCSVmethods.DataWrite(path, CarsCSV);
                        break;
                    case "BIN":
                        CarsCSVmethods.DataWrite(path, CarsBIN);
                        break;
                }
            }
            else if (SFD.FilterIndex == 1 || init[init.Length - 1].ToLower() == "bin")
            {
                switch (Storage)
                {
                    case "DDR":
                        CarsBINmethods.DataWrite(path, CarsDDR);
                        break;
                    case "CSV":
                        CarsBINmethods.DataWrite(path, CarsCSV);
                        break;
                    case "BIN":
                        CarsBINmethods.DataWrite(path, CarsBIN);
                        break;
                }
            }
        }

        private void NewCsvMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CarsCSV.Clear();
            Storage = "CSV";
            DataGrid.ItemsSource = CarsCSV;
            Path = "Files/CSVfile.csv";
            File.Create(Path);
        }

        private void NewBinMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CarsBIN.Clear();
            Storage = "BIN";
            DataGrid.ItemsSource = CarsBIN;
            Path = "Files/BINfile.bin";
            File.Create(Path);
        }
    }
}
