using newBabyQuick;
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

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window parent = Window.GetWindow(this);
            Window1 login = new Window1();
            Bdd.getInstance().getConnection().Close();
            login.Show();
            Mail.clean();
            parent.Close();   
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AboutUs about = new AboutUs();
            about.Show();
        }
    }
}
