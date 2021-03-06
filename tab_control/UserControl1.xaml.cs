﻿using newBabyQuick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tab_control.Classes;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private static Membre connectedMember;
        public UserControl1()
        {
            InitializeComponent();
            txtNomPrenom.Text = ConnectedMember.Nom + " " + ConnectedMember.Prenom;
        }
        public static Membre ConnectedMember
        {
            get { return connectedMember; }
            set { connectedMember = value;}
        }

        private void changePassword_Click(object sender, RoutedEventArgs e)
        {
            string vOld = old.Password;
            string vNew = new1.Password;
            string vNew2 = new2.Password;

            Bdd bdd = Bdd.getInstance();
            UserDao uD = new UserDao(bdd);

            

            if (ConnectedMember != null)
            {
               
                if (uD.compare(ConnectedMember.Email, vOld))
                {
                    if (vNew == vNew2 && !uD.compare(ConnectedMember.Email, vNew))
                    {
                        ConnectedMember.Password = vNew;
                        uD.setPassword(vNew,connectedMember.Email);
                        Notification.createNotification(new DataNotification("Mot de passe correctement modifié",DataNotification.INFORMATION));
                    }
                    else
                    {
                        Notification.createNotification(new DataNotification("Les mots de passe ne correspondent pas ou sont identiques à l'ancien", DataNotification.ERROR));
                    }
                }
                else
                {
                    Notification.createNotification(new DataNotification("L'ancien mot de passe ne corresponds pas à l'actuel", DataNotification.ERROR));
                }
            }
            

        }

    }
}
