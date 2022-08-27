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
    public partial class FMenu : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-EB9PTRRD;Initial Catalog=latihan;Integrated Security = True;");
        SqlCommand cmd;
        public FMenu()
        {
            InitializeComponent();
            display();
        }

        private void button1_Click(object sender, EventArgs e)
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
                pb.Image.Dispose();
                ofd.Filter = "JPG FILES (*.jpg)|*jpg|PNG FILES (*png)|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void display()
        {
            cmd = new SqlCommand("select * from MsMenu", con);
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
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtPrice.Text != "")
            {
                string fname = txtName.Text + ".jpg";
                string folder = @"C:\lks";
                string path = System.IO.Path.Combine(folder, fname);
                Image a = pb.Image;
                a.Save(path);
                cmd = new SqlCommand($"insert into MsMenu(name,price,photo,carbo,protein) values('{txtName.Text}', '{int.Parse(txtPrice.Text)}', '{path}', '{txtCarbo.Text}', '{txtProtein.Text}')" , con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Menambah Data");
                display();
                clear();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtPhoto.Text = @"C:\lks\" + txtName.Text;
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewRow dr = dgv.SelectedRows[0];
            txtMenuId.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhoto.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCarbo.Text = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProtein.Text = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (System.IO.File.Exists(dr.Cells["photo"].Value.ToString()))
            {
                pb.Image = Image.FromFile(dr.Cells["photo"].Value.ToString());
            }

            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {

        }

        private void pb_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtPrice.Text != "")
            {
                string fname = txtName.Text + ".jpg";
                string folder = @"C:\lks";
                string path = System.IO.Path.Combine(folder, fname);
                Image a = pb.Image;
                if (System.IO.File.Exists(txtPhoto.Text))
                {
                    System.IO.File.Delete(txtPhoto.Text);
                }
                cmd = new SqlCommand($"update MsMenu set name = '{txtName.Text}', price = '{txtPrice.Text}',photo = '{path}', carbo = '{txtCarbo.Text}', protein = '{txtProtein.Text}' where id = '{txtMenuId.Text}'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Berhasil Update Data");
                display();
                clear();
            }
        }
    }
}
