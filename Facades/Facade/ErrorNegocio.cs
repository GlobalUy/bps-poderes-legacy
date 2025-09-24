using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("4FE0046E-D3E5-490A-A080-91C49AF32BA0"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ErrorNegocio
    {
        private String _codigo;
        [DataMember]
        public String Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private String _descripcion;
        [DataMember]
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
