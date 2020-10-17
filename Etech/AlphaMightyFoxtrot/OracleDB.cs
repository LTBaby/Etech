using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace Etech.AlphaMightyFoxtrot
{
    class OracleDB
    {
        OracleConnection connection = new OracleConnection("DATA SOURCE=localhost:1522/XE;PERSIST SECURITY INFO=True;USER ID=TREVOR;Password=itrw311");
        public void OpenDB()
        {
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {

            }

        }

        public string InsertIntoDB(string tablename, string values)
        {
            string err = "";
            string sInsertquery = "INSERT INTO " + tablename + " VALUES(" + values + ")";
            
            OracleCommand command = new OracleCommand(sInsertquery);
            command.Connection = connection;
            try {
                OpenDB(); 
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                err = ex.ToString();
            }
            CloseDB();
            return err;
        }

        public void DeleteFromDB(string TableName, string VSalues)
        {
            //
        }

        public void CloseDB()
        {
            connection.Close();
        }
        public bool SelectFromWhereDB(string TableName, string Column,string Where)
        {
            bool err = false;
            string Select = "SELECT " + Column + " FROM " + TableName + " WHERE " + Where;
            OracleConnection connection = new OracleConnection("DATA SOURCE=localhost:1522/XE;PERSIST SECURITY INFO=True;USER ID=TREVOR;Password=itrw311");
            OracleCommand command = new OracleCommand(Select);
            command.Connection = connection;
            connection.Open();
            OracleDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                DataReader.Close();
                err = true;
            }
            else
            {
                DataReader.Close();
                err = false;
            }
            connection.Close();
            return err;
        }
    }
}
