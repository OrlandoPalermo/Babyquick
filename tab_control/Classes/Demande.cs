using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newBabyQuick.Classes
{
    public class Demande
    {
        private int id, idParent, idBabysitter;
        private short vu, accept;

        public Demande(int idP, int idB)
        {
            idParent     = idP;
            idBabysitter = idB;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdParent
        {
            get { return idParent; }
            set { idParent = value; }
        }

        public int IdBabysitter
        {
            get { return idBabysitter; }
            set { idBabysitter = value; }
        }

        public short Vu
        {
            get { return vu; }
            set { vu = value; }
        }

        public short Accept
        {
            get { return accept; }
            set { accept = value; }
        }
    }
}