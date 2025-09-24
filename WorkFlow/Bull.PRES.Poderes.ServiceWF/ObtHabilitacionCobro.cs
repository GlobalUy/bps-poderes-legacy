using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;
using System.ServiceModel;

namespace Bull.PRES.Poderes.ServiceWF
{
     
    [ServiceBehavior(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", Name = "wsPoderes", InstanceContextMode = InstanceContextMode.PerCall)]
    public sealed partial class ObtHabilitacionCobro : SequentialWorkflowActivity
	{
        /* Parametros de entarda del metodo*/
        //public Bull.PRES.Poderes.ServiceWF.Entities.DocumentoPersona docApoderado { get; set; }
        //public Bull.PRES.Poderes.ServiceWF.Entities.DocumentoPersona docApoderante { get; set; }
        //public String usuarioActual = default(System.String);

        /*Parametro de entrada*/
        public Bull.PRES.Poderes.ServiceWF.Entities.ParamObtHabilitacionCobro ParamObtHabilitacionCobro = new Bull.PRES.Poderes.ServiceWF.Entities.ParamObtHabilitacionCobro();
        /*------------------------------------------------------------------ */

        /*Parametro de salida*/
        public Bull.PRES.Poderes.ServiceWF.Entities.ResultObtHabilitacionCobro ReturnValue = new Bull.PRES.Poderes.ServiceWF.Entities.ResultObtHabilitacionCobro();
        /*------------------------------------------------------------------ */
        

        
        public Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ResultObtPersonaPorDocumento ObtPoderDante_ReturnValue = new Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ResultObtPersonaPorDocumento();
        public Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ResultObtPersonaPorDocumento ObtApoderadoReturnValue = null;



        public ObtHabilitacionCobro()
        {
            InitializeComponent();
            
            
        }
        

        private void codeActSetErrores_ExecuteCode(object sender, EventArgs e)
        {
            Bull.PRES.Poderes.ServiceWF.Entities.ErrorNegocio err = null;

            if (ObtPoderDante_ReturnValue.ColErrorNegocio.Length>0)
            {
                err = new Bull.PRES.Poderes.ServiceWF.Entities.ErrorNegocio();
                err.Codigo = "1701";
                err.Descripcion = "Poderdante: Persona inexistente";
                err.Severidad = 1;
                ReturnValue.ColErrorNegocio.Add(err);
            }

            if (ObtApoderadoReturnValue.ColErrorNegocio.Length>0)
            {
                err = new Bull.PRES.Poderes.ServiceWF.Entities.ErrorNegocio();
                err.Codigo = "1701";
                err.Descripcion = "Apoderado: Persona inexistente";
                err.Severidad = 1;
                ReturnValue.ColErrorNegocio.Add(err);
            }


            if (ReturnValue.ColErrorNegocio.Count > 0) return; //si hay errores me voy
            

            /*NO HAY ERROR*/

            //ContextoServicio = new Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio();
            //ContextoServicio.Uact = ParamObtHabilitacionCobro.ContextoServicio.UsuarioActual;
            //ContextoServicio.FechaOpera = DateTime.Now;
            //ContextoServicio.Agencia = ParamObtHabilitacionCobro.ContextoServicio.CodAgencia;
            //ContextoServicio.CodRol = ParamObtHabilitacionCobro.ContextoServicio.CodRol;
            //ContextoServicio.Sistema = ParamObtHabilitacionCobro.ContextoServicio.CodSistema;


            
            ObtPoderesCobroMixto_paramObtTienePoder.CodGrupo = 1;
            ObtPoderesCobroMixto_paramObtTienePoder.PersIdentificadorApoderado = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador;
            ObtPoderesCobroMixto_paramObtTienePoder.PersIdentificadorPoderDante = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador.Value;

            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS = new Bull.ApplicationFramework.WebServices.ContextoWS();// Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ContextoWS();
            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS.CodAgencia = ParamObtHabilitacionCobro.ContextoServicio.CodAgencia;
            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS.CodRol = ParamObtHabilitacionCobro.ContextoServicio.CodRol;
            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS.CodSistemaCliente = 0;
            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS.FechaOpera = DateTime.Now;
            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS.Debug = 0;
            ObtPoderesCobroMixto_paramObtTienePoder.CtxWS.UsuarioActual = ParamObtHabilitacionCobro.ContextoServicio.UsuarioActual;


            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CodGrupo = 2;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.PersIdentificadorApoderado = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.PersIdentificadorPoderDante = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador.Value;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS = new Bull.ApplicationFramework.WebServices.ContextoWS();// new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ContextoWS();
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.CodAgencia = ParamObtHabilitacionCobro.ContextoServicio.CodAgencia;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.CodRol = ParamObtHabilitacionCobro.ContextoServicio.CodRol;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.CodSistemaCliente = 0;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.FechaOpera = DateTime.Now;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.Debug = 0;
            ObtTienePoderCobroSoloApoderado_paramObtTienePoder.CtxWS.UsuarioActual = ParamObtHabilitacionCobro.ContextoServicio.UsuarioActual;
            


            ObtTinePoderAutCobroAfam_paramObtTienePoder.CodGrupo = 3;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.PersIdentificadorApoderado = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.PersIdentificadorPoderDante = ObtPoderDante_ReturnValue.PersonaCons.DocumentoCons.PersIdentificador.Value;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS = new Bull.ApplicationFramework.WebServices.ContextoWS(); // new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ContextoWS();
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS.CodAgencia = ParamObtHabilitacionCobro.ContextoServicio.CodAgencia;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS.CodRol = ParamObtHabilitacionCobro.ContextoServicio.CodRol;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS.CodSistemaCliente = 0;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS.FechaOpera = DateTime.Now;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS.Debug = 0;
            ObtTinePoderAutCobroAfam_paramObtTienePoder.CtxWS.UsuarioActual = ParamObtHabilitacionCobro.ContextoServicio.UsuarioActual;

        }


        private Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio contextoServicio=null;
        public Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio ContextoServicio
        {
            set
            {
                contextoServicio = value;
            }
            get {
                if (contextoServicio == null)
                {
                    contextoServicio = new Bull.PRES.Poderes.ServiceWF.SReferencePersonas.ContextoServicio();
                    contextoServicio.Uact = ParamObtHabilitacionCobro.ContextoServicio.UsuarioActual;
                    contextoServicio.FechaOpera = DateTime.Now;
                    contextoServicio.Agencia = ParamObtHabilitacionCobro.ContextoServicio.CodAgencia;
                    contextoServicio.CodRol = ParamObtHabilitacionCobro.ContextoServicio.CodRol;
                    contextoServicio.Sistema = ParamObtHabilitacionCobro.ContextoServicio.CodSistema;
                    contextoServicio.Debug = 0;
                }
                return contextoServicio;
            }
        }
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder ObtTienePoderCobroSoloApoderado_paramObtTienePoder = new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder();
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder ObtTinePoderAutCobroAfam_paramObtTienePoder = new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder();
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder ObtPoderesCobroMixto_paramObtTienePoder = new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ParamObtTienePoder(); 
        
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder ObtTienePoderCobroSoloApoderado_ReturnValue =new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder();
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder ObtTinePoderAutCobroAfam_ReturnValue=new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder();
        public Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder ObtPoderesCobroMixto_ReturnValue= new Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ResultObtTienePoder();

        private void SetResult_ExecuteCode(object sender, EventArgs e)
        {
            ReturnValue = new Bull.PRES.Poderes.ServiceWF.Entities.ResultObtHabilitacionCobro();
            ReturnValue.AutorizaCobroAFAM = ObtTinePoderAutCobroAfam_ReturnValue.Resultado;
            ReturnValue.CobroMixto = ObtPoderesCobroMixto_ReturnValue.Resultado;
            ReturnValue.CobroSoloApoderado = ObtTienePoderCobroSoloApoderado_ReturnValue.Resultado;
        }
        
        

    
      
   
   
      

	}
}
