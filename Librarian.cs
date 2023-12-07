using Project_partB_Dykun;
using System.ComponentModel.DataAnnotations;

namespace Project_Part_B
{
    public class Librarian : IPerson
    {
        static int currentId = 1;
        [Key]
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string? _firstName;
        private string? _middleName;
        private string? _lastName;
        private DateTime _birth;
        private long _phoneNumber;
        private int _salary;

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

        public long PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value < 380999999999 && value > 380380000000)
                {
                    _phoneNumber = value;
                }
                else
                    _phoneNumber = 380990432132;
            }
        }

        public int Salary
        {
            get { return _salary; }
            set
            {
                if (value > 0)
                    _salary = value;
                else
                    _salary = 100;
            }
        }

        public string FullName => _firstName + " " + _middleName + " " + _lastName;

        public Librarian(string FirstName, string MiddleName, string LastName,
            DateTime Birth, long PhoneNumber, int Salary)
        {
            _firstName = FirstName;
            _middleName = MiddleName;
            _lastName = LastName;
            _birth = Birth;
            _phoneNumber = PhoneNumber;
            _salary = Salary;
            Id = currentId++;
        }

        public override string ToString()
        {
            return $"Id = {Id}, Iм'я: {FullName}, Вiк: {Age}, " +
                $"Телефон: +{PhoneNumber}, Зарплата: {Salary}$";
        }
    }
}
