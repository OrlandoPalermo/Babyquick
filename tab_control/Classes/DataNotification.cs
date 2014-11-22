using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_control.Classes
{
    public class DataNotification : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private String information, background;
        private short type;

        public const short SUCCESS     = 1;
        public const short ERROR       = 2;
        public const short INFORMATION = 3;

        public DataNotification(String information, short type)
        {
            Information = DateTime.UtcNow.AddHours(1) + " " + information;
            Type = type;
            
            
        }

        public String Information
        {
            get { return information; }
            set
            {
                information = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Information"));
                }
            }
        }
        public String Background
        {
            get { return background; }
            set
            {
                background = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Background"));
                }
            }
        }

        public short Type
        {
            get { return type; }
            set
            {
                type = value;
                setBackground();
            }
        }

        public void setBackground()
        {
            switch (Type)
            {
                case DataNotification.SUCCESS:
                    Background = "LimeGreen";
                    break;
                case DataNotification.ERROR:
                    Background = "Coral";
                    break;
                case DataNotification.INFORMATION:
                    Background = "LemonChiffon";
                    break;
            }

        }

    }
}
