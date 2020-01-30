using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDashboard.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Customer> customer;

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer SeletctedCustomer { get; set; }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (this.customer == value)
                    return;

                this.customer = value;
                this.OnPropertyChanged(nameof(this.Customers));
            }
        }

        public MainWindowViewModel()
        {
            this.Customers = new ObservableCollection<Customer>
            {
                new Customer{FirstName = "Ande", LastName = "Fed", Phone = "111" },
                new Customer{FirstName = "Vlad", LastName = "Rad", Phone = "222" }
            };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}