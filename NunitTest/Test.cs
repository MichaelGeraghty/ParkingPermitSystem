using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Business;

namespace NunitTest
{
    [TestFixture]
    class Test
    {
        //access business layer to test methods
        Bll businessTest = new Bll();

        //provides a template permit to test Insert,Update and delete methods 
        [Test]//Passed
        public void TestInsertUpdateDelete()
        {
            //permit
            int studentID = 189431483;
            String model = "Mini Cooper";
            String reg = "181-MO-21533";
            String owner = "Kyle Green";
            int parkingSpace = 19;
            DateTime due_date = new DateTime(2018, 07, 07);
            //test insert into database
            businessTest.Insert(studentID, model, reg, owner, parkingSpace, due_date);
            //change due date 
            due_date = new DateTime(2019, 07, 07);
            //update this permit with new due date
            businessTest.Update(studentID, model, reg, owner, parkingSpace, due_date);
            //delete this permit
            businessTest.Delete(studentID);
        }
        //get total permits in db at time of testing =7 (passed)
        [Test]//passed
        public void getTotalPermits()
        {
           Assert.AreEqual(businessTest.getNumberPermits(),7);
           
        }
        //get valid permits = 4 at time of testing (passed)
        [Test]//passed
        public void getValidPermits()
        {
            Assert.AreEqual(businessTest.getNumberValidPermits(), 4);
        }
        //return percent of valid permits in system at time of test average will be 57%
        [Test]//passed
        public void TestCalculateAverage()
        {
            Assert.AreEqual(businessTest.CalculateAverage(), 57);
        }
        //Print the correct percentage 57 from above
        [Test]//passed
        public void TestPrintPercent()
        {
            businessTest.PrintPercent();
        }
        //returns fees depending on time of permits out of date
        [Test]//Passed
        public void TestCalculateFees()
        {
            businessTest.CollectFees();
        }
        //return number of unique vehicles
        [Test]//passed
        public void TestUniqueVehicles()
        {
            businessTest.UniqueVehicles();
        }
        
        
    }
}
