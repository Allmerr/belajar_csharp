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
    public partial class FOrder : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        string id, price, carbo, protein;
        public string currentId;
        private int i;

        public FOrder()
        {
            InitializeComponent();
            display1();
            display2();
        }
       
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAdmin newPage = new FAdmin();
            newPage.Show();
        }

        public void display1()
        {
            cmd = new SqlCommand("SELECT * FROM MsMenu", con);
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            dgv1.DataSource = dt;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void display2()
        {
            dt.Columns.Add("IdName");
            dt.Columns.Add("Menu");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Carbo");
            dt.Columns.Add("Protein");
            dt.Columns.Add("Price");
            dt.Columns.Add("Total");

            dgv2.DataSource = dt;
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            id = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMenuName.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
            price = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
            carbo = dgv1.Rows[e.RowIndex].Cells[4].Value.ToString();
            protein = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (System.IO.File.Exists(dgv1.Rows[e.RowIndex].Cells[3].Value.ToString()))
            {
                pb.Image = Image.FromFile(dgv1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }

            /*DataGridViewRow dr = dgv1.SelectedRows[0];
            id = dr.Cells[0].Value.ToString();
            txtMenuName.Text = dr.Cells[1].Value.ToString();
            price = dr.Cells[2].Value.ToString();
            carbo = dr.Cells[4].Value.ToString();
            protein = dr.Cells[5].Value.ToString();

            if (System.IO.File.Exists(dr.Cells["photo"].Value.ToString()))
            {
                pb.Image = Image.FromFile(dr.Cells["photo"].Value.ToString());
            }*/

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgv2.Rows.Count > 0)
            {
                dgv2.Rows.RemoveAt(dgv2.CurrentRow.Index);
                dgv2.DataSource = dt;
            }
            jumlah();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMenuName.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("Pilih data yang akan di order!");
            }
            else
            {
                int x = Convert.ToInt32(price) * Convert.ToInt32(txtQty.Text);
                dt.Rows.Add(id, txtMenuName.Text, txtQty.Text, carbo, protein, price, x);
                this.dgv2.DataSource = dt;
            }

            clear();
            jumlah();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            simpan();
            dt.Rows.Clear();
            dgv2.Refresh();
        }

        public void jumlah()
        {
            long carbo = 0;
            long protein = 0;
            long total = 0;


            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                total += Convert.ToInt32(dgv2.Rows[i].Cells[6].Value);
                carbo += Convert.ToInt32(dgv2.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv2.Rows[i].Cells[3].Value);
                protein += Convert.ToInt32(dgv2.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv2.Rows[i].Cells[4].Value);
            }

            lblCarbo.Text = $"Carbo : {carbo.ToString()}";
            lblProtein.Text = $"Protein : {protein.ToString()}";
            lblTotal.Text = $"Total : {total.ToString()}";

        }

        private void simpan()
        {
            for(int i = 0; i < dgv2.Rows.Count; i++)
            {
                cmd = new SqlCommand($"INSERT INTO OrderDetail(orderid,menuid,qty,status) VALUES('{FHead.IDi}', '{Convert.ToInt32(dgv2.Rows[i].Cells[0].Value)}', '{dgv2.Rows[i].Cells[2].Value}', 'waiting')",con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Menambah Order!");
            }
        }
        private void clear()
        {
            txtMenuName.Text = "";
            txtQty.Text = "";
            pb.Image = null;
        }
    }
}
