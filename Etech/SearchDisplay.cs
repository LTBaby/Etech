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
    public partial class SearchDisplay : Form
    {
        int count = 0;
        public List<string> name { get; set; }
        public List<string> price { get; set; }
        public List<string> img { get; set; }
        public SearchDisplay()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

        }

        private void SearchDisplay_Load(object sender, EventArgs e)
        {
            labelTitleAdd.Text = name[0];
            label22.Text = price[0];
            pictureBox11.ImageLocation = img[0];
            label1.Text = count.ToString();
        }

        private void bunifuFlatButton9_Click_1(object sender, EventArgs e)
        {
            labelTitleAdd.Text = name[count];
            label22.Text = price[count];
            pictureBox11.ImageLocation = img[count];
            count = count < (name.Count - 1) ? count+= 1 : (name.Count - 1);
            label1.Text = count.ToString();

        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            labelTitleAdd.Text = name[count];
            label22.Text = price[count];
            pictureBox11.ImageLocation = img[count];
            count = count > 0 ? count-= 1 : 0;
            label1.Text = count.ToString();
        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {

        }
    }
}
