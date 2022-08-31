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

namespace smk_restaurant
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public Login()
        {
            InitializeComponent();
        }

        public static string name;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand($"SELECT * FROM MsEmploye WHERE email = '{txtEmail.Text}' AND password = '{txtPassword.Text}'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            if (dt.Rows.Count > 0)
            {
                switch(dt.Rows[0]["position"] as string)
                {
                    case "admin":
                        name = dt.Rows[0]["name"].ToString();
                        MessageBox.Show("Berhasil Login!");
                        this.Hide();
                        FAdmin x = new FAdmin();
                        x.Show();
                        break;
                    case "kasir":
                        name = dt.Rows[0]["name"].ToString();
                        MessageBox.Show("Berhasil Login!");
                        this.Hide();
                        FKasir y = new FKasir();
                        y.Show();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Password atau Email salah!");
            }
        }
    }
}
