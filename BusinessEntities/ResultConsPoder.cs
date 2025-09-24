// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 12:53:26 p.m.
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
    [Guid("48b4ce99-9964-4145-8588-9bc91b458940")]
    public class ResultConsPoder
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


        private string _descFacultad;
        [ComMapping("DESC_FACULTAD")]
        public string DescFacultad
        {
            get { return _descFacultad; }
            set { _descFacultad = value; }
        }


        private string _descTipoPoder;
        [ComMapping("DESC_TIPO_PODER")]
        public string DescTipoPoder
        {
            get { return _descTipoPoder; }
            set { _descTipoPoder = value; }
        }       


    }
}

