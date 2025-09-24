// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 17/04/2020 02:09:41 p.m.
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

namespace Bull.PRES.Poderes.Facades.GestionPoderes
{
    /// <summary>
    /// </summary>
    [Serializable]
    [Guid("17b21eff-a988-488c-ad87-cd03585981e4"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public class ResultIngresarPoder
    {
        public ResultIngresarPoder()
        {
            ErroresNegocio = new List<ErrorNegocio>();
        }

        [DataMember]
        public List<ErrorNegocio> ErroresNegocio { get; set; }

        [DataMember]
        public Resultado Resultado { get; set; }				
    }
}


