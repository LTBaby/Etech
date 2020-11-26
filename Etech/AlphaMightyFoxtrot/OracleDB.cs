﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

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

        public string UpdateWhereDB(string tablename, string values, string where)
        {
            string err = "";
            string sInsertquery = "UPDATE " + tablename + " SET " + values + " WHERE " + where;

            OracleCommand command = new OracleCommand(sInsertquery);
            command.Connection = connection;
            try
            {
                OpenDB();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
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
        public bool SelectFromWhereDBLogin(string TableName, string Column,string Where)
        {
            bool err = false;
            string exep = "";
            string Select = "SELECT " + Column + " FROM " + TableName + " WHERE " + Where;
            OracleCommand command = new OracleCommand(Select);
            command.Connection = connection;
            try
            {
                OpenDB();
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
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                exep = ex.ToString();
            }
            CloseDB();
            
            return err;

           
        }
        public List<string> SelectFromDBReader(string TableName, string Column)
        {
            List<string> results = new List<string>();
            string Select = "SELECT " + Column + " FROM " + TableName;
            OracleCommand command = new OracleCommand(Select);
            command.Connection = connection;
            OpenDB();
            OracleDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while(DataReader.Read())
                {
                    results.Add(DataReader[0].ToString());
                }
                DataReader.Close();
            }
            else
            {
                DataReader.Close();
            }
            CloseDB();
            return results;
        }

        public List<string> SelectFromWhereDB(string TableName, string Column, string Where)
        {
            List<string> results = new List<string>();
            string Select = "SELECT " + Column + " FROM " + TableName + " WHERE " + Where;
            OracleCommand command = new OracleCommand(Select);
            command.Connection = connection;
            OpenDB();
            OracleDataReader DataReader = command.ExecuteReader();
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    results.Add(DataReader[0].ToString());
                }
                DataReader.Close();
            }
            else
            {
                DataReader.Close();
            }
            CloseDB();
            return results;
        }

    }
}
