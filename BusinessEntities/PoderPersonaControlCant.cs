using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Guid("8BA3AEF1-B05E-4F08-84DA-8199660C515D")]
    public class PoderPersonaControlCant
    {
        public PoderPersonaControlCant()
        {
            ErroresNegocio = new List<ErrorNegocio>();
        }

        public List<ErrorNegocio> ErroresNegocio { get; set; }


        private int _secApoderados;
        [ComMapping("SEC_APODERADOS")]
        public int SecApoderados
        {
            get { return _secApoderados; }
            set { _secApoderados = value; }
        }

        private DateTime _fechaVigDesde;
        [ComMapping("Fecha_Vig_Desde")]
        public DateTime FechaVigDesde
        {
            get { return _fechaVigDesde; }
            set { _fechaVigDesde = value; }
        }

        private int _persIdentificador_1;
        [ComMapping("PERS_IDENTIFICADOR_1")]
        public int PersIdentificador_1
        {
            get { return _persIdentificador_1; }
            set { _persIdentificador_1 = value; }
        }


        private int _codPoder;
        [ComMapping("COD_PODER")]
        public int CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }


        private string _estado;
        [ComMapping("ESTADO")]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private int? _codVinculo;
        [ComMapping("COD_VINCULO")]
        public int? CodVinculo
        {
            get { return _codVinculo; }
            set { _codVinculo = value; }
        }


        private int? _codFacultad;
        [ComMapping("COD_FACULTAD")]
        public int? CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
        }

        private string _comentarios;
        [ComMapping("COMENTARIOS")]
        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }


        private DateTime _fechaPerDesde;
        [ComMapping("FECHA_PER_DESDE")]
        public DateTime FechaPerDesde
        {
            get { return _fechaPerDesde; }
            set { _fechaPerDesde = value; }
        }


        private DateTime? _fechaPerHasta;
        [ComMapping("FECHA_PER_HASTA")]
        public DateTime? FechaPerHasta
        {
            get { return _fechaPerHasta; }
            set { _fechaPerHasta = value; }
        }


        private DateTime? _fechaRenRev;
        [ComMapping("FECHA_REN_REV")]
        public DateTime? FechaRenRev
        {
            get { return _fechaRenRev; }
            set { _fechaRenRev = value; }
        }


        private DateTime _fechaVigHasta;
        [ComMapping("Fecha_Vig_Hasta")]
        public DateTime FechaVigHasta
        {
            get { return _fechaVigHasta; }
            set { _fechaVigHasta = value; }
        }


    }
}
