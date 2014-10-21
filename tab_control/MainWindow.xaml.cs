using newBabyQuick;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    public partial class MainWindow : Window
    {
        private Intermediaire connectedMember;
        private Babysitter babysitterRechercher;
        private int idParentPourRecherche;
        private ObservableCollection<Parent> parents;
        public MainWindow(Intermediaire inter)
        {
            
            InitializeComponent();
            connectedMember = inter;
            DataContext = inter;
            Mail.ConnectedMember = inter;

            Bdd bdd = Bdd.getInstance();
            RendezVousDao rDao = new RendezVousDao(bdd);
            UserDao uDao = new UserDao(bdd);

            ObservableCollection<RendezVous> listRendezVous = rDao.read();
            parents = new ObservableCollection<Parent>();

            DataTable dataT = new DataTable("Test");
            dataT.Columns.Add("Nom", typeof(String));
            dataT.Columns.Add("Prenom", typeof(String));
            dataT.Columns.Add("Email", typeof(String));
            dataT.Columns.Add("Nombre d'enfants", typeof(int));
            dataT.Columns.Add("Date de début", typeof(String));
            dataT.Columns.Add("Date de fin", typeof(String));
            dataT.Columns.Add("Babysitter assigné", typeof(String));

            foreach(RendezVous r in listRendezVous) {
                DataRow row = dataT.NewRow();

                Membre p = uDao.getMembre(r.IdParent);
                Membre b = uDao.getMembre(r.IdBabysitter);

                row["Nom"] = p.Nom;
                row["Prenom"] = p.Prenom;
                row["Email"] = p.Email;
                row["Nombre d'enfants"] = ((Parent)p).NbEnfants;
                row["Date de début"] = r.DatePrevu;
                row["Date de fin"] = r.Datefin;
                row["Babysitter assigné"] = b.Nom;

                dataT.Rows.Add(row);

                parents.Add(p as Parent);
                requetes.ItemsSource = dataT.AsDataView();
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            optInter.SelectedIndex = 0;
        }

        private void requetes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                idParentPourRecherche = parents.ElementAt(requetes.SelectedIndex).Id;
                buttonRechercherB.IsEnabled = true;

            }
            catch (Exception E)
            {
                buttonRechercherB.IsEnabled = false;
            }
        }

    }
}
