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
    public partial class FMember : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public FMember()
        {
            InitializeComponent();
            display();
        }

        private void FMember_Load(object sender, EventArgs e)
        {

        }

        private void display()
        {
            cmd = new SqlCommand("select * from MsMember", con);
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
            txtSearch.Clear();
            txtMemberId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtHandphone.Clear();

            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Yakin Ingin Hapus Data ini ?","KONFIRMASI",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd = new SqlCommand($"delete from MsMember where id = '{txtMemberId.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Hapus Data");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Gagal Hapus Data");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" & txtEmail.Text != "")
            {
                DateTime date = dtp.Value;
                cmd = new SqlCommand($"insert into MsMember(name,email,handphone,joindate) values('{txtName.Text}', '{txtEmail.Text}', '{txtHandphone.Text}', '{date.Date.ToString("yyyy-MM-dd")}')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Menambah Data!");
                display();
                clear();

            }
            else
            {
                MessageBox.Show("Gagal Menambah Data !");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
             if(txtName.Text != "" & txtEmail.Text != "")
            {
                DateTime date = dtp.Value;
                cmd = new SqlCommand($"update MsMember set name = '{txtName.Text}' , email = '{txtEmail.Text}' , handphone = '{txtHandphone.Text}' where id = '{txtMemberId.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Update Data");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Gagal Update Data");
            }
        }

        public void cari(string valueCari)
        {
            SqlDataAdapter sda = new SqlDataAdapter($"select * from MsMember where concat(id,name,email,handphone,joindate) like '%{valueCari}%'", con);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgv.DataSource = dt;
        }
        private void btnSeacrh_Click(object sender, EventArgs e)
        {
            string valueCari = txtSearch.Text.ToString();
            cari(valueCari);

        }
    }
}
