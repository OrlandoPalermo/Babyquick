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
            + "SET nom=@nom, prenom=@prenom, email=@email, gsm=@gsm, nb_enfants=@nb_Enfants " +
            " WHERE email = @email";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            //command.Parameters.AddWithValue("@nom", m.Nom);
            //command.Parameters.AddWithValue("@prenom", m.Prenom);
            //command.Parameters.AddWithValue("@email", m.Email);
            //command.Parameters.AddWithValue("@gsm", m.Gsm);
            //command.Parameters.AddWithValue("@nb_enfants", m.NbEnfants);
            
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
            command.Parameters.Add("@nb_enfants", SqlDbType.TinyInt).Value = m.NbEnfants;

            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            bdd.getConnection().Close();
           // Console.WriteLine("Ok update fait : " + m.Nom);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string getPassword(string email)
        {
            
            
            bdd.getConnection().Open();
            string requete = "SELECT password FROM Membre WHERE email = @email";
            
            SqlDataReader reader;
            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            reader = command.ExecuteReader();
            string password = "";
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                       password = reader["password"]as string;
                      
                }
            }
            bdd.getConnection().Close();
            return password;

        }

        //public Membre getMembre(string email)
        //{
        //    SqlCommand command = new SqlCommand("SELECT nom, prenom, types_membre, gsm, email, date_dispo, nb_enfants FROM Membre WHERE email = @email", bdd.getConnection());
        //    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
        //    SqlDataReader r = command.ExecuteReader();
        //    Membre m = null;
        //    if (r.HasRows)
        //    {


        //        while (r.Read())
        //        {
        //            short type = short.Parse(r["types_membre"].ToString());

        //            switch (type)
        //            {
        //                case 1:
        //                    short nbE = short.Parse(r["nb_enfants"].ToString());
        //                    m = new Parent(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, nbE);
        //                    break;
        //                case 2:
        //                    m = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"] as string);
        //                    break;
                        
        //                case 3:
                           
        //            }
        //        }
        //    }

        //    return m;
        //}
    }
}
