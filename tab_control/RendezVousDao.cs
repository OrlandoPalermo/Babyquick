using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_control
{
    class RendezVousDao
    {
        private Bdd bdd;
        public RendezVousDao(Bdd b)
        {
            this.bdd = b;
        }

        public ObservableCollection<RendezVous> read()
        {
            bdd.getConnection().Open();
            ObservableCollection<RendezVous> list = new ObservableCollection<RendezVous>();

            SqlCommand req = new SqlCommand("SELECT * FROM RendezVous WHERE id_babysitter IS NULL OR id_babysitter = 0", bdd.getConnection());
            SqlDataReader reader = req.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    
                    int idMembre = int.Parse(reader["id_membre"].ToString());

                    RendezVous rendezV = new RendezVous(reader["date_emission"].ToString(), reader["date_prevu"].ToString(), reader["date_fin"].ToString(), 0, idMembre);
                    list.Add(rendezV);
                }
            }
            bdd.getConnection().Close();
            return list;
        }
    }
}

