using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_control
{
    public class RendezVous
    {
        private String dateEmission, datePrevu, datefin;
        int idDemandeur, idBabysitter, idParent;
        short vu, accept;

        public RendezVous(String dateEmi, String datePre, String dateF, int idDe, int idBa, int idP)
        {
            DateEmission = dateEmi;
            DatePrevu = datePre;
            Datefin = dateF;
            IdDemandeur = idDe;
            IdBabysitter = idBa;
            IdParent = idP;
            Vu = 0;
            Accept = 0;
        }

        public RendezVous(String dateEmi, String datePre, String dateF)
        {
            DateEmission = dateEmi;
            DatePrevu = datePre;
            Datefin = dateF;
        }

        public int IdParent
        {
            get { return idParent; }
            set { idParent = value; }
        }

        public String Datefin
        {
            get { return datefin; }
            set { datefin = value; }
        }

        public String DatePrevu
        {
            get { return datePrevu; }
            set { datePrevu = value; }
        }

        public String DateEmission
        {
            get { return dateEmission; }
            set { dateEmission = value; }
        }

        public int IdBabysitter
        {
            get { return idBabysitter; }
            set { idBabysitter = value; }
        }

        public int IdDemandeur
        {
            get { return idDemandeur; }
            set { idDemandeur = value; }
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
