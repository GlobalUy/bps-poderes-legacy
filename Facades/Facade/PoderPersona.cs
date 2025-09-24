using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.EnterpriseServices;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("3021C392-5F54-4205-83B5-FE0CCCAA690A"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class PoderPersona
    {
        private int _persIdentificador;
        [ComMapping("PERS_IDENTIFICADOR")]
        [DataMember]
        public int PersIdentificador
        {
            get { return _persIdentificador; }
            set { _persIdentificador = value; }
        }

        [DataMember]
        public Documento Documento { get; set; }
        
        [DataMember]
        public string Nombre1 { get; set; }
        [DataMember]
        public string Nombre2 { get; set; }
        [DataMember]
        public string Apellido1 { get; set; }
        [DataMember]
        public string Apellido2 { get; set; }
        

        private int _codPoder;
        [ComMapping("COD_PODER")]
        [DataMember]
        public int CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }

        private string _descPoder;
        [ComMapping("DESC_PODER")]
        [DataMember]
        public string DescPoder
        {
            get { return _descPoder; }
            set { _descPoder = value; }
        }

        /// <summary>
        /// Agregado para la RFC 783 - Rediseño de Portal GAFI
        /// Autor: Martin De los Reyes
        /// </summary>
        [DataMember]
        public int CodFacultad { get; set; }

        [DataMember]
        public string DescFacultad { get; set; }

        [DataMember]
        public DateTime FechaPerDesde { get; set; }
        
        [DataMember]
        public DateTime? FechaPerHasta { get; set; }
    }
}
