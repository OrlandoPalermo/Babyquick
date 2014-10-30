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

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {

        public static DataNotification noti = new DataNotification("Panneau des notifications activé", DataNotification.SUCCESS); 

        public Notification()
        {
            InitializeComponent();
            DataContext = noti;
                       
        }

        public static void createNotification(DataNotification data) {
            noti.Information = data.Information;
            noti.Type = data.Type;
        }
    }
}
