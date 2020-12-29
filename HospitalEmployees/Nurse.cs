using System;
using System.Collections.Generic;

namespace HospitalEmployees
{
    public class Nurse: Employee
    {
        private string type = "nurse";

        public List<int> Shifts
        {
            get
            {
                Shifts.Sort();
                return Shifts;
            }
            set
            {
                if (Shifts.Count > 10)
                {
                    throw new Exceptions.TooManyShiftsException();
                }
            }
        }

        public Nurse(string name, string surname, int PESEL, string login, string password) :
                base(name, surname, PESEL, login, password)
        {
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

        public override string Export()
        {
            string shifts_toexport = "";

            foreach (int item in Shifts)
            {
                shifts_toexport += $"{item},";
            }
            return $"{type};{Name};{Surname};{PESEL};{login};{password};{shifts_toexport};null;null"; ;
        }
    }
}
