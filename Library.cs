

namespace Project_partA_Dykun
{
    public class Library : ILibrary
    {
        private string? _address;
        public List<Book> Books;
        private Librarian _librarian;

        public string Address
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Librarian Librarian // асоціація
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }


        public Library(string address, Librarian librarian) // агрегація
        {
            _address = address;
            _librarian = librarian;
            Books = new List<Book>(); // композиція
        }

        public void AddBook(string title, Author author, int numberOfPages, Genre genre, int yearOfWriting, Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(string title)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(string title)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetCatalog()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
