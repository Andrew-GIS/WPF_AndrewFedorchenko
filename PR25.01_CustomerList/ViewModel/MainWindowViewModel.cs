using PR25._01_CustomerList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR25._01_CustomerList.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            this.Customers = new ObservableCollection<Customer>
            {
                new Customer {FirstName = "Andew", LastName = "Fedorchenko", City = "Kiew"},
                new Customer {FirstName = "Vlad", LastName = "Radchenko", City = "Khar"}
            };
        }
    }
}
