using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AukcijaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAukcija" in both code and config file together.
    [ServiceContract]
    public interface IAukcija
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        Eksponat vratiEksponat(string idEksponata);

        [OperationContract]
        List<Eksponat> vratiSveEksponate();

        [OperationContract]
        void prijaviLicitaciju(string idEksponata, string ime, string prezime);

        [OperationContract]
        KlijentAukcije vratiKlijentaAukcije(string idEksponata);

        [OperationContract]
        void odustaniOdLicitacije(string idEksponata, string klijentAukcijeId);
        
        [OperationContract]
        int vratiCenu(string idEksponata);

        [OperationContract]
        void povecajCenu(string idEksponata, string ime, string prezime, int iznos);

        [OperationContract]
        string vratiIdKlijenta(string idEksponata, string ime, string prezime);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
