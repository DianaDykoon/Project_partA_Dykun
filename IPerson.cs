

namespace Project_partA_Dykun
{
    public interface IPerson
    {
        int Id { get; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        DateTime Birth { get; set; }

        public string FullName
        {
            get;
        }

        public string ToString();
    }
}
