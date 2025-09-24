using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;
using Bull.ApplicationFramework.WebServices;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.Facades.GestionPoderes
{
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("7BBACB0D-1ED2-4F9E-8CE6-1D543F2EB2D0"), ClassInterface(ClassInterfaceType.AutoDual)]
    [ServiceBehavior(Namespace = "http://bps.gub.uy/Prestaciones/GestionPoderes/v001")]
    public class ServiceFacade : FacadeAbstract, IServiceFacade
    {
        [AutoComplete]
        public ResultIngresarPoder ingresarPoder(ParamIngresarPoder param)
        {
            Contexto co = new Contexto(param.uact, DateTime.Now, 0);

            try
            {
                using (new Tracer(new object[] { param }, co))
                {
                    using (Facades.GestionPoderes.BusinessFacade bf = new Facades.GestionPoderes.BusinessFacade())
                    {
                        return bf.IngresarPoder(param, co);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        [AutoComplete]
        public ResultVersion version()
        {
            Contexto co = new Contexto();

            try
            {
                ResultVersion version = new ResultVersion();

                version.nombreServicio = "Pres.Poderes.wssGestionPoderes";
                version.versionEstandar = "3.1";
                version.versionServicio = "1.0";

                return version;
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }
    }
}
