using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
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
	partial class ObtHabilitacionCobro
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
            System.Workflow.Activities.ChannelToken channeltoken2 = new System.Workflow.Activities.ChannelToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding4 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo2 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.ChannelToken channeltoken3 = new System.Workflow.Activities.ChannelToken();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding5 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding6 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo3 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.ChannelToken channeltoken4 = new System.Workflow.Activities.ChannelToken();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding7 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding8 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding9 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding10 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding11 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo4 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.ChannelToken channeltoken5 = new System.Workflow.Activities.ChannelToken();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding12 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding13 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding14 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding15 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding16 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo5 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding17 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding18 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding19 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding20 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding21 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding22 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding23 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding24 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding25 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.TypedOperationInfo typedoperationinfo6 = new System.Workflow.Activities.TypedOperationInfo();
            System.Workflow.Activities.WorkflowServiceAttributes workflowserviceattributes1 = new System.Workflow.Activities.WorkflowServiceAttributes();
            this.SetResult = new System.Workflow.Activities.CodeActivity();
            this.ObtPoderesCobroMixto = new System.Workflow.Activities.SendActivity();
            this.ObtTinePoderAutCobroAfam = new System.Workflow.Activities.SendActivity();
            this.ObtTienePoderCobroSoloApoderado = new System.Workflow.Activities.SendActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.SetErrores = new System.Workflow.Activities.CodeActivity();
            this.ObtApoderado = new System.Workflow.Activities.SendActivity();
            this.ObtPoderDante = new System.Workflow.Activities.SendActivity();
            this.receiveActivity1 = new System.Workflow.Activities.ReceiveActivity();
            // 
            // SetResult
            // 
            this.SetResult.Name = "SetResult";
            this.SetResult.ExecuteCode += new System.EventHandler(this.SetResult_ExecuteCode);
            // 
            // ObtPoderesCobroMixto
            // 
            channeltoken1.EndpointName = "NetTcpBinding_ServicioPoderes";
            channeltoken1.Name = "PoderesChannel";
            channeltoken1.OwnerActivityName = "";
            this.ObtPoderesCobroMixto.ChannelToken = channeltoken1;
            this.ObtPoderesCobroMixto.Name = "ObtPoderesCobroMixto";
            activitybind1.Name = "ObtHabilitacionCobro";
            activitybind1.Path = "ObtPoderesCobroMixto_paramObtTienePoder";
            workflowparameterbinding1.ParameterName = "paramObtTienePoder";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "ObtHabilitacionCobro";
            activitybind2.Path = "ObtPoderesCobroMixto_ReturnValue";
            workflowparameterbinding2.ParameterName = "(ReturnValue)";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.ObtPoderesCobroMixto.ParameterBindings.Add(workflowparameterbinding1);
            this.ObtPoderesCobroMixto.ParameterBindings.Add(workflowparameterbinding2);
            typedoperationinfo1.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ServicioPoderes);
            typedoperationinfo1.Name = "ObtTienePoder";
            this.ObtPoderesCobroMixto.ServiceOperationInfo = typedoperationinfo1;
            // 
            // ObtTinePoderAutCobroAfam
            // 
            channeltoken2.EndpointName = "NetTcpBinding_ServicioPoderes";
            channeltoken2.Name = "PoderesChannel";
            channeltoken2.OwnerActivityName = "ObtHabilitacionCobro";
            this.ObtTinePoderAutCobroAfam.ChannelToken = channeltoken2;
            this.ObtTinePoderAutCobroAfam.Name = "ObtTinePoderAutCobroAfam";
            activitybind3.Name = "ObtHabilitacionCobro";
            activitybind3.Path = "ObtTinePoderAutCobroAfam_paramObtTienePoder";
            workflowparameterbinding3.ParameterName = "paramObtTienePoder";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            activitybind4.Name = "ObtHabilitacionCobro";
            activitybind4.Path = "ObtTinePoderAutCobroAfam_ReturnValue";
            workflowparameterbinding4.ParameterName = "(ReturnValue)";
            workflowparameterbinding4.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.ObtTinePoderAutCobroAfam.ParameterBindings.Add(workflowparameterbinding3);
            this.ObtTinePoderAutCobroAfam.ParameterBindings.Add(workflowparameterbinding4);
            typedoperationinfo2.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ServicioPoderes);
            typedoperationinfo2.Name = "ObtTienePoder";
            this.ObtTinePoderAutCobroAfam.ServiceOperationInfo = typedoperationinfo2;
            // 
            // ObtTienePoderCobroSoloApoderado
            // 
            channeltoken3.EndpointName = "NetTcpBinding_ServicioPoderes";
            channeltoken3.Name = "PoderesChannel";
            channeltoken3.OwnerActivityName = "";
            this.ObtTienePoderCobroSoloApoderado.ChannelToken = channeltoken3;
            this.ObtTienePoderCobroSoloApoderado.Name = "ObtTienePoderCobroSoloApoderado";
            activitybind5.Name = "ObtHabilitacionCobro";
            activitybind5.Path = "ObtPoderesCobroMixto_paramObtTienePoder";
            workflowparameterbinding5.ParameterName = "paramObtTienePoder";
            workflowparameterbinding5.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            activitybind6.Name = "ObtHabilitacionCobro";
            activitybind6.Path = "ObtTienePoderCobroSoloApoderado_ReturnValue";
            workflowparameterbinding6.ParameterName = "(ReturnValue)";
            workflowparameterbinding6.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.ObtTienePoderCobroSoloApoderado.ParameterBindings.Add(workflowparameterbinding5);
            this.ObtTienePoderCobroSoloApoderado.ParameterBindings.Add(workflowparameterbinding6);
            typedoperationinfo3.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePoderes.ServicioPoderes);
            typedoperationinfo3.Name = "ObtTienePoder";
            this.ObtTienePoderCobroSoloApoderado.ServiceOperationInfo = typedoperationinfo3;
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.ObtTienePoderCobroSoloApoderado);
            this.ifElseBranchActivity1.Activities.Add(this.ObtTinePoderAutCobroAfam);
            this.ifElseBranchActivity1.Activities.Add(this.ObtPoderesCobroMixto);
            this.ifElseBranchActivity1.Activities.Add(this.SetResult);
            ruleconditionreference1.ConditionName = "noError";
            this.ifElseBranchActivity1.Condition = ruleconditionreference1;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // SetErrores
            // 
            this.SetErrores.Name = "SetErrores";
            this.SetErrores.ExecuteCode += new System.EventHandler(this.codeActSetErrores_ExecuteCode);
            // 
            // ObtApoderado
            // 
            channeltoken4.EndpointName = "BasicHttpBinding_svc_Rcor_Personas";
            channeltoken4.Name = "PersonaChannel";
            this.ObtApoderado.ChannelToken = channeltoken4;
            this.ObtApoderado.Name = "ObtApoderado";
            activitybind7.Name = "ObtHabilitacionCobro";
            activitybind7.Path = "ParamObtHabilitacionCobro.Apoderado.NroDocumento";
            workflowparameterbinding7.ParameterName = "nroDocumento";
            workflowparameterbinding7.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            activitybind8.Name = "ObtHabilitacionCobro";
            activitybind8.Path = "ParamObtHabilitacionCobro.Apoderado.TipoDocumento";
            workflowparameterbinding8.ParameterName = "codTipoDocumento";
            workflowparameterbinding8.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            activitybind9.Name = "ObtHabilitacionCobro";
            activitybind9.Path = "ParamObtHabilitacionCobro.Apoderado.CodPaisEmisor";
            workflowparameterbinding9.ParameterName = "codPaisEmisor";
            workflowparameterbinding9.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            activitybind10.Name = "ObtHabilitacionCobro";
            activitybind10.Path = "ObtApoderadoReturnValue";
            workflowparameterbinding10.ParameterName = "(ReturnValue)";
            workflowparameterbinding10.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            activitybind11.Name = "ObtHabilitacionCobro";
            activitybind11.Path = "ContextoServicio";
            workflowparameterbinding11.ParameterName = "contexto";
            workflowparameterbinding11.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.ObtApoderado.ParameterBindings.Add(workflowparameterbinding7);
            this.ObtApoderado.ParameterBindings.Add(workflowparameterbinding8);
            this.ObtApoderado.ParameterBindings.Add(workflowparameterbinding9);
            this.ObtApoderado.ParameterBindings.Add(workflowparameterbinding10);
            this.ObtApoderado.ParameterBindings.Add(workflowparameterbinding11);
            typedoperationinfo4.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePersonas.svc_Rcor_Personas);
            typedoperationinfo4.Name = "ObtPersonaPorDocumento";
            this.ObtApoderado.ServiceOperationInfo = typedoperationinfo4;
            // 
            // ObtPoderDante
            // 
            channeltoken5.EndpointName = "BasicHttpBinding_svc_Rcor_Personas";
            channeltoken5.Name = "PersonaChannel";
            this.ObtPoderDante.ChannelToken = channeltoken5;
            this.ObtPoderDante.Name = "ObtPoderDante";
            activitybind12.Name = "ObtHabilitacionCobro";
            activitybind12.Path = "ObtPoderDante_ReturnValue";
            workflowparameterbinding12.ParameterName = "(ReturnValue)";
            workflowparameterbinding12.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            activitybind13.Name = "ObtHabilitacionCobro";
            activitybind13.Path = "ParamObtHabilitacionCobro.Poderdante.CodPaisEmisor";
            workflowparameterbinding13.ParameterName = "codPaisEmisor";
            workflowparameterbinding13.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            activitybind14.Name = "ObtHabilitacionCobro";
            activitybind14.Path = "ParamObtHabilitacionCobro.Poderdante.TipoDocumento";
            workflowparameterbinding14.ParameterName = "codTipoDocumento";
            workflowparameterbinding14.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            activitybind15.Name = "ObtHabilitacionCobro";
            activitybind15.Path = "ParamObtHabilitacionCobro.Poderdante.NroDocumento";
            workflowparameterbinding15.ParameterName = "nroDocumento";
            workflowparameterbinding15.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            activitybind16.Name = "ObtHabilitacionCobro";
            activitybind16.Path = "ContextoServicio";
            workflowparameterbinding16.ParameterName = "contexto";
            workflowparameterbinding16.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding12);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding13);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding14);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding15);
            this.ObtPoderDante.ParameterBindings.Add(workflowparameterbinding16);
            typedoperationinfo5.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.SReferencePersonas.svc_Rcor_Personas);
            typedoperationinfo5.Name = "ObtPersonaPorDocumento";
            this.ObtPoderDante.ServiceOperationInfo = typedoperationinfo5;
            // 
            // receiveActivity1
            // 
            this.receiveActivity1.Activities.Add(this.ObtPoderDante);
            this.receiveActivity1.Activities.Add(this.ObtApoderado);
            this.receiveActivity1.Activities.Add(this.SetErrores);
            this.receiveActivity1.Activities.Add(this.ifElseActivity1);
            this.receiveActivity1.CanCreateInstance = true;
            this.receiveActivity1.Name = "receiveActivity1";
            activitybind17.Name = "ObtHabilitacionCobro";
            activitybind17.Path = "CodPaisEmisor";
            workflowparameterbinding17.ParameterName = "_codPaisEmisor";
            workflowparameterbinding17.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            activitybind18.Name = "ObtHabilitacionCobro";
            activitybind18.Path = "CodTipoDocumento";
            workflowparameterbinding18.ParameterName = "_codTipoDocumento";
            workflowparameterbinding18.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            activitybind19.Name = "ObtHabilitacionCobro";
            activitybind19.Path = "NroDocumento";
            workflowparameterbinding19.ParameterName = "_nroDocumento";
            workflowparameterbinding19.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            activitybind20.Name = "ObtHabilitacionCobro";
            activitybind20.Path = "UsuarioActual";
            workflowparameterbinding20.ParameterName = "_usuarioActual";
            workflowparameterbinding20.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            activitybind21.Name = "ObtHabilitacionCobro";
            activitybind21.Path = "ReturnValue";
            workflowparameterbinding21.ParameterName = "(ReturnValue)";
            workflowparameterbinding21.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            activitybind22.Name = "ObtHabilitacionCobro";
            activitybind22.Path = "docApoderado";
            workflowparameterbinding22.ParameterName = "docApoderado";
            workflowparameterbinding22.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            activitybind23.Name = "ObtHabilitacionCobro";
            activitybind23.Path = "docApoderante";
            workflowparameterbinding23.ParameterName = "docApoderante";
            workflowparameterbinding23.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            activitybind24.Name = "ObtHabilitacionCobro";
            activitybind24.Path = "usuarioActual";
            workflowparameterbinding24.ParameterName = "usuarioActual";
            workflowparameterbinding24.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            activitybind25.Name = "ObtHabilitacionCobro";
            activitybind25.Path = "ParamObtHabilitacionCobro";
            workflowparameterbinding25.ParameterName = "ParamObtHabilitacionCobro";
            workflowparameterbinding25.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding17);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding18);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding19);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding20);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding21);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding22);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding23);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding24);
            this.receiveActivity1.ParameterBindings.Add(workflowparameterbinding25);
            typedoperationinfo6.ContractType = typeof(Bull.PRES.Poderes.ServiceWF.IServiceFacade);
            typedoperationinfo6.Name = "ObtHabilitacionCobro";
            this.receiveActivity1.ServiceOperationInfo = typedoperationinfo6;
            workflowserviceattributes1.ConfigurationName = "ObtHabilitacionCobro";
            workflowserviceattributes1.IncludeExceptionDetailInFaults = true;
            workflowserviceattributes1.Name = "wsPoderes";
            workflowserviceattributes1.Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes";
            // 
            // ObtHabilitacionCobro
            // 
            this.Activities.Add(this.receiveActivity1);
            this.Name = "ObtHabilitacionCobro";
            this.SetValue(System.Workflow.Activities.ReceiveActivity.WorkflowServiceAttributesProperty, workflowserviceattributes1);
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity SetResult;
        private SendActivity ObtPoderDante;
        private SendActivity ObtApoderado;
        private SendActivity ObtTinePoderAutCobroAfam;
        private SendActivity ObtTienePoderCobroSoloApoderado;
        private SendActivity ObtPoderesCobroMixto;
        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity1;
        private CodeActivity SetErrores;
        private ReceiveActivity receiveActivity1;



































































































































    }
}
