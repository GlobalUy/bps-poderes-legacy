using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities.wsFuncionario
{
    [Serializable]
    [Guid("0A167C59-56E9-463B-807C-01C5665918FE")]
    public class Documento
    {
        private string _codPaisEmisor;
        public string CodPaisEmisor
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
