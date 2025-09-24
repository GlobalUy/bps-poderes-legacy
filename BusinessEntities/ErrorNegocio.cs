using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("CD646BC3-96A5-49C4-986B-DB10FF272A07")]
    public class ErrorNegocio
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
        private string _detalle;

        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }
    }
}
