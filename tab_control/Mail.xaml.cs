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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    partial class Mail : UserControl
    {
        private Membre m,m2;
        private ObservableCollection<Membre> users = new ObservableCollection<Membre>();

        public Mail()
        {
            InitializeComponent();
            m = new Membre("Alexandre", "prenom", "gsm", "alexandrebrosteau@gmail.com", 1, 0, "10/10/2014", "a");
            m2 = new Membre("Orlando", "poop", "0475235263", "orlandoPalerm@gmail.com", 1, 0, "12/10/2014", "b");


            users.Add(m);
            users.Add(m2);

           
            listMail.ItemsSource = users;
        }

        private void listMail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Membre mb = listMail.SelectedItem as Membre;
            de.Content =mb.Nom;
                   
            
        }

    }
}
