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
using System.Windows.Shapes;

namespace Author_Book_Info.Views
{
    /// <summary>
    /// Interaction logic for NewAuthor.xaml
    /// </summary>
    public partial class NewAuthor : Window
    {
        private Author authorNew;

        private Author authorOld;

        public NewAuthor(Author author)
        {
            InitializeComponent();
            this.authorNew = new Author();
            this.DataContext = this.authorNew;
            this.authorOld = author;
            this.authorNew.FirstName = author.FirstName;
            this.authorNew.LastName = author.LastName;
            this.authorNew.BirthDate = author.BirthDate;
            this.authorNew.Country = author.Country;
            this.authorNew.Language = author.Language;
            this.authorNew.PlaceBirth = author.PlaceBirth;
            this.authorNew.IsNew = author.IsNew;
        }

        private void CancelCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void OkAuthorCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();

            this.authorOld.FirstName = this.authorNew.FirstName;
            this.authorOld.LastName = this.authorNew.LastName;
            this.authorOld.BirthDate = this.authorNew.BirthDate;
            this.authorOld.Country = this.authorNew.Country;
            this.authorOld.Language = this.authorNew.Language;
            this.authorOld.PlaceBirth = this.authorNew.PlaceBirth;
            this.authorOld.IsNew = this.authorNew.IsNew;
            this.authorOld.Books = new ObservableCollection<Book>();
        }

        private void Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
                e.CanExecute = true;
        }
    }
}