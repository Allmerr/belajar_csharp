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
    public partial class FAdmin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public FAdmin()
        {
            InitializeComponent();
            getname();
        }
        
        private void getname()
        {
            cmd = new SqlCommand($"SELECT name FROM MsEmploye WHERE email = '{Form1.name}'", con);
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                label2.Text = "Welcome, " + dr[0].ToString();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FMenu x = new FMenu();
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Yakin Mau Logout??", "informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Form1 x = new Form1();
                x.Show();
            }
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            FMember x = new FMember();
            x.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            FOrder x = new FOrder();
            x.Show();
        }
    }
}
