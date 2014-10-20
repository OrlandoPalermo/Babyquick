using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace newBabyQuick
{
    public abstract class Membre
    {
        private int id;
        private String nom, prenom, gsm, email, password, id_asp;
        private short type;


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

        public short Type
        {
            get { return type; }
            set { type = value; }
        }

        public String Id_asp
        {
            get { return id_asp; }
            set { id_asp = value; }
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