using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Bull.PRES.Poderes.ServiceWF
{
	partial class ObtHabilitacionCobroSinApo
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Activities.ChannelToken channeltoken1 = new System.Workflow.Activities.ChannelToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo1 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.ChannelToken channeltoken2 = new System.Workflow.Activities.ChannelToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding7 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo2 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding8 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding9 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo3 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.SetResult = new System.Workflow.Activities.CodeActivity();
            this.ObtTienePoderCobroSoloApoderado = new System.Workflow.Activities.SendActivity();
            this.error = new System.Workflow.Activities.IfElseBranchActivity();
            this.no_hay_error = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.SetErrores = new System.Workflow.Activities.CodeActivity();
            this.ObtPoderDante = new System.Workflow.Activities.SendActivity();
            this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
            // 
            // SetResult
            // 
            this.SetResult.Name = "SetResult";
            this.SetResult.ExecuteCode += new System.EventHandler(this.SetResult_ExecuteCode);
            // 
            // ObtTienePoderCobroSoloApoderado
            // 
            channeltoken1.EndpointName = "NetTcpBinding_ServicioPoderes";
            channeltoken1.Name = "PoderesChannel";
            channeltoken1.OwnerActivityName = "";
            this.ObtTienePoderCobroSoloApoderado.ChannelToken = channeltoken1;
            this.ObtTienePoderCobroSoloApoderado.Name = "ObtTienePoderCobroSoloApoderado";
            activitybind1.Name = "ObtHabilitacionCobroSinApo";
            activitybind1.Path = "ObtTienePoderCobroSoloApoderado_paramObtTienePoder";
            workflowparameterbinding1.ParameterName = "paramObtTienePoder";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "ObtHabilitacionCobroSinApo";
            activitybind2.Path = "ObtTienePoderCobroSoloApoderado_ReturnValue";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.ObtTienePoderCobroSoloApoderado.ParameterBindings.Add(workflowparameterbinding1);
            this.ObtTienePoderCobroSoloApoderado.ParameterBindings.Add(workflowparameterbinding2);
            typedoperationinfo1.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ServicioPoderes);
            typedoperationinfo1.Name = "ObtTienePoder";
            this.ObtTienePoderCobroSoloApoderado.ServiceOperationInfo = typedoperationinfo1;
            // 
            // error
            // 
            this.error.Name = "error";
            // 
            // no_hay_error
            // 
            this.no_hay_error.Activities.Add(this.ObtTienePoderCobroSoloApoderado);
            this.no_hay_error.Activities.Add(this.SetResult);
            ruleconditionreference1.ConditionName = "no_hay_error";
            this.no_hay_error.Condition = ruleconditionreference1;
            this.no_hay_error.Name = "no_hay_error";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.no_hay_error);
            this.ifElseActivity1.Activities.Add(this.error);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // SetErrores
            // 
            this.SetErrores.Name = "SetErrores";
            this.SetErrores.ExecuteCode += new System.EventHandler(this.codeActSetErrores_ExecuteCode);
            // 
            // ObtPoderDante
            // 
            channeltoken2.EndpointName = "BasicHttpBinding_svc_Rcor_Personas";
            channeltoken2.Name = "PersonaChannel";
            this.ObtPoderDante.ChannelToken = channeltoken2;
            this.ObtPoderDante.Name = "ObtPoderDante";
            activitybind3.Name = "ObtHabilitacionCobroSinApo";
            activitybind3.Path = "ObtPoderDante_ReturnValue";
            workflowparameterbinding3.ParameterName = "(ReturnValue)";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "ObtHabilitacionCobroSinApo";
            activitybind4.Path = "Param.Poderdante.CodPaisEmisor";
            workflowparameterbinding4.ParameterName = "codPaisEmisor";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            activitybind5.Name = "ObtHabilitacionCobroSinApo";
            activitybind5.Path = "Param.Poderdante.TipoDocumento";
            workflowparameterbinding5.ParameterName = "codTipoDocumento";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            activitybind6.Name = "ObtHabilitacionCobroSinApo";
            activitybind6.Path = "Param.Poderdante.NroDocumento";
            workflowparameterbinding6.ParameterName = "nroDocumento";
            workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            activitybind7.Name = "ObtHabilitacionCobroSinApo";
            activitybind7.Path = "ContextoServicio";
            workflowparameterbinding7.ParameterName = "contexto";
            workflowparameterbinding7.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding3);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding4);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding5);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding6);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding7);
            typedoperationinfo2.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePersonas.svc_Rcor_Personas);
            typedoperationinfo2.Name = "ObtPersonaPorDocumento";
            this.ObtPoderDante.ServiceOperationInfo = typedoperationinfo2;
            // 
            // receiveActivity1
            // 
            this.receiveActivity1.Activities.Add(this.ObtPoderDante);
            this.receiveActivity1.Activities.Add(this.SetErrores);
            this.receiveActivity1.Activities.Add(this.ifElseActivity1);
            this.receiveActivity1.CanCreateInstance = true;
            this.receiveActivity1.Name = "receiveActivity1";
            activitybind8.Name = "ObtHabilitacionCobroSinApo";
            activitybind8.Path = "ReturnValue";
            workflowparameterbinding8.ParameterName = "(ReturnValue)";
            workflowparameterbinding8.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            activitybind9.Name = "ObtHabilitacionCobroSinApo";
            activitybind9.Path = "Param";
            workflowparameterbinding9.ParameterName = "ParamObtHabilitacionCobroSinApo";
            workflowparameterbinding9.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding8);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding9);
            typedoperationinfo3.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.IServiceFacade);
            typedoperationinfo3.Name = "ObtHabilitacionCobroSinApo";
            this.receiveActivity1.ServiceOperationInfo = typedoperationinfo3;
            workflowserviceattributes1.ConfigurationName = "Bull.PRES.Poderes.ServiceWF.ObtHabilitacionCobroSinApo";
            workflowserviceattributes1.Name = "wsPoderes";
            workflowserviceattributes1.Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes";
            // 
            // ObtHabilitacionCobroSinApo
            // 
            this.Activities.Add(this.receiveActivity1);
            this.Name = "ObtHabilitacionCobroSinApo";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity SetResult;
        private IfElseBranchActivity error;
        private IfElseBranchActivity no_hay_error;
        private IfElseActivity ifElseActivity1;
        private SendActivity ObtTienePoderCobroSoloApoderado;
        private CodeActivity SetErrores;
        private SendActivity ObtPoderDante;
        private ReceiveActivity receiveActivity1;





















    }
}
