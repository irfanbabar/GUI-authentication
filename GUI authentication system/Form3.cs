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
    public partial class Form3 : Form
    {
        Form opener;
  
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            string ServerInformation = "server=LAPPO-PC\\SQLEXPRESS; Trusted_Connection=yes;" +
                                      "database=GUIDATABASE; connection timeout=30;";
            SqlConnection connection = new SqlConnection(ServerInformation);

            string query1 = "select * from Users";
            SqlCommand cmd1 = new SqlCommand(query1, connection);
            
            connection.Open();
            
            SqlDataReader rdr = cmd1.ExecuteReader();

            if (rdr.Read() == true)
            {
                
                while (rdr.Read())
                {
                  MessageBox.Show("Name: " + rdr[1].ToString() + "\nEmail: " + rdr[3].ToString() + "\nRole: " + rdr[4].ToString());
                }
            }
            else 
            {
                MessageBox.Show("No data found");
            }
            connection.Close();
            opener.Close();
            this.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
