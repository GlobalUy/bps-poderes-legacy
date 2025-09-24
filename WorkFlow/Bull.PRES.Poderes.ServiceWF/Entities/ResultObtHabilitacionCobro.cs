using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    //[DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", Name = "ResultObtHabilitacionCobro")]
    public class ResultObtHabilitacionCobro
    {
        public ResultObtHabilitacionCobro()
        {
            this.ColErrorNegocio = new List<ErrorNegocio>();
        }

        private string _CobroMixto;

        [DataMember(IsRequired = true, Order = 0)]
        public string CobroMixto
        {
            get { return _CobroMixto; }
            set { _CobroMixto = value; }
        }
        private string _CobroSoloApoderado;

        [DataMember(IsRequired = true, Order = 1)]
        public string CobroSoloApoderado
        {
            get { return _CobroSoloApoderado; }
            set { _CobroSoloApoderado = value; }
        }
        private string _AutorizaCobroAFAM;

        [DataMember(IsRequired = true, Order = 2)]
        public string AutorizaCobroAFAM
        {
            get { return _AutorizaCobroAFAM; }
            set { _AutorizaCobroAFAM = value; }
        }
        private List<ErrorNegocio> _ColErrorNegocio;

        [DataMember(IsRequired = true, Order = 3)]
        public List<ErrorNegocio> ColErrorNegocio
        {
            get { return _ColErrorNegocio; }
            set { _ColErrorNegocio = value; }
        }

    }
}
