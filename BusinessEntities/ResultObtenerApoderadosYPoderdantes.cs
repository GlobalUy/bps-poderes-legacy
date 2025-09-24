using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [Guid("CDA1071D-222A-46BC-B82F-6A27CA4CBCEA")]
    public class ResultObtenerApoderadosYPoderdantes
    {
        public ResultObtenerApoderadosYPoderdantes()
        {
            ApoderadosPersona = new List<PoderPersona>();
            PoderdantesPersona = new List<PoderPersona>();
            ErroresNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
        }

        public List<PoderPersona> ApoderadosPersona { get; set; }
        public List<PoderPersona> PoderdantesPersona { get; set; }
        public List<Bull.ApplicationFramework.Services.ErrorNegocio> ErroresNegocio { get; set; }
    }
}
