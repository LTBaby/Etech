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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

          
            AlphaMightyFoxtrot.Customer customer = new AlphaMightyFoxtrot.Customer();
            customer.FirstName = bunifuMaterialTextbox1.Text;
            customer.LastName = bunifuMaterialTextbox2.Text;
            customer.PhysicalAddress = bunifuMaterialTextbox3.Text;
            customer.EmailAddress = bunifuMaterialTextbox5.Text;
            customer.ContactNumber = bunifuMaterialTextbox6.Text;
            customer.Password = bunifuMaterialTextbox7.Text;

            var date = bunifuDatepicker1.Value;
            string datetime = bunifuDatepicker1.Value.ToString("MM/dd/yyyy");
            if (DateTime.TryParse(datetime, out date))
            {
                customer.DateOfBirth = date;
            }
            datetime = DateTime.Now.ToString("MM/dd/yyyy");
            if (DateTime.TryParse(datetime, out date))
            {
                customer.RecentLogin = date;
            }
            string err = customer.AddCustomer();
            MessageBox.Show(err);
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_MouseClick(object sender, MouseEventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }
    }
}
