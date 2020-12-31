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
        private string path = "/Users/kacper.szczepanek/data.csv";

        public Data()
        {
            DataImport();
        }

        private void DataImport()
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] split = line.Split(';');
                if (split[0] == "doctor")
                {
                    Doctors.Add(new Doctor(split[1], split[2], split[3], split[4], split[5], int.Parse(split[6]), split[7]));
                }
                else if (split[0] == "nurse")
                {
                    Nurses.Add(new Nurse(split[1], split[2], split[3], split[4], split[5]));
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
            using (StreamWriter writer = new StreamWriter(path))
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

        public int[] IsLoggedIn(string login, string password)
        {
            int[] result = new int[] { 0, 0 };
            foreach (var item in Doctors)
            {
                if (item.Login(login, password) == true)
                {
                    result = new int[] { 1, 1 };
                    return result;
                }
            }
            foreach (var item in Nurses)
            {
                if (item.Login(login, password) == true)
                {
                    result = new int[] { 1, 2 };
                    return result;
                }
            }
            foreach (var item in Administrators)
            {
                if (item.Login(login, password) == true)
                {
                    result = new int[] { 1, 0 };
                    return result;
                }
            }
            return result;
        }
    }
}
