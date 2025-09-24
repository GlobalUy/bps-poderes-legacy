using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("621F0EAB-901F-474A-888D-4E01C5C17F28")]
    [DataContract(Namespace="http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ResultObtTienePoder
    {
        public ResultObtTienePoder()
        {
            ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
        }

        private List<Bull.ApplicationFramework.Services.ErrorNegocio> colErrorNegocio;

        [DataMember(IsRequired = true)]
        public List<Bull.ApplicationFramework.Services.ErrorNegocio> ColErrorNegocio
        {
            get { return colErrorNegocio; }
            set { colErrorNegocio = value; }
        }


        private string _resultado;

        [DataMember(IsRequired = true)]
        public string Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

    }
}
