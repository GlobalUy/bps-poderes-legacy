// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 12:43:02 p.m.
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
    [Guid("7533740e-e4ee-4567-8eb8-b48fa8b36d14")]
    public class PInstituto
    {

        private int _codFacultad;
        [ComMapping("COD_FACULTAD")]
        public int CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
        }


        private DateTime _fechaVigDesdeApo;
        [ComMapping("FECHA_VIG_DESDE_APO")]
        public DateTime FechaVigDesdeApo
        {
            get { return _fechaVigDesdeApo; }
            set { _fechaVigDesdeApo = value; }
        }


        private int _secInstituto;
        [ComMapping("SEC_INSTITUTO")]
        public int SecInstituto
        {
            get { return _secInstituto; }
            set { _secInstituto = value; }
        }
    }
}

