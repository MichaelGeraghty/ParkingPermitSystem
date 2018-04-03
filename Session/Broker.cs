using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Session
{
    public class Broker
    {
        //OleDb
        OleDbConnection connection;
        OleDbCommand command;
        String query = "";
        //create a connection to our access db
        private void ConnectTo()
        {
            connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\NUIG\NET\workspace\ParkingPermitSystem\ParkingPermit.accdb;Persist Security Info = False;");
            command = connection.CreateCommand();
        }
        //instantiate connection
        public Broker()
        {
            ConnectTo();
        }
        //trys and finally used to open and close connection for each operation

        //Insert takes a Permit and passes its values into an insert query to be added to the db
        public void Insert(Permit permit)
        {
            try
            {
                command.CommandText = "INSERT INTO Permits (Student_ID,Vehicle_Model,Registration,Owner,Parking_Space,Due_Date) " +
                    "VALUES('" + permit.Student_ID + "', '" + permit.Vehicle_Model + "', '" + permit.Registration + "','" 
                    + permit.Owner + "', '" + permit.Parking_Space + "', '" + permit.Due_Date + "')";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection!=null)
                {
                    connection.Close();
                }
            }
        }
        //show table creates an arraylist of permits that we read in from the database to be displayed to the user
        public DataTable ShowTable()
        {
            List<Permit> permitList = new List<Permit>();
            try
            {
                command.CommandText = "SELECT * FROM Permits";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                query = "SELECT * FROM Permits";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.SelectCommand = cmd;

                da.Fill(dt);

                while (reader.Read())
                {
                    Permit permit = new Permit();

                    permit.Student_ID = Convert.ToInt32(reader["Student_ID"].ToString());
                    permit.Vehicle_Model = reader["Vehicle_Model"].ToString();
                    permit.Registration = reader["Registration"].ToString();
                    permit.Owner = reader["Owner"].ToString();
                    permit.Parking_Space = Convert.ToInt32(reader["Parking_Space"].ToString());
                    permit.Due_Date = Convert.ToDateTime(reader["Due_Date"].ToString());

                    permitList.Add(permit);
                }

                foreach(Permit element in permitList){
                    Console.WriteLine(element.ToString());
                }
                return (dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //Delete takes a student id we pass this id into a query if we find the corresponding entry we delete the record from the db
        public void Delete(int studentID)
        {
            try
            {
                command.CommandText = "DELETE FROM Permits WHERE Student_ID ="+studentID;
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //Update takes a permit we search the db for a matching id then replace all values with the updated version
        public void Update(Permit newPermit)
        {
            try
            {
                command.CommandText = "UPDATE Permits SET Student_ID ="+ newPermit.Student_ID+",Vehicle_Model =\""
                    + newPermit.Vehicle_Model+"\",Registration =\"" + newPermit.Registration+"\",Owner =\""+ newPermit.Owner
                    +"\",Parking_Space ="+ newPermit.Parking_Space+ ",Due_Date =\"" + newPermit.Due_Date + "\" WHERE Student_ID =" + newPermit.Student_ID;
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //count number of permits in the system
        public int Count()
        {
            try
            {
                command.CommandText = "SELECT COUNT (*) FROM Permits";
                command.CommandType = CommandType.Text;
                connection.Open();

                Int32 count = (Int32)command.ExecuteScalar();

                return count;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //count number of permits with due date in date and valid
        public int ValidCount()
        {
            try
            {

                command.CommandText = "SELECT COUNT (*) FROM Permits WHERE Due_Date >= NOW();";
                command.CommandType = CommandType.Text;
                connection.Open();
                 Int32 validCount = (Int32)command.ExecuteScalar();


                return validCount;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //return a list of permits along with fee incured from being out of date
        public List<Permit> CalculateFees()
        {
            List<Permit> feeCollectionList = new List<Permit>();
            try
            {
                command.CommandText = "SELECT * FROM Permits WHERE Due_Date < NOW();";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Permit permit = new Permit();

                    permit.Student_ID = Convert.ToInt32(reader["Student_ID"].ToString());
                    permit.Vehicle_Model = reader["Vehicle_Model"].ToString();
                    permit.Registration = reader["Registration"].ToString();
                    permit.Owner = reader["Owner"].ToString();
                    permit.Parking_Space = Convert.ToInt32(reader["Parking_Space"].ToString());
                    permit.Due_Date = Convert.ToDateTime(reader["Due_Date"].ToString());

                    feeCollectionList.Add(permit);
                }

                return feeCollectionList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
        //returns unique vehicle models
        public List<String> GetUniqueCars()
        {
            List<String> uniqueList = new List<String>();
            try
            {
                command.CommandText = "SELECT DISTINCT Vehicle_Model FROM Permits";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String Vehicle_Model = reader["Vehicle_Model"].ToString();

                    uniqueList.Add(Vehicle_Model);
                }

                return uniqueList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

    }

}
