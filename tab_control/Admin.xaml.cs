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
        private int fenetreActive;

        public Admin()
        {
            fenetreActive = 1;
            Bdd bdd = Bdd.getInstance();
            UserDao uD = new UserDao(bdd);

            Membre m = new Membre("Jack", "Border", "0496323522", "borderlands_@gmail.com", 1, 0, "10/10/2014", "a");
            Membre m2 = new Membre("al", "adin", "0474324195", "test@gmail.com", 1, 0, "10/10/2014", "a");
            Membre baby1 = new Membre("baby", "sitter", "0474324195", "baby1@gmail.com", 2, 0, "10/12/2014", "test");
            Membre inter = new Membre("inter", "test", "0495123563", "inter@gmail.com", 3, 0, "10/05/2012", "test");
           
            uD.add(m);
            uD.add(m2);
            uD.add(baby1);
            uD.add(inter);
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
                    case 2:
                        babysitters.Add(me);
                        break;

                    case 3:
                        intermediaire.Add(me);
                        break;
                }
            }
            //Console.WriteLine(membres[0].NbEnfants + ", " +  membres[0].Nom);

// Charge le dataGrid avec la liste. 
            this.ParentsBDD.ItemsSource = parents;
            this.BabysitterBDD.ItemsSource = babysitters;
            this.IntermediaireBDD.ItemsSource = intermediaire;
        }

        private void SuprimerMembre_Click(object sender, RoutedEventArgs e)
        {
            if (m != null)
            {
                Bdd bdd = Bdd.getInstance();
                UserDao userDao = new UserDao(bdd);
                userDao.delete(m);

                switch (fenetreActive)
                {
                    case 1:
                        parents.Remove(m);
                        break;
                    case 2:
                        babysitters.Remove(m);
                        break;
                    case 3:
                        intermediaire.Remove(m);
                        break;
                }
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
                        userDao.update(m);
                        break;
                    case 1:
                        m.Prenom = result;
                        userDao.update(m);
                        break;
                    case 2:
                        m.Email = result;
                        userDao.update(m);
                        break;
                    case 3:
                        m.Gsm = result;
                        userDao.update(m);
                        break;
                    case 4:
                        m.NbEnfants = short.Parse(result);
                        userDao.update(m);
                        break;
                }              
                //userDao.update(m);

                Console.WriteLine("Okkkkkkkkkkkkkkkk");
                
            }
            else
            {
                MessageBox.Show("Merci de sélectionner une ligne de la base de données !");
            }

        }

        private void BabysitterBDD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = ((Membre)BabysitterBDD.SelectedItem);
        }

        private void BabysitterBDD_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
                        userDao.update(m);
                        break;
                    case 1:
                        m.Prenom = result;
                        userDao.update(m);
                        break;
                    case 2:
                        m.Email = result;
                        userDao.update(m);
                        break;
                    case 3:
                        m.Gsm = result;
                        userDao.update(m);
                        break;
                    case 4:
                        m.DateDispo = result;
                        //Console.WriteLine("testdate" + m.DateDispo);
                        userDao.update(m);
                        //Console.WriteLine("test date après " + m.DateDispo);
                        break;
                    case 5:
                        m.Confirm = bool.Parse(result);
                        userDao.update(m);
                        break;
                }
               // userDao.update(m);

                Console.WriteLine("Okkkkkkkkkkkkkkkk");
               // Console.WriteLine("test date"+ m.DateDispo);

            }
            else
            {
                MessageBox.Show("Merci de sélectionner une ligne de la base de données !");
            }
        }

        private void IntermediaireBDD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m = ((Membre)IntermediaireBDD.SelectedItem);
        }

        private void IntermediaireBDD_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
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
                        userDao.update(m);
                        break;
                    case 1:
                        m.Prenom = result;
                        userDao.update(m);
                        break;
                    case 2:
                        m.Email = result;
                        userDao.update(m);
                        break;
                    case 3:
                        m.Gsm = result;
                        userDao.update(m);
                        break;
                }
                // userDao.update(m);

                Console.WriteLine("Okkkkkkkkkkkkkkkk");
                // Console.WriteLine("test date"+ m.DateDispo);

            }
            else
            {
                MessageBox.Show("Merci de sélectionner une ligne de la base de données !");
            }
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            String fenetre = ((TabItem)sender).Header.ToString();

            if (fenetre == "Parents")
            {
                fenetreActive = 1;
            }
            else if (fenetre == "Babysitter")
            {
                fenetreActive = 2;
            }
            else
            {
                fenetreActive = 3;
            }
        }

        


    }
}
