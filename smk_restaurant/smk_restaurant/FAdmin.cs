using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smk_restaurant
{
    public partial class FAdmin : Form
    {
        public FAdmin()
        {
            InitializeComponent();
            getName();
        }

        private void getName()
        {
            lblWelcome.Text += Login.name;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login x = new Login();
            x.Show();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            FMember x = new FMember();
            x.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FMenu x = new FMenu();
            x.Show();
        }
    }
}
