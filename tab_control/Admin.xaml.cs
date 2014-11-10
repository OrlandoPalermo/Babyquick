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
    /// Logique d'interaction pour Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private AdminC connectedMember;
        private Membre m;
        private ObservableCollection<Parent> parents;
        private ObservableCollection<Babysitter> babysitters;
        private ObservableCollection<Intermediaire> intermediaire;
        private int fenetreActive;

        public Admin(AdminC admin)
        {
            connectedMember = admin;
            DataContext = admin;
            Mail.ConnectedMember = admin;
            fenetreActive = 1;
            Bdd bdd = Bdd.getInstance();
            UserDao uD = new UserDao(bdd);
            UserControl1.ConnectedMember = admin;

            /*Membre m = new Membre("Jack", "Border", "0496323522", "borderlands_@gmail.com", 1, 0, "10/10/2014", "a");
            Membre m2 = new Membre("al", "adin", "0474324195", "test@gmail.com", 1, 0, "10/10/2014", "a");
            Membre baby1 = new Membre("baby", "sitter", "0474324195", "baby1@gmail.com", 2, 0, "10/12/2014", "test");
            Membre inter = new Membre("inter", "test", "0495123563", "inter@gmail.com", 3, 0, "10/05/2012", "test");
           
            uD.add(m);
            uD.add(m2);
            uD.add(baby1);
            uD.add(inter);*/
            List<Membre> membres = uD.findAll();
            
            parents       = new ObservableCollection<Parent>();
            babysitters   = new ObservableCollection<Babysitter>();
            intermediaire = new ObservableCollection<Intermediaire>();
            InitializeComponent();
            

            foreach (Membre me in membres)
            {
                switch (me.Type)
                {
                    case 1:
                        parents.Add(me as Parent);
                        break;
                    case 2:
                        babysitters.Add(me as Babysitter);
                        Console.WriteLine(((Babysitter)me).Confirm);
                        break;

                    case 3:
                        intermediaire.Add(me as Intermediaire);
                        break;
                }
            }

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
                        parents.Remove(m as Parent);
                        break;
                    case 2:
                       
                        babysitters.Remove(m as Babysitter);
                        break;
                    case 3:
                        
                        intermediaire.Remove(m as Intermediaire);
                        break;
                }
                m = null;


            }
            else
            {
                Notification.createNotification(new DataNotification("Merci de bien sélectionner une ligne de la base de données !", DataNotification.INFORMATION));
            }
        }


        private void SelectionItem_Click(object sender, RoutedEventArgs e)
        {
            if (fenetreActive == 1)
                m = ((Parent)ParentsBDD.SelectedItem);
            else if (fenetreActive == 2)
                m = ((Babysitter)ParentsBDD.SelectedItem);
            
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
                        userDao.update(m as Parent);
                        break;
                    case 1:
                        m.Prenom = result;
                        userDao.update(m as Parent);
                        break;
                    case 2:
                        m.Gsm = result;
                        userDao.update(m as Parent);
                        break;
                    case 3:
                        ((Parent)m).NbEnfants = short.Parse(result);
                        userDao.update(m as Parent);
                        break;
                }              
            }
            else
            {
                Notification.createNotification(new DataNotification("Merci de bien sélectionner une ligne de la base de données !", DataNotification.INFORMATION));
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
                
               
                switch (colIndex)
                {
                    case 0:
                        var result = (e.EditingElement as TextBox).Text.ToString();
                        m.Nom = result;
                        userDao.update(m as Babysitter);
                        break;
                    case 1:
                        result = (e.EditingElement as TextBox).Text.ToString();
                        m.Prenom = result;
                        userDao.update(m as Babysitter);
                        break;
                    case 2:
                        result = (e.EditingElement as TextBox).Text.ToString();
                        m.Gsm = result;
                        userDao.update(m as Babysitter);
                        break;
                    case 3:
                        result = (e.EditingElement as TextBox).Text.ToString();
                        ((Babysitter)m).DateDispo = result;
                        //Console.WriteLine("testdate" + m.DateDispo);
                        userDao.update(m as Babysitter);
                        //Console.WriteLine("test date après " + m.DateDispo);
                        break;
                    case 4:
                        ((Babysitter)m).Confirm = bool.Parse((e.EditingElement as CheckBox).IsChecked.ToString());
                        userDao.update(m as Babysitter);
                        break;
                }
               // userDao.update(m);

               // Console.WriteLine("test date"+ m.DateDispo);

            }
            else
            {
                Notification.createNotification(new DataNotification("Merci de bien sélectionner une ligne de la base de données !", DataNotification.INFORMATION));
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
                        userDao.update(m as Intermediaire);
                        break;
                    case 1:
                        m.Prenom = result;
                        userDao.update(m as Intermediaire);
                        break;
                    case 2:
                        m.Gsm = result;
                        userDao.update(m as Intermediaire);
                        break;
                }
                // userDao.update(m);

                // Console.WriteLine("test date"+ m.DateDispo);

            }
            else
            {
                Notification.createNotification(new DataNotification("Merci de bien sélectionner une ligne de la base de données !", DataNotification.INFORMATION));
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

        public AdminC ConnectedMember
        {
            get { return connectedMember; }
            set { connectedMember = value; }
        }

        private void nonActif_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Babysitter> nonActif = new ObservableCollection<Babysitter>();
            foreach (Babysitter b in babysitters)
            {
              
                if (b.Confirm == false)
                { 
                    nonActif.Add(b);
                    
                   
                }
                this.BabysitterBDD.ItemsSource = nonActif;
                
            }
        }

        private void tousBaby_Click(object sender, RoutedEventArgs e)
        {
            this.BabysitterBDD.ItemsSource = babysitters;
        }

        

    }
}
