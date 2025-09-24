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
    [Guid("CEB970ED-DD52-455C-93E7-DDAB9DEA3DA4")]
    [Serializable]
    public class DCErrorNegocio
    {

        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _severidad;
        public int Severidad
        {
            get { return _severidad; }
            set { _severidad = value; }
        }


    }
}
