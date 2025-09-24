// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 17/04/2020 10:27:35 p.m.
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
    [Guid("d3498135-fc5d-497a-8c3b-a04df1be746f"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public class ResultVersion
    {
        private string _nombreServicio;
        [DataMember]
        public string nombreServicio
        {
            get { return _nombreServicio; }
            set { _nombreServicio = value; }
        }

        private string _versionServicio;
        [DataMember]
        public string versionServicio
        {
            get { return _versionServicio; }
            set { _versionServicio = value; }
        }

        private DateTime? _fechaExpiracion;
        [DataMember(EmitDefaultValue = false)]
        public DateTime? fechaExpiracion
        {
            get { return _fechaExpiracion; }
            set { _fechaExpiracion = value; }
        }

        private string _versionEstandar;
        [DataMember]
        public string versionEstandar
        {
            get { return _versionEstandar; }
            set { _versionEstandar = value; }
        }				
    }
}


