using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework.WebServices;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.Facades.wsFuncionario
{
    [Serializable]
    [Guid("0A167C59-56E9-463B-807C-01C5665918FE")]
    public class Documento
    {
        private string _codPaisEmisor;
        [ComMapping("COD_PAIS_EMISOR")]
        public string CodPaisEmisor
        {
            get { return _codPaisEmisor; }
            set { _codPaisEmisor = value; }
        }

        private string _codTipoDocumento;
        [ComMapping("COD_TIPO_DOCUMENTO")]
        public string CodTipoDocumento
        {
            get { return _codTipoDocumento; }
            set { _codTipoDocumento = value; }
        }

        private string _nroDocumento;
        [ComMapping("NRO_DOCUMENTO")]
        public string NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }
    }

}
