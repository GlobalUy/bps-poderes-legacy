// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 12/08/2008 10:12:04 a.m.
//
// Development platform was: Bull Guidance Package Version: 1.0.19
//
// ==============================================================================

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    
    [Guid("96b1dd6a-e0ec-4aa4-8bee-bb617bf4ee07")]
    [Serializable]
    public class DCPersona 
	{
        int _persIdentificador;
        public int PersIdentificador
        {
            get { return _persIdentificador; }
            set { _persIdentificador = value; }
        }
	}
}