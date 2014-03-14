using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // 1. Ahhoz, hogy egy WCF Service működjön, meg kell "mutatni", hogy mely metódusok legyenek elérhetők
    //    kívűlről. Régen ez úgy volt, hogy ezeket a metódusokat a [WebMethod] -attributommal kellett jelölni közvetlenül azon
    //    az osztályon ahol a metódusok voltak.
    //    A WCF -ben más módszer van, mert itt egy [ServiceContract] -attributommal jelölt interface-t kell alkalmaznia az osztálynak (ServiceClass),
    //    ami majd implementálja a metódusokat...
    //    Azokat a metódusokat amiket kifelé akarunk publikálni, az [OperationContract] -attributommal kell jelölni....
    //    .
    //    Tehát ebben az esetben a ServiceClass -fogja alkalmazni az IService interface-t, és a "GetData" 
    //    valamint a "GetDataUsingDataContract" metódusok lesznek láthatók kívülről...
  
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

    }

    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        string GetData2(int value);
    }

    // 2. A datacontract arra való, hogy ne csak a beépített típusokat, hanem sajátokat is lessen argumentumként
    //    és visszatérési értékként használni a "kifelé publikált" metódusoknál.
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

    [ServiceContract]
    public interface SecondServiceContract
    {
        [OperationContract]
        string EgyFunkcio();
    }
}
