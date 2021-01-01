using System;
namespace HospitalApp.Abstracts
{
    public abstract class Submenu
    {
        public string FullName;
        protected Data data;

        public Submenu()
        {
            data = new Data();
        }

        public virtual void ShowPersonnel()
        {

        }

        public virtual void ShowDuty()
        {

        }

        protected void holder()
        {
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
