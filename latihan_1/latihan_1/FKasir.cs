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
    public partial class FKasir : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public FKasir()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FKasir_Load(object sender, EventArgs e)
        {
            getname();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 x = new Form1();
            x.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            FPayment x = new FPayment();
            x.Show();
        }
    }
}
