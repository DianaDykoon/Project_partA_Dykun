using Project_Part_B;

namespace Project_partB_Dykun
{
    public class Program
    {
        static void Main()
        {
            DateTime date = DateTime.Now;
            Author author1 = new("Ivan", "Baranov", "Oleksandrovich", new DateTime(2000, 10, 3), "Ivan B", "Ukraine");
            Author author2 = new("Maria", "Bondar", "Dmitrovich", new DateTime(1987, 10, 4), "Mary", "USA");
            Author author3 = new("Alex", "Alexeyev", "Yurievich", new DateTime(1982, 3, 1), "Alex", "Polsha");
            Author author4 = new("Eugheniy", "Petrenko", "Olegovich", new DateTime(1984, 4, 12), "Zhenya", "Ukraine");

            List<Author> authors = new() { author1, author2, author3, author4 };

            Librarian librarian1 = new("Oleg", "Lyash", "Ivanovich", new DateTime(2002, 7, 10), 380970234580, 1500);
            Librarian librarian2 = new("Dmytro", "Boykov", "Bohdanovich", new DateTime(2004, 2, 12), 380970424560, 2000);
            Librarian librarian3 = new("Valeria", "Kekuin", "Andreevna", new DateTime(2003, 12, 12), 380503534580, 1700);

            // Створення бібліотеки з бібліотекарями та книгами
            Library library = new("Kharkiv");
            library.Librarians.Add(librarian1);
            library.Librarians.Add(librarian2);
            library.Librarians.Add(librarian3);
            library.AddBook("Детектив", author4, 200, Genre.Detective, 2009, Publisher.Macmillan);
            library.AddBook("Трiлер", author3, 340, Genre.Thriller, 2010, Publisher.Pearson);
            library.AddBook("Новела", author2, 174, Genre.Comedy, 2012, Publisher.Pearson);

            // Додавання журналів у бібліотеку
            Magazine mag1 = new(25, Genre.Comedy, "People", Publisher.Scholastic, 2023, author1, 1);
            Magazine mag2 = (Magazine)mag1.Clone();
            mag2.IssueNumber = 2;
            mag2.NumberOfPages = 29;
            Magazine mag3 = (Magazine)mag1.Clone();
            mag3.IssueNumber = 3;
            mag3.NumberOfPages = 20;

            library.AddMagazine(mag1.Title, mag1.Author, mag1.NumberOfPages,
                mag1.Genre, mag1.YearOfWriting, mag1.Publisher, mag1.IssueNumber);
            library.AddMagazine(mag2.Title, mag2.Author, mag2.NumberOfPages,
                mag2.Genre, mag2.YearOfWriting, mag2.Publisher, mag2.IssueNumber);
            library.AddMagazine(mag3.Title, mag3.Author, mag3.NumberOfPages,
                mag3.Genre, mag3.YearOfWriting, mag3.Publisher, mag3.IssueNumber);

            bool restart = true;
            while (restart)
            {
                Console.WriteLine(" 1 - Додати нову публiкацiю\n 2 - Видалити публiкацiю\n" +
                    " 3 - Вивести всi книги\n 4 - Вивести всi журнали\n 5 - Вивести весь каталог бiблiотеки\n" +
                    " 6 – Вивести список авторiв\n 7 – Вивести список бiблiотекарiв\n" +
                    " 8 - Подивитись iнформацiю про бiблiотеку\n 0 - Вийти з програми");
                Console.Write("Виберiть пункт меню (0 - 8) --->");
                int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 0:
                        restart = false;
                        break;

                    case 1:
                        AddObject(ref library, authors);
                        break;

                    case 2:
                        RemoveObject(ref library);
                        break;

                    case 3:
                        Console.WriteLine("\n---------- Список книг бiблiотеки ---------- ");
                        foreach (var book in library)
                            Console.WriteLine(book);
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("\n---------- Список журналiв бiблiотеки ---------- ");
                        foreach (var magazine in library.Magazines)
                            Console.WriteLine(magazine.DisplayInfo());
                        Console.WriteLine();
                        break;

                    case 5:
                        string catalog = library.GetCatalog();
                        Console.WriteLine("\n---------- Каталог бiблiотеки ---------- ");
                        Console.WriteLine(catalog);
                        break;

                    case 6:
                        Console.WriteLine("\n---------- Список авторiв ---------- ");
                        foreach (var author in authors)
                            Console.WriteLine(author.ToString());
                        Console.WriteLine();
                        break;

                    case 7:
                        Console.WriteLine("\n---------- Список бiблiотекарiв ---------- ");
                        foreach (var librarian in library.Librarians)
                            Console.WriteLine(librarian.ToString());
                        Console.WriteLine();
                        break;

                    case 8:
                        Console.WriteLine(library.ToString());
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Такого пункту меню не iснує\n");
                        break;
                }
            }
        }

        // Метод для додавання публікації у бібліотеку
        static void AddObject(ref Library library, List<Author> authors)
        {
            Console.Write("Яку публiкацiю ви хочете додати до бiблiотеки? (1 - Книгу, 2 - Журнал) --->");
            int type = int.Parse(Console.ReadLine());
            switch (type)
            {
                case 1:
                    Console.WriteLine("Введiть назву книги --->");
                    string title = Console.ReadLine();
                    Console.WriteLine("Введiть id автора --->");
                    int authorId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введiть кiлькiсть сторiнок --->");
                    int numberOfPages = int.Parse(Console.ReadLine());
                    Genre genre = new();
                    try
                    {
                        Console.WriteLine("Введiть жанр книги --->");
                        genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Помилка: {e.Message}.");
                    }
                    Console.WriteLine("Введiть рiк видання --->");
                    int year = int.Parse(Console.ReadLine());
                    Publisher publisher = new();
                    try
                    {
                        Console.WriteLine("Введiть видавництво --->");
                        publisher = (Publisher)Enum.Parse(typeof(Publisher), Console.ReadLine(), true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Помилка: {e.Message}.");
                    }
                    library.AddBook(title, authors[authorId - 1], numberOfPages, genre, year, publisher);

                    break;

                case 2:
                    Console.WriteLine("Введiть назву журнала --->");
                    string title2 = Console.ReadLine();
                    Console.WriteLine("Введiть id автора --->");
                    int authorId2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введiть кiлькiсть сторiнок --->");
                    int numberOfPages2 = int.Parse(Console.ReadLine());
                    Genre genre2 = new();
                    try
                    {
                        Console.WriteLine("Введiть жанр журналу --->");
                        genre = (Genre)Enum.Parse(typeof(Genre), Console.ReadLine(), true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Помилка: {e.Message}.");
                    }
                    Console.WriteLine("Введiть рiк видання --->");
                    int year2 = int.Parse(Console.ReadLine());
                    Publisher publisher2 = new();
                    try
                    {
                        Console.WriteLine("Введiть видавництво --->");
                        publisher = (Publisher)Enum.Parse(typeof(Publisher), Console.ReadLine(), true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Помилка: {e.Message}.");
                    }
                    Console.WriteLine("Введiть номер випуску --->");
                    int issueNumber = int.Parse(Console.ReadLine());

                    library.AddMagazine(title2, authors[authorId2 - 1], numberOfPages2, genre2, year2, publisher2, issueNumber);
                    break;
            }
        }

        // Метод видалення публікації з бібліотеки
        static void RemoveObject(ref Library library)
        {
            Console.Write("Яку публiкацiю ви хочете видалити? (1 - Книгу, 2 - Журнал) --->");
            int type = int.Parse(Console.ReadLine());
            switch (type)
            {
                case 1:
                    Console.Write("Введiть назву книги для видалення: ");
                    string titleOfBook = Console.ReadLine();

                    if (library.RemoveBook(titleOfBook))
                    {
                        Console.WriteLine($"Книгу пiд назвою {titleOfBook} видалено успiшно");
                        break;
                    }
                    else
                        Console.WriteLine("Книги з такою назвою не iснує");

                    break;

                case 2:
                    Console.Write("Введiть назву журнала для видалення: ");
                    string titleOfMagazine = Console.ReadLine();

                    if (library.RemoveMagazine(titleOfMagazine))
                    {
                        Console.WriteLine($"Журнал пiд назвою {titleOfMagazine} видалено успiшно");
                        break;
                    }
                    else
                        Console.WriteLine("Журналу з такою назвою не iснує");
                    break;

                default:
                    Console.WriteLine("Помилка вводу!");
                    break;
            }
        }
    }
}