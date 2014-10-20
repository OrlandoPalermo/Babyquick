using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Parent
/// </summary>
/// namespace newBabyQuick
namespace newBabyQuick
{
    public class Parent : Membre
    {
        private short nbEnfants;

        public Parent(String nom, String prenom, String gsm, String email, short nbE, String password)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = 1;
            NbEnfants = nbE;
            Email = email;
            Password = password;
        }

        public Parent(String nom, String prenom, String gsm, String email, short nbE)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = 1;
            NbEnfants = nbE;
            Email = email;
        }


        public short NbEnfants
        {
            get { return nbEnfants; }
            set { nbEnfants = value; }
        }
    }
}