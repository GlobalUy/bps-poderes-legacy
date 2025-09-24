using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [Guid("D90540AE-D0BA-42D1-B966-137EE65264D2")]
    public class PoderPersona
    {
        private int _persIdentificador_1;
        [ComMapping("PERS_IDENTIFICADOR_1")]
        public int PersIdentificador_1
        {
            get { return _persIdentificador_1; }
            set { _persIdentificador_1 = value; }
        }

        private int _persIdentificador_2;
        [ComMapping("PERS_IDENTIFICADOR_2")]
        public int PersIdentificador_2
        {
            get { return _persIdentificador_2; }
            set { _persIdentificador_2 = value; }
        }


        private string _nombre1;
        public string Nombre1
        {
            get { return _nombre1; }
            set { _nombre1 = value; }
        }

        private string _nombre2;
        public string Nombre2
        {
            get { return _nombre2; }
            set { _nombre2 = value; }
        }

        private string _apellido1;
        public string Apellido1
        {
            get { return _apellido1; }
            set { _apellido1 = value; }
        }

        private string _apellido2;
        public string Apellido2
        {
            get { return _apellido2; }
            set { _apellido2 = value; }
        }

        private int _persIdentificador;
        public int PersIdentificador
        {
            get { return _persIdentificador; }
            set { _persIdentificador = value; }
        }

        private int _codPaisEmisor;
        public int CodPaisEmisor
        {
            get { return _codPaisEmisor; }
            set { _codPaisEmisor = value; }
        }

        private string _codTipoDocumento;
        public string CodTipoDocumento
        {
            get { return _codTipoDocumento; }
            set { _codTipoDocumento = value; }
        }

        private string _nroDocumento;
        public string NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }

        [ComMapping("FECHA_PER_DESDE")]
        public DateTime FechaPerDesde { get; set; }
        [ComMapping("FECHA_PER_HASTA")]
        public DateTime? FechaPerHasta { get; set; }

        private int _codPoder;
        [ComMapping("COD_PODER")]
        public int CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }

        private string _descPoder;
        [ComMapping("DESC_PODER")]
        public string DescPoder
        {
            get { return _descPoder; }
            set { _descPoder = value; }
        }

        /// <summary>
        /// Agregado para la RFC 783 - Rediseño de Portal GAFI
        /// Autor: Martin De los Reyes
        /// </summary>
        [ComMapping("COD_FACULTAD")]
        public int CodFacultad { get; set; }
        [ComMapping("DESC_FACULTAD")]
        public string DescFacultad { get; set; }
    }
}
