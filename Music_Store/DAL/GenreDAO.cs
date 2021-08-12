using SE1438_Group2_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lab3_Template.DTL
{
    class GenreDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "Select * from Genres";
            return DAO.GetDataTable(sql);

        }
        public static DataTable GetAlbumByGenre(int id)
        {
            return DAO.GetDataTable("SELECT * FROM Albums WHERE GenreId = "+id);
        }

        public static string getNameByGenreID(int id)
        {
            String name = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Genres WHERE GenreId = @ID");
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    name = row["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return name;
        }

        public static Genre GetGenreByName(string name)
        {
            Genre genre = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Genres WHERE Name = @name");
                cmd.Parameters.AddWithValue("@name", name);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    genre = new Genre
                    {
                        GenreID = int.Parse(row["GenreId"].ToString()),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString(),
                    };

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return genre;
        }
    }
}
