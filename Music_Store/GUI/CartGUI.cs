
using Lab3_Template.DTL;
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
    public partial class CartGUI : Form
    {
        public CartGUI()
        {
            InitializeComponent();
            bindGrid1();

        }

        private void bindGrid1()
        {
            var cart = ShoppingCartDAO.GetCart();
            var cartItems = cart.GetCartItems();
            txtTotal.Text = String.Format("{0:0.00}", cart.GetTotal());
            dataGridViewCart.Columns.Clear();
            dataGridViewCart.DataSource = cartItems;
            dataGridViewCart.Columns["RecordID"].Visible = false;
            dataGridViewCart.Columns["cartID"].Visible = false;
            int count = dataGridViewCart.Columns.Count;
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
            dataGridViewCart.Columns.Insert(0, btnDetail);
            DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn
            {
                Name = "Remove",
                Text = "Remove from cart",
                UseColumnTextForButtonValue = true
            };
            dataGridViewCart.Columns.Insert(count + 1, btnRemove);

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (Variables.UserName == null || Variables.UserName == "")
            {
                this.Close();
                LoginGUI lg = new LoginGUI();
                DialogResult dr = lg.ShowDialog();
                
                if (dr == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {
                List<OrderDetail> ods = new List<OrderDetail>();

                /*DataTable dt = (DataTable)dataGridViewCart.DataSource;*/
                var cart = ShoppingCartDAO.GetCart();
                var cartItems = cart.GetCartItems();
                for (int i = 0; i < cartItems.Count; i++)
                {
                    OrderDetail o = new OrderDetail();
                    o.AlbumID = cartItems[i].AlbumID;
                    o.Quantity = cartItems[i].Count;
                    o.UnitPrice = OrderDetailDAO.getUnitPriceDetailByID(o.AlbumID);
                   
                    ods.Add(o);
                }
                double total = double.Parse(txtTotal.Text);
                CheckoutGUI c = new CheckoutGUI(total, ods);
                DialogResult dr = c.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    this.Close();
                }
                
            }

        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int albumID = 0;
            if (e.ColumnIndex == dataGridViewCart.Columns["Detail"].Index)
            {
                albumID = (int)dataGridViewCart.Rows[e.RowIndex].Cells["albumID"].Value;
                Album album = AlbumDAO.GetAlbumByID(albumID);
                AlbumDetailGUI ad = new AlbumDetailGUI(album);
                DialogResult dr = ad.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var cart = ShoppingCartDAO.GetCart();
                    cart.AddToCart(albumID);
                    
                    ad.Close();
                    bindGrid1();
                }
            }
            if (e.ColumnIndex == dataGridViewCart.Columns["Remove"].Index)
            {
                albumID = (int)dataGridViewCart.Rows[e.RowIndex].Cells["albumID"].Value;
                ShoppingCartDAO scd = new ShoppingCartDAO();
         //       MessageBox.Show("a: " + dataGridViewCart.Rows[e.RowIndex].Cells["CartID"].Value);
                scd.ShoppingCartId = (string)dataGridViewCart.Rows[e.RowIndex].Cells["CartID"].Value;
           //     MessageBox.Show("b: " + scd.ShoppingCartId);
                scd.RemoveFromCart(albumID);
                bindGrid1();
            }
        }
    }
}
