using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Business;
using Session;

namespace ParkingPermit
{
    class Program
    {
        //Broker instance which provides the connection to and operaters to the access database
        //Connections are made and closed as an operation is called rather than connecting and holding connection till disconnect
        public static Broker b = new Broker();
        public static Bll business = new Bll();
        
        public static void Main(string[] args)
        {
            //variables
            int studentID;
            String model;
            String reg;
            String owner;
            int parkingSpace;
            DateTime due_date;
            int option;

            //Menu option
            Console.WriteLine("Enter 1 to insert an entry, 2 to show entries, 3 to update an entry, 4 to delete an entry,\n" +
                " 5 to calculate percent of valid utilised Permits, 6 to Determine fees due, 7 to determine number of unique vehicle models and 0 to exit");
            Console.WriteLine("Enter an option");
            option = Convert.ToInt32(Console.ReadLine());
            //while the entry is not 0 keep asking for an option
            while (option!=0)
            {
                //insert entry
                if (option == 1)
                {
                    Console.WriteLine("Enter Student id: ");
                    studentID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car model");
                    model = Console.ReadLine();
                    Console.WriteLine("Enter car registration");
                    reg = Console.ReadLine();
                    Console.WriteLine("Enter owners name");
                    owner = Console.ReadLine();
                    Console.WriteLine("Enter Parking Space number: ");
                    parkingSpace = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Day: ");
                    var day = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Month: ");
                    var month = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    due_date = new DateTime(year, month, day);

                    business.Insert(studentID, model, reg, owner, parkingSpace,due_date);
                }
                //show table contents
                else if (option == 2)
                {
                    business.ShowTable();
                }
                //update an entry
                else if (option == 3)
                {   
                    Console.WriteLine("Enter Student ID to update: ");
                    studentID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car model");
                    model = Console.ReadLine();
                    Console.WriteLine("Enter car registration");
                    reg = Console.ReadLine();
                    Console.WriteLine("Enter owners name");
                    owner = Console.ReadLine();
                    Console.WriteLine("Enter Parking Space number: ");
                    parkingSpace = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Enter Due Date");
                    Console.WriteLine("Day: ");
                    var day = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Month: ");
                    var month = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Year: ");
                    var year = Convert.ToInt32(Console.ReadLine());
                    due_date = new DateTime(year, month, day);

                    business.Update(studentID, model, reg, owner, parkingSpace,due_date);
                }
                //delete an entry
                else if (option == 4)
                {
                    Console.WriteLine("Enter Student ID to delete: ");
                    studentID = Convert.ToInt32(Console.ReadLine());

                    business.Delete(studentID);
                }
                else if (option == 5)
                {
                    Console.WriteLine(business.PrintPercent());
                }
                else if (option == 6)
                {
                    business.CollectFees();
                }
                else if (option == 7)
                {
                    business.UniqueVehicles();
                }
                //subsequent request for option
                Console.WriteLine("Enter 1 to insert an entry, 2 to show entries, 3 to update an entry and 4 to delete an entry," +
                    "\n 5 to calculate percent of valid utilised Permits, 6 to Determine fees due, 7 to determine number of unique vehicle models");
                Console.WriteLine("Enter an option");
                option = Convert.ToInt32(Console.ReadLine());
            }

            Console.ReadLine();
        }
       
    }
}
