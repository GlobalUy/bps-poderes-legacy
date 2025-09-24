// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 12/08/2008 10:05:53 a.m.
//
// Development platform was: Bull Guidance Package Version: 1.0.19
//
// ==============================================================================

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;


namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Guid("2e913d03-b294-49bf-8fc7-90fdfcddac6a")]
    [Serializable]
	public class DCApoderado 
	{
        public DCApoderado ()
        {
            this.Persona = new DCPersona();
            this.PoderDante = new  DCPersona();
        }

        string _descTipo;		
        public string DescTipo
		{
            get { return _descTipo; }
            set { _descTipo = value; }
		}

        string _Tipo;
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        int? _codFacultad;		
		public int? CodFacultad
		{
			get { return _codFacultad; }
			set { _codFacultad = value; }
		}


        string _descFacultad;		
        public string DescFacultad
		{
            get { return _descFacultad; }
            set { _descFacultad = value; }
		}

        string _afam;
        public string Afam
        {
            get { return _afam; }
            set { _afam = value; }
        }

        string _instituto;		
        public string Instituto
		{
            get { return _instituto; }
            set { _instituto = value; }
		}		
		
		DCPersona _poderDante;
        public DCPersona PoderDante
        {
            get { return _poderDante; }
            set { _poderDante = value; }
        }
        
        DCPersona _persona;
        public DCPersona Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

	}
}