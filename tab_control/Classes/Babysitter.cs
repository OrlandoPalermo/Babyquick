using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Babysitter
/// </summary>
/// 
namespace newBabyQuick
{
    public class Babysitter : Membre
    {
        private String dateDispo;
        private bool confirm;
        public Babysitter(String nom, String prenom, String gsm, String email, String password)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = 2;
            Email = email;
            Password = password;
        }

        public Babysitter(String nom, String prenom, String gsm, String email)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = 2;
            Email = email;
        }

        public String DateDispo
        {
            get { return dateDispo; }
            set { dateDispo = value; }
        }

        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }

    }
}