using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_authentication_system
{
    public partial class registrationBox : Form
    {
        public registrationBox()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void registrationBox_Load(object sender, EventArgs e)
        {


            pictureBox1.Image = Image.FromFile(@"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10350990_856380721074583_5549273632151111387_n.jpg");
            pictureBox1.ImageLocation = @"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10350990_856380721074583_5549273632151111387_n.jpg";

            pictureBox2.Image = Image.FromFile(@"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10521377_856381414407847_6994074695486298470_n.jpg");
            pictureBox2.ImageLocation = @"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10521377_856381414407847_6994074695486298470_n.jpg";


            pictureBox3.Image = Image.FromFile(@"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10982486_848584431854212_7586413611598786777_n.jpg");
            pictureBox3.ImageLocation = @"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10982486_848584431854212_7586413611598786777_n.jpg";


            pictureBox4.Image = Image.FromFile(@"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10999525_856381197741202_8803115981809302337_n.jpg");
            pictureBox4.ImageLocation = @"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\10999525_856381197741202_8803115981809302337_n.jpg";

            pictureBox5.Image = Image.FromFile(@"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\11005712_877783125598564_1226127916_n.jpg");
            pictureBox5.ImageLocation = @"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\11005712_877783125598564_1226127916_n.jpg";

            pictureBox6.Image = Image.FromFile(@"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\11008933_852292438150078_241601339_n.jpg");
            pictureBox6.ImageLocation = @"\Users\lappo\Projects\GUI-authentication\Fall 2015_CS619_895_3352_F15CS61995A00\GUI authentication system\GUI authentication system\Images\11008933_852292438150078_241601339_n.jpg";

            //Form3 fm = new Form3();
            //fm.ShowDialog();
        }

        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            
            string ServerInformation = "server=LAPPO-PC\\SQLEXPRESS; Trusted_Connection=yes;"+
                                       "database=GUIDATABASE; connection timeout=30;";
            SqlConnection connection = new SqlConnection(ServerInformation);
            string query = "insert into Users (Name, Password, Email, Role) values ('"+UserName.Text+"','"+UserPassword.Text+
                                                                "','"+UserEmail.Text+"','"+UserRole.Text+"')";

            SqlCommand cmd1 = new SqlCommand(query, connection);
            connection.Open();
            int number = 0;
            cmd1.ExecuteNonQuery();
            foreach (var pb in this.Controls.OfType<PictureBox>().OrderBy(c=>c.Name))
            {
                
                if (Int32.Parse(pb.Tag.ToString()) == 1) 
                {
                    number += 1;
                    string qury = "insert into Images (UserID, Path, OrderNumber) values ( (select top 1 ID From Users Order by ID DESc),'"
                                                                                    +pb.ImageLocation+"',"+number.ToString()+")";
                    SqlCommand cmd2 = new SqlCommand(qury, connection);
                    try { 
                        cmd2.ExecuteNonQuery();
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show("--  "+ex.ToString());
                    }
                }
            }
            
            try 
            {
                
                Status.Text = "Connection Successfully";
                connection.Close();
                Form2 frm = new Form2();
                frm.ShowDialog();
            }catch(SqlException error)
            {
                // MessageBox.Show("DB Connection Failed");
                MessageBox.Show(error.ToString());
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //PictureOrder order1 = new PictureOrder();
            //if (order1.orderNum == 0) { order1.orderNum = 1; } else { order1.orderNum = 0; }
            //order1.orderNum = (order1.orderNum == 0) ? 1 : 0;
            if (pictureBox1.Size.Height == 32 && Int32.Parse(pictureBox1.Tag.ToString()) == 0)
            {
                pictureBox1.Size = new System.Drawing.Size(100, 40);
                pictureBox1.Tag = 1;
            }
            else 
            {
                pictureBox1.Size = new System.Drawing.Size(100, 32);
                pictureBox1.Tag = 0;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Size.Height == 32 && Int32.Parse(pictureBox2.Tag.ToString()) == 0)
            {
                pictureBox2.Size = new System.Drawing.Size(100, 40);
                pictureBox2.Tag = 1;
            }
            else
            {
                pictureBox2.Size = new System.Drawing.Size(100, 32);
                pictureBox2.Tag = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Size.Height == 32 && Int32.Parse(pictureBox3.Tag.ToString()) == 0)
            {
                pictureBox3.Size = new System.Drawing.Size(100, 40);
                pictureBox3.Tag = 1;
            }
            else
            {
                pictureBox3.Size = new System.Drawing.Size(100, 32);
                pictureBox3.Tag = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Size.Height == 32 && Int32.Parse(pictureBox4.Tag.ToString()) == 0)
            {
                pictureBox4.Size = new System.Drawing.Size(100, 40);
                pictureBox4.Tag = 1;
            }
            else
            {
                pictureBox4.Size = new System.Drawing.Size(100, 32);
                pictureBox4.Tag = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Size.Height == 32 && Int32.Parse(pictureBox5.Tag.ToString()) == 0)
            {
                pictureBox5.Size = new System.Drawing.Size(100, 40);
                pictureBox5.Tag = 1;
            }
            else
            {
                pictureBox5.Size = new System.Drawing.Size(100, 32);
                pictureBox5.Tag = 0;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Size.Height == 32 && Int32.Parse(pictureBox6.Tag.ToString()) == 0)
            {
                pictureBox6.Size = new System.Drawing.Size(100, 40);
                pictureBox6.Tag = 1;
            }
            else
            {
                pictureBox6.Size = new System.Drawing.Size(100, 32);
                pictureBox6.Tag = 0;
            }
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
    }
}
