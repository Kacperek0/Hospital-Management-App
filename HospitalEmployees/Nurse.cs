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

        public Nurse(string name, string surname, string PESEL, string login, string password, string shifts)
        {
            this.Role = "nurse";
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;
            Shifts = new List<int>();

            string[] split = shifts.Split(',');
            foreach (var item in split)
            {
                Shifts.Add(int.Parse(item));
            }
        }

        public override string GetRole()
        {
            return "nurse";
        }

        public void AddShift(int day)
        {
            if (!Shifts.Contains(day) && Shifts.Count < 10 && day < 30 && day > 0)
            {
                Shifts.Add(day);
                Shifts.Sort();
            }
            else
            {
                Console.WriteLine("Failed to add a shift.");
            }
        }

        public void RemoveShift(int index)
        {
            if (Shifts.Count > 1)
            {
                if (Shifts.Contains(index))
                {
                    Shifts.Remove(index);
                    Shifts.Sort();
                }
                else
                {
                    Console.WriteLine("There is no such shift.");
                }
            }
            else
            {
                Console.WriteLine("There have to be at least one shift.");
            }

        }

        public void ShowShifts()
        {
            Console.WriteLine("There are scheduled shifts at following days of the month:");
            foreach (var item in Shifts)
            {
                Console.Write($"{item}, ");
            }
        }

        public override string Export()
        {
            string shifts_toexport = "";

            for (int i = 0; i < Shifts.Count; i++)
            {
                if (i == Shifts.Count - 1)
                {
                    shifts_toexport += $"{Shifts[i]}";
                }
                else
                {
                    shifts_toexport += $"{Shifts[i]},";
                }
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
