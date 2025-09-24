// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 17/04/2020 02:09:42 p.m.
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
    [Guid("3b55f5ac-6b28-4f05-90f8-1a4c21580490"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public class ParamIngresarPoder
    {
        [DataMember(IsRequired = true)]
        public int persIdPoderdante { get; set; }

        [DataMember(IsRequired = true)]
        public int persIdApoderado { get; set; }

        [DataMember(IsRequired = true)]
        public int codPoder { get; set; }

        [DataMember(IsRequired = true)]
        public int codFacultad { get; set; }

        [DataMember]
        public int codVinculo { get; set; }

        [DataMember(IsRequired = true)]
        public bool suep { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime fechaPerDesde { get; set; }

        [DataMember]
        public DateTime? fechaPerHasta { get; set; }

        [DataMember]
        public string estado { get; set; }

        [DataMember]
        public string comentarios { get; set; }

        [DataMember]
        public int tipoCuratela { get; set; }

         [DataMember(IsRequired = true)]
        public string origen { get; set; }

        [DataMember(IsRequired = true)]
        public string uact { get; set; }
    }
}


