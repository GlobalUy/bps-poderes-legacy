// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 07/08/2008 03:01:36 p.m.
//
// Development platform was: $Platform$
//
// ==============================================================================
using System;
using System.Runtime.InteropServices;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    /// <summary>
    /// This is a sample class by DOMPRES\iotegui.
    /// </summary>
    [Serializable]
    [Guid("5d7d5df1-6695-4414-b253-3c07513727f2")]
	public class Persona
	{
		
			
		private int _persIdentificador;		
		[ComMapping("PERS_IDENTIFICADOR")]
		public int PersIdentificador
		{
			get { return _persIdentificador; }
			set { _persIdentificador = value; }
		}

        private DateTime? fechaFallecimiento;
        public DateTime? FechaFallecimiento
        {
            get { return fechaFallecimiento; }
            set { fechaFallecimiento = value; }
        }
		
	}
}
