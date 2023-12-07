using Project_Part_B;

namespace Project_partB_Dykun
{
    public interface ILibrary
    {
        string Address { get; set; }

        public void AddBook(string title, Author author, int numberOfPages,
            Genre genre, int yearOfWriting, Publisher publisher);
        public void AddMagazine(string title, Author author, int numberOfPages,
            Genre genre, int yearOfWriting, Publisher publisher, int isNumber);

        public bool RemoveBook(string title);

        public bool RemoveMagazine(string title);

        public string GetCatalog();

        public string ToString();
    }
}
