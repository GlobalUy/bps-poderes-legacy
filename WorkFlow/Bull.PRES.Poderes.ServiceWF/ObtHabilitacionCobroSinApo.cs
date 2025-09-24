using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.ServiceModel;

namespace Bull.PRES.Poderes.ServiceWF
{
    [ServiceBehavior(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", Name = "wsPoderes", InstanceContextMode = InstanceContextMode.PerCall)]
	public sealed partial class ObtHabilitacionCobroSinApo: SequentialWorkflowActivity
	{
		public ObtHabilitacionCobroSinApo()
		{
			InitializeComponent();
		}

        public Bull.PRES.Poderes.ServiceWF.Entities.ResultObtHabilitacionCobroSinApo ReturnValue = new Bull.PRES.Poderes.ServiceWF.Entities.ResultObtHabilitacionCobroSinApo();
        public Bull.PRES.Poderes.ServiceWF.Entities.ParamObtHabilitacionCobroSinApo Param = new Bull.PRES.Poderes.ServiceWF.Entities.ParamObtHabilitacionCobroSinApo();


        private Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio contextoServicio = null;
        public Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio ContextoServicio
        {
            set
            {
                contextoServicio = value;
            }
            get
            {
                if (contextoServicio == null)
                {
                    contextoServicio = new Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio();
                    contextoServicio.Uact = Param.ContextoServicio.UsuarioActual;
                    contextoServicio.FechaOpera = DateTime.Now;
                    contextoServicio.Agencia = Param.ContextoServicio.CodAgencia;
                    contextoServicio.CodRol = Param.ContextoServicio.CodRol;
                    contextoServicio.Sistema = Param.ContextoServicio.CodSistema;
                    contextoServicio.Debug = 0;
                }
                return contextoServicio;
            }
        }

        public Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ResultObtPersonaPorDocumento ObtPoderDante_ReturnValue = new Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ResultObtPersonaPorDocumento();

        private void codeActSetErrores_ExecuteCode(object sender, EventArgs e)
        {
            Bull.PRES.Poderes.ServiceWF.Entities.ErrorNegocio err = null;

            if (ObtPoderDante_ReturnValue.ColErrorNegocio.Length > 0)
            {
                err = new Bull.PRES.Poderes.ServiceWF.Entities.ErrorNegocio();
                err.Codigo = "1701";
                err.Descripcion = "Poderdante: Persona inexistente";
                err.Severidad = 1;
                ReturnValue.ColErrorNegocio.Add(err);
            }

           
            if (ReturnValue.ColErrorNegocio.Count > 0) return; //si hay errores me voy


            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CodGrupo = 2;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.PersIdentificadorApoderado = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.PersIdentificadorPoderDante = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador.Value;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS = new Bull.ApplicationFramework.WebServices.ContextoWS();// new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ContextoWS();
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.CodAgencia = Param.ContextoServicio.CodAgencia;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.CodRol = Param.ContextoServicio.CodRol;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.CodSistemaCliente = 0;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.FechaOpera = DateTime.Now;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.Debug = 0;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.UsuarioActual = Param.ContextoServicio.UsuarioActual;

        }

        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder ObtTienePoderCobroSoloApoderado_paramObtTienePoder = new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder();
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder ObtTienePoderCobroSoloApoderado_ReturnValue = new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder();

        private void SetResult_ExecuteCode(object sender, EventArgs e)
        {
            ReturnValue.CobroSoloApoderado = ObtTienePoderCobroSoloApoderado_ReturnValue.Resultado;
        }
	}

}
