using System;
using System.Collections.Generic;
using System.IO;
using HospitalEmployees;

namespace HospitalApp
{
    public class Data
    {

        public List<Doctor> Doctors = new List<Doctor>();
        public List<Nurse> Nurses = new List<Nurse>();
        public List<Administrator> Administrators = new List<Administrator>();
        public string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                   Environment.OSVersion.Platform == PlatformID.MacOSX)
                 ? Environment.GetEnvironmentVariable("HOME")
                 : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        public Data()
        {
            DataImport();
        }

        private void DataImport()
        {
            string[] lines = File.ReadAllLines($"{homePath}/data.csv");
            foreach (string line in lines)
            {
                string[] split = line.Split(';');
                if (split[0] == "doctor")
                {
                    Doctors.Add(new Doctor(split[1], split[2], split[3], split[4], split[5], split[6], int.Parse(split[7]), split[8]));
                }
                else if (split[0] == "nurse")
                {
                    Nurses.Add(new Nurse(split[1], split[2], split[3], split[4], split[5], split[6]));
                }
                else if (split[0] == "admin")
                {
                    Administrators.Add(new Administrator(split[1], split[2], split[3], split[4], split[5]));
                }
                else
                {
                    throw new Exceptions.InternalDataErrorException();
                }

            }
        }

        public void DataExport()
        {
            using (StreamWriter writer = new StreamWriter($"{homePath}/data.csv"))
            {
                foreach (var item in Doctors)
                {
                    writer.WriteLine(item.Export());
                }
                foreach (var item in Nurses)
                {
                    writer.WriteLine(item.Export());
                }
                foreach (var item in Administrators)
                {
                    writer.WriteLine(item.Export());
                }
            }

        }

        public void AddNurse(string name, string surname, string PESEL, string login, string password)
        {
            Nurses.Add(new Nurse(name, surname, PESEL, login, password, "0"));
        }

        public void AddDoctor(string name, string surname, string PESEL, string login, string password, int pwznumber, string specialization)
        {
            Doctors.Add(new Doctor(name, surname, PESEL, login, password, "0", pwznumber, specialization));
        }

        public void AddAdmin(string name, string surname, string PESEL, string login, string password)
        {
            Administrators.Add(new Administrator(name, surname, PESEL, login, password));
        }
    }
}
