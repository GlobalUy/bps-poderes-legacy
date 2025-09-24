using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Serializable]
    [Guid("FA95E7C4-C6AE-4A82-98B8-345D689A1D3A"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ResultObtenerApoderadosYPoderdantes
    {
        public ResultObtenerApoderadosYPoderdantes()
        {
            ApoderadosPersona = new List<PoderPersona>();
            PoderdantesPersona = new List<PoderPersona>();
            ErroresNegocio = new List<ErrorNegocio>();
        }

        [DataMember]
        public List<PoderPersona> ApoderadosPersona { get; set; }

        [DataMember]
        public List<PoderPersona> PoderdantesPersona { get; set; }

        [DataMember]
        public List<ErrorNegocio> ErroresNegocio { get; set; }
    }
}
