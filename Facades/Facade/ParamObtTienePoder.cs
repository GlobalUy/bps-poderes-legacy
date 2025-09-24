using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Bull.ApplicationFramework.WebServices;



namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("001F2B35-AD0F-46D3-85A7-16D96999C92F")]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ParamObtTienePoder
    {

        public ParamObtTienePoder()
        {
        }
        

        private int persIdentificadorPoderDante;

        [DataMember(IsRequired = true, Order=0)]
        public int PersIdentificadorPoderDante
        {
            get { return persIdentificadorPoderDante; }
            set { persIdentificadorPoderDante = value; }
        }

        private int? persIdentificadorApoderado;

        [DataMember(IsRequired = true,Order=1)]
        public int? PersIdentificadorApoderado
        {
            get { return persIdentificadorApoderado; }
            set { persIdentificadorApoderado = value; }
        }

        private int _codGrupo;

        [DataMember(IsRequired = true, Order = 2)]
        public int CodGrupo
        {
            get { return _codGrupo; }
            set { _codGrupo = value; }
        }


        [DataMember(IsRequired = true, Order = 3)]
        public string UsuarioActual { get; set; }
    }

}
