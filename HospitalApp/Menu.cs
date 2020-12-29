using System;
using System.Collections.Generic;
using System.Threading;
using HospitalEmployees;
using System.IO;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace HospitalApp
{
    public class Menu
    {
        public Menu()
        {
            string path = "/hospital.csv";
            string awsAccessKeyId = "";
            string awsSecretAccessKey = "";

            List<Doctor> Doctors = new List<Doctor>();
            List<Nurse> Nurses = new List<Nurse>();
            List<Administrator> Administrators = new List<Administrator>();



            string version = "0.1 pre-alpha";
            while (true)
            {
                Console.WriteLine("------ Hospital Mgmt App ------\n" +
                    $"v. {version}\n" +
                    $"\n" +
                    $"\n" +
                    $"Please press button to continue...\n\n");
                Console.WriteLine("1. Log in\n" +
                    "0. Exit\n");
                int menuSelect = int.Parse(Console.ReadLine());
                switch (menuSelect)
                {
                    case 1:
                        {

                            break;
                        }
                    case 0:
                        {
                            DataExport();
                            Console.WriteLine("Thank you. Bye");
                            Thread.Sleep(5000);
                            break;
                        }
                    default:
                        break;
                }
            }


            void DataLoader()
            {
                var client = new AmazonDynamoDBClient(awsAccessKeyId, awsSecretAccessKey);
                var request = new ScanRequest
                {
                    TableName = "HospitalApp",
                };
                var response = client.Scan(request);

                foreach (Dictionary<string, AttributeValue> item in response.Items)
                {
                    Console.WriteLine(item);
                }
            }

            void DataExport()
            {
                StreamWriter writer = new StreamWriter(path);
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
    }
}
