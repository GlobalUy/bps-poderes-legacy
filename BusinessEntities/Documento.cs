using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("33E5526C-F025-4269-8F7A-6AC984631468")]
    public class Documento
    {

        private int _persIdentificador;
        public int PersIdentificador 
        {
            get { return _persIdentificador; }
            set { _persIdentificador = value; }
        }

        private int _codPaisEmisor;
        public int CodPaisEmisor
        {
            get { return _codPaisEmisor; }
            set { _codPaisEmisor = value; }
        }

        private string _codTipoDocumento;
        public string CodTipoDocumento
        {
            get { return _codTipoDocumento; }
            set { _codTipoDocumento = value; }
        }

        private string _nroDocumento;
        public string NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }
    }
}
