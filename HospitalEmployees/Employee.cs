using System;
namespace HospitalEmployees
{
    public class Employee
    {
        public string Name;
        public string Surname;
        public int PESEL
        {
            get { return PESEL; }
            set
            {
                if (PESEL.ToString().Length != 8)
                {
                    throw new Exceptions.PeselLengthException();
                }
                else
                {
                    PESEL = value;
                }
            }
        }
        protected string login;
        protected string password;

        public Employee(string name, string surname, int PESEL, string login, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;
        }
    }
}
