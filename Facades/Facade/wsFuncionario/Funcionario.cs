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
    [Guid("79E5FF9C-38F5-4A21-83FF-F5B6BFCA7837")]
    public class Funcionario
    {
        private int _nroFuncionario;
        [ComMapping("NRO_FUNCIONARIO")]
        public int NroFuncionario
        {
            get { return _nroFuncionario; }
            set { _nroFuncionario = value; }
        }

        private string _nombre1;
        [ComMapping("NOMBRE_1")]
        public string Nombre1
        {
            get { return _nombre1; }
            set { _nombre1 = value; }
        }

        private string _nombre2;

        [ComMapping("NOMBRE_2")]
        public string Nombre2
        {
            get { return _nombre2; }
            set { _nombre2 = value; }
        }
        private string _apellido1;
        [ComMapping("APELLIDO_1")]
        public string Apellido1
        {
            get { return _apellido1; }
            set { _apellido1 = value; }
        }
        private string _apellido2;
        [ComMapping("APELLIDO_2")]
        public string Apellido2
        {
            get { return _apellido2; }
            set { _apellido2 = value; }
        }
        private int _codPaisEmisor;
        [ComMapping("COD_PAIS_EMISOR")]
        public int CodPaisEmisor
        {
            get { return _codPaisEmisor; }
            set { _codPaisEmisor = value; }
        }
        private string _paisEmisor;
        [ComMapping("PAIS_EMISOR")]
        public string PaisEmisor
        {
            get { return _paisEmisor; }
            set { _paisEmisor = value; }
        }
        private string _tipoDocumento;
        [ComMapping("TIPO_DOCUMENTO")]
        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        private string _nroDocumento;
        [ComMapping("NRO_DOCUMENTO")]
        public string NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }
        private int _codSexo;
        [ComMapping("COD_SEXO")]
        public int CodSexo
        {
            get { return _codSexo; }
            set { _codSexo = value; }
        }
        private string _sexo;
        [ComMapping("SEXO")]
        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
        private DateTime? _fechaNacimiento;
        [ComMapping("FECHA_NACIMIENTO")]
        public DateTime? FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        private DateTime? _fechaIngreso;
        [ComMapping("FECHA_INGRESO")]
        public DateTime? FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }
        private int? _codRelacionFuncional;
        [ComMapping("COD_RELACIONAL")]
        public int? CodRelacionFuncional
        {
            get { return _codRelacionFuncional; }
            set { _codRelacionFuncional = value; }
        }
        private string _relacionFuncional;
        [ComMapping("RELACION_FUNCIONAL")]
        public string RelacionFuncional
        {
            get { return _relacionFuncional; }
            set { _relacionFuncional = value; }
        }
        private int? _codUnidad;
        [ComMapping("COD_UNIDAD")]
        public int? CodUnidad
        {
            get { return _codUnidad; }
            set { _codUnidad = value; }
        }
        private string _unidad;
        [ComMapping("UNIDAD")]
        public string Unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }
        private string _estado;
        [ComMapping("ESTADO")]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _codLugarFisico;
        [ComMapping("COD_LUGAR_FISICO")]
        public string CodLugarFisico
        {
            get { return _codLugarFisico; }
            set { _codLugarFisico = value; }
        }
        private string _lugarFisico;
        [ComMapping("LUGAR_FISICO")]
        public string LugarFisico
        {
            get { return _lugarFisico; }
            set { _lugarFisico = value; }
        }
        private string _escalafonPresupuestal;
        [ComMapping("ESCALAFON_PRESUPUESTAL")]
        public string EscalafonPresupuestal
        {
            get { return _escalafonPresupuestal; }
            set { _escalafonPresupuestal = value; }
        }
        private int _gradoPresupuestal;
        [ComMapping("GRADO_PRESUPUESTAL")]
        public int GradoPresupuestal
        {
            get { return _gradoPresupuestal; }
            set { _gradoPresupuestal = value; }
        }
        private string _cargoProsupuestal;
        [ComMapping("CARGO_PRESUPUESTAL")]
        public string CargoProsupuestal
        {
            get { return _cargoProsupuestal; }
            set { _cargoProsupuestal = value; }
        }
        private string _escalafonCobro;
        [ComMapping("ESCALAFON_GRADO")]
        public string EscalafonCobro
        {
            get { return _escalafonCobro; }
            set { _escalafonCobro = value; }
        }
        private int _gradoCobro;
        [ComMapping("GRADO_COBRO")]
        public int GradoCobro
        {
            get { return _gradoCobro; }
            set { _gradoCobro = value; }
        }
        private string _cargoCobro;
        [ComMapping("CARGO_COBRO")]
        public string CargoCobro
        {
            get { return _cargoCobro; }
            set { _cargoCobro = value; }
        }
        private string _eMailExterno;
        [ComMapping("E_MAIL_EXTERNO")]
        public string EMailExterno
        {
            get { return _eMailExterno; }
            set { _eMailExterno = value; }
        }
        private string _numeroCC;
        [ComMapping("NUMERO_CC")]
        public string NumeroCC
        {
            get { return _numeroCC; }
            set { _numeroCC = value; }
        }
        private string _serieCC;
        [ComMapping("SERIE_CC")]
        public string SerieCC
        {
            get { return _serieCC; }
            set { _serieCC = value; }
        }
        private string _antiguedad;
        [ComMapping("ANTIGUEDAD")]
        public string Antiguedad
        {
            get { return _antiguedad; }
            set { _antiguedad = value; }
        }
        private DateTime? _fechaVencimientoCarnetSalud;
        [ComMapping("FECHA_VENCIMIENTO_CARNET_SALUD")]
        public DateTime? FechaVencimientoCarnetSalud
        {
            get { return _fechaVencimientoCarnetSalud; }
            set { _fechaVencimientoCarnetSalud = value; }
        }

        private string _usuarioRed;
        [ComMapping("USUARIO_RED")]
        public string UsuarioRed
        {
            get { return _usuarioRed; }
            set { _usuarioRed = value; }
        }

        private DateTime? _fechaEgreso;
        [ComMapping("FECHA_EGRESO")]
        public DateTime? FechaEgreso
        {
            get { return _fechaEgreso; }
            set { _fechaEgreso = value; }
        }
    }
}
