using System;
using System.Threading;

namespace HospitalEmployees
{
    public abstract class Employee
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
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
        public string login { get; set; }
        protected string password { get; set; }

        public string FullName
        {
            get
            {
                return String.Format($"{Name} {Surname}");
            }
        }

        public virtual string GetRole()
        {
            return "employee";
        }

        public virtual string Export()
        {
            return $"{Role};{Name};{Surname};{PESEL};{login};{password};null;null;null"; ;
        }
    }
}
