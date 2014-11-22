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

        public bool compare(String email, String password)
        {
            bdd.Open();

            SqlCommand req = new SqlCommand("SELECT id FROM Membre WHERE email = @e AND password = HASHBYTES('SHA1', @p)", bdd.getConnection());
            req.Parameters.Add("@e", SqlDbType.VarChar).Value = email;
            req.Parameters.Add("@p", SqlDbType.VarChar).Value = password;

            SqlDataReader reader = req.ExecuteReader();

            if (reader.HasRows)
            {
                bdd.getConnection().Close();
                return true;
            }
            else
            {
                bdd.getConnection().Close();
                return false;
            }
        }

       /* public void add(Membre m)
        {
            bdd.Open();
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
            bdd.Open();
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
                             m = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"].ToString(), r["date_fin_dispo"].ToString());
                             ((Babysitter)m).Confirm = ((r["confirm"].ToString() == "1") ? true : false);
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
            bdd.Open();
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
             bdd.Open();

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
            bdd.Open();

            string requete = "UPDATE Membre "
            + "SET nom=@nom, prenom=@prenom, gsm=@gsm, date_dispo = @date_dispo, date_fin_dispo=@date_fin_dispo, confirm = @confirm " +
            " WHERE email = @email";

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@nom", SqlDbType.VarChar).Value = m.Nom;
            command.Parameters.Add("@prenom", SqlDbType.VarChar).Value = m.Prenom;
            command.Parameters.Add("@gsm", SqlDbType.VarChar).Value = m.Gsm;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = m.Email;
            command.Parameters.Add("@date_dispo", SqlDbType.Date).Value = m.DateDispo;/*((m.DateDispo == null) ? "" : m.DateDispo);*/
            command.Parameters.Add("@date_fin_dispo", SqlDbType.Date).Value = m.DateFinDispo;
            command.Parameters.Add("@confirm", SqlDbType.TinyInt).Value = (m.Confirm) ? 1 : 0;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            bdd.getConnection().Close();
        }

        public void update(Intermediaire m)
        {
            bdd.Open();

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

        public void setPassword(string password,string email)
        {
            bdd.Open();

            string requete = "UPDATE Membre SET password= HASHBYTES('SHA1', @password) WHERE email = @email";
            

            SqlCommand command = new SqlCommand(requete, bdd.getConnection());
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

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
            bdd.Open();
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
            bdd.Open();
           
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
            bdd.getConnection().Close();
            bdd.Open();
            SqlCommand command = new SqlCommand("SELECT nom, prenom, types_membre, gsm, email, date_dispo, nb_enfants, date_fin_dispo FROM Membre WHERE id = @id", bdd.getConnection());
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
                            m = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"] as string, r["date_fin_dispo"] as String);
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
            bdd.Open();
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

        public List<String> getEmail(String startMail)
        {
            List<String> emails = new List<String>();
            try
            {
                bdd.Open();
                SqlCommand req = new SqlCommand("SELECT email FROM Membre WHERE email LIKE @mail", bdd.getConnection());
                req.Parameters.Add("@mail", SqlDbType.VarChar).Value = "%" + startMail + "%";
                SqlDataReader read = req.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        emails.Add(read["email"] as string);
                    }
                }
                
            }
            catch (Exception ErreurMail)
            {
                bdd.getConnection().Close();
            }

            bdd.getConnection().Close();
            return emails;
        }

        public String getTypeMembre(String email)
        {
            bdd.Open();
            SqlCommand req = new SqlCommand("SELECT types_membre FROM Membre WHERE email = @email", bdd.getConnection());
            req.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            SqlDataReader read = req.ExecuteReader();
            String typeM = "";
            if (read.HasRows)
            {
                while (read.Read())
                {
                    short type = short.Parse(read["types_membre"].ToString());

                    switch (type)
                    {
                        case 0: typeM = "Admin"; break;
                        case 1: typeM = "Parent"; break;
                        case 2: typeM = "Babysitter"; break;
                        case 3: typeM = "Intérmédiaire"; break;
                    }
                }
            }

            bdd.getConnection().Close();
            return typeM;
        }

        public List<Babysitter> getBabyDispo(string dateDeb, string dateFin)
        {
            bdd.Open();
           
            List<Babysitter> babyDispo = new List<Babysitter>();
            SqlCommand req = new SqlCommand("SELECT id, nom, prenom , gsm, email, types_membre, date_dispo,date_fin_dispo FROM Membre WHERE types_membre = 2 AND id IN(SELECT id FROM Membre WHERE date_dispo <= @dateD AND date_fin_dispo >= @dateF)", bdd.getConnection());
            req.Parameters.Add("@dateD", SqlDbType.Date).Value = dateDeb;
            req.Parameters.Add("@dateF", SqlDbType.Date).Value = dateFin;
            SqlDataReader r = req.ExecuteReader();
            int id;

            if (r.HasRows){
                while(r.Read())
                {
                    Babysitter bb = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"].ToString(), r["date_fin_dispo"].ToString());
                    id = int.Parse(r["id"].ToString());
                    bb.Id = id;
                    babyDispo.Add(bb);
                    
                }
            }
            bdd.getConnection().Close();
            return babyDispo;
        }

       /* public List<Babysitter> getBabyDispo(string dateDeb)
        {
            bdd.Open();

            List<Babysitter> babyDispo = new List<Babysitter>();
            SqlCommand req = new SqlCommand("SELECT nom, prenom , gsm, email, types_membre, date_dispo, date_fin_dispo FROM Membre WHERE types_membre = 2 AND id IN(SELECT id FROM Membre WHERE date_dispo = @dateD )", bdd.getConnection());
            req.Parameters.Add("@dateD", SqlDbType.Date).Value = dateDeb;

            SqlDataReader r = req.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    Babysitter bb = new Babysitter(r["nom"] as string, r["prenom"] as string, r["gsm"] as string, r["email"] as string, r["date_dispo"].ToString(), r["date_fin_dispo"].ToString());

                    babyDispo.Add(bb);

                }
            }
            bdd.getConnection().Close();
            return babyDispo;
        }*/
    }
}
