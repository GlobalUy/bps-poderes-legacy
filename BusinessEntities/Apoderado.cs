// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 07/08/2008 02:30:09 p.m.
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
    [Guid("e655f3d1-18d4-4c79-8cad-83472619d5c0")]
	public class Apoderado
	{
		
        public Apoderado ()
        {
            this.Persona = new Persona();
            this.PoderDante = new Persona();
        }

        private string _descTipo;		
		[ComMapping("DESC_TIPO")]
        public string DescTipo
		{
            get { return _descTipo; }
            set { _descTipo = value; }
		}

        private string _Tipo;
        [ComMapping("TIPO")]
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private int? _codFacultad;		
		[ComMapping("COD_FACULTAD")]
		public int? CodFacultad
		{
			get { return _codFacultad; }
			set { _codFacultad = value; }
		}


        private string _descFacultad;		
		[ComMapping("DESC_FACULTAD")]
        public string DescFacultad
		{
            get { return _descFacultad; }
            set { _descFacultad = value; }
		}

        private string _afam;
        [ComMapping("AFAM")]
        public string Afam
        {
            get { return _afam; }
            set { _afam = value; }
        }

        private string _instituto;		
		[ComMapping("INSTITUTO")]
        public string Instituto
		{
            get { return _instituto; }
            set { _instituto = value; }
		}		
		
		private Persona _poderDante;
        [ComMapping("PODER_DANTE")]
        public Persona PoderDante
        {
            get { return _poderDante; }
            set { _poderDante = value; }
        }
        
        private Persona _persona;
        [ComMapping("PERSONA")]
        public Persona Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        private string _codPoder;
        [ComMapping("COD_PODER")]
        public string CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }

        

	}
}
