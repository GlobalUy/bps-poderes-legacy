// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 07/09/2012 11:09:29 a.m.
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
using Bull.ApplicationFramework.WebServices;

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Serializable]
    [Guid("a8861c87-f2a6-4eaa-b3a6-e50d3e1f41ba"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ParamObtHabilitacionCobro
    {
        #region Constructor
        public ParamObtHabilitacionCobro()
        {
            this.Apoderado = new DatoPersona();
            this.Poderdante = new DatoPersona();
        }
        #endregion


        private DatoPersona _poderdante;
        [DataMember(IsRequired = true, Order = 0)]
        public DatoPersona Poderdante
        {
            get { return _poderdante; }
            set { _poderdante = value; }
        }

        private DatoPersona _apoderado;
        [DataMember(IsRequired = true, Order = 1)]
        public DatoPersona Apoderado
        {
            get { return _apoderado; }
            set { _apoderado = value; }
        }

        [DataMember(IsRequired = true, Order = 2)]
        public string UsuarioActual { get; set; }

        		
    }
}


