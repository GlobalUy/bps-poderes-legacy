using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.Facades.GestionPoderes
{
    [Serializable]
    [Guid("2C834939-5E81-4134-A88A-23110A03AD5C"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public class ErrorNegocio
    {
        private int _codigo;
        [DataMember]
        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private String _descripcion;
        [DataMember]
        public String descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
    }
}
