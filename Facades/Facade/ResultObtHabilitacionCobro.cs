// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 07/09/2012 11:09:26 a.m.
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
    [Guid("14628747-723e-4d55-9b28-8f83a3a2f919"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ResultObtHabilitacionCobro
    {
        public ResultObtHabilitacionCobro()
        {
            ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
        }
        private List<Bull.ApplicationFramework.Services.ErrorNegocio> _ColErrorNegocio;

        [DataMember(IsRequired = true)]
        public List<Bull.ApplicationFramework.Services.ErrorNegocio> ColErrorNegocio
        {
            get { return _ColErrorNegocio; }
            set { _ColErrorNegocio = value; }
        }
        
        private string _CobroMixto;

        [DataMember(IsRequired = true)]
        public string CobroMixto
        {
            get { return _CobroMixto; }
            set { _CobroMixto = value; }
        }
        
        private string _CobroSoloApoderado;

        [DataMember(IsRequired = true)]
        public string CobroSoloApoderado
        {
            get { return _CobroSoloApoderado; }
            set { _CobroSoloApoderado = value; }
        }
        
        private string _AutorizaCobroAFAM;

        [DataMember(IsRequired = true)]
        public string AutorizaCobroAFAM
        {
            get { return _AutorizaCobroAFAM; }
            set { _AutorizaCobroAFAM = value; }
        }

        private string _ActuacionConjunta;
        
        [DataMember(IsRequired = true)]
        public string ActuacionConjunta
        {
            get { return _ActuacionConjunta; }
            set { _ActuacionConjunta = value; }
        }

    }
}


