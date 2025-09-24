#region Declaraciones Using
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#endregion 

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// Summary description for resultPersona
    /// </summary>

    [Serializable]
    [Guid("F83746CB-E768-4F09-AC07-72F355B4AC1E"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class DatoPersona
    {
        #region Constructor
        public DatoPersona()
        {

        }
        #endregion

        private int _CodPaisEmisor;
        [DataMember]
        public int CodPaisEmisor
        {
            get { return _CodPaisEmisor; }
            set { _CodPaisEmisor = value; }
        }

        private string _TipoDocumento; 
        [DataMember]
        public string TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        private string _NroDocumento;
        [DataMember]
        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }
    }
}
