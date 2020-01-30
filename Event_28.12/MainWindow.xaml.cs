using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace Event_28._12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"MouseEnter: source {e.Source} sender {sender}");
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine($"MouseDown {e.Source} sender {sender}");
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Click {e.Source} sender {sender}");
            if (e.Source == CheckBox)
            {
                return;
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    Button btn = new Button() { Content = $"Button {i}" };
                    btn.Margin = new Thickness(30, 10, 30, 10);
                    btn.Name = $"Button{i}";
                    MyStack.Children.Add(btn);
                }
                MyStack.AddHandler(Button.ClickEvent, new RoutedEventHandler(btn_Button_Click));
            }
        }

        private void btn_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.Source;
            btn.Background = Brushes.Green;
            e.Handled = true;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.CheckBox.IsChecked == true)
            {
                Ellipse.Fill = Brushes.Red;
            }
            else
            {
                Ellipse.Fill = Brushes.Green;
            }
        }
    }
}