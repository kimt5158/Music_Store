using SE1438_Group2_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lab3_Template.DTL
{
    class ArtistDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "Select * from Artists";
            return DAO.GetDataTable(sql);

        }
        public static string getNameByArtistID(int id)
        {
            String name = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Artists WHERE ArtistId = @ID");
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
    }
}
