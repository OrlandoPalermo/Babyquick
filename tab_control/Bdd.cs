using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace tab_control
{
}

namespace tab_control.Classes
{
    public class Bdd
    {
        private SqlConnection connexion;
        private static Bdd instance;
        private Connect connect;


        private Bdd()
        {
            connect = new Connect();
            connect.loadData();
            connexion = new SqlConnection(connect.Connection);
        }

        

        public static Bdd getInstance()
        {
            if (instance == null)
            {
                instance = new Bdd();
            }

            return instance;
        }

        public SqlConnection getConnection()
        {
            return connexion;
        }

        public void Open()
        {
            if (connexion.State == ConnectionState.Open)
            {
                connexion.Close();
            }
            connexion.Open();
        }
    }
}
