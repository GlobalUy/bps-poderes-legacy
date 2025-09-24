// ===============================================================================
// Disclaimer: this class was created by DOMPRES\sbeguiristain on 09/06/2020 12:59:53
//
// Development platform was: Bull Guidance Package Version: 1.1.8
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
    [Guid("0f4ef569-af06-4d94-87e2-a9e1e884e8c3")]
    public class ConfigIngresoPoder
    {


        private int _codPoder;
        [ComMapping("COD_PODER")]
        public int CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }


        private int _codFacultad;
        [ComMapping("COD_FACULTAD")]
        public int CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
        }


        private DateTime _fechaVigDesde;
        [ComMapping("FECHA_VIG_DESDE")]
        public DateTime FechaVigDesde
        {
            get { return _fechaVigDesde; }
            set { _fechaVigDesde = value; }
        }


        private string _codOrigenPoder;
        [ComMapping("COD_ORIGEN_PODER")]
        public string CodOrigenPoder
        {
            get { return _codOrigenPoder; }
            set { _codOrigenPoder = value; }
        }


        private int? _plazo;
        [ComMapping("PLAZO")]
        public int? Plazo
        {
            get { return _plazo; }
            set { _plazo = value; }
        }


        private string _unidadPlazo;
        [ComMapping("UNIDAD_PLAZO")]
        public string UnidadPlazo
        {
            get { return _unidadPlazo; }
            set { _unidadPlazo = value; }
        }


        private string _poderIncomp;
        [ComMapping("PODER_INCOMP")]
        public string PoderIncomp
        {
            get { return _poderIncomp; }
            set { _poderIncomp = value; }
        }


        private string _facultadIncomp;
        [ComMapping("FACULTAD_INCOMP")]
        public string FacultadIncomp
        {
            get { return _facultadIncomp; }
            set { _facultadIncomp = value; }
        }


        private int? _perCompatible;
        [ComMapping("PER_COMPATIBLE")]
        public int? PerCompatible
        {
            get { return _perCompatible; }
            set { _perCompatible = value; }
        }


        private string _unidadPerCompatible;
        [ComMapping("UNIDAD_PER_COMPATIBLE")]
        public string UnidadPerCompatible
        {
            get { return _unidadPerCompatible; }
            set { _unidadPerCompatible = value; }
        }


        private int? _itf;
        [ComMapping("ITF")]
        public int? Itf
        {
            get { return _itf; }
            set { _itf = value; }
        }


        private string _uact;
        [ComMapping("UACT")]
        public string Uact
        {
            get { return _uact; }
            set { _uact = value; }
        }


        private DateTime _fact;
        [ComMapping("FACT")]
        public DateTime Fact
        {
            get { return _fact; }
            set { _fact = value; }
        }


        private int? _nroSesion;
        [ComMapping("NRO_SESION")]
        public int? NroSesion
        {
            get { return _nroSesion; }
            set { _nroSesion = value; }
        }


    }
}

