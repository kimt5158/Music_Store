
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
    public partial class ALbumGUI : Form
    {
        public ALbumGUI()
        {
            InitializeComponent();
            bindGrid1();

        }

        private void bindGrid1()
        {
            dataGridView1.DataSource = AlbumDAO.GetDataTable();
            dataGridView1.Columns["AlbumID"].Visible = false;
            dataGridView1.Columns["GenreID"].Visible = false;
            dataGridView1.Columns["ArtistID"].Visible = false;

            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };

            int count = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(count, btnDetail);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count+1, btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            dataGridView1.Columns.Insert(count+2, btnDelete);
        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AlbumAdd a = new AlbumAdd();
            a.Action = 0;
            DialogResult dr = a.ShowDialog();
            if(dr == DialogResult.OK)
            {
                dataGridView1.DataSource = AlbumDAO.GetDataTable();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int albumID = (int)dataGridView1.Rows[e.RowIndex].Cells["albumID"].Value;
            Album album = AlbumDAO.GetAlbumByID(albumID);
            if (e.ColumnIndex == dataGridView1.Columns["Detail"].Index)
            {
                AlbumDetailGUI ad = new AlbumDetailGUI(album);
                DialogResult dr = ad.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var cart = ShoppingCartDAO.GetCart();
                    cart.AddToCart(albumID);
                    CartGUI cg = new CartGUI();
                    cg.ShowDialog();
                }
            }

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                
                AlbumAdd a = new AlbumAdd();
                a.TxtTitle.Text = album.Title;
                a.CbGenre.SelectedIndex = album.GenreID - 1;
                a.CbArtist.SelectedIndex = album.ArtistID - 1;
                a.TxtPrice.Text = album.Price.ToString();
                a.TxtURL.Text = album.AlbumUrl;
                a.AlbumID = albumID;
                a.Action = 1;
                DialogResult dr = a.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    dataGridView1.DataSource = AlbumDAO.GetDataTable();
                }
                
            }

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                DialogResult result = MessageBox.Show("Do you want to delete this album?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool count = AlbumDAO.Delete(album);
                    if (count == true)
                    {
                        DialogResult dr =  MessageBox.Show("Delete compeleted");
                        if (dr == DialogResult.OK)
                        {
                            dataGridView1.DataSource = AlbumDAO.GetDataTable();
                        }
                    }
                }
            }
        }


    }
}
