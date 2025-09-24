// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 07/09/2012 11:42:50 a.m.
//
// Development platform was: Bull Guidance Package 
//
// ==============================================================================

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel;

using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Serializable]
    [Guid("03aad3fb-93f4-4a7a-9ca1-1a9290eb0360"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ResultObtHabilitacionCobroSinApo
    {
        
        //Ejemplo:
        //[DataMember]
        //public string Nombre { get; set; }

        public ResultObtHabilitacionCobroSinApo()
        {
            this.ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
        }

        private string _CobroSoloApoderado;
        [DataMember(IsRequired = true)]
        public string CobroSoloApoderado
        {
            get { return _CobroSoloApoderado; }
            set { _CobroSoloApoderado = value; }
        }

        private List<Bull.ApplicationFramework.Services.ErrorNegocio> _ColErrorNegocio;
        [DataMember(IsRequired = true)]
        public List<Bull.ApplicationFramework.Services.ErrorNegocio> ColErrorNegocio
        {
            get { return _ColErrorNegocio; }
            set { _ColErrorNegocio = value; }
        }
    }
}


