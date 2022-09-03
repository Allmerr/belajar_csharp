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
    public partial class FMenu : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public FMenu()
        {
            InitializeComponent();
            display();
        }

        private void display()
        {
            cmd = new SqlCommand("SELECT * FROM MsMenu", con);
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
            txtMenuId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtPhoto.Clear();
            txtCarbo.Clear();
            txtProtein.Clear();


            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            pb.Image = null;
        }

        private void btnPhotoDetail_Click(object sender, EventArgs e)
        {
            if(pb.Image == null)
            {
                ofd.Filter = "JPG FILES (*.jpg)|*jpg|PNG FILES (*png)|*.png";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(ofd.FileName);
                }
            }
            else
            {
                pb.Image = null;
                ofd.Filter = "JPG FILES (*.jpg)|*jpg|PNG FILES (*png)|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtPhoto.Text = @"C:\lks\" + txtName.Text;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtPrice.Text != "")
            {
                string fname = txtName.Text + ".jpg";
                string folder = @"C:\lks";
                string path = System.IO.Path.Combine(folder, fname);

                Image imgUser = pb.Image;
                imgUser.Save(path);

                cmd = new SqlCommand($"INSERT INTO MsMenu(name,price,photo,carbo,protein) VALUES('{txtName.Text}','{txtPrice.Text}','{path}','{txtCarbo.Text}','{txtProtein.Text}')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Menambah Data!");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Gagal Menambah Data!");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FAdmin x = new FAdmin();
            x.Show();
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex <= -1) return;

            txtMenuId.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhoto.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCarbo.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProtein.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (System.IO.File.Exists(dgv.Rows[e.RowIndex].Cells[3].Value.ToString()))
            {
                pb.Image = Image.FromFile(dgv.Rows[e.RowIndex].Cells[3].Value.ToString());
            }

            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtPrice.Text != "")
            {
                string fname = txtName.Text + RandomString(8) + ".jpg";
                string folder = @"C:\lks";
                string path = System.IO.Path.Combine(folder, fname);

                Image imgUser = pb.Image;
                imgUser.Save(path);

                cmd = new SqlCommand($"UPDATE MsMenu set name = '{txtName.Text}', price = '{txtPrice.Text}' , photo = '{path}' , carbo = '{txtCarbo.Text}' , protein = '{txtProtein.Text}' WHERE id = '{txtMenuId.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Mengubah Data!");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Gagal Mengubah Data!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?","KONFIRMASI",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pb.Image.Dispose();
                System.IO.File.Delete(txtPhoto.Text);

                cmd = new SqlCommand($"DELETE FROM MsMenu WHERE id = '{txtMenuId.Text}'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Menghapus Data!");
                display();
                clear();
            }
            else
            {
                MessageBox.Show("Gagal Menghapus Data!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
