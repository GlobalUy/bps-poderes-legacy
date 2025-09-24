// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 12:19:51 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.4
//
// ==============================================================================



using System;
using System.Runtime.InteropServices;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [Guid("6a207f22-4c6f-4a96-a601-28e770b92423")]
    public class PApoderado
    {

        private int? _codFacultad;
        [ComMapping("COD_FACULTAD")]
        public int? CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
        }


        private string _codPoder;
        [ComMapping("COD_PODER")]
        public string CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }

        private int? _codVinculo;
        [ComMapping("COD_VINCULO")]
        public int? CodVinculo
        {
            get { return _codVinculo; }
            set { _codVinculo = value; }
        }


        private string _comentarios;
        [ComMapping("COMENTARIOS")]
        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }


        private string _estado;
        [ComMapping("ESTADO")]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
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

        private int _secApoderados;
        [ComMapping("SEC_APODERADOS")]
        public int SecApoderados
        {
            get { return _secApoderados; }
            set { _secApoderados = value; }
        }
    }
}

