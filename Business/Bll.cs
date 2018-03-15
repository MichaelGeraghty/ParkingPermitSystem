using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session;
using Domain;

namespace Business
{
    public class Bll
    {
        public static Broker b = new Broker();

        public void Insert(int studentID, string model, string reg, string owner, int parkingSpace, DateTime due_date)
        {
            Permit permit = new Permit();
            permit.Student_ID = studentID;
            permit.Vehicle_Model = model;
            permit.Registration = reg;
            permit.Owner = owner;
            permit.Parking_Space = parkingSpace;
            permit.Due_Date = due_date;

            b.Insert(permit);
        }
        public int CalculateAverage()
        {
            double valid = Convert.ToDouble(getNumberValidPermits());
            double total = Convert.ToDouble(getNumberPermits());
            double percent = valid / total;

            return Convert.ToInt32(percent*100);
        }
        public string PrintPercent()
        {
            return "Percent of valid permits in system currently is : " + CalculateAverage() + "%";
        }
        public int getNumberPermits()
        {
            return b.Count();
        }
        public int getNumberValidPermits()
        {
            return b.ValidCount();
        }
        //takes in list of overdue permits then goes through to check if the over due is within a month which will occur a fee of 60
        //otherwise if fee is greater than a month charge 160
        //10 is the default renewal cost
        public void CollectFees()
        {
            List<Permit> list = new List<Permit>();
            list = b.CalculateFees();

            foreach (Permit element in list)
            {
                double fee = 10;
                if ((element.Due_Date < DateTime.Now.AddMonths(-1))) {
                    fee += 50;
                }
                else
                {
                    fee += 150;
                }
                Console.WriteLine(element.ToString() + " Fee's incured are £" + fee);

                fee = 0;
            }
        }
        //return the vehicle models and the number of unique vehicles in sytsem
        public void UniqueVehicles()
        {
            List<String> uniqueList = new List<String>();
            int count = 0;

            uniqueList = b.GetUniqueCars();

            foreach (String element in uniqueList)
            {
                count++;
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine("The number of unique Vehicles in database is " + count);
        }

        //update takes the elements necessary to update a valid permit and passes this permit to the broker to update
        public void Update(int studentID, string model, string reg, string owner, int parkingSpace, DateTime due_date)
        {
            Permit newPermit = new Permit();

            newPermit.Student_ID = studentID;
            newPermit.Vehicle_Model = model;
            newPermit.Registration = reg;
            newPermit.Owner = owner;
            newPermit.Parking_Space = parkingSpace;
            newPermit.Due_Date = due_date;

            b.Update(newPermit);
        }

        //calling the show table of our broker
        public void ShowTable()
        {
            b.ShowTable();
        }
        //calling delete entry
        public void Delete(int studentID)
        {
            b.Delete(studentID);
        }
    }
}
