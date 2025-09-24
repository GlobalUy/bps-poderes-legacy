// ===============================================================================
// Disclaimer: this class was created by DOMPRES\sbeguiristain on 09/06/2020 15:47:13
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
    [Guid("f03d1ba8-ae80-4343-9bf4-0092f1406d46")]
    public class OrigenPoder
    {


        private string _codOrigenPoder;
        [ComMapping("COD_ORIGEN_PODER")]
        public string CodOrigenPoder
        {
            get { return _codOrigenPoder; }
            set { _codOrigenPoder = value; }
        }


        private string _descripcion;
        [ComMapping("DESCRIPCION")]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
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

