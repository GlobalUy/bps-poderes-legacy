// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 01/09/2011 02:50:39 p.m.
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
    [Guid("50c2a946-4842-4a5b-9e4b-0a1ba2223ba8")]
    public class TipoFacultad
    {
        private int _codFacultad;
        [ComMapping("COD_FACULTAD")]
        public int CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
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

