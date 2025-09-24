// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 22/08/2012 05:43:31 p.m.
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
    [Guid("0f07bd26-b202-4869-a97b-385efc583df0"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ParamObtListaPoderes
    {

        public ParamObtListaPoderes()
        {
        }

        private string _cobroAFAM;

        [DataMember(IsRequired = true, Order = 0)]
        public string CobroAFAM
        {
            get { return _cobroAFAM; }
            set { _cobroAFAM = value; }
        }

        private int _tipoFacultades;

        [DataMember(IsRequired = true, Order = 1)]
        public int TipoFacultades
        {
            get { return _tipoFacultades; }
            set { _tipoFacultades = value; }
        }

        private int _persIdentificadorApoderado;

        [DataMember(IsRequired = true, Order = 2)]
        public int PersIdentificadorApoderado
        {
            get { return _persIdentificadorApoderado; }
            set { _persIdentificadorApoderado = value; }
        }

        private int _persIdentificadorPoderdante;

        [DataMember(IsRequired = true, Order = 3)]
        public int PersIdentificadorPoderdante
        {
            get { return _persIdentificadorPoderdante; }
            set { _persIdentificadorPoderdante = value; }
        }

        [DataMember(IsRequired = true, Order = 4)]
        public string UsuarioActual { get; set; }
		
    }
}


