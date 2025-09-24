using Bull.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("F03226B3-26BA-46DD-B7B9-D675612DEC6B")]
    public class ParametrosGenerales
    {
        [ComMapping("COD_PARAMETRO")]
        public string CodParametro { get; set; }

        [ComMapping("DESCRIPCION")]
        public string Descripcion { get; set; }

        [ComMapping("COD_BENEFICIO")]
        public string CodBeneficio { get; set; }

        [ComMapping("COD_TIPO_SOLICITUD")]
        public string CodTipoSolicitud { get; set; }

        [ComMapping("HABILITADO")]
        public string Habilitado { get; set; }

        [ComMapping("TIPO_DATO")]
        public string TipoDatos { get; set; }

        [ComMapping("VALOR")]
        public object Valor { get; set; }

        [ComMapping("DESC_ABREVIADA")]
        public string DescAbreviada { get; set; }
    }
}
