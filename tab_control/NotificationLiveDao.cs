using newBabyQuick.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tab_control.Classes;

namespace newBabyQuick.DB
{
    public class NotificationLiveDao
    {
        private Bdd bdd;

        public NotificationLiveDao(Bdd bdd)
        {
            this.bdd = bdd;
        }

        public void add(NotificationLive not)
        {
            bdd.getConnection().Open();
            SqlCommand req = new SqlCommand("INSERT INTO Notifications(id_membre, vu, type_notif, date_emission) VALUES(@idM, 0, @ty, GETDATE())", bdd.getConnection());

            req.Parameters.Add("@idM", SqlDbType.Int).Value = not.IdMembre;
            req.Parameters.Add("@ty", SqlDbType.TinyInt).Value = not.TypeNotif;

            req.ExecuteNonQuery();

            bdd.getConnection().Close();
        }

        public ObservableCollection<NotificationLive> read(int idMembre)
        {
            bdd.getConnection().Open();
            ObservableCollection<NotificationLive> notifs = new ObservableCollection<NotificationLive>();

            SqlCommand req = new SqlCommand("SELECT TOP 5 id, type_notif, date_emission FROM Notifications WHERE id_membre = @idM ORDER BY date_emission", bdd.getConnection());

            req.Parameters.Add("@idM", SqlDbType.Int).Value = idMembre;

            SqlDataReader r = req.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    short typeNot = short.Parse(r["type_notif"].ToString());
                    NotificationLive not = new NotificationLive(idMembre, typeNot);
                    not.Id = int.Parse(r["id"].ToString());
                    not.DateEmission = r["date_emission"].ToString();
                    notifs.Add(not);
                }
            }

            bdd.getConnection().Close();

            return notifs;
        }

        public void vu(int idNotif)
        {
            bdd.getConnection().Open();

            SqlCommand req = new SqlCommand("UPDATE Notifications SET vu = 1 WHERE id = @id", bdd.getConnection());
            req.Parameters.Add("@id", SqlDbType.Int).Value = idNotif;

            req.ExecuteNonQuery();

            bdd.getConnection().Close();
        }

        public int countNotSeen(int idMembre)
        {
            bdd.getConnection().Open();

            SqlCommand req = new SqlCommand("SELECT id FROM Notifications WHERE id_membre = @id AND vu = 0", bdd.getConnection());
            req.Parameters.Add("@id", SqlDbType.Int).Value = idMembre;

            SqlDataReader r = req.ExecuteReader();

            int nb = 0;

            if (r.HasRows)
            {
                while (r.Read())
                {
                    nb++;
                }
            }

            bdd.getConnection().Close();

            return nb;
        }
    }
}