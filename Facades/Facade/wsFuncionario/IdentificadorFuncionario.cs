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
    [Guid("D63F16C5-3C5F-439D-895D-DDDAF6AB3359")]
    public class IdentificadorFuncionario
    {
        [ComMapping("DOCUMENTO")]
        public Documento Documento { get; set; }
        [ComMapping("FUNCIONARIO")]
        public Funcionario Funcionario { get; set; }
    }
}
