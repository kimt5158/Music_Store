using Lab3_Template.DTL;
using SE1438_Group2_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_Group2_Lab3.GUI
{
    public partial class AlbumDetailGUI : Form
    {
        int albumID;
        public AlbumDetailGUI(Album album)
        {
            InitializeComponent();
            try
            {
                albumID = album.AlbumID;
                txtTitle.Text = album.Title;
                txtPrice.Text = album.Price.ToString();
                txtGenre.Text = GenreDAO.getNameByGenreID(album.GenreID);
                txtArtist.Text = ArtistDAO.getNameByArtistID(album.ArtistID);
                string path = album.AlbumUrl.Replace('/', '\\');
                pictureBox1.Image = Image.FromFile(getProjectPath() + path);
            }
            catch(Exception ex)
            {

            }


        }

        private string getProjectPath()
        {
            string path = Application.StartupPath;
            DirectoryInfo di = new DirectoryInfo(path);
            for (int i = 0; i < 2; i++)
            {
                di = Directory.GetParent(di.FullName);
            }
            return di.FullName;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*ShoppingCartDAO scd = ShoppingCartDAO.GetCart();
            scd.AddToCart(albumID);*/
        }
    }
}
