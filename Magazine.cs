using Project_Part_B;

namespace Project_partB_Dykun
{
    public class Magazine : Publication, ICloneable
    {
        private int _issueNumber;

        public int IssueNumber
        {
            get { return _issueNumber; }
            set { _issueNumber = value; }
        }

        private int _numberOfPages;
        private Genre _genre;
        private string _title;
        private Publisher _publisher;
        private int _yearOfWriting;
        private Author _author; // !!!

        public override int NumberOfPages
        {
            get { return _numberOfPages; }
            set
            {
                if (value > 0)
                    _numberOfPages = value;
                else
                    _numberOfPages = 0;
            }
        }

        public override Genre Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public override string Title
        {
            get { return _title; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _title = value;
                else
                    _title = "Без назви";
            }
        }

        public override Publisher Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        public override int YearOfWriting
        {

            get { return _yearOfWriting; }
            set
            {
                DateTime date = DateTime.Now;
                if (value < date.Year)
                    _yearOfWriting = value;
                else
                    _yearOfWriting = 2023;
            }
        }

        public override Author Author // асоціація
        {
            get { return _author; }
            set { _author = value; }
        }

        public Magazine(int numberOfPages, Genre genre, string title,
            Publisher publisher, int yearOfWriting, Author author, int issueNumber)
        {
            _numberOfPages = numberOfPages;
            _genre = genre;
            _title = title;
            _publisher = publisher;
            _yearOfWriting = yearOfWriting;
            _author = author;
            _issueNumber = issueNumber;
        }

        public object Clone() => MemberwiseClone(); // поверхневе копіювання

        public override string DisplayInfo()
        {
            return $"Автор: {Author.Pseudonym}, Назва: {Title}, " +
                $" Номер випуску: {_issueNumber}, Видавництво: {Publisher}, " +
                $"Жанр: {Genre}, Сторiнок: {NumberOfPages}, Рiк видання: {YearOfWriting}";
        }
    }
}
