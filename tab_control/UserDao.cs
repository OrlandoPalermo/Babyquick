using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace tab_control
{
    class UserDao : INotifyPropertyChanged
    {
        private Bdd bdd;

        public UserDao(Bdd bdd)
        {
            this.bdd = bdd;
        }

        public void add(Membre m)
        {
            bdd.getConnection().Open();
            string requete = "INSERT INTO Membre"
                + "(nom, prenom, gsm, email, types_membre, nb_enfants, date_dispo, password)"
                + "VALUES(@nom, @prenom, @gsm, @email, @types_membre, @nb_enfants, @date_dispo, @password)";
            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
            command.Parameters.Add("@types_membre", SqlDbType.TinyInt).Value = m.Type;
            command.Parameters.Add("@nb_enfants", SqlDbType.TinyInt).Value = m.NbEnfants;
            command.Parameters.Add("@date_dispo", SqlDbType.VarChar).Value = m.DateDispo;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = m.Password;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            Console.WriteLine("Ok !");
            bdd.getConnection().Close();
        }

        public List<Membre> findAll()
        {
            List<Membre> membres = new List<Membre>();
            SqlDataReader reader;
            bdd.getConnection().Open();
            string requete = "SELECT * FROM Membre";
            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            reader = command.ExecuteReader();
           

            if (reader.HasRows)
            {
                Membre m = null;
                while (reader.Read())
                {
                    Console.WriteLine(reader["nb_enfants"]);
                    short type = short.Parse(reader["types_membre"].ToString());
                    short nbE = short.Parse(reader["nb_enfants"].ToString());
                    m = new Membre(reader["nom"] as string, reader["prenom"] as string, reader["gsm"] as string, reader["email"] as string, type, nbE, reader["date_dispo"] as string);
                    membres.Add(m);
                }
            }
            bdd.getConnection().Close();
            return membres;
        }

        public void delete(Membre m)
        {
            bdd.getConnection().Open();
            string requete = "DELETE FROM Membre WHERE email = @mail";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = m.Email;
            command.ExecuteNonQuery();
            bdd.getConnection().Close();
            this.RaisePropertyChanged("Name");
        }

        /*Permet de modifier les tuples dans la table.*/
        public void update(Membre m)
        {
            bdd.getConnection().Open();

            string requete = "UPDATE Membre "
            +"SET Nom=@nom, Prenom=@prenom, Email=@email, gsm=@gsm, nb_enfants=@nb_Enfants "+
            " WHERE email = @email";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
    //        command.Parameters.AddWithValue("@nom", m.Nom);
      //      command.Parameters.AddWithValue("@prenom", m.Prenom);
        //    command.Parameters.AddWithValue("@email", m.Email);
          //  command.Parameters.AddWithValue("@gsm", m.Gsm);
            //command.Parameters.AddWithValue("@nb_enfants", m.NbEnfants);
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
            
            command.Parameters.Add("@nb_enfants", SqlDbType.TinyInt).Value = m.NbEnfants;
            
            command.ExecuteNonQuery();
            bdd.getConnection().Close();
            Console.WriteLine("Ok update fait");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
