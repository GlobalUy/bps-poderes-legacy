using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    [DataContract]
    public class ContextoServicio
    {
        public ContextoServicio()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string _UsuarioActual;
        
        [DataMember(IsRequired=true,Order=0)]
        public string UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        private int _CodRol;

        [DataMember(IsRequired = true, Order = 1)]
        public int CodRol
        {
            get { return _CodRol; }
            set { _CodRol = value; }
        }

        private int _CodAgencia;

        [DataMember(IsRequired = true, Order = 2)]
        public int CodAgencia
        {
            get { return _CodAgencia; }
            set { _CodAgencia = value; }
        }


        private int _CodSistema;

        [DataMember(IsRequired = true, Order =3)]
        public int CodSistema
        {
            get { return _CodSistema; }
            set { _CodSistema = value; }
        }
    }
}
