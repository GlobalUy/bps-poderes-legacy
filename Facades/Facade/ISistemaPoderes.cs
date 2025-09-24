// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 12/08/2008 10:02:14 a.m.
//
// Development platform was: Bull Guidance Package Version: 1.0.19
//
// ==============================================================================
#region Declaraciones Using
using System;
using System.Collections.Generic;
using System.Text;
using Bull.Seguridad.BusinessEntity;
using System.Runtime.InteropServices;
using System.EnterpriseServices;
using System.ServiceModel;
#endregion

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Guid("12EAD882-4034-467d-AA22-132410275AFC")]
    [ServiceContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public interface ISistemaPoderes : IDisposable
	{
        [AutoComplete]
        List<DCApoderado> ObtApoderados(int persIdPoderdante, int? persIdApoderado, int codGrupo, Contexto co);

        [AutoComplete]
        DCPersona ObtDatosPersonaPorDocumento(int codPaisEmisor, string codTipoDocumento, string nroDocumento, Contexto co);

        [AutoComplete]
        DCPersona ObtDatosPersonaPorPersID(int persId, Contexto co);

        [AutoComplete]
        List<DCResultConsPoder> ObtListaPoderes(string cobroAFAM, int tipoFacultades, int persIdApoderado, int persIdPoderdante, Contexto co);

        [AutoComplete]
        ResultObtenerApoderadosYPoderdantes ObtenerApoderadosYPoderdantes(ParamObtenerApoderadosYPoderdantes param, Contexto co);
        
       /* [AutoComplete]
        List<DCApoderado> ObtApoderados(int? persIdPoderdante, int persIdApoderado, Contexto co);

        [AutoComplete]
        List<DCApoderado> ObtApoderadosAFAM(int? persIdPoderdante, int persIdApoderado, Contexto co);

        [AutoComplete]
        List<DCApoderado> ObtApoderadosInst(int? persIdPoderdante, int persIdApoderado, Contexto co);
        */
	}
}