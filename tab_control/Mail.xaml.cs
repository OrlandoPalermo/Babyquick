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
        private Membre m;
        private ObservableCollection<Membre> users = new ObservableCollection<Membre>();

        public Mail()
        {
            InitializeComponent();
            m = new Membre("Alexandre", "prenom", "gsm", "alexandrebrosteau@gmail.com", 1, 0, "10/10/2014", "a");

            users.Add(m);

            listMail.ItemsSource = users;
            de.Content = m.Nom;
        }

    }
}
