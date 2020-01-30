using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Command_Practice28._12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> emploeys;

        public MainWindow()
        {
            InitializeComponent();
            CommandBinding New_bind = new CommandBinding(ApplicationCommands.New);
            New_bind.Executed += NewCommand_Executed;
            CommandBinding Del_bind = new CommandBinding(ApplicationCommands.Delete);
            Del_bind.CanExecute += GeneralCommand_CanExecute;
            Del_bind.Executed += DelCommand_Executed;
            CommandBinding Show_bind = new CommandBinding(MyCustomCommand.Show);
            Show_bind.CanExecute += GeneralCommand_CanExecute;
            Show_bind.Executed += ShowCommand_Executed;
            this.CommandBindings.Add(New_bind);
            this.CommandBindings.Add(Del_bind);
            this.CommandBindings.Add(Show_bind);
            emploeys = Employee.GiveMeListOfEmploee();
            this.GridOfEmpl.ItemsSource = emploeys;
            //NameText.Text = this.GridOfEmpl.SelectedItem.Name;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            emploeys.Add(new Employee(3, "", "", DateTime.Now, false));
        }

        private void DelCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            emploeys.Remove(GridOfEmpl.SelectedItem as Employee);
        }

        private void ShowCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new EmploInfo { DataContext = this.GridOfEmpl.SelectedItem as Employee }.Show();
        }

        private void GeneralCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (GridOfEmpl.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
    }
}