using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseCore
{
    public static class DbOperation
    {
        public static String ConnectionString = "";
        public static SqlConnection SqlConnection;

        //Todo:baglanti acma metodu yazilacak.
        private static void OpenConnection()
        {
            SqlConnection = new SqlConnection(ConnectionString);

            if (SqlConnection.State != ConnectionState.Open)
            {
                try
                {
                    SqlConnection.Open();
                }
                catch 
                {
                    //Todo:Txt ye log yaz!

                }
            }
            else
            {
                //Todo:Txt ye log yaz!
            }
        }

        private static void CloseConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    SqlConnection.Close();
                }
                catch
                {
                    //Todo:Txt ye log yaz!

                }
            }
            else
            {
                //Todo:Txt ye log yaz!
            }
        }

        //insert, update, delete islemleri burada yapilacak!
        public static int ExecuteCommand(string commandQuery)
        {
            OpenConnection();

            SqlCommand command = new SqlCommand(commandQuery, SqlConnection);
            int islemSonuc = command.ExecuteNonQuery();

            CloseConnection();

            return islemSonuc;
        }

        // select cumlelerini calistirip tablo dondurme!
        public static DataTable GetTable(string selectQuery)
        {
            OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter(selectQuery, SqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            CloseConnection();

            return dt;
            
        }
    }
}
