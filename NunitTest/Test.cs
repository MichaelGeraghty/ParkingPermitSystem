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
        Bll businessTest = new Bll();

        //calling the update on the previously inseted permit to simulate a parking space being changed and a due date being updated by a year
        [Test]
        public void TestInsertUpdateDelete()
        {
            int studentID = 189431483;
            String model = "Mini Cooper";
            String reg = "181-MO-21533";
            String owner = "Kyle Green";
            int parkingSpace = 19;
            DateTime due_date = new DateTime(2018, 07, 07);

            businessTest.Insert(studentID, model, reg, owner, parkingSpace, due_date);

            due_date = new DateTime(2019, 07, 07);
            businessTest.Update(studentID, model, reg, owner, parkingSpace, due_date);

            businessTest.Delete(studentID);
        }
        //get total permits in db at time of testing =7 (passed)
        [Test]
        public void getTotalPermits()
        {
           Assert.AreEqual(businessTest.getNumberPermits(),7);
           
        }
        //valid permits = 4 at time of testing (passed)
        [Test]
        public void getValidPermits()
        {
            Assert.AreEqual(businessTest.getNumberValidPermits(), 4);
        }
        //at time of test average will be 57%
        [Test]
        public void TestCalculateAverage()
        {
            Assert.AreEqual(businessTest.CalculateAverage(), 57);
        }
        [Test]
        public void TestPrintPercent()
        {
            businessTest.PrintPercent();
        }
        [Test]
        public void TestCalculateFees()
        {
            businessTest.CollectFees();
        }
        [Test]
        public void TestUniqueVehicles()
        {
            businessTest.UniqueVehicles();
        }
        
        
    }
}
