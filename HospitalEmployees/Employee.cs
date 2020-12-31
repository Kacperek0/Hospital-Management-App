using System;
using System.Threading;

namespace HospitalEmployees
{
    public class Employee
    {
        private string type = "emp";
        public string Name;
        public string Surname;
        public string PESEL;
        //{
        //    get { return PESEL; }
        //    set
        //    {
        //        //if (PESEL.Length != 11)
        //        //{
        //        //    throw new Exceptions.PeselLengthException();
        //        //}
        //        //else
        //        //{
        //        //    PESEL = value;
        //        //}
        //    }
        //}
        protected string login;
        protected string password;

        public Employee(string name, string surname, string PESEL, string login, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;
        }

        //protected virtual bool Login(string login, string password)
        //{
        //    if (this.login == login && this.password == password)
        //    {
        //        Console.WriteLine("You have logged in successfully.");
        //        Thread.Sleep(1000);
        //        return true;
        //    }
        //    else return false;
        //}

        public virtual string Export()
        {
            return $"{type};{Name};{Surname};{PESEL};{login};{password};null;null;null"; ;
        }
    }
}
