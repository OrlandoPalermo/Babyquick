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
            this.Close();
            
        }
    }
}
