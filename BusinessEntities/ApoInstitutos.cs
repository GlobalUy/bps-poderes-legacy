// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 14/08/2008 03:08:39 p.m.
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
    [Guid("2d551308-a6e9-4dd8-bd9a-ddec464fcb21")]
	public class ApoInstitutos
	{
		
			
		private int _secInstituto;		
		[ComMapping("SEC_INSTITUTO")]
		public int SecInstituto
		{
			get { return _secInstituto; }
			set { _secInstituto = value; }
		}		
		
		
		private int _persIdentificadorApo;		
		[ComMapping("PERS_IDENTIFICADOR_APO")]
		public int PersIdentificadorApo
		{
			get { return _persIdentificadorApo; }
			set { _persIdentificadorApo = value; }
		}		
		
		
		private int _persIdentificadorBen;		
		[ComMapping("PERS_IDENTIFICADOR_BEN")]
		public int PersIdentificadorBen
		{
			get { return _persIdentificadorBen; }
			set { _persIdentificadorBen = value; }
		}		
		
		
		private DateTime _fechaVigDesde;		
		[ComMapping("FECHA_VIG_DESDE")]
		public DateTime FechaVigDesde
		{
			get { return _fechaVigDesde; }
			set { _fechaVigDesde = value; }
		}		
		
		
		private DateTime _fechaVigDesdeApo;		
		[ComMapping("FECHA_VIG_DESDE_APO")]
		public DateTime FechaVigDesdeApo
		{
			get { return _fechaVigDesdeApo; }
			set { _fechaVigDesdeApo = value; }
		}		
		
		
		private int? _codFacultad;		
		[ComMapping("COD_FACULTAD")]
		public int? CodFacultad
		{
			get { return _codFacultad; }
			set { _codFacultad = value; }
		}		
			
		
		
	}
}
