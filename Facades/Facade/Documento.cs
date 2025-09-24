using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("B51040A4-6722-44DB-90F9-780F947E8BF7"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public  class Documento
    {
        private int _persIdentificador;
        [DataMember]
        public int PersIdentificador
        {
            get { return _persIdentificador; }
            set { _persIdentificador = value; }
        }

        private int _codPaisEmisor;
        [DataMember]
        public int CodPaisEmisor
        {
            get { return _codPaisEmisor; }
            set { _codPaisEmisor = value; }
        }

        private string _codTipoDocumento;

        [DataMember]
        public string CodTipoDocumento
        {
            get { return _codTipoDocumento; }
            set { _codTipoDocumento = value; }
        }

        private string _nroDocumento;

        [DataMember]
        public string NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }
    }
}
