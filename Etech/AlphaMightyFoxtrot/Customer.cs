using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Etech.AlphaMightyFoxtrot
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhysicalAddress { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public DateTime RecentLogin { get; set; }
        
        public string AddCustomer()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Customer";
            string Values = "SEQ_CUSTOMER.nextval,'" + FirstName + "','" + LastName + "','" + PhysicalAddress + "','" + ContactNumber +  "','" + Password + "'," +  "TO_DATE('" + RecentLogin.ToString("MM/dd/yyyy") + "','mm/dd/yyyy')" + ",null," + "TO_DATE('" + DateOfBirth.ToString("MM/dd/yyyy") + "','mm/dd/yyyy'),'" + EmailAddress + "'";
            string err = oracleDB.InsertIntoDB(TableName,Values);
            return err;
        }

        public bool LoginCustomer()
        {
            OracleDB oracleDB = new OracleDB();
            string TableName = "Customer";
            string Column = "*";
            string Where = "Email_address = '" + EmailAddress + "' AND Password = '" + Password + "'";
            bool err = oracleDB.SelectFromWhereDBLogin(TableName, Column, Where);
            return err;
        }
    }
}
