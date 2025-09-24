using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    /// <summary>
    /// fmacri
    /// </summary>
    [Serializable]
    [Guid("130B31B1-2AC3-4CE4-9AE9-D966C94CA28F")]
    public class Funcionario
    {
        private string _documento;
        [ComMapping("DOCUMENTO")]
        public string Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

        private string _estado;
        [ComMapping("ESTADO")]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
