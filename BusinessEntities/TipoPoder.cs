// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 01/09/2011 02:46:17 p.m.
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
    [Guid("1f512948-6382-4084-b616-f7d4aaf99ea0")]
    public class TipoPoder
    {
        private int _codPoder;
        [ComMapping("COD_PODER")]
        public int CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }

        private string _descripcion;
        [ComMapping("DESCRIPCION")]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}

