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
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private Membre m;
        private ObservableCollection<Membre> parents, babysitters, intermediaire;

        public Admin()
        {
            Bdd bdd = Bdd.getInstance();
            UserDao uD = new UserDao(bdd);

            Membre m = new Membre("Jack", "Border", "0496323522", "borderlands_@gmail.com", 1, 0, "10/10/2014", "a");
            Membre m2 = new Membre("al", "adin", "0474324195", "test@gmail.com", 1, 0, "10/10/2014", "a");
           
            uD.add(m);
            uD.add(m2);
            List<Membre> membres = uD.findAll();
            
            parents       = new ObservableCollection<Membre>();
            babysitters   = new ObservableCollection<Membre>();
            intermediaire = new ObservableCollection<Membre>();
            InitializeComponent();
            

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

            this.ParentsBDD.ItemsSource = parents;
        }

        private void SuprimerMembre_Click(object sender, RoutedEventArgs e)
        {
            if (m != null)
            {
                Bdd bdd = Bdd.getInstance();
                UserDao userDao = new UserDao(bdd);
                userDao.delete(m);
                m = null;
            }
            else
            {
                MessageBox.Show("Merci de sélectionner une ligne de la base de données !");
            }
        }


        private void SelectionItem_Click(object sender, RoutedEventArgs e)
        {
            m = ((Membre)ParentsBDD.SelectedItem);
            
        }

        private void ParentsBDD_CellEditEnding_1(object sender, DataGridCellEditEndingEventArgs e)
        {
           
            if (m != null)
            {
                Bdd bdd = Bdd.getInstance();
                UserDao userDao = new UserDao(bdd);
                
                int index = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(e.Row);
                int colIndex = e.Column.DisplayIndex;
                var result = (e.EditingElement as TextBox).Text.ToString();
                switch (colIndex)
                {
                    case 0:
                        m.Nom = result;
                        break;
                    case 1:
                        m.Prenom = result;
                        break;
                    case 2:
                        m.Email = result;
                        break;
                    case 3:
                        m.Gsm = result;
                        break;
                    case 4:
                        m.NbEnfants = short.Parse(result);
                        break;
                }              
                userDao.update(m);

                Console.WriteLine("Okkkkkkkkkkkkkkkk");
                
            }
            else
            {
                MessageBox.Show("Merci de sélectionner une ligne de la base de données !");
            }

        }


    }
}
