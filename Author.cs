using Project_partB_Dykun;
using System.ComponentModel.DataAnnotations;

namespace Project_Part_B
{
    public class Author : IPerson
    {
        static int currentId = 1;
        [Key]
        private int _id;

        private string? _firstName;
        private string? _middleName;
        private string? _lastName;
        private DateTime _birth;
        private string? _pseudonym;
        private string? _nationality;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
                else
                    _firstName = "Iван";
            }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _middleName = value;
                }
                else
                    _middleName = "Білий";
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _lastName = value;
                }
                else
                    _lastName = "";
            }
        }

        public DateTime Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        public int Age
        {
            get
            {
                DateTime data = DateTime.Now;
                int age = data.Year - Birth.Year;
                return age;
            }
        }

        public string Pseudonym
        {
            get { return _pseudonym; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _pseudonym = value;
                }
                else
                    _pseudonym = FullName;
            }
        }

        public string Nationality
        {
            get { return _nationality; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nationality = value;
                }
                else
                    _nationality = "Ukraine";
            }
        }

        public string FullName => _firstName + " " + _middleName + " " + _lastName;

        public Author(string FirstName, string MiddleName, string LastName,
            DateTime Birth, string Pseudonym, string Nationality)
        {
            _firstName = FirstName;
            _middleName = MiddleName;
            _lastName = LastName;
            _birth = Birth;
            _pseudonym = Pseudonym;
            _nationality = Nationality;
            Id = currentId++;
        }

        public override string ToString()
        {
            return $"Id = {Id}, Iм'я: {FullName}, Вiк: {Age}, " +
                $"Псевдонiм: {Pseudonym}, Нацiональнiсть: {Nationality}";
        }
    }
}