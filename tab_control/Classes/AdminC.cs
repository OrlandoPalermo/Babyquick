using newBabyQuick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_control.Classes
{
    public class AdminC : Membre
    {
         public AdminC(String nom, String prenom, String gsm, String email, String password)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = 0;
            Email = email;
            Password = password;
        }
    }
}
