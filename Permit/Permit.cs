using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permit
{
    //permit 
    public class Permit
    {
        //variables
        int student_ID;
        String vehicle_Model;
        String registration;
        String owner;
        int parking_Space;
        //getters and setters
        public int Student_ID { get => student_ID; set => student_ID = value; }
        public string Vehicle_Model { get => vehicle_Model; set => vehicle_Model = value; }
        public string Registration { get => registration; set => registration = value; }
        public string Owner { get => owner; set => owner = value; }
        public int Parking_Space { get => parking_Space; set => parking_Space = value; }
    }
}
