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
using System.Windows.Threading;
using tab_control.Classes;

namespace tab_control
{
    /// <summary>
    /// Logique d'interaction pour Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        private static ObservableCollection<DataNotification> notifs;

        public Notification()
        {
            InitializeComponent();
            notifs = new ObservableCollection<DataNotification>();
            DataNotification notifsDeBase = new DataNotification("Panneau des notifications activé", DataNotification.SUCCESS);
            notifs.Add(notifsDeBase);
            Notifications.Background = Brushes.LimeGreen;
            Notifications.ItemsSource = notifs;

        }

        public static void createNotification(DataNotification data)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(
                             DispatcherPriority.Normal,
                             (Action)delegate()
                             {
                                 notifs.Insert(0, data);
                             }
                         );

        }
    }
}
