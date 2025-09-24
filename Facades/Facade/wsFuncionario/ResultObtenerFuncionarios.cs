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
    [Guid("E33B9F26-2FC5-415D-82E2-64EF1D118B67")]
    public class ResultObtenerFuncionarios
    {
        [ComMapping("FUNCIONARIOS")]
        public List<IdentificadorFuncionario> Funcionarios { get; set; }
        [ComMapping("ERRORES")]
        public List<ErroresNegocio> Errores { get; set; }
    }
}
