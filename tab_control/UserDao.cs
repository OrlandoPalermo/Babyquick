using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using newBabyQuick;
using tab_control.Classes;

namespace tab_control
{
    class UserDao : INotifyPropertyChanged
    {
        private Bdd bdd;

        public UserDao(Bdd bdd)
        {
            this.bdd = bdd;
        }

       /* public void add(Membre m)
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
        */
        public List<Membre> findAll()
        {
            List<Membre> membres = new List<Membre>();
            SqlDataReader r;
            bdd.getConnection().Open();
            string requete = "SELECT * FROM Membre";
            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            r = command.ExecuteReader();
           

            if (r.HasRows)
            {
                Membre m = null;
                while (r.Read())
                {
                    short type = short.Parse(r["types_membre"].ToString());
   
                    switch(type) {
                        case 1:
                             short nbE = short.Parse(r["nb_enfants"].ToString());
                             m = new Parent(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, nbE);
                             break;
                        case 2:
                             m = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"] as string);
                             break;
                        case 3:
                            m = new Intermediaire(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["password"] as string);
                            break;

                    }
                     
                    
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
        public void update(Parent m)
        {
            //TODO faire les répercutions sur la BDD Asp.net
             bdd.getConnection().Open();

            string requete = "UPDATE Membre SET nom = @nom, prenom = @prenom, gsm = @gsm, nb_enfants = @nb_Enfants WHERE email = @email";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
            command.Parameters.Add("@nb_enfants", SqlDbType.TinyInt).Value = m.NbEnfants;
            int rows = command.ExecuteNonQuery();
            bdd.getConnection().Close();
        }

        public void update(Babysitter m)
        {
            bdd.getConnection().Open();

            string requete = "UPDATE Membre "
            + "SET nom=@nom, prenom=@prenom, gsm=@gsm, date_dispo = @date_dispo " +
            " WHERE email = @email";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
            command.Parameters.Add("@date_dispo", SqlDbType.VarChar).Value = ((m.DateDispo == null) ? "" : m.DateDispo);

            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            bdd.getConnection().Close();
        }

        public void update(Intermediaire m)
        {
            bdd.getConnection().Open();

            string requete = "UPDATE Membre "
            + "SET nom=@nom, prenom=@prenom, gsm=@gsm" +
            " WHERE email = @email";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
        
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            bdd.getConnection().Close();
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
                    password = reader["password"] as string;  

                }
                    
            }

            bdd.getConnection().Close();
            return password;
        }

        public Membre getMembre(string email)
        {
            bdd.getConnection().Open();
            SqlCommand command = new SqlCommand("SELECT id, nom, prenom, types_membre, gsm, email FROM Membre WHERE email = @email", bdd.getConnection());
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            SqlDataReader r = command.ExecuteReader();
            Membre m = null;
            if (r.HasRows)
            {
                int id;
                while (r.Read())
                {
                    short type = short.Parse(r["types_membre"].ToString());

                    switch (type)
                    {
                        case 0:
                            m = new AdminC(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, "null");
                            break;
                        case 1:
                        case 2: return null;
                        case 3:
                            m = new Intermediaire(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, "null");
                            break;
                    }
                    id = int.Parse(r["id"].ToString());
                    m.Id = id;
                }
            }
            bdd.getConnection().Close();
            return m;
        }

        public Membre getMembre(int id)
        {
            bdd.getConnection().Open();
            SqlCommand command = new SqlCommand("SELECT nom, prenom, types_membre, gsm, email, date_dispo, nb_enfants FROM Membre WHERE id = @id", bdd.getConnection());
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataReader r = command.ExecuteReader();
            Membre m = null;
            if (r.HasRows)
            {
                while (r.Read())
                {
                    short type = short.Parse(r["types_membre"].ToString());

                    switch (type)
                    {
                        case 0: return null;
                        case 1:
                           short nbE = short.Parse(r["nb_enfants"].ToString());
                             m = new Parent(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, nbE);
                            break;
                        case 2:
                            m = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"] as string);
                            break;
                        case 3: return null;
                    }
                }
            }
            m.Id = id;
            bdd.getConnection().Close();
            return m;
        }

        public int getId(string email)
        {
            bdd.getConnection().Open();
            SqlCommand command = new SqlCommand("SELECT id FROM Membre WHERE email = @email", bdd.getConnection());
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            SqlDataReader r = command.ExecuteReader();
            int id = 0;
            if (r.HasRows)
            {
                while (r.Read())
                {
                    id = int.Parse(r["id"].ToString());
                }
            }
            bdd.getConnection().Close();
            return id;
        }
    }
}
