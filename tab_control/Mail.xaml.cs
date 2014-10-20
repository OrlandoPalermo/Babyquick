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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
   public partial class Mail : UserControl
    {
        private static Membre connectedMember;
        private Membre m,m2;
        private static ObservableCollection<Message> messages = new ObservableCollection<Message>();
       
        public Mail()
        {
            InitializeComponent();
           /* m = new Membre("Alexandre", "prenom", "gsm", "alexandrebrosteau@gmail.com", 1, 0, "10/10/2014", "a");
            m2 = new Membre("Orlando", "poop", "0475235263", "orlandoPalerm@gmail.com", 1, 0, "12/10/2014", "b");


            users.Add(m);
            users.Add(m2);*/

            Console.WriteLine("Je suis appelé !");
            listMail.ItemsSource = messages;
        }

        public static Membre ConnectedMember
        {
            get { return connectedMember; }
            set { 
                connectedMember = value;
                Bdd bdd = Bdd.getInstance();
                MessageDao MDao = new MessageDao(bdd);
                messages = MDao.getMessages(connectedMember.Id);
            }
        }

        private void listMail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Message mb = listMail.SelectedItem as Message;
            de.Content =mb.Sujet;

            mail.Text = mb.Contenu;
            
        }

        private void SubmitMail_Click(object sender, RoutedEventArgs e)
        {
            Bdd bdd = Bdd.getInstance();
            MessageDao MDao = new MessageDao(bdd);
            UserDao UDao = new UserDao(bdd);

            String email, sujet, contenu;
            email = Pseudo.Text;
            sujet = Subject.Text;
            contenu = Contenu.Text;

            if (email != "" && sujet != "" && contenu != "")
            {
                int idReceveur = UDao.getId(email);

                //TODO FAILLLLLE à cause du 0
                if (idReceveur != 0 && idReceveur != null)
                {
                    Message m = new Message(ConnectedMember.Id, idReceveur, sujet, contenu);
                    MDao.add(m);
                }
                
            }
        }

    }
}
