using SE1438_Group2_Lab3.DAL;
using SE1438_Group2_Lab3.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_Group2_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Embed(Panel p, Form f)
        {
            p.Controls.Clear();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Visible = true;
            f.Dock = DockStyle.Fill;
            p.Controls.Add(f);//thêm form mới vào panel
            p.Show();
        }


        private void setupMenu()
        {
            if (Variables.Role == 1)
            {
                albumToolStripMenuItem.Visible = true;
                reportToolStripMenuItem.Visible = true;
            }
            else
            {
                albumToolStripMenuItem.Visible = false;
                reportToolStripMenuItem.Visible = false;
            }
            if (Variables.UserName == null || Variables.UserName == "")
            {
                loginToolStripMenuItem.Text = "Login";
            }
            else
            {
                loginToolStripMenuItem.Text = "Logout (" + Variables.UserName + ")";
            }

            var cart = ShoppingCartDAO.GetCart();
            string cartSummary = "Cart (" + cart.GetCount() + ")";
            cartToolStripMenuItem.Text = cartSummary;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new StoreGUI());
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new Report());
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartGUI cg = new CartGUI();
            cg.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            setupMenu();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Variables.UserName != null && Variables.UserName != "")
            {
                Variables.UserName = null;
                Variables.Role = 0;
                ShoppingCartDAO.UserName = null;
                ShoppingCartDAO sc = new ShoppingCartDAO();
                sc.ResetCartID();
                setupMenu();
            }
            else
            {
                LoginGUI lg = new LoginGUI();
                lg.ShowDialog();
            }
            
        }

        private void albumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new ALbumGUI());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new AboutGUI());
        }
    }
}
