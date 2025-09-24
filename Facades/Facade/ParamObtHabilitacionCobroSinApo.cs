// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 07/09/2012 11:42:51 a.m.
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
    [Guid("3757c890-5ea2-4094-9154-c44b176a238b"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ParamObtHabilitacionCobroSinApo
    {

        private DatoPersona _poderdante;

        [DataMember(IsRequired = true, Order = 0)]
        public DatoPersona Poderdante
        {
            get { return _poderdante; }
            set { _poderdante = value; }
        }

        [DataMember(IsRequired = true, Order = 1)]
        public string UsuarioActual { get; set; }
        				
    }
}


