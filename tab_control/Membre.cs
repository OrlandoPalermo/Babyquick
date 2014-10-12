using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_control
{
    class Membre 
    {
        private int id;
        private String nom, prenom, gsm, email, dateDispo, password;  
        private short type, nbEnfants;
        private bool confirm;

        public Membre(String nom, String prenom, String gsm, String email, short type, short nbE, string dateDispo, String password)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = type;
            NbEnfants = nbE;
            DateDispo = dateDispo;
            Email = email;
            Password = password;
        }

        public Membre(String nom, String prenom, String gsm, String email, short type, short nbE, string dateDispo)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = type;
            NbEnfants = nbE;
            DateDispo = dateDispo;
            Email = email;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public String DateDispo
        {
            get { return dateDispo; }
            set { dateDispo = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Gsm
        {
            get { return gsm; }
            set { gsm = value; }
        }

        public String Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }

        public short NbEnfants
        {
            get { return nbEnfants; }
            set { nbEnfants = value; }
        }

        public short Type
        {
            get { return type; }
            set { type = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType() || obj == null)
                return false;

            Membre m = obj as Membre;

            return Email == m.Email && Password == m.Password;

        }

    }
}
