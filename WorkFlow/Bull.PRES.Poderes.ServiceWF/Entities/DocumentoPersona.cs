using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.ServiceWF.Entities
{
    [DataContract]
	public class DocumentoPersona
	{
        
        private int _CodPaisEmisor;

        [DataMember(IsRequired = true, Order = 0)]
        public int CodPaisEmisor
        {
            get { return _CodPaisEmisor; }
            set { _CodPaisEmisor = value; }
        }

        private string _TipoDocumento;
        
        [DataMember(IsRequired = true, Order = 1)]
        public string TipoDocumento
        {
            get { return _TipoDocumento; }
            set { _TipoDocumento = value; }
        }

        private string _NroDocumento;
        
        [DataMember(IsRequired = true, Order = 2)]
        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; }
        }
	}
}
