using newBabyQuick;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using tab_control.Classes;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
   public partial class Mail : UserControl
    {
        private static Membre connectedMember;
        private static ObservableCollection<Message> messages = new ObservableCollection<Message>();
        private Message messageSelected;
        public Mail()
        {
            InitializeComponent();

            listMail.ItemsSource = messages;

            //Permet de modifier la liste automatiquement toutes les 10 secondes
            Timer timer = new Timer(10000);
            timer.Elapsed += (source, e) =>
            {
                updateListMail();
            };
            timer.Enabled = true;
            timer.Start();
        }

        public static Membre ConnectedMember
        {
            get { return connectedMember; }
            set { 
                connectedMember = value;
                updateListMail();
            }
        }

       /**
        * Permet de rafraichir la liste des mails reçus quand on clique sur le bouton
        * 
        * */
       public static void updateListMail() {
           if (ConnectedMember != null)
           {
               Bdd bdd = Bdd.getInstance();
               MessageDao MDao = new MessageDao(bdd);

               ObservableCollection<Message> listTmp = MDao.getMessages(ConnectedMember.Id);

               if (listTmp.Count > messages.Count)
               {
                   for (int i = messages.Count; i < listTmp.Count; i++)
                   {
                       //Permet de passer par le thread principal pour pouvoir modifier la liste
                       System.Windows.Application.Current.Dispatcher.Invoke(
                              DispatcherPriority.Normal,
                              (Action)delegate()
                              {
                                  messages.Add(listTmp[i]);
                              }
                          );
                   }
               }

           }
       }

       private void listMail_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {

           messageSelected = listMail.SelectedItem as Message;
           Console.WriteLine(listMail.SelectedItem);
           //Permet d'éviter les plantages lors de la suppression
           try
           {
               de.Content = messageSelected.Sujet;
               mail.Text = messageSelected.Contenu;
           }
           catch (Exception E)
           {
               de.Content = "";
               mail.Text = "";
           }

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
                if (idReceveur != 0)
                {
                    Message m = new Message(ConnectedMember.Id, idReceveur, sujet, contenu);
                    MDao.add(m);
                    MailSender mail = new MailSender(ConnectedMember.Email, email, sujet, contenu);
                    mail.Send();

                    Pseudo.Clear();
                    Subject.Clear();
                    Contenu.Clear();

                    Notification.createNotification(new DataNotification("Votre email a bien été envoyé !", DataNotification.SUCCESS));
                }

            }
            else
            {
                Notification.createNotification(new DataNotification("Merci de bien renseigner tous les champs !", DataNotification.INFORMATION));
            }
        }

        private void Pseudo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pseudo.Text.Length >= 2)
            {
                Bdd bdd = Bdd.getInstance();
                UserDao UDao = new UserDao(bdd);

                List<String> emails = UDao.getEmail(Pseudo.Text);

                if (emails.Capacity == 0)
                {
                    emails.Add("Pas de résultat.");
                }

                HelpEmail.ItemsSource = emails;
                HelpEmail.Visibility = Visibility.Visible;
                
            }
            else
            {
                HelpEmail.ItemsSource = null;
                HelpEmail.Visibility = Visibility.Hidden;
            }
        }

        private void HelpEmail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Bdd bdd = Bdd.getInstance();
                UserDao UDao = new UserDao(bdd);
                String email = HelpEmail.SelectedItem.ToString();
                if (email != null)
                {
                    Pseudo.Text = email;
                    type_pers.Content = UDao.getTypeMembre(email);
                    HelpEmail.ItemsSource = null;
                    HelpEmail.Visibility = Visibility.Hidden;
                }
            
            }
            catch (Exception E)
            {

            }
            
           
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            updateListMail();
        }

        private void SuprimerMembre_Click(object sender, RoutedEventArgs e)
        {
            if (messageSelected != null)
            {
                Bdd bdd = Bdd.getInstance();
                MessageDao mDao = new MessageDao(bdd);

               /* mDao.delete(messageSelected.Id);
                messages.Remove(messageSelected);*/
            }
            else
            {
                //MessageBox.Show("Veuillez sélectionner un message !");
                Notification.createNotification(new DataNotification("Veuillez sélectionner un message !", DataNotification.INFORMATION));
            }
            
        }

    }
}
