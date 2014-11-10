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
    class MessageDao
    {
        private Bdd bdd;

        public MessageDao(Bdd b)
        {
            bdd = b;
        }

        public void add(Message m)
        {
            bdd.getConnection().Open();
            SqlCommand req = new SqlCommand("INSERT INTO Message(sujet, contenu, id_envoyeur, id_receveur, vu) VALUES(@s, @c, @idEn, @idRe, 0)", bdd.getConnection());
            req.Parameters.Add("@s", SqlDbType.VarChar).Value = m.Sujet;
            req.Parameters.Add("@c", SqlDbType.VarChar).Value = m.Contenu;
            req.Parameters.Add("@idEn", SqlDbType.Int).Value = m.IdEnvoyeur;
            req.Parameters.Add("@idRe", SqlDbType.Int).Value = m.IdReceveur;

            req.ExecuteNonQuery();
            bdd.getConnection().Close();

        }

        public void delete(int idMessage)
        {
            bdd.getConnection().Open();
            SqlCommand req = new SqlCommand("DELETE FROM Message WHERE id = @id", bdd.getConnection());
            req.Parameters.Add("@id", SqlDbType.Int).Value = idMessage;
            req.ExecuteNonQuery();
            bdd.getConnection().Close();
        }

        public void vu(int idMessage)
        {
            bdd.getConnection().Open();
            SqlCommand req = new SqlCommand("UPDATE Message SET vu = 1 WHERE id = @id", bdd.getConnection());
            req.Parameters.Add("@id", SqlDbType.Int).Value = idMessage;
            req.ExecuteNonQuery();
            bdd.getConnection().Close();
        }

        public ObservableCollection<Message> getMessages(int idReceveur)
        {
            ObservableCollection<Message> messages = new ObservableCollection<Message>();
            bdd.getConnection().Close();
            bdd.getConnection().Open();

            SqlCommand req = new SqlCommand("SELECT * FROM Message WHERE id_receveur = @id_receveur", bdd.getConnection());
            req.Parameters.Add("@id_receveur", SqlDbType.Int).Value = idReceveur;
            SqlDataReader reader = req.ExecuteReader();

            if (reader.HasRows)
            {
                Message m = null;
                while (reader.Read())
                {
                    int id, id_receveur, id_envoyeur;
                    string sujet, contenu;

                    id = int.Parse(reader["id"].ToString());
                    id_receveur = int.Parse(reader["id_receveur"].ToString());
                    id_envoyeur = int.Parse(reader["id_envoyeur"].ToString());

                    sujet = reader["sujet"] as string;
                    contenu = reader["contenu"] as string;

                    m = new Message(id_envoyeur, id_receveur, sujet, contenu);
                    m.Id = id;

                    messages.Add(m);
                }
            }

            bdd.getConnection().Close();
            return messages;
        }

    }
}
