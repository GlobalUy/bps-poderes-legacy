using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Bull.PRES.Poderes.Facades.GestionPoderes
{
    [Serializable]
    [Guid("04DD8AEB-17C1-4FB5-B6AC-FADD3EBB8425"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public class Resultado
    {
        public Resultado() { }

        public Resultado(int secApoderado, string estado, string descEstado)
        {
            this.secApoderado = secApoderado;
            this.estado = estado;
            this.descEstado = descEstado;
        }

        [DataMember]
        public int secApoderado { get; set; }	
        
        [DataMember]
        public string estado { get; set; }	
        
        [DataMember]
        public string descEstado { get; set; }	

    }
}
