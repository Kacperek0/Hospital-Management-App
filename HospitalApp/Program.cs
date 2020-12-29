using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Amazon.DynamoDBv2.DocumentModel;
using HospitalEmployees;

namespace HospitalApp
{

    class MainClass
    {

        public static void Main(string[] args)
        {
            new Menu();
        }
    }
}
