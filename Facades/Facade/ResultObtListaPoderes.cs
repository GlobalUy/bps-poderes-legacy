// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 22/08/2012 05:43:21 p.m.
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
    [Guid("e5c52ed1-731b-4184-8b8c-333f4455dd0a"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ResultObtListaPoderes
    {
        public ResultObtListaPoderes()
        {
            ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
        }
        
        private List<Bull.ApplicationFramework.Services.ErrorNegocio> colErrorNegocio;

        [DataMember(IsRequired = true)]
        public List<Bull.ApplicationFramework.Services.ErrorNegocio> ColErrorNegocio
        {
            get { return colErrorNegocio; }
            set { colErrorNegocio = value; }
        }

        private List<DCResultConsPoder> colPoderes;

        [DataMember(IsRequired = true)]
        public List<DCResultConsPoder> ColPoderes
        {
            get { return colPoderes; }
            set { colPoderes = value; }
        }
    }
}


