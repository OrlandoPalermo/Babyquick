using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tab_control.Classes
{
    public class Connect
    {
        private String ipServeur, nomDB, user, passwdUser;
        private String connection;

        public String Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public String IpServeur
        {
            get { return ipServeur; }
            set { ipServeur = value; }
        }

        public String NomDB
        {
            get { return nomDB; }
            set { nomDB = value; }
        }

        public String User
        {
            get { return user; }
            set { user = value; }
        }

        public String PasswdUser
        {
            get { return passwdUser; }
            set { passwdUser = value; }
        }
       
        public void loadData()
        {
            XmlReader reader = XmlReader.Create("..\\..\\Xml\\XMLFile1.xml");

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "ipServeur": ipServeur = reader.ReadElementContentAsString();
                            break;
                        case "nomDB": nomDB = reader.ReadElementContentAsString();
                            break;
                        case "user": user = reader.ReadElementContentAsString();
                            break;
                        case "passwdUser": passwdUser = reader.ReadElementContentAsString();
                            break;
                    }
                }
            }
            connection = "Data Source=" + ipServeur + ";Initial Catalog=" + nomDB + ";User ID=" + user + ";Password=" + passwdUser;
        }

        public void updateData(string ip, string nomDB, string user, string passwdUser)
        {
            XmlDocument xmlDoc = new XmlDocument();


            xmlDoc.Load("..\\..\\Xml\\XMLFile1.xml");

            XmlNode racine = xmlDoc.DocumentElement;

            foreach (XmlNode connexionBDD in racine.ChildNodes)
            {
                foreach (XmlNode node in connexionBDD.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "ipServeur":
                            node.InnerText = ip;
                            this.ipServeur = ip;
                            break;

                        case "nomDB": 
                            node.InnerText = nomDB;
                            this.nomDB = nomDB;
                            break;

                        case "user":
                            node.InnerText = user;
                            this.user = user;
                            break;

                        case "passwdUser":
                            node.InnerText = passwdUser;
                            this.passwdUser = passwdUser;
                            break;
                    }
                }
            }

            xmlDoc.Save("..\\..\\Xml\\XMLFile1.xml");

        }
    }
}
