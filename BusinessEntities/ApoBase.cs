// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 14/08/2008 02:09:05 p.m.
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
    [Guid("3aec7e37-213b-43ba-880c-ab1d7db7f20c")]
	public class ApoBase
	{
		
			
		private int _secApoderados;		
		[ComMapping("SEC_APODERADOS")]
		public int SecApoderados
		{
			get { return _secApoderados; }
			set { _secApoderados = value; }
		}		
		
		
		private DateTime _fechaVigDesde;		
		[ComMapping("FECHA_VIG_DESDE")]
		public DateTime FechaVigDesde
		{
			get { return _fechaVigDesde; }
			set { _fechaVigDesde = value; }
		}		
		
		
		private int _persIdentificador1;		
		[ComMapping("PERS_IDENTIFICADOR_1")]
		public int PersIdentificador1
		{
			get { return _persIdentificador1; }
			set { _persIdentificador1 = value; }
		}		
		
		
		private int _persIdentificador2;		
		[ComMapping("PERS_IDENTIFICADOR_2")]
		public int PersIdentificador2
		{
			get { return _persIdentificador2; }
			set { _persIdentificador2 = value; }
		}		
		
		
		private int _codPoder;		
		[ComMapping("COD_PODER")]
		public int CodPoder
		{
			get { return _codPoder; }
			set { _codPoder = value; }
		}		
		
		
		private string _estado;		
		[ComMapping("ESTADO")]
		public string Estado
		{
			get { return _estado; }
			set { _estado = value; }
		}		
		
		
		private int? _codVinculo;		
		[ComMapping("COD_VINCULO")]
		public int? CodVinculo
		{
			get { return _codVinculo; }
			set { _codVinculo = value; }
		}		
		
		
		private int? _codFacultad;		
		[ComMapping("COD_FACULTAD")]
		public int? CodFacultad
		{
			get { return _codFacultad; }
			set { _codFacultad = value; }
		}		
		
		
		private string _comentarios;		
		[ComMapping("COMENTARIOS")]
		public string Comentarios
		{
			get { return _comentarios; }
			set { _comentarios = value; }
		}		
		
		
		private DateTime _fechaPerDesde;		
		[ComMapping("FECHA_PER_DESDE")]
		public DateTime FechaPerDesde
		{
			get { return _fechaPerDesde; }
			set { _fechaPerDesde = value; }
		}		
		
		
		private DateTime? _fechaPerHasta;		
		[ComMapping("FECHA_PER_HASTA")]
		public DateTime? FechaPerHasta
		{
			get { return _fechaPerHasta; }
			set { _fechaPerHasta = value; }
		}		
		
		
		private DateTime? _fechaRenRev;		
		[ComMapping("FECHA_REN_REV")]
		public DateTime? FechaRenRev
		{
			get { return _fechaRenRev; }
			set { _fechaRenRev = value; }
		}		
		
		
		
	}
}
