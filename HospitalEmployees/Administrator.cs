using System;
namespace HospitalEmployees
{
    public class Administrator: Employee
    {
        public readonly bool Admin = true;

        public Administrator(string name, string surname, int PESEL, string login, string password) :
                base(name, surname, PESEL, login, password)
        {
        }
    }
}
