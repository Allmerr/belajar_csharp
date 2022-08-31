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
    public partial class FMember : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public FMember()
        {
            InitializeComponent();
            display();
        }

        private void display()
        {
            cmd = new SqlCommand("SELECT * FROM MsMember",con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv.DataSource = dt;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void clear()
        {
            txtMemberId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtHandphone.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAdmin x = new FAdmin();
            x.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtHandphone.Text != "")
            {
                DateTime date = dtp.Value;
                cmd = new SqlCommand($"INSERT INTO MsMember(name,email,handphone,joindate) VALUES('{txtName.Text}','{txtEmail.Text}','{txtHandphone.Text}','{date.Date.ToString("yyyy-MM-dd")}')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil menambahkan data!");
                display();
                clear();
            }
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1) return;
            txtMemberId.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtHandphone.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();

            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEmail.Text != "")
            {
                DateTime date = dtp.Value;
                cmd = new SqlCommand($"UPDATE MsMember SET name = '{txtName.Text}', email = '{txtEmail.Text}', handphone = '{txtHandphone.Text}', joindate = '{date.Date.ToString("yyyy-MM-dd")}' WHERE id = '{txtMemberId.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil mengubah data!");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Data kurang lengkap!");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Apakah anda ingin menghapus data ini ?","KONFIRMASI",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd = new SqlCommand($"DELETE FROM MsMember WHERE id = '{txtMemberId.Text}'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Menghapus data!");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Gagal Menghapus data!");
            }
        }

        private void btnSeacrh_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand($"SELECT * FROM MsMember WHERE CONCAT (id,name,email,handphone) LIKE '%{txtSearch.Text.ToString()}%'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgv.DataSource = dt;
        }
    }
}
