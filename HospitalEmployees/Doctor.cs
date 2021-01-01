﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace HospitalEmployees
{
    public class Doctor: Employee
    {
        public int PWZnumber { get; set; }
        //{
        //    get { return PWZnumber;  }
        //    private set
        //    {
        //        if (PWZnumber.ToString().Length != 7)
        //        {
        //            throw new Exceptions.PWZnumberLengthException();
        //        }
        //        else
        //        {
        //            PWZnumber = value;
        //        }
        //    }
        //}
        public string Specialization { get; set; }
        //{
        //    get { return Specialization; }
        //    private set
        //    {
        //        if (Specialization.ToLower() == "cardiologist")
        //        {
        //            Specialization = value;
        //        }
        //        else if (Specialization.ToLower() == "urologist")
        //        {
        //            Specialization = value;
        //        }
        //        else if (Specialization.ToLower() == "neurologist")
        //        {
        //            Specialization = value;
        //        }
        //        else if (Specialization.ToLower() == "laryngologist")
        //        {
        //            Specialization = value;
        //        }
        //        else
        //        {
        //            throw new Exceptions.BadSpecializationException();
        //        }
        //    }
        //}
        public List<int> Shifts { get; set; }
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

        public Doctor(string name, string surname, string PESEL, string login, string password,
            int pwznumber, string specialization)
        {
            this.Role = "doctor";
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;
            this.PWZnumber = pwznumber;
            this.Specialization = specialization;
            Shifts = new List<int>();
        }

        public override string GetRole()
        {
            return "doctor";
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
            return $"{Role};{Name};{Surname};{PESEL};{login};{password};{shifts_toexport};{PWZnumber};{Specialization}";
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
