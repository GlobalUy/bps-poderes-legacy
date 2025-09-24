
// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 05/09/2012 05:50:18 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.6
//
// ==============================================================================

using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace Bull.PRES.Poderes.Facades
{
	[Guid("bc5f9a82-fbdb-497b-9fbe-816bc2cea84e")]
	[ServiceContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public interface IServiceFacade 
	{
        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtHabilitacionCobroSinApo")]
        [return: MessageParameter(Name = "ResultObtHabilitacionCobroSinApo")]
        ResultObtHabilitacionCobroSinApo ObtHabilitacionCobroSinApo([MessageParameter(Name = "ParamObtHabilitacionCobroSinApo")] ParamObtHabilitacionCobroSinApo param);

        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtHabilitacionCobro")]
        [return: MessageParameter(Name = "ResultObtHabilitacionCobro")]
        ResultObtHabilitacionCobro ObtHabilitacionCobro([MessageParameter(Name = "ParamObtHabilitacionCobro")] ParamObtHabilitacionCobro param);

		// ==============================================================================
		// Para agregar metodos usar el Guidance.
		// Click derecho sobre la interfaz, Agregar Service Facade Method
		// ==============================================================================

        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtListaPoderes")]
        [return: MessageParameter(Name = "ResultObtListaPoderes")]
        ResultObtListaPoderes ObtListaPoderes([MessageParameter(Name = "ParamObtListaPoderes")] ParamObtListaPoderes param);

        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtTienePoder")]
        [return: MessageParameter(Name = "ResultObtTienePoder")]
        ResultObtTienePoder ObtTienePoder(ParamObtTienePoder paramObtTienePoder);

        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtenerApoderadosYPoderdantes")]
        [return: MessageParameter(Name = "ResultObtenerApoderadosYPoderdantes")]
        ResultObtenerApoderadosYPoderdantes ObtenerApoderadosYPoderdantes([MessageParameter(Name = "ParamObtenerApoderadosYPoderdantes")] ParamObtenerApoderadosYPoderdantes param);

        //[OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtApoderadosInst")]
        //[return: MessageParameter(Name = "ResultObtApoderadosInst")]
        //ResultObtApoderadosInst ObtApoderadosInst([MessageParameter(Name = "ParamObtApoderadosInst")] ParamObtApoderadosInst param);

        //[OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtApoderadosAFAM")]
        //[return: MessageParameter(Name = "ResultObtApoderadosAFAM")]
        //ResultObtApoderadosAFAM ObtApoderadosAFAM([MessageParameter(Name = "ParamObtApoderadosAFAM")] ParamObtApoderadosAFAM param);

        //[OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtDatosPersonaPorPersID")]
        //[return: MessageParameter(Name = "ResultObtDatosPersonaPorPersID")]
        //ResultObtDatosPersonaPorPersID ObtDatosPersonaPorPersID([MessageParameter(Name = "ParamObtDatosPersonaPorPersID")] ParamObtDatosPersonaPorPersID param);

        //[OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtDatosPersonaPorDocumento")]
        //[return: MessageParameter(Name = "ResultObtDatosPersonaPorDocumento")]
        //ResultObtDatosPersonaPorDocumento ObtDatosPersonaPorDocumento([MessageParameter(Name = "ParamObtDatosPersonaPorDocumento")] ParamObtDatosPersonaPorDocumento param);

        //[OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/v001/ObtApoderados")]
        //[return: MessageParameter(Name = "ResultObtApoderados")]
        //ResultObtApoderados ObtApoderados([MessageParameter(Name = "ParamObtApoderados")] ParamObtApoderados param);

        
		
	}
}

