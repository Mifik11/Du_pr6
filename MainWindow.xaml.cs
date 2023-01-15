using System;
using System.Collections.Generic;
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
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Du_6
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public enum Education //informaci jsem čerpal z vašého kódu na github
    {
        žádne,
        základní,
        střední,
        vysoké,
    }
    public partial class MainWindow : Window
    {
        Employee employee;
        public MainWindow()
        {
            InitializeComponent();
            cbPozice.Items.Add(Education.žádne);
            cbPozice.Items.Add(Education.základní);
            cbPozice.Items.Add(Education.střední);
            cbPozice.Items.Add(Education.vysoké);
            DataContext = employee = new Employee()
            {
               birthday = DateTime.Now
            };
        }

        private void btUlozit_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory("Employee");
            File.WriteAllText($"Employee/{employee.name}_{employee.surname}.txt", $" Name : {employee.name}\n Surname : {employee.surname}\n Birthday : {employee.birthday.ToString("dd.MM.yyyy")}\n Education : {employee.education}\n Position : {employee.position}\n Pay : {employee.pay} Kč");
        }
    }
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _surname;
        private DateTime _birthday = new DateTime();
        public string name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("name");
                OnPropertyChanged("Status");
            }
        }
        public string surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged("surname");
                OnPropertyChanged("Status");
            }
        }
        public DateTime birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged("birthday");
                OnPropertyChanged("Status");
            }
        }
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    class Employee : Person
    {
        private string _position;
        private double _pay;
        private Education _education;
        public string position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged("position");
                OnPropertyChanged("Status");
            }
        }
        public double pay
        {
            get => _pay;
            set
            {
                _pay = value;
                OnPropertyChanged("pay");
                OnPropertyChanged("Status");
            }
        }
        public Education education
        {
            get => _education;
            set
            {
                _education = value;
                OnPropertyChanged("education");
                OnPropertyChanged("Status");
            }
        }
    }
}
