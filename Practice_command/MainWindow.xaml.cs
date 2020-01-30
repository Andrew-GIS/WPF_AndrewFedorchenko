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

namespace Practice_command
{
    public partial class MainWindow : Window
    {
        private bool isButtonInabled;
        public MainWindow()
        {
            InitializeComponent();

            var bind = new CommandBinding(ApplicationCommands.Help);

            bind.Executed += Bind_Executed;

            bind.CanExecute += Bind_CanExecute;

            this.CommandBindings.Add(bind);

            var checkBoxbind = new CommandBinding(MyCommands.ChangeButtonStatus);
            checkBoxbind.Executed += CheckBox_Executed;
            this.CommandBindings.Add(checkBoxbind);
        }

        private void CheckBox_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.isButtonInabled = !this.isButtonInabled;
        }

        private void Bind_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            //e.CanExecute = DateTime.Now.Second % 2 == 0;
            //e.CanExecute = this.StatusChackBox.IsChecked.Value;
            e.CanExecute = this.isButtonInabled;
        }

        private void Bind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new MainWindow().ShowDialog();
        }

    }
    public static class MyCommands
    {
        public static RoutedCommand ChangeButtonStatus { get; set; }

        static MyCommands()
        {
            ChangeButtonStatus = new RoutedCommand(nameof(ChangeButtonStatus), typeof(MainWindow));
        }
    }
}
