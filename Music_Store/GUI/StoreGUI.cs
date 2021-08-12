using Lab3_Template.DTL;
using SE1438_Group2_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_Group2_Lab3.GUI
{
    public partial class StoreGUI : Form
    {
        int genreID = 1;
        public StoreGUI()
        {
            InitializeComponent();
        }

        private void StoreGUI_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'musicStoreDataSet.Genres' table. You can move, or remove it, as needed.
            this.genresTableAdapter.Fill(this.musicStoreDataSet.Genres);
            bindGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //genreID = (int)dataGridView1.Rows[e.RowIndex].Cells["Name"].Value;
        }
        public void bindGrid()
        {
            dataGridView2.DataSource = GenreDAO.GetAlbumByGenre(genreID);
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
            dataGridView2.Columns.Insert(0, btnDetail);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string genreName = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            genreID =GenreDAO.GetGenreByName(genreName).GenreID;
            dataGridView2.DataSource = GenreDAO.GetAlbumByGenre(genreID);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView2.Columns["Detail"].Index)
            {
                int albumID = (int)dataGridView2.Rows[e.RowIndex].Cells["albumID"].Value;
                Album album = AlbumDAO.GetAlbumByID(albumID);
                AlbumDetailGUI ad = new AlbumDetailGUI(album);
                DialogResult dr = ad.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    var cart = ShoppingCartDAO.GetCart();
                    cart.AddToCart(albumID);
                    CartGUI cg = new CartGUI();
                    cg.ShowDialog();
                }
            }
        }
    }
}
