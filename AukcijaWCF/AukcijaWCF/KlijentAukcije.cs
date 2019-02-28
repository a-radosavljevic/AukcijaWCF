using System;

namespace AukcijaWCF
{
    public class KlijentAukcije
    {
        private Guid klijentAukcijeId;
        private string ime;
        private string prezime;

        public Guid KlijentAukcijeId
        {
            get
            {
                return klijentAukcijeId;
            }

            set
            {
                klijentAukcijeId = value;
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public KlijentAukcije()
        {
            this.KlijentAukcijeId = Guid.NewGuid();
            this.ime = "Nepoznato";
            this.prezime = "Nepoznato";
        }

        public KlijentAukcije(string ime, string prezime)
        {
            this.KlijentAukcijeId = Guid.NewGuid();
            this.ime = ime;
            this.prezime = prezime;
        }
    }
}