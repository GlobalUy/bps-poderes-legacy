// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 20/04/2020 09:09:56 a.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================


using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Legacy;
using Bull.Comunes.BusinessLogic;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using System.Collections.Generic;

namespace Bull.PRES.Poderes.Adapters
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("cfcfc55c-61ad-4097-803f-947283834aec"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class AdapterVb6 : BusinessLogicAbstract
    {
        [AutoComplete]
        public List<BusinessEntities.ErrorNegocio> flngValidarPreGrabar(int codFacultad, int codPoder, int codVinculo, string comentarios, string estado, DateTime fechaPerDesde, DateTime? fechaPerHasta, string origen, int persIdApoderado, int persIdPoderdante, bool suep, int tipoCuratela, string uact, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact }, co))
            {
                try
                {
                    List<BusinessEntities.ErrorNegocio> erroresNegocio = new List<BusinessEntities.ErrorNegocio>();
                    object[] comPoderHeader = new object[] { "sec_apo", "pers_id_1", "pers_id_2", "estado", "cod_vinc_apo", "comentarios", "fch_per_desde", "fch_per_hasta", "fch_ren_rev", "cod_facultad", "suep", "cod_poder", "origen" };
                    object[,] comPoderBody = new object[,] { { "" }, { persIdPoderdante }, { persIdApoderado }, { estado }, { codVinculo == 0 ? (int?)null : codVinculo }, { comentarios }, { fechaPerDesde }, { fechaPerHasta }, { "" }, { codFacultad }, { suep ? "S" : "N" }, { codPoder }, { origen } };
                    object[] comPoder = new object[] { comPoderHeader, comPoderBody };

                    if (uact == BusinessEntities.Constantes.UACT_DEBUG)
                        co.Debug = 2;

                    object validarPreGrabar = Utils.InvokeMethod("VerificacionPodere.cVerificacionPodere", "flngValidarPreGrabar", comPoder, uact, co.FechaOpera, null, null, co.Debug);

                    if (validarPreGrabar != null && Convert.ToInt32(((object[])validarPreGrabar)[0]) > 0) 
                    {
                        object[] arrErrores = (object[])validarPreGrabar;

                        foreach (object error in arrErrores)
                        {
                            erroresNegocio.Add(new BusinessEntities.ErrorNegocio() { Codigo = Convert.ToInt32(error) });
                        }
                    }

                    return erroresNegocio;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
            }
        }

        [AutoComplete]
        public BusinessEntities.ResultIngresarPoder fnarr2GrabarPoder(int codFacultad, int codPoder, int codVinculo, string comentarios, string estado, DateTime fechaPerDesde, DateTime? fechaPerHasta, string origen, int persIdApoderado, int persIdPoderdante, bool suep, int tipoCuratela, string uact, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact }, co))
            {
                try
                {
                    int secApoderadoResult = 0; 
                    const string TIPO_ACCION_GRABAR = "G";
                    BusinessEntities.ResultIngresarPoder resultIngresarPoder = new BusinessEntities.ResultIngresarPoder();
                    object[] comPoderHeader = new object[] { "sec_apo", "pers_id_1", "pers_id_2", "estado", "cod_vinc_apo", "comentarios", "fch_per_desde", "fch_per_hasta", "origen", "fch_ren_rev", "cod_facultad", "suep", "cod_poder", "tipo_accion", "modificacion", "tiene_poder_ant", "fch_per_desde_modif", "fch_per_hasta_modif", "pers_id_2_modif", "vComParamGen", "itf" };
                    object[,] comPoderBody = new object[,] { { "" }, { persIdPoderdante }, { persIdApoderado }, { estado }, { codVinculo == 0 ? (int?)null : codVinculo }, { comentarios }, { fechaPerDesde }, { fechaPerHasta }, { origen }, { "" }, { codFacultad }, { suep ? "S" : "N" }, { codPoder }, { TIPO_ACCION_GRABAR }, { false }, { "N" }, { null }, { null }, { null }, { null }, { "" } };
                    object[] comPoder = new object[] { comPoderHeader, comPoderBody };

                    if (uact == BusinessEntities.Constantes.UACT_DEBUG)
                        co.Debug = 2;

                    object secApoderado = Utils.InvokeMethod("AdmGrabarPoderes.cAdmGrabarPoderes", "fnarr2GrabarPoder", comPoder, uact, co.FechaOpera, null, null, co.Debug);

                    if (secApoderado != null)
                    {
                        int.TryParse(secApoderado.ToString(), out secApoderadoResult);
                        resultIngresarPoder.SecApoderado = secApoderadoResult;
                    }
                    
                    switch (estado)
                    { 
                        case BusinessEntities.Constantes.ESTADO_PENDIENTE:
                            resultIngresarPoder.Estado = BusinessEntities.Constantes.ESTADO_PENDIENTE;
                            resultIngresarPoder.DescEstado = BusinessEntities.Constantes.DESC_ESTADO_PENDIENTE;
                            break;
                        default:
                            resultIngresarPoder.Estado = BusinessEntities.Constantes.ESTADO_OTORGADO;
                            resultIngresarPoder.DescEstado = BusinessEntities.Constantes.DESC_ESTADO_OTORGADO;
                            break;
                    }
                                        
                    return resultIngresarPoder;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
            }
        }
    }
}
