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
            /*Membre tmpMembre = new Membre(email.Text, password.Text);

            //Ce membre est pour l'instant créer artificiellement pour simuler un membre provenant de la BDD
            Membre realMembre = new Membre("a", "a");
            */
                Admin main = new Admin();
                main.Show();
            
            
            Bdd bdd = Bdd.getInstance();
            UserDao uD = new UserDao(bdd);

            //Membre m = new Membre("Jack", "Border", "0496323522", "borderlands_@gmail.com", 1, 0, "10/10/2014", "a");
            //uD.add(m);

            List<Membre> membres = uD.findAll();
            List<Membre> parents = new List<Membre>(), babysitters = new List<Membre>(), intermediaire = new List<Membre>();

            foreach (Membre me in membres)
            {
                switch (me.Type)
                {
                    case 1:
                        parents.Add(me);
                        break;
                }
            }
            //Console.WriteLine(membres[0].NbEnfants + ", " +  membres[0].Nom);
            
            main.ParentsBDD.ItemsSource = parents;
        }
    }
}
