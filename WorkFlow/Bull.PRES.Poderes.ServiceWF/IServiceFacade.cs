using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Bull.PRES.Poderes.ServiceWF.Entities;

namespace Bull.PRES.Poderes.ServiceWF
{
	// NOTE: If you change the interface name "IWorkflow1" here, you must also update the reference to "IWorkflow1" in App.config.
    [ServiceContract(Name = "wsPoderes", Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", SessionMode = SessionMode.Allowed)]
    [XmlSerializerFormat] 
	public interface IServiceFacade
	{
        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/ObtHabilitacionCobro")]
        ResultObtHabilitacionCobro ObtHabilitacionCobro(ParamObtHabilitacionCobro ParamObtHabilitacionCobro);

        [OperationContract(Action = "http://bps.gub.uy/Prestaciones/wsPoderes/ObtHabilitacionCobroSinApo")]
        ResultObtHabilitacionCobroSinApo ObtHabilitacionCobroSinApo(ParamObtHabilitacionCobroSinApo ParamObtHabilitacionCobroSinApo);

	}
}
