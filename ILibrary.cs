

namespace Project_partA_Dykun
{
    public interface ILibrary
    {
        string Address { get; set; }

        public void AddBook(string title, Author author, int numberOfPages,
            Genre genre, int yearOfWriting, Publisher publisher);

        public Book GetBook(string title); //??

        public void RemoveBook(string title);

        public List<Book> GetCatalog();

        public string ToString();

    }
}
