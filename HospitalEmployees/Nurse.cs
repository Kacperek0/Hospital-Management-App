using System;
using System.Collections.Generic;
using System.Threading;

namespace HospitalEmployees
{
    public class Nurse: Employee
    {

        public List<int> Shifts;
        //{
        //    get
        //    {
        //        Shifts.Sort();
        //        return Shifts;
        //    }
        //    set
        //    {
        //        if (Shifts.Count > 10)
        //        {
        //            throw new Exceptions.TooManyShiftsException();
        //        }
        //    }
        //}

        public Nurse(string name, string surname, string PESEL, string login, string password)
        {
            this.Role = "nurse";
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;
            Shifts = new List<int>();
        }

        public override string GetRole()
        {
            return "nurse";
        }

        public void AddShift(int day)
        {
            if (!Shifts.Contains(day) && Shifts.Count < 10)
            {
                Shifts.Add(day);
                Shifts.Sort();
            }
            else
            {
                throw new Exceptions.AddShiftFailureException();
            }
        }

        public void RemoveShift(int index)
        {
            Shifts.Remove(index);
            Shifts.Sort();
        }

        public void ShowShifts()
        {
            foreach (var item in Shifts)
            {
                Console.Write($"{item}, ");
            }
        }

        public override string Export()
        {
            string shifts_toexport = "";

            foreach (int item in Shifts)
            {
                shifts_toexport += $"{item},";
            }
            return $"{Role};{Name};{Surname};{PESEL};{login};{password};{shifts_toexport};null;null"; ;
        }

        public bool Login(string login, string password)
        {
            if (base.login == login && base.password == password)
            {
                Console.WriteLine("You have logged in successfully.");
                Thread.Sleep(1000);
                return true;
            }
            else return false;
        }
    }
}
