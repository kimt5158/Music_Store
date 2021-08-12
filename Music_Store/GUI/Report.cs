using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SE1438_Group2_Lab3.DAL;

namespace SE1438_Group2_Lab3.GUI
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            DataTable dt = OrderDAO.GetDataTable();
            dvOrder.DataSource = dt;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tbFrom.Text = monthCalendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            tbTo.Text = monthCalendar.SelectionRange.End.ToString("dd/MM/yyyy");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var dateFrom = monthCalendar.SelectionRange.Start;
            var dateTo = monthCalendar.SelectionRange.End;
            string firstName = tbFirstName.Text;
            string country = tbCountry.Text;
            SqlCommand cmd = new SqlCommand("Select * from orders Where orderDate Between @sd and @ed And " +
                "firstname Like @fn And country like @ct");
            cmd.Parameters.AddWithValue("@sd", monthCalendar.SelectionStart);
            cmd.Parameters.AddWithValue("@ed", monthCalendar.SelectionEnd);
            cmd.Parameters.AddWithValue("@fn", "%"+firstName+"%");
            cmd.Parameters.AddWithValue("@ct", "%" + country + "%");
            dvOrder.DataSource = DAO.GetDataTable(cmd);
            dvOrderDetail.DataSource = null;
        }
        
        private void dvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderID = Convert.ToInt32(dvOrder.Rows[e.RowIndex].Cells["OrderID"].Value);
            DataTable dt = OrderDetailDAO.GetDataTableByOrderID(orderID);
            string fName = dvOrder.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
            string country = dvOrder.Rows[e.RowIndex].Cells["Country"].Value.ToString();
            DateTime dat = Convert.ToDateTime(dvOrder.Rows[e.RowIndex].Cells["OrderDate"].Value);
            tbCountry.Text = country;
            tbFirstName.Text = fName;
            tbFrom.Text = dat.ToString("dd/MM/yyyy");
            tbTo.Text = dat.ToString("dd/MM/yyyy");
            monthCalendar.SetDate(dat);
            dvOrderDetail.DataSource = dt;
        }
    }
}
