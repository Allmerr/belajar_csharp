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
    public partial class FHead : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        SqlDataAdapter sda;
        SqlDataReader dr;
        public static string IDi;
        public FHead()
        {
            InitializeComponent();
            display();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void FHead_Load(object sender, EventArgs e)
        {
            generateId();
        }

        private void display()
        {
            cmd = new SqlCommand("SELECT * FROM MsMember", con);
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgv.DataSource = dt;
        }

        private void generateId()
        {
            long hitung;
            string urut = "";
            cmd = new SqlCommand("SELECT id FROM OrderHeader WHERE id in(select max(id) from OrderHeader) order by id desc", con);
            con.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {
                if (dr["id"].ToString().Substring(0,8) != DateTime.Now.ToString("yyyyMMdd"))
                {
                    urut = DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    hitung = Convert.ToInt64(dr["id"].ToString()) + 1;
                    urut = Convert.ToString(hitung);
                }
            }
            else
            {
                urut = DateTime.Now.ToString("yyyyMMdd") + "0001";
            }

            dr.Close();
            IDi = urut;
            con.Close();
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                con.Open();

                var cmd = new SqlCommand($"INSERT INTO OrderHeader(id,memberId,date) VALUES('{IDi}', '{txtNamePembeli.Text}', CURRENT_TIMESTAMP)", con);
                cmd.ExecuteNonQuery();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
                var res = cmd.ExecuteScalar();
                FOrder x = new FOrder();
                x.currentId = res.ToString();
                x.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Pilih nama terlebih dahulu!");
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNamePembeli.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
