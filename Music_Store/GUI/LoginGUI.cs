using SE1438_Group2_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_Group2_Lab3.GUI
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = UserDAO.GetUsers()
                .Where(u => u.UserName == txtName.Text && u.Password == txtPass.Text)
                .FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("User does not exist!");
            }
            else
            {
                Variables.UserName = user.UserName;
                Variables.Role = user.Role;
                ShoppingCartDAO.UserName = user.UserName;
                var cart = ShoppingCartDAO.GetCart();
                cart.MigrateCart();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
