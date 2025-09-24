using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework.WebServices;

namespace Bull.PRES.Poderes.BusinessEntities.wsFuncionario
{
    /// <summary>
    /// Identificador funcionario
    /// </summary>
    [Serializable]
    [Guid("D63F16C5-3C5F-439D-895D-DDDAF6AB3359")]
    public class IdentificadorFuncionario
    {
        public Documento Documento { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
