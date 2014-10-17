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
           
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
        /*
         * Bouton permettant la connexion d'un membre (intermédiaire ou admin) 
         */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          /*  uD = new UserDao(donnee);

            string mail = email.Text;
            string pass = uD.getPassword(mail);
            m = uD.getMembre(mail);

            if (pass == password.Text && m.Email == email.Text)
            {
                short type = m.Type;
                switch (type)
                {
                    case 0:
                        Admin main = new Admin();
                        main.Show();
                        this.Close();
                        break;
                    case 3:
                        MainWindow inter = new MainWindow();
                        inter.Show();
                        this.Close();
                        break;
                }
            }
            */
            //MainWindow inter = new MainWindow();
            //inter.Show();
            //this.Close();

            Admin main = new Admin();
            main.Show();
            this.Close();
        }
    }
}
