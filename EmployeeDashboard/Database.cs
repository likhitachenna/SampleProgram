using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeDashboard
{
    internal class Database
    {
        public static DataTable ExecuteStoredProcedure(string storedProcedureName, SqlCommand cmd)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlConnection connection = Connection.GetInstance();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                cmd.Connection = connection;
                cmd.CommandText = storedProcedureName;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Invalid Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public static DataTable ExecuteStoredProcedure(string storedProcedureName)
        {
            DataSet dataSet = new DataSet();
            try {
                SqlConnection connection = Connection.GetInstance();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlDataAdapter res = new SqlDataAdapter(storedProcedureName, connection);
                res.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
            }
            catch(Exception e){
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        public static bool IsValidConnection()
        {
            SqlConnection connection = Connection.GetInstance();
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Invalid Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
    public class Connection
    {
        public static System.Data.SqlClient.SqlConnection _database = null;
        private Connection()
        { }
        public static System.Data.SqlClient.SqlConnection GetInstance()
        {
            if (null == _database)
            {
                _database = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            }
            return _database;
        }
    }
}
