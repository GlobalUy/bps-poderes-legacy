using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace Bull.PRES.Poderes.Facades.GestionPoderes
{
    [Guid("FB13A321-8360-4AD5-9E4C-6407D2E46A42")]
    [ServiceContract(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public interface IServiceFacade
    {
        [OperationContract(Action = "Version", ReplyAction = "VersionResponse")]
        [return: MessageParameter(Name = "ResultVersion")]
        ResultVersion version();

        [OperationContract(Action = "IngresarPoder", ReplyAction = "IngresarPoderResponse")]
        [return: MessageParameter(Name = "ResultIngresarPoder")]
        ResultIngresarPoder ingresarPoder([MessageParameter(Name = "ParamIngresarPoder")] ParamIngresarPoder param);
    }
}
