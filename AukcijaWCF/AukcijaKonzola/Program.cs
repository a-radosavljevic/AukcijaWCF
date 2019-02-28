using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AukcijaKonzola
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.AukcijaClient proxy = new ServiceReference1.AukcijaClient();

            IList<object> eksponati = proxy.vratiSveEksponate();

            foreach(object o in eksponati)
                Console.WriteLine(o)
        }
    }
}
