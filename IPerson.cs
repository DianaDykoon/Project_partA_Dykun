

namespace Project_partA_Dykun
{
    public interface IPerson
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }

        public string FullName
        {
            get;
        }

        public string ToString();
    }
}
