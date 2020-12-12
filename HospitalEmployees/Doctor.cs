using System;
using System.Collections.Generic;

namespace HospitalEmployees
{
    public class Doctor: Employee
    {
        public int PWZnumber
        {
            get { return PWZnumber;  }
            private set
            {
                if (PWZnumber.ToString().Length != 7)
                {
                    throw new Exceptions.PWZnumberLengthException();
                }
                else
                {
                    PWZnumber = value;
                }
            }
        }
        public string Specialization
        {
            get { return Specialization; }
            private set
            {
                if (Specialization.ToLower() == "cardiologist")
                {
                    Specialization = value;
                }
                else if (Specialization.ToLower() == "urologist")
                {
                    Specialization = value;
                }
                else if (Specialization.ToLower() == "neurologist")
                {
                    Specialization = value;
                }
                else if (Specialization.ToLower() == "laryngologist")
                {
                    Specialization = value;
                }
                else
                {
                    throw new Exceptions.BadSpecializationException();
                }
            }
        }
        public List<int> Shifts
        {
            get { return Shifts; }
            set
            {
                if (Shifts.Count > 10)
                {
                    throw new Exceptions.TooManyShiftsException();
                }
            }
        }

        public Doctor(string name, string surname, int PESEL, string login, string password,
            int pwznumber, string specialization):
                base(name, surname, PESEL, login, password)
        {
            this.PWZnumber = pwznumber;
            this.Specialization = specialization;
        }

        public void AddShift(int day)
        {
            if (!Shifts.Contains(day) && Shifts.Count < 10 )
            {
                Shifts.Add(day);
                Shifts.Sort();
            }
            else
            {
                throw new Exceptions.AddShiftFailureException();
            }
        }

    }
}
