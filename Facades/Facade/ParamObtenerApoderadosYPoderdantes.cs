using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("93B7AACE-5D7D-4967-8861-70AC02B60B30"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ParamObtenerApoderadosYPoderdantes
    {
        [DataMember]
        public int PersIdentificador { get; set; }

        [DataMember]
        public string RegitrosVigentes { get; set; }

        [DataMember]
        public string IncluirDatosPersonas { get; set; }

        [DataMember(IsRequired = true)]
        public string UsuarioActual { get; set; }
    }
}
