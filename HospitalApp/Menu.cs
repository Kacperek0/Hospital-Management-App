using System;
using System.Collections.Generic;
using System.Threading;
using HospitalEmployees;
using System.IO;

namespace HospitalApp
{
    public class Menu
    {
        protected Data Data;
        private string version = "0.1 pre-alpha";

        public Menu()
        {
            try
            {
                Data = new Data();
                bool state = true;
                while (state)
                {
                    try
                    {
                        Console.WriteLine
                        (
                            "------ Hospital Mgmt App ------\n" +
                            $"v. {version}\n" +
                            $"\n" +
                            $"\n" +
                            $"Please press button to continue...\n\n");
                        Console.WriteLine("1. Log in\n" +
                        "0. Exit\n"
                            );
                        int menuSelect = int.Parse(Console.ReadLine());
                        switch (menuSelect)
                        {
                            case 1:
                                {
                                    new Login(); //not printing content :not_stonks:
                                    break;
                                }
                            case 0:
                                {
                                    Data.DataExport();
                                    Console.WriteLine("Thank you. Bye");
                                    Thread.Sleep(1000);
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("Try again...");
                                    Thread.Sleep(1000);
                                    break;
                                }
                        }
                        state = false;
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Null here? Good try :), but please try again.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Bad input format. Please try with numbers!");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Overflow, please try with numbers only!");
                    }

                }
                    
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please place data file in your home directory and press any button to try again.");
                Console.ReadKey();
            }
        }
    }
}
