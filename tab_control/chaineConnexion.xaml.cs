using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour chaineConnexion.xaml
    /// </summary>
    public partial class chaineConnexion : UserControl
    {
        private Connect connect;
        private SqlConnection connexion;

        public chaineConnexion()
        {
            connect = new Connect();
            InitializeComponent();
            changeConnectionButton.IsEnabled = false;
            testConnection.IsEnabled = true;
        }

        private void changeConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (ipServ.Text != "" && nomDB.Text != "" && user.Text != "" && passwdUser.Text != "")
            {
                connect.updateData(ipServ.Text, nomDB.Text, user.Text, passwdUser.Text);
                MessageBox.Show("Connexion à la base de données effectué, redémarrez le programme");
            }
            else
            {
                MessageBox.Show("Veuillez compléter tous les champs");
            }


        }

        private void testConnection_Click(object sender, RoutedEventArgs e)
        {
            if (ipServ.Text != "" && nomDB.Text != "" && user.Text != "" && passwdUser.Text != "")
            {
             
                connect.Connection = "Data Source=" + ipServ.Text + ";Initial Catalog=" + nomDB.Text + ";User ID=" + user.Text + ";Password=" + passwdUser.Text;

                try
                {
                    connexion = new SqlConnection(connect.Connection);
                    changeConnectionButton.IsEnabled = true;
                }
                catch (Exception )
                {
                    MessageBox.Show("La chaîne de connection n'est pas correcte");
                    ipServ.Text = "";
                    nomDB.Text = "";
                    user.Text = "";
                    passwdUser.Text = "";
                }
                
            }
        }
    }
}
