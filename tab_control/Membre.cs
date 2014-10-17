using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace tab_control
{
    public class Membre : INotifyPropertyChanged
    {
        private int id;
        private String nom, prenom, gsm, email, dateDispo, password;  
        private short type, nbEnfants;
        private bool confirm;

        public Membre(String nom, String prenom, String gsm, String email, short type, short nbE, string dateDispo, String password)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = type;
            NbEnfants = nbE;
            DateDispo = dateDispo;
            Email = email;
            Password = password;
        }

        public Membre(String nom, String prenom, String gsm, String email, short type, short nbE, string dateDispo)
        {
            Nom = nom;
            Prenom = prenom;
            Gsm = gsm;
            Type = type;
            NbEnfants = nbE;
            DateDispo = dateDispo;
            Email = email;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.RaisePropertyChanged("Id");
            }
        }

        public String Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                this.RaisePropertyChanged("Nom");
            }
        }

        public String DateDispo
        {
            get { return dateDispo; }
            set
            {
                dateDispo = value;
                this.RaisePropertyChanged("DateDispo");
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                this.RaisePropertyChanged("Password");
            }
        }

        public String Gsm
        {
            get { return gsm; }
            set { gsm = value;

            this.RaisePropertyChanged("Gsm");
            }
        }

        public String Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                this.RaisePropertyChanged("Prenom");
            }
        }

        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value;

            this.RaisePropertyChanged("Confirm");
            }
        }

        public short NbEnfants
        {
            get { return nbEnfants; }
            set { nbEnfants = value;

            this.RaisePropertyChanged("NbEnfants");
            }
        }

        public short Type
        {
            get { return type; }
            set { type = value;
            this.RaisePropertyChanged("Type");

            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType() || obj == null)
                return false;

            Membre m = obj as Membre;

            return Email == m.Email && Password == m.Password;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(String propName)
        {
            if(this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
