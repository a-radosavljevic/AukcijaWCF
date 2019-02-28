using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AukcijaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Aukcija" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Aukcija.svc or Aukcija.svc.cs at the Solution Explorer and start debugging.
    public class Aukcija : IAukcija
    {


        public static List<Eksponat> NizEksponata;

        public Aukcija()
        {
            if (NizEksponata != null)
                return;
            NizEksponata = new List<Eksponat>(5);

            for (int i = 0; i < 5; i++)
                NizEksponata.Add(new Eksponat("Eksponat" + i, i * 100));

                //NizEksponata[i] = new Eksponat("Eksponat" + i, i * 100);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void odustaniOdLicitacije(string idEksponata, string klijentAukcijeId)
        {
            foreach (Eksponat e in NizEksponata)
                if (e.Id.ToString().Equals(idEksponata))
                    e.odustaniOdLicitacije(klijentAukcijeId);
        }

        public void povecajCenu(string idEksponata, string ime, string prezime, int iznos)
        {
            foreach (Eksponat e in NizEksponata)
                if (e.Id.ToString().Equals(idEksponata))
                {
                    e.Cena += iznos;
                    e.najveciPonudjac = e.vratiKlijentaAukcije(ime,prezime);
                }
        }

        public void prijaviLicitaciju(string idEksponata, string ime, string prezime)
        {
            KlijentAukcije k = new KlijentAukcije(ime, prezime);
            foreach (Eksponat e in NizEksponata)
                if (e.Id.ToString().Equals(idEksponata))
                    e.klijenti.Add(k);
        }

        public int vratiCenu(string idEksponata)
        {
            foreach (Eksponat e in NizEksponata)
                if (e.Id.ToString().Equals(idEksponata))
                    return e.Cena;
            return -1;
        }

        public Eksponat vratiEksponat(string idEksponata)
        {
            foreach (Eksponat eks in NizEksponata)
                if (eks.Id.ToString() == idEksponata)
                    return eks;
            return null;
        }

        public string vratiIdKlijenta(string idEksponata, string ime, string prezime)
        {
            foreach (Eksponat eks in NizEksponata)
                if (eks.Id.ToString() == idEksponata)
                    return eks.vratiKlijentaAukcije(ime, prezime).KlijentAukcijeId.ToString();
            return null;

        }

        public KlijentAukcije vratiKlijentaAukcije(string idEksponata)
        {
            foreach (Eksponat e in NizEksponata)
                if (e.Id.ToString().Equals(idEksponata))
                    return e.najveciPonudjac;
            return null;
        }

        public List<Eksponat> vratiSveEksponate()
        {
            return NizEksponata;
        }
    }
}
