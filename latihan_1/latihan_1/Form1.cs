using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace latihan_1
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;

        public static string name;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand($"SELECT * FROM MsEmploye WHERE email = '{txtEmail.Text}' AND password = '{txtPassword.Text}'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
            if(dt.Rows.Count > 0)
            {
                switch (dt.Rows[0]["position"] as string)
                {
                    case "admin":
                        {
                            name = txtEmail.Text;
                            MessageBox.Show("Berhail Login");
                            this.Hide();
                            FAdmin a = new FAdmin();
                            a.Show();
                            break;
                        }
                    case "kasir" :
                        {
                            name = txtEmail.Text;
                            MessageBox.Show("Berhail Login");
                            this.Hide();
                            FKasir a = new FKasir();
                            a.Show();
                            break;
                        }
                    default: 
                        break;
                }
            }
            else
            {
                MessageBox.Show("Password/Email salah");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtEmail.Clear(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
