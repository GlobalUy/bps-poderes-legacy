using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities.wsFuncionario
{
    [Serializable]
    [Guid("FF5A1D01-C73C-4530-9495-9B7375DE3302")]
    public class ErroresNegocio
    {
        private string _codigo;

        public string Codigo
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
