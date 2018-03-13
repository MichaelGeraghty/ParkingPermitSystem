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

        public void Insert(int studentID, string model, string reg, string owner, int parkingSpace)
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
        public void Update(int studentID, string model, string reg, string owner, int parkingSpace)
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
