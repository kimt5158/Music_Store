using Lab3_Template.DTL;
using SE1438_Group2_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_Group2_Lab3.GUI
{
    public partial class AlbumAdd : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MusicStore;Integrated Security=True");
        int action = 0;
        int albumID = 0;
        public AlbumAdd()
        {
            InitializeComponent();
            loadComboboxGenres();
            loadComboboxArtist();
        }

        public TextBox TxtTitle { get => txtTitle; set => txtTitle = value; }
        public TextBox TxtPrice { get => txtPrice; set => txtPrice = value; }
        public TextBox TxtURL { get => txtURL; set => txtURL = value; }
        public ComboBox CbArtist { get => cbArtist; set => cbArtist = value; }
        public ComboBox CbGenre { get => cbGenre; set => cbGenre = value; }
        public int Action { get => action; set => action = value; }
        public int AlbumID { get => albumID; set => albumID = value; }

       

        public void loadComboboxGenres()
        {
            cbGenre.Items.Clear();
            DataTable dt = GenreDAO.GetDataTable();
            foreach(DataRow dr in dt.Rows)
            {
                cbGenre.Items.Add(dr["name"].ToString());
            }
            cbGenre.SelectedIndex = 0;
        }

        public void loadComboboxArtist()
        {
            cbArtist.Items.Clear();
            
            DataTable dt = ArtistDAO.GetDataTable();
            
            foreach (DataRow dr in dt.Rows)
            {
                cbArtist.Items.Add(dr["name"].ToString());
            }
            cbArtist.SelectedIndex = 0;
        }


        

       
        private void button4_Click(object sender, EventArgs e)
        {
            Album a = new Album()
            {
                AlbumID = albumID,
                GenreID = cbGenre.SelectedIndex + 1,
                ArtistID = cbArtist.SelectedIndex + 1,
                Title = txtTitle.Text,
                Price = double.Parse(txtPrice.Text),
                AlbumUrl = txtURL.Text
            };
            if(action == 0)
            {
                if (AlbumDAO.Insert(a))
                {
                    MessageBox.Show("Add successfully!");
                    this.Close();
                }
            }
            else
            {
                if (AlbumDAO.Update(a))
                {
                    MessageBox.Show("Update successfully!");
                    this.Close();
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                InitialDirectory = getProjectPath() + "\\Images\\",
                Title = "Select image file",
                Filter = "Gif files (*.gif)|*.gif| Png files (*.png)|*.png",
                FilterIndex = 1,
                CheckFileExists = true,
                CheckPathExists = true
            };


            if (opf.ShowDialog() == DialogResult.OK)
            {
                string ext = opf.FileName.Substring(opf.FileName.IndexOf('.'));
                string filename = Guid.NewGuid().ToString() + ext;
                string fileDest = getProjectPath() + "\\Images\\" + filename;
                File.Copy(opf.FileName, fileDest);
                txtURL.Text = "/Images/" + filename;
                pictureBox2.Image = Image.FromFile(fileDest);
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

    }
}
