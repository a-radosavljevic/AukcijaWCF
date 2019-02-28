using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AukcijaWCF
{
    [DataContract]
    [Serializable]
    public class Eksponat
    {
        [DataMember]
        public string Naziv
        {
            get;

            set;
        }

        [DataMember]
        public int Cena
        {
            get;

            set;
        }

        [DataMember]
        public Guid Id
        {
            get;

            set;
        }

        [DataMember]
        public List<KlijentAukcije> klijenti
        {
            get;

            set;
        }

        [DataMember]
        public KlijentAukcije najveciPonudjac
        {
            get;

            set;
        }
        
        public Eksponat()
        {
            this.Naziv = "Nepoznato";
            this.Cena = -1;
            Id = Guid.NewGuid();

            this.najveciPonudjac = null;

            klijenti = new List<KlijentAukcije>();
        }

        public Eksponat(string naziv, int cena)
        {
            this.Naziv = naziv;
            this.Cena = cena;
            Id = Guid.NewGuid();

            this.najveciPonudjac = null;

            klijenti = new List<KlijentAukcije>();
        }

        public void odustaniOdLicitacije(string klijentAukcijeId)
        {
            foreach (KlijentAukcije k in klijenti)
                if (k.KlijentAukcijeId.ToString().Equals(klijentAukcijeId))
                    klijenti.Remove(k);
        }
        
        public int vratiCenu()
        {
            return this.Cena;
        }

        public KlijentAukcije vratiKlijentaAukcije(string ime, string prezime)
        {
            foreach (KlijentAukcije k in klijenti)
                if (k.KlijentAukcijeId.ToString().Equals(ime) && k.KlijentAukcijeId.ToString().Equals(prezime))
                    return k;
            return null;
        }

        public string vratiNaziv()
        {
            return this.Naziv;
        }

        public override string ToString()
        {
            return this.Naziv + "";
        }
    }
}