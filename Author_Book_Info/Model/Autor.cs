using Author_Book_Info.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author_Book_Info
{
    public class Author: EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public string PlaceBirth { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}