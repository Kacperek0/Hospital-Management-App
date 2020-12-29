using System;
namespace HospitalEmployees
{
    public class Administrator: Employee
    {
        private string type = "admin";

        public Administrator(string name, string surname, string PESEL, string login, string password) :
                base(name, surname, PESEL, login, password)
        {
        }

        public override string Export()
        {
            return $"{type};{Name};{Surname};{PESEL};{login};{password};null;null;null";
        }
    }
}
