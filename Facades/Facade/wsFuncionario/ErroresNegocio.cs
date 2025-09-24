using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework.WebServices;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.Facades.wsFuncionario
{
    [Serializable]
    [Guid("0D54AF90-2763-4CFA-B343-04126D33225E")]
    public class ErroresNegocio
    {
        private string _codigo;
        [ComMapping("CODIGO")]
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _descripcion;
        [ComMapping("DESCRIPCION")]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private string _detalle;
        [ComMapping("DETALLE")]
        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }
    }
}
