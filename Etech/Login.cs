using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etech
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Customer customer = new AlphaMightyFoxtrot.Customer();
            customer.EmailAddress = bunifuMaterialTextbox3.Text;
            customer.Password = bunifuMaterialTextbox5.Text;
            bool err = customer.LoginCustomer();
            if (!err)
            {
                MessageBox.Show("not correct");
            }
            else {
                DateTime date = new DateTime() ;
                string datetime = DateTime.Now.ToString("MM/dd/yyyy");
                if (DateTime.TryParse(datetime, out date))
                {
                    customer.RecentLogin = date;
                }
            }
        }
    }
}
