// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 17/04/2020 02:35:07 p.m.
// Development platform was: Bull Guidance Package Version: 1.1.8
// ==============================================================================

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;
using Bull.ApplicationFramework;
using System.Collections.Generic;


namespace Bull.PRES.Poderes.Facades.GestionPoderes
{
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("2a10356e-bd94-4168-b713-266b725f6e31"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class BusinessFacade : FacadeAbstract
    {
        [AutoComplete]
        public ResultIngresarPoder IngresarPoder(ParamIngresarPoder param, Contexto co)
        {
            using (new Tracer(new object[] { param }, co))
            {
                try 
                {
                    ResultIngresarPoder resultIngresarPoder = new ResultIngresarPoder();
                    BusinessEntities.ResultIngresarPoder result = null;

                    using (BusinessLogic.AdmGestionPoderes admGestionPoderes = new BusinessLogic.AdmGestionPoderes())
                    {
                        result = admGestionPoderes.IngresarPoder(param.codFacultad, param.codPoder, param.codVinculo, param.comentarios, param.estado, param.fechaPerDesde, param.fechaPerHasta, param.origen, param.persIdApoderado, param.persIdPoderdante, param.suep, param.tipoCuratela, param.uact, co);
                    }

                    if (result.ErroresNegocio == null || result.ErroresNegocio.Count == 0)
                    {
                        resultIngresarPoder.Resultado = new Resultado(result.SecApoderado, result.Estado, result.DescEstado); 
                    }
                    else
                    {
                        resultIngresarPoder.ErroresNegocio = result.ErroresNegocio.ConvertAll(err => new GestionPoderes.ErrorNegocio() { codigo = err.Codigo, descripcion = err.Descripcion });
                    }

                    return resultIngresarPoder;
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
}
