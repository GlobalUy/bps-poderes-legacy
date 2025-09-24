// ===============================================================================
// Disclaimer: this class was created by DOMPRES\sbeguiristain on 09/06/2020 11:01:19
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
    [Guid("c555fd75-40f5-4837-891b-628166ad4e18")]
    public class ApoderadoOrigen
    {


        private int _secApoderados;
        [ComMapping("SEC_APODERADOS")]
        public int SecApoderados
        {
            get { return _secApoderados; }
            set { _secApoderados = value; }
        }


        private DateTime _aFechaVigDesde;
        [ComMapping("A_FECHA_VIG_DESDE")]
        public DateTime AFechaVigDesde
        {
            get { return _aFechaVigDesde; }
            set { _aFechaVigDesde = value; }
        }


        private string _codOrigenPoder;
        [ComMapping("COD_ORIGEN_PODER")]
        public string CodOrigenPoder
        {
            get { return _codOrigenPoder; }
            set { _codOrigenPoder = value; }
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

