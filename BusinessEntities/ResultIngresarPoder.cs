using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("D70DA5EB-92AA-447B-A617-7CE846F707CF")]
    public class ResultIngresarPoder
    {
        public ResultIngresarPoder()
        {
            ErroresNegocio = new List<ErrorNegocio>();
        }

        public List<ErrorNegocio> ErroresNegocio { get; set; }

        public int SecApoderado { get; set; }

        public string Estado { get; set; }

        public string DescEstado { get; set; }	
    }
}
