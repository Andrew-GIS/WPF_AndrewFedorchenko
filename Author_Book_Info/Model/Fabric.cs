using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Author_Book_Info
{
    public class Fabric
    {
        public static ObservableCollection<Author> GiveAuthorList()
        {
            ObservableCollection<Author> Author_list = new ObservableCollection<Author>
            {
                new Author {FirstName = "John", LastName = "Tolkien", BirthDate= new DateTime(1892, 1, 3), Country = "UK", Language = "EN", PlaceBirth= "Bloemfontein", Books = new ObservableCollection<Book>()
                    {
                        
                        new Book{Title ="Lord of The Ring", Cost = 19.99m, Date = new DateTime(1892, 1, 3), IsNew = false}
                    },
                    IsNew = false
                },

                new Author {FirstName = "William", LastName = "Porter ", BirthDate= new DateTime(1862, 9, 11), Country = "USA", Language = "EN", PlaceBirth= "Greensboro", Books = new ObservableCollection<Book>()
                    {
                        new Book{Title ="Roads of Destiny", Cost = 15.16m, Date = new DateTime(1909, 1, 3), IsNew = false}
                    },
                    IsNew = false
                },
            };
            return Author_list;
        }
    }
}
