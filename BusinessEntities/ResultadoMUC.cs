// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 02:59:44 p.m.
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
    [Guid("68582f2d-14b6-4da6-9786-c744b6ae5a5f")]
    public class ResultadoMUC
    {


        private string _cobroAFAM;
        [ComMapping("COBRO_AFAM")]
        public string CobroAFAM
        {
            get { return _cobroAFAM; }
            set { _cobroAFAM = value; }
        }


        private string _cobroMixto;
        [ComMapping("COBRO_MIXTO")]
        public string CobroMixto
        {
            get { return _cobroMixto; }
            set { _cobroMixto = value; }
        }

        private string _cobroSoloApo;
        [ComMapping("COBRO_SOLO_APO")]
        public string CobroSoloApo
        {
            get { return _cobroSoloApo; }
            set { _cobroSoloApo = value; }
        }
        


    }
}

