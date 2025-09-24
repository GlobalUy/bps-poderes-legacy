using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Bull.PRES.Poderes.BusinessEntities.wsFuncionario
{
    [Serializable]
    [Guid("AD2C38C9-4850-4D59-A3C2-4966376AF1BF")]
    public class Funcionario
    {
        private int _nroFuncionario;

        public int NroFuncionario
        {
            get { return _nroFuncionario; }
            set { _nroFuncionario = value; }
        }

        private string _nombre1;

        public string Nombre1
        {
            get { return _nombre1; }
            set { _nombre1 = value; }
        }

        private string _nombre2;

        public string Nombre2
        {
            get { return _nombre2; }
            set { _nombre2 = value; }
        }
        private string _apellido1;

        public string Apellido1
        {
            get { return _apellido1; }
            set { _apellido1 = value; }
        }
        private string _apellido2;

        public string Apellido2
        {
            get { return _apellido2; }
            set { _apellido2 = value; }
        }
        private string _codPaisEmisor;

        public string CodPaisEmisor
        {
            get { return _codPaisEmisor; }
            set { _codPaisEmisor = value; }
        }
        private string _paisEmisor;

        public string PaisEmisor
        {
            get { return _paisEmisor; }
            set { _paisEmisor = value; }
        }
        private string _tipoDocumento;

        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        private string _nroDocumento;

        public string NroDocumento
        {
            get { return _nroDocumento; }
            set { _nroDocumento = value; }
        }
        private string _codSexo;

        public string CodSexo
        {
            get { return _codSexo; }
            set { _codSexo = value; }
        }
        private string _sexo;

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
        private DateTime? _fechaNacimiento;

        public DateTime? FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        private DateTime? _fechaIngreso;

        public DateTime? FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        private int? _codRelacionFuncional;

        public int? CodRelacionFuncional
        {
            get { return _codRelacionFuncional; }
            set { _codRelacionFuncional = value; }
        }
        private string _relacionFuncional;

        public string RelacionFuncional
        {
            get { return _relacionFuncional; }
            set { _relacionFuncional = value; }
        }

        private int? _codUnidad;

        public int? CodUnidad
        {
            get { return _codUnidad; }
            set { _codUnidad = value; }
        }
        private string _unidad;

        public string Unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }
        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _codLugarFisico;

        public string CodLugarFisico
        {
            get { return _codLugarFisico; }
            set { _codLugarFisico = value; }
        }
        private string _lugarFisico;

        public string LugarFisico
        {
            get { return _lugarFisico; }
            set { _lugarFisico = value; }
        }
        private string _escalafonPresupuestal;

        public string EscalafonPresupuestal
        {
            get { return _escalafonPresupuestal; }
            set { _escalafonPresupuestal = value; }
        }
        private string _gradoPresupuestal;

        public string GradoPresupuestal
        {
            get { return _gradoPresupuestal; }
            set { _gradoPresupuestal = value; }
        }
        private string _cargoProsupuestal;

        public string CargoProsupuestal
        {
            get { return _cargoProsupuestal; }
            set { _cargoProsupuestal = value; }
        }
        private string _escalafonCobro;

        public string EscalafonCobro
        {
            get { return _escalafonCobro; }
            set { _escalafonCobro = value; }
        }
        private string _gradoCobro;

        public string GradoCobro
        {
            get { return _gradoCobro; }
            set { _gradoCobro = value; }
        }
        private string _cargoCobro;
            
        public string CargoCobro
        {
            get { return _cargoCobro; }
            set { _cargoCobro = value; }
        }
        private string _eMailExterno;

        public string EMailExterno
        {
            get { return _eMailExterno; }
            set { _eMailExterno = value; }
        }
        private string _numeroCC;

        public string NumeroCC
        {
            get { return _numeroCC; }
            set { _numeroCC = value; }
        }
        private string _serieCC;

        public string SerieCC
        {
            get { return _serieCC; }
            set { _serieCC = value; }
        }
        private string _antiguedad;

        public string Antiguedad
        {
            get { return _antiguedad; }
            set { _antiguedad = value; }
        }
        private DateTime? _fechaVencimientoCarnetSalud;

        public DateTime? FechaVencimientoCarnetSalud
        {
            get { return _fechaVencimientoCarnetSalud; }
            set { _fechaVencimientoCarnetSalud = value; }
        }

        private string _usuarioRed;

        public string UsuarioRed
        {
            get { return _usuarioRed; }
            set { _usuarioRed = value; }
        }

        private DateTime? _fechaEgreso;

        public DateTime? FechaEgreso
        {
            get { return _fechaEgreso; }
            set { _fechaEgreso = value; }
        }
    }
}
