using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    //[DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", Name = "ParamObtHabilitacionCobro")]
    public class ParamObtHabilitacionCobro
    {
        #region Constructor
        public ParamObtHabilitacionCobro()
        {
            this.Apoderado = new DatoPersona();
            this.Poderdante = new DatoPersona();
            this.ContextoServicio = new ContextoServicio();
        }
        #endregion


        private DatoPersona _poderdante;

        [DataMember(IsRequired = true, Order = 0)]
        public DatoPersona Poderdante
        {
            get { return _poderdante; }
            set { _poderdante = value; }
        }

        private DatoPersona _apoderado;

        [DataMember(IsRequired = true, Order = 1)]
        public DatoPersona Apoderado
        {
            get { return _apoderado; }
            set { _apoderado = value; }
        }

        private ContextoServicio _contextoServicio;

        [DataMember(IsRequired = true, Order = 2)]
        public  ContextoServicio ContextoServicio
        {
            get { return _contextoServicio; }
            set { _contextoServicio = value; }
        }
    }
}
