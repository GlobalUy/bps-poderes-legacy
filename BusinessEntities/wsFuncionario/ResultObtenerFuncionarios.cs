using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bull.PRES.Poderes.BusinessEntities.wsFuncionario
{
    public class ResultObtenerFuncionarios
    {
        public List<IdentificadorFuncionario> Funcionarios { get; set; }
        public List<ErroresNegocio> Errores{ get; set; }
    }
}
