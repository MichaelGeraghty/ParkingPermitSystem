using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Session;

namespace ParkingPermit
{
    class Program
    {
        //Broker instance which provides the connection to and operaters to the access database
        //Connections are made and closed as an operation is called rather than connecting and holding connection till disconnect
        public static Broker b = new Broker();
        
        public static void Main(string[] args)
        {
            //variables
            int studentID;
            String model;
            String reg;
            String owner;
            int parkingSpace;
            int option;

            //Menu option
            Console.WriteLine("Enter 1 to insert an entry, 2 to show entries, 3 to update an entry, 4 to delete an entry and 0 to exit");
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

                    Insert(studentID, model, reg, owner, parkingSpace);
                }
                //show table contents
                else if (option == 2)
                {
                    ShowTable();
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

                    Update(studentID, model, reg, owner, parkingSpace);
                }
                //delete an entry
                else if (option == 4)
                {
                    Console.WriteLine("Enter Student ID to delete: ");
                    studentID = Convert.ToInt32(Console.ReadLine());

                    b.Delete(studentID);
                }
                //subsequent request for option
                Console.WriteLine("Enter 1 to insert an entry, 2 to show entries, 3 to update an entry and 4 to delete an entry");
                Console.WriteLine("Enter an option");
                option = Convert.ToInt32(Console.ReadLine());
            }

            Console.ReadLine();
        }

       //insert takes the elements necessary to create a valid permit and passes this permit to the broker to be inserted into the database
        private static void Insert(int studentID, string model, string reg, string owner, int parkingSpace)
        {
            Permit permit = new Permit();
            permit.Student_ID = studentID;
            permit.Vehicle_Model = model;
            permit.Registration = reg;
            permit.Owner = owner;
            permit.Parking_Space = parkingSpace;

            b.Insert(permit);
        }
        //update takes the elements necessary to update a valid permit and passes this permit to the broker to update
        private static void Update(int studentID, string model, string reg, string owner, int parkingSpace)
        {
            Permit newPermit = new Permit();

            newPermit.Student_ID = studentID;
            newPermit.Vehicle_Model = model;
            newPermit.Registration = reg;
            newPermit.Owner = owner;
            newPermit.Parking_Space = parkingSpace;

            b.Update(newPermit);
        }
        //calling the show table of our broker
        private static void ShowTable()
        {
            b.ShowTable();
        }
        

    }
}
