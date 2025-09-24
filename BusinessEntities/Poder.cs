// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 23/08/2011 05:32:15 p.m.
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
    [Guid("66a1fc5e-c19b-4ffa-96a8-7dc39feb6412")]
    public class Poder
    {
        private DateTime _fechaVigDesde;
        [ComMapping("Fecha_Vig_Desde")]
        public DateTime FechaVigDesde
        {
            get { return _fechaVigDesde; }
            set { _fechaVigDesde = value; }
        }

        private DateTime _fechaVigHasta;
        [ComMapping("Fecha_Vig_Hasta")]
        public DateTime FechaVigHasta
        {
            get { return _fechaVigHasta; }
            set { _fechaVigHasta = value; }
        }

        private int _persIdentificador_1;
        [ComMapping("PERS_IDENTIFICADOR_1")]
        public int PersIdentificador_1
        {
            get { return _persIdentificador_1; }
            set { _persIdentificador_1 = value; }
        }

        private int _persIdentificador_2;
        [ComMapping("PERS_IDENTIFICADOR_2")]
        public int PersIdentificador_2
        {
            get { return _persIdentificador_2; }
            set { _persIdentificador_2 = value; }
        }
    }
}

