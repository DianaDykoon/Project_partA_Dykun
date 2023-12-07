using Project_Part_B;
using System.Collections;

namespace Project_partB_Dykun
{
    public class Library : ILibrary, IEnumerable
    {
        private string? _address;
        public List<Book> Books; // !!
        public List<Magazine> Magazines; // !!
        public List<Librarian> Librarians; 
        public List<Publication> Publications;
        private static int bookCounter;
        private static int magazineCounter;

        public static int BookCounter
        {
            get { return bookCounter; }
        }

        public static int MagazineCounter
        {
            get { return magazineCounter; }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _address = value;
                else
                    _address = "Kharkiv";
            }
        }

        public Library(string address) // агрегація
        {
            _address = address;
            Librarians = new List<Librarian>(); // композиція
            Books = new List<Book>(); // композиція
            Magazines = new List<Magazine>(); // композиція
            Publications = new List<Publication>(); // композиція
        }

        public void AddBook(string title, Author author, int numberOfPages,
            Genre genre, int yearOfWriting, Publisher publisher)
        {
            Book book = new(numberOfPages, genre, title, publisher, yearOfWriting, author);
            Publications.Add(book);
            Books.Add(book);
            bookCounter++;
        }

        public void AddMagazine(string title, Author author, int numberOfPages,
            Genre genre, int yearOfWriting, Publisher publisher, int isNumber)
        {
            Magazine magazine = new(numberOfPages, genre, title, publisher, yearOfWriting, author, isNumber);
            Publications.Add(magazine);
            Magazines.Add(magazine);
            magazineCounter++;
        }

        public bool RemoveBook(string title)
        {
            if (!Books.Exists(p => p.Title == title))
            {
                return false;
            }
            else
            {
                int amount = Books.RemoveAll(deleteBook => deleteBook.Title == title);
                Publications.RemoveAll(deleteBook => deleteBook.Title == title);
                bookCounter -= amount;
                return true;
            }
        }

        public bool RemoveMagazine(string title)
        {
            if (!Magazines.Exists(p => p.Title == title))
            {
                return false;
            }
            else
            {
                int amount = Magazines.RemoveAll(deleteMagazine => deleteMagazine.Title == title);
                Publications.RemoveAll(deleteMagazine => deleteMagazine.Title == title);
                magazineCounter -= amount;
                return true;
            }
        }

        public string GetCatalog()
        {
            string str = "";
            foreach (var publication in Publications)
                str += publication.DisplayInfo() + "\n";
            return str;
        }

        public override string ToString()
        {
            return $"Адреса бiблiотеки - {Address}, кiлькiсть книжок -" +
                $" {BookCounter}, кiлькiсть журналiв - {MagazineCounter}";
        }

        public IEnumerator GetEnumerator()
        {
            return Books.GetEnumerator();
        }
    }
}
