using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Permit
    {
        //variables
        int student_ID;
        String vehicle_Model;
        String registration;
        String owner;
        int parking_Space;
        DateTime due_Date;

        //getters and setters
        public int Student_ID { get => student_ID; set => student_ID = value; }
        public string Vehicle_Model { get => vehicle_Model; set => vehicle_Model = value; }
        public string Registration { get => registration; set => registration = value; }
        public string Owner { get => owner; set => owner = value; }
        public int Parking_Space { get => parking_Space; set => parking_Space = value; }
        public DateTime Due_Date { get => due_Date.Date; set => due_Date = value; }

        //overriding tostring()
        public override string ToString()
        {
            return Student_ID + " " + Vehicle_Model + " " + Registration + " " + Owner + " " + Parking_Space + " " + Due_Date.ToShortDateString();
        }
    }
}
