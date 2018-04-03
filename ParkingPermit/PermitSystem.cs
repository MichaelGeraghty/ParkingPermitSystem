using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace ParkingPermit
{
    public partial class PermitSystem : Form
    {
        //Access to Business layer methods
        public static Bll business = new Bll();
        

        public PermitSystem()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showTable()
        {
            results.DataSource = business.ShowTable();
            results.AutoResizeColumns();
        }

        private void showTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime dt = DateTime.Now;
            showTable();
            DateTime dt2 = DateTime.Now;
            history.Rows.Add(new String[] { dt.ToShortDateString() + " " + dt.ToLongTimeString(), "Show Table ",(dt2 - dt).ToString() , Convert.ToString(business.getNumberPermits()), Convert.ToString(business.getNumberValidPermits()) });
            history.Sort(Column1, ListSortDirection.Descending);
            history.AutoResizeColumns();
            this.Cursor = Cursors.Default;
        }

        private void insert()
        {
            int StudentID;
            StudentID = int.Parse(studentID.Text);

            business.Insert(StudentID,Convert.ToString(vehicleModel.Text), Convert.ToString(registration.Text), Convert.ToString(owner.Text), Convert.ToInt32(Math.Round(parkingSpace.Value,0)),Convert.ToDateTime(dueDate.Value));
        }
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime dt = DateTime.Now;
            insert();
            DateTime dt2 = DateTime.Now;
            history.Rows.Add(new String[] { dt.ToShortDateString() + " " + dt.ToLongTimeString(), "Insert ", (dt2 - dt).ToString(), Convert.ToString(business.getNumberPermits()), Convert.ToString(business.getNumberValidPermits()) });
            history.Sort(Column1, ListSortDirection.Descending);
            history.AutoResizeColumns();
            this.Cursor = Cursors.Default;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void update()
        {
            int StudentID;
            StudentID = int.Parse(studentID.Text);

            business.Update(StudentID, Convert.ToString(vehicleModel.Text), Convert.ToString(registration.Text), Convert.ToString(owner.Text), Convert.ToInt32(Math.Round(parkingSpace.Value, 0)), Convert.ToDateTime(dueDate.Value));
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime dt = DateTime.Now;
            update();
            DateTime dt2 = DateTime.Now;
            history.Rows.Add(new String[] { dt.ToShortDateString() + " " + dt.ToLongTimeString(), "Update ", (dt2 - dt).ToString(), Convert.ToString(business.getNumberPermits()), Convert.ToString(business.getNumberValidPermits()) });
            history.Sort(Column1, ListSortDirection.Descending);
            history.AutoResizeColumns();
            this.Cursor = Cursors.Default;
        }
        private void delete()
        {
            int StudentID;
            StudentID = int.Parse(studentID.Text);

            business.Delete(StudentID);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime dt = DateTime.Now;
            delete();
            DateTime dt2 = DateTime.Now;
            history.Rows.Add(new String[] { dt.ToShortDateString() + " " + dt.ToLongTimeString(), "Delete ", (dt2 - dt).ToString(), Convert.ToString(business.getNumberPermits()), Convert.ToString(business.getNumberValidPermits()) });
            history.Sort(Column1, ListSortDirection.Descending);
            history.AutoResizeColumns();
            this.Cursor = Cursors.Default;
        }
    }
}
