using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("5BD4E788-50B6-4424-8F50-9F148E877540")]
    [DataContract(Namespace="http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ContextoWS
    {
        string usuarioActual;
        /// <summary>
        /// Usuario con el cual se está invocando al servicio
        /// </summary>
        [DataMember(IsRequired = true, Order = 0)]
        public string UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        DateTime fechaOpera;
        /// <summary>
        /// Fecha de Operación
        /// </summary>
        [DataMember(IsRequired = true, Order = 1)]
        public DateTime FechaOpera
        {
            get { return fechaOpera; }
            set { fechaOpera = value; }
        }

        int debug;
        /// <summary>
        /// Flag de Debug
        /// </summary>
        [DataMember(IsRequired = true, Order = 2)]
        public int Debug
        {
            get { return debug; }
            set { debug = value; }
        }

        int codSistemaCliente;
        /// <summary>
        /// Código del sistema (SEG_SISTEMAS) el cual está invocando al WebService
        /// </summary>
        [DataMember(IsRequired = true, Order = 3)]
        public int CodSistemaCliente
        {
            get { return codSistemaCliente; }
            set { codSistemaCliente = value; }
        }


        int codAgencia;
        /// <summary>
        /// Código de oficina (SEG_OFICINAS) desde la cual se está invocando al WebService
        /// </summary>
        [DataMember(IsRequired = true, Order = 4)]
        public int CodAgencia
        {
            get { return codAgencia; }
            set { codAgencia = value; }
        }

        int codRol;
        /// <summary>
        /// Código de rol operante (SEG_COD_ROLES)
        /// </summary>
        [DataMember(IsRequired = true, Order = 5)]
        public int CodRol
        {
            get { return codRol; }
            set { codRol = value; }
        }

        int nroSesion;
        /// <summary>
        /// Número identificador de instancia de ejecución
        /// </summary>
        [DataMember(IsRequired = true, Order = 6)]
        public int NroSesion
        {
            get { return nroSesion; }
            set { nroSesion = value; }
        }


    }
}
