using newBabyQuick;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using tab_control.Classes;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    { 
        private Bdd donnee = Bdd.getInstance();
        private UserDao uD;
        private Membre m;
        public Window1()
        {
            InitializeComponent();
            email.Focus();
        }

        /*
         * Bouton permettant la connexion d'un membre (intermédiaire ou admin) 
         */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isInputCompleted())
                buttonConnection.IsEnabled = true;
            else
                buttonConnection.IsEnabled = false;
        }

        public bool isInputCompleted()
        {
            return email.Text != "" && password.Password != ""; 
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (isInputCompleted())
                buttonConnection.IsEnabled = true;
            else
                buttonConnection.IsEnabled = false;
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (email.Text != "" && password.Password != "")
                {
                    Login();
                }
            }
        }

        private void Login()
        {
            Bdd bdd = Bdd.getInstance();
            UserDao MDao = new UserDao(bdd);
            String emailM = email.Text as string;

            if (MDao.compare(emailM, password.Password))
            {
                Membre membre = MDao.getMembre(emailM);

                if (membre == null)
                    MessageBox.Show("Vous n'êtes pas autorisé à utiliser ce programme !");
                else
                {
                    switch (membre.Type)
                    {
                        case 0:
                            Admin main = new Admin(membre as AdminC);
                            main.Show();
                            this.Close();
                            break;
                        case 1:
                        case 2:
                            MessageBox.Show("Vous n'êtes pas autorisé à utiliser ce programme !");
                            break;
                        case 3:
                            MainWindow inter = new MainWindow(membre as Intermediaire);
                            inter.Show();
                            this.Close();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Les identifiants sont erronés !", "Erreur identifiants", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
