using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace QFurto.Repositories
{
    public class DataContext
    {
        public static MySqlConnection MySqlConnection { get; set; }
        public static MySqlTransaction MySqlTransaction { get; set; }

        public void BeginTransaction()
        {
            MySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            MySqlConnection.Open();
            MySqlTransaction = MySqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            MySqlTransaction.Commit();
        }

        public void Rollback()
        {
            MySqlTransaction.Rollback();
        }

        public void Finally()
        {
            if (MySqlTransaction != null)
            {
                MySqlTransaction.Dispose();
            }
            if (MySqlConnection != null)
            {
                MySqlConnection.Close();
                MySqlConnection.Dispose();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}