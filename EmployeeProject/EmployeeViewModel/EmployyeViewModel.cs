using EmployeeProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeProject.EmployeeViewModel
{
    public class EmployyeViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployye { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand GetCommand { get; set; }

        public EmployyeViewModel()
        {
            this.Employees = new ObservableCollection<Employee>();
            this.NewCommand = new RelayCommand(NewCommandExecute);
            this.DeleteCommand = new RelayCommand(DeleteCommandExecute, DeleteCommandCanExecute);
            this.GetCommand = new RelayCommand(GetCommandExecute, GetCommandCanExecute);
        }


        public bool DeleteCommandCanExecute(object obj)
        {
            if (SelectedEmployye != null)
                return true;
            else
                return false;
        }

        public bool GetCommandCanExecute(object obj)
        {
            if (Employees.Count == 0)
                return true;
            else
                return false;
        }

        public void NewCommandExecute(object obj)
        {
            this.Employees.Add(new Employee { Id = Employee.Counter });
        }

        public void GetCommandExecute(object obj)
        {
            Employees.Add(new Employee { Id = Employee.Counter++, Name = "Andrew", Department = "GIS", HireDate = DateTime.Now, IsManager = false });
            Employees.Add(new Employee { Id = Employee.Counter++, Name = "Ivan", Department = "GIS", HireDate = DateTime.Now, IsManager = true });

        }

        public void DeleteCommandExecute(object obj)
        {
            Employees.Remove(SelectedEmployye);
        }
    }
}
