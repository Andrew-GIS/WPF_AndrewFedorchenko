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

namespace FormaShep
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
        private void OnRemoveOne_Click(object sender, RoutedEventArgs e)
        {
            this.ProductGrid.Items.Remove(this.ProductGrid.SelectedItem);
        }

        private void OnClearAll_Click(object sender, RoutedEventArgs e)
        {
            this.ProductGrid.Items.Clear();
        }

        private void OnAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (EnteredText.Text == string.Empty)
            {
                MessageBox.Show("Enter name of your Product, please");
            }
            else
            {
                Random randomPrice = new Random();
                int price = randomPrice.Next(1, 10);
                this.ProductGrid.Items.Add(new Product { ProductName = $"{EnteredText.Text}", ProductPrice = $"{price}$" });
                this.EnteredText.Text = String.Empty;
            }
        }
    }
}
