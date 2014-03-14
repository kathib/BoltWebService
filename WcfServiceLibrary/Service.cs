using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // 3. A ServiceClass -osztály tehát alkalmaz egy olyan interface-t (IService1) amin használva van a [ServiceContract] -attributom.
    //    ezek után minden olyan metódus, ami az IService -interface-en meg van jelölve az [OperationContract] - attributommal,
    //    hívható lesz kívülről. (GetData, GetDataUsingDataContract)
    //    .
    //    Fontos dolog még, hogy a ServiceClass -osztáy ebben az esetben maga a Service... Ez azt jelenti, hogy a dokumentációban
    //    mikor Service-ről beszélnek (aminek "endpointjai vannak például) akkor ezt az osztályt értik alatta.
    //    a 4. pont az App.Config -file ban van...
    public class ServiceClass : IService, IService2
    {
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

        public string GetData2(int value)
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceClass2 : SecondServiceContract
    {
        public string EgyFunkcio()
        {
            throw new NotImplementedException();
        }
    }
}
