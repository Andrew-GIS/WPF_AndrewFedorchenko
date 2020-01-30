using PR_SelfCustomer.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard;

namespace PR_SelfCustomer.CustomerViewModel
{
    public class CustomerEditViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        private CustomersRepository Repository { get; set; }

        public ICommand GetCommand { get; set; }

        public CustomerEditViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;
            this.Repository = new CustomersRepository();

            this.GetCommand = new RelayCommand(GetVommand_Execute, GetCommand_CanExecute);


            this.Customers = new ObservableCollection<Customer>();

        }

        public bool GetCommand_CanExecute(object obj)
        {
            return true;
        }

        public void GetVommand_Execute(object obj)
        {
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>(this.Repository.GetCustomersAsync().Result);

            foreach (var item in collection)
            {
                this.Customers.Add(item);
            }
        }
    }
}
