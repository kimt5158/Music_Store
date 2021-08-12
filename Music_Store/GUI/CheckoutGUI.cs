
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
    public partial class CheckoutGUI : Form
    {
        public double total = 0;
        private List<OrderDetail> ods;

        public CheckoutGUI(double v,List<OrderDetail> ods)
        {
            InitializeComponent();
            total = v;
            this.ods = ods;
            setInfo();
        }

        public void setInfo()
        {
            if(Variables.UserName != null || Variables.UserName != "")
            {
                User user = UserDAO.GetUserInfo(Variables.UserName);
                tbUserName.Text = user.UserName;
                tbFirstName.Text = user.FirstName;
                tbLastName.Text = user.LastName;
                tbAddress.Text = user.Address;
                tbCity.Text = user.City;
                tbState.Text = user.State;
                tbCountry.Text = user.Country;
                tbPhone.Text = user.Phone;
                tbEmail.Text = user.Email;
                tbTotal.Text = total.ToString();
                tbPromocode.Text = "FREE";
            }
            

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!checkTxtBox(tbFirstName))
            {
                MessageBox.Show("First Name is empty!");
                cancelResult();
            }
            else if (!checkTxtBox(tbLastName))
            {
                MessageBox.Show("Last Name is empty!");
                cancelResult();
            }
            else if (!checkTxtBox(tbEmail))
            {
                MessageBox.Show("Email is empty!");
                cancelResult();
            }
            else
            {
                Order o = new Order();
                o.OrderID = OrderDAO.GetMaxID();
                o.UserName = Variables.UserName;
                o.OrderDate = dateTimePickerOrderDate.Value;
                o.FirstName = tbFirstName.Text;
                o.LastName = tbLastName.Text;
                o.Address = tbAddress.Text;
                o.City = tbCity.Text;
                o.State = tbState.Text;
                o.Country = tbCountry.Text;
                o.Phone = tbPhone.Text;
                o.Email = tbEmail.Text;
                o.Total = double.Parse(tbTotal.Text);
                o.PromoCode = "FREE";
                if (OrderDAO.Insert(o))
                {
                    int orderID = OrderDAO.GetMaxID();
                    foreach (OrderDetail ot in ods)
                    {
                        ot.OrderID = orderID;
                        OrderDetailDAO.Insert(ot);
                    }

                    MessageBox.Show("Order "+ orderID + " successfully!");
                    var cart = ShoppingCartDAO.GetCart();
                    cart.EmptyCart();
                    this.Close();
                }
                else
                {
                    cancelResult();
                }
            }
        }
        private Boolean checkTxtBox(TextBox tx)
        {
            if (tx.Text.Length == 0)
            {
                return false;
            }
            return true;
        }
        private void cancelResult()
        {
            this.DialogResult = DialogResult.None;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
