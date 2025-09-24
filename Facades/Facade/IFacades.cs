using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ServiceModel;
using Bull.Seguridad.BusinessEntity;

namespace Bull.PRES.Poderes.Facades
{
    [Guid("8FCDB2B5-C095-443a-9223-D98AE167D33A")]
    [ComVisible(true)]
    [ServiceContract(Name = "Poderes", Namespace = "http://bps.gub.uy/Poderes/Poderes/v001", SessionMode = SessionMode.Allowed)]
    public interface IFacades
    {
    //    [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "ObtTienePoder")]
    //    string ObtTienePoder(int persIdentificadorPoderdante, int? persIdentificadorApoderado, int codGrupo, Contexto co);
    }
}
