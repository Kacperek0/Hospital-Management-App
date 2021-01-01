using System;
using System.Threading;

namespace HospitalEmployees
{
    public class Administrator: Employee
    {
        public Administrator(string name, string surname, string PESEL, string login, string password)
        {
            this.Role = "admin";
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;

        }

        public override string GetRole()
        {
            return "admin";
        }

        public override string Export()
        {
            return $"{Role};{Name};{Surname};{PESEL};{login};{password};null;null;null";
        }

        public bool Login(string login, string password)
        {
            if (this.login == login && this.password == password)
            {
                Console.WriteLine("You have logged in successfully.");
                Thread.Sleep(1000);
                return true;
            }
            else return false;
        }
    }
}
