using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_control
{
    public class Message
    {
        private int id, idEnvoyeur, idReceveur;
        private short vu;
        private String sujet, contenu;

        public Message(int idEn, int idRe, String sujet, String contenu)
        {
            IdEnvoyeur = idEn;
            IdReceveur = idRe;
            Sujet = sujet;
            Contenu = contenu;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdEnvoyeur
        {
            get { return idEnvoyeur; }
            set { idEnvoyeur = value; }
        }


        public int IdReceveur
        {
            get { return idReceveur; }
            set { idReceveur = value; }
        }

        public short Vu
        {
            get { return vu; }
            set { vu = value; }
        }

        public String Sujet
        {
            get { return sujet; }
            set { sujet = value; }
        }

        public String Contenu
        {
            get { return contenu; }
            set { contenu = value; }
        }
    }
}
