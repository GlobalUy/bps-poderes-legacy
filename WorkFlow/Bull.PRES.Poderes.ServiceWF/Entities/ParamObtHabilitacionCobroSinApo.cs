using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    [DataContract]
    public class ParamObtHabilitacionCobroSinApo
    {
        public ParamObtHabilitacionCobroSinApo()
        {
            this.Poderdante = new DatoPersona();
        }

        private DatoPersona _poderdante;
        [DataMember(IsRequired = true, Order = 0)]
        public DatoPersona Poderdante
        {
            get { return _poderdante; }
            set { _poderdante = value; }
        }

        private ContextoServicio _contextoServicio;
        [DataMember(IsRequired = true, Order = 1)]
        public ContextoServicio ContextoServicio
        {
            get { return _contextoServicio; }
            set { _contextoServicio = value; }
        }


    }
}
