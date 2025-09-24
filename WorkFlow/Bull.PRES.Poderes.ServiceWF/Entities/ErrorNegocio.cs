using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    [DataContract]
    public class ErrorNegocio
    {
        public ErrorNegocio()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string _Codigo;

        [DataMember(IsRequired = true, Order = 0)]
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        private string _Descripcion;

        [DataMember(IsRequired = true, Order = 1)]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private int _Severidad;

        [DataMember(IsRequired = true, Order = 2)]
        public int Severidad
        {
            get { return _Severidad; }
            set { _Severidad = value; }
        }
    }
}
