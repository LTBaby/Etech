using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Etech
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1 : AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    List<string> Categories = product.ProductCategories();
                    bunifuDropdown1.Items.Clear();
                    foreach (string name in Categories)
                    {
                        bunifuDropdown1.Items.Add(name);
                        
                    }
                    
                    break;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        
        string ImageUrl, ThumbnailUrl;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string ImageDestination = "";
            string [] ImageName ;
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":C\";

                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.png;)|*.jpg;*.bmp;*.png;";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageDestination = fileDialog.FileName;
                    Image img = new Bitmap(ImageDestination);

                    AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    ImageName = ImageDestination.Split('\\');
                    ImageUrl = product.CopyProductImages(fileDialog.FileName, ImageName[ImageName.Length - 1]);
                    pictureBox1.Image = img;
                }

                fileDialog = null;
            }
            catch (System.ArgumentException ae)
            {
                ImageDestination = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string ImageDestination = "";
            string[] ImageName;
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":C\";

                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.png;)|*.jpg;*.bmp;*.png;" ;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageDestination = fileDialog.FileName;
                    Image img = new Bitmap(ImageDestination);

                    AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
                    ImageName = ImageDestination.Split('\\');
                    ThumbnailUrl = product.CopyProductThumbnails(fileDialog.FileName, ImageName[ImageName.Length - 1]);
                    pictureBox2.Image = img;
                }

                fileDialog = null;
            }
            catch (System.ArgumentException ae)
            {
                ImageDestination = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bunifuGradientPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            AlphaMightyFoxtrot.Product product = new AlphaMightyFoxtrot.Product();
            product.Title = bunifuMetroTextbox1.Text;
            product.Price = float.Parse(bunifuMetroTextbox2.Text);
            product.Description = textBox1.Text;
            var date = DateTime.Now;
            string datetime = DateTime.Now.ToString("MM/dd/yyyy");
            if (DateTime.TryParse(datetime, out date))
            {
                product.CreatedDate = date;
            }
            if (bunifuiOSSwitch1.Value){
                product.Active = 't';
            }else
                product.Active = 'f';
            product.CategoryId = bunifuDropdown1.selectedIndex + 1;
            product.ImageUrl = ImageUrl;
            product.ThumbnailUrl = ThumbnailUrl;
            product.AddProduct();
        }
    }
}
