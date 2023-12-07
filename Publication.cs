using Project_Part_B;


namespace Project_partB_Dykun
{
    public abstract class Publication
    {
        public abstract int NumberOfPages { get; set; }
        public abstract Genre Genre { get; set; }
        public abstract string Title { get; set; }
        public abstract Publisher Publisher { get; set; }
        public abstract int YearOfWriting { get; set; }
        public abstract Author Author { get; set; }

        public abstract string DisplayInfo();
    }
}
