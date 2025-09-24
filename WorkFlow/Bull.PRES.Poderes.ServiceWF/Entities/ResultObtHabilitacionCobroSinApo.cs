using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    [DataContract]
    public class ResultObtHabilitacionCobroSinApo
    {
        public ResultObtHabilitacionCobroSinApo()
        {
            this.ColErrorNegocio = new List<ErrorNegocio>();
        }

        private string _CobroSoloApoderado;

        [DataMember(IsRequired = true, Order = 0)]
        public string CobroSoloApoderado
        {
            get { return _CobroSoloApoderado; }
            set { _CobroSoloApoderado = value; }
        }

        private List<ErrorNegocio> _ColErrorNegocio;

        [DataMember(IsRequired = true, Order = 1)]
        public List<ErrorNegocio> ColErrorNegocio
        {
            get { return _ColErrorNegocio; }
            set { _ColErrorNegocio = value; }
        }
    }
}
