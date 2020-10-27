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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            SelectCategoryAndDisplayShop(bunifuDropdown1.selectedValue);
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            SelectCategoryAndDisplayShop(bunifuDropdown2.selectedValue);
        }

        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            SelectCategoryAndDisplayShop(bunifuDropdown3.selectedValue);
        }

        private void bunifuDropdown4_onItemSelected(object sender, EventArgs e)
        {
            SelectCategoryAndDisplayShop(bunifuDropdown4.selectedValue);
        }

        private void bunifuDropdown5_onItemSelected(object sender, EventArgs e)
        {
            SelectCategoryAndDisplayShop(bunifuDropdown5.selectedValue);
        }

        private void bunifuDropdown6_onItemSelected(object sender, EventArgs e)
        {
            SelectCategoryAndDisplayShop(bunifuDropdown6.selectedValue);

        }
        public void SelectCategoryAndDisplayShop(string Category)
        {
            AlphaMightyFoxtrot.OracleDB oracleDB = new AlphaMightyFoxtrot.OracleDB();
            List<string> CategoryId = oracleDB.SelectFromWhereDB("Category", "Category_Id", "Name = '" + Category + "'");
            Shop shop = new Shop();
            shop.CategorySelected = CategoryId[0];
            shop.CurrentCategoryBrowsing = Category;
            this.Hide();
            shop.Show();
        }
    }
}
