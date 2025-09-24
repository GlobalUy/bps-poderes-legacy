// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 05/09/2012 05:50:37 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.6
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
using Bull.ApplicationFramework.WebServices;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Bull.PRES.Poderes.BusinessEntities;
using Bull.PRES.Poderes.BusinessLogic;


using System.Web;
using System.Linq;
using Bull.PRES.Poderes.Facades;

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("ea4bb7d5-4dfa-4626-8ad4-59a74f02bcb0"), ClassInterface(ClassInterfaceType.AutoDual)]
    [ServiceBehavior(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ServiceFacade : FacadeAbstract, IServiceFacade
    {



        [AutoComplete]
        private Contexto MapContextoWsToContexto(ContextoWS contextoWS)
        {
            Contexto co = new Contexto();
            co.UsuarioActual = contextoWS.UsuarioActual;
            co.FechaOpera = contextoWS.FechaOpera;
            co.Debug = contextoWS.Debug;
            return co;
        }

        #region pasaje MSE

        [AutoComplete()]
        public ResultObtListaPoderes ObtListaPoderes(ParamObtListaPoderes paramObtListaPoderes)
        {
            Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtListaPoderes.UsuarioActual);
            ResultObtListaPoderes result = new ResultObtListaPoderes();
            try
            {

                using (new Tracer(new object[] { paramObtListaPoderes }, contexto))
                {


                    result.ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
                    //Crear los objetos personas para opoderado y poderdante
                    //Valilos datos de entrada del WS.

                    Bull.ApplicationFramework.Services.ErrorNegocio err = null;
                    DCPersona apoderado;
                    DCPersona poderdante;
                    bool ExistenPersonas;
                    ExistenPersonas = true;

                    if (paramObtListaPoderes.PersIdentificadorPoderdante == int.MinValue || paramObtListaPoderes.PersIdentificadorPoderdante <= 0)
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1701";
                        err.Descripcion = "Poderdante: Persona inexistente";
                        err.Severidad = 1;
                        result.ColErrorNegocio.Add(err);
                        ExistenPersonas = false;
                    }

                    if (paramObtListaPoderes.PersIdentificadorApoderado == int.MinValue || paramObtListaPoderes.PersIdentificadorApoderado <= 0)
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1701";
                        err.Descripcion = "Apoderado: Persona inexistente";
                        err.Severidad = 1;
                        result.ColErrorNegocio.Add(err);
                        ExistenPersonas = false;
                    }

                    if (ExistenPersonas)
                    {
                        using (ISistemaPoderes sistema = new SistemaPoderes())
                        {
                            //Validacion del PersIdApoderado
                            apoderado = sistema.ObtDatosPersonaPorPersID(paramObtListaPoderes.PersIdentificadorApoderado, contexto);
                            //Validacion del PersIDPoderdante
                            poderdante = sistema.ObtDatosPersonaPorPersID(paramObtListaPoderes.PersIdentificadorPoderdante, contexto);
                        }

                        //Cargo los errores en caso de que alguno de los doc NO exista
                        if (poderdante.PersIdentificador == int.MinValue)
                        {
                            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                            err.Codigo = "1701";
                            err.Descripcion = "Poderdante: Persona inexistente";
                            err.Severidad = 1;
                            result.ColErrorNegocio.Add(err);
                        }

                        if (apoderado.PersIdentificador == int.MinValue)
                        {
                            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                            err.Codigo = "1701";
                            err.Descripcion = "Apoderado: Persona inexistente";
                            err.Severidad = 1;
                            result.ColErrorNegocio.Add(err);
                        }
                    }


                    if (!((paramObtListaPoderes.TipoFacultades == 1) || (paramObtListaPoderes.TipoFacultades == 2) ||
                            (paramObtListaPoderes.TipoFacultades == 3) || (paramObtListaPoderes.TipoFacultades == 4)))
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1702";
                        err.Descripcion = "EL valor del parametro tipoFacultades puede ser 1(Cobro), 2(Tramite), 3(Prestamo), 4(Todos) .";
                        err.Severidad = 1;
                        result.ColErrorNegocio.Add(err);
                    }

                    if (!(paramObtListaPoderes.CobroAFAM.Equals("S") || paramObtListaPoderes.CobroAFAM.Equals("N")))
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1703";
                        err.Descripcion = "EL valor del parámetro cobroAFAM no puede ser nulo y debe ser S o N.";
                        err.Severidad = 1;
                        result.ColErrorNegocio.Add(err);
                    }

                    if (result.ColErrorNegocio.Count == 0)
                    {
                        using (SistemaPoderes sistema = new SistemaPoderes())
                        {
                            var ret = sistema.ObtListaPoderes(paramObtListaPoderes.CobroAFAM, paramObtListaPoderes.TipoFacultades, paramObtListaPoderes.PersIdentificadorApoderado, paramObtListaPoderes.PersIdentificadorPoderdante, contexto);

                            result.ColPoderes = ret.Select(i => new DCResultConsPoder()
                            {
                                CodFacultad = i.CodFacultad,
                                DescFacultad = i.DescFacultad,
                                CodPoder = i.CodPoder,
                                DescTipoPoder = i.DescTipoPoder
                            }).ToList();

                        }
                    }
                    //return result;                
                }
            }
            catch (Exception ex)
            {

                //documento inactivo
                if (ex.Message.Contains("PER-2002"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Documento no activo en la base de datos";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                //persona inactiva (FECHA_BAJA <> null)
                else if (ex.Message.Contains("PER-2003"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Persona no activa en la base de datos";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                else if (ex.Message.Contains("Poderdante:"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Poderdante: Persona inexistente";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                else if (ex.Message.Contains("Apoderado:"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Apoderado: Persona inexistente";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                else if (ex.Message.Contains("Persona inexistente"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Persona inexistente";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                else
                {
                    ApplicationFramework.Utils.HandleException(ex, contexto);
                    throw;
                }


            }
            finally
            {
                ApplicationFramework.Utils.LogFinally(MethodBase.GetCurrentMethod(), contexto);
            }
            return result;
        }

        //[AutoComplete()]
        //public ResultObtTienePoder ObtTienePoder(ParamObtTienePoder paramObtTienePoder)
        //{
        //    //Contexto contexto = MapContextoWsToContexto(paramObtTienePoder.CtxWS);
        //    Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtTienePoder.UsuarioActual);
        //    ResultObtTienePoder result = new ResultObtTienePoder();
        //    Bull.ApplicationFramework.Services.ErrorNegocio err = null;
        //    List<Bull.ApplicationFramework.Services.ErrorNegocio> ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();

        //    try
        //    {
        //        using (new Tracer(new object[] { paramObtTienePoder }, contexto))
        //        {
        //            //Cargo los errores en caso de que alguno de los doc NO exista

        //            if (paramObtTienePoder.PersIdentificadorPoderDante == null || 
        //                paramObtTienePoder.PersIdentificadorPoderDante == int.MinValue || 
        //                paramObtTienePoder.PersIdentificadorPoderDante <= 0)
        //            {
        //                err = new Bull.ApplicationFramework.Services.ErrorNegocio();
        //                err.Codigo = "1701";
        //                err.Descripcion = "Poderdante: Persona inexistente";
        //                err.Severidad = 1;
        //                result.ColErrorNegocio.Add (err);
        //                //resultObtHabilitacionCobro.ColErrorNegocio.Add(err);
        //            }

        //            if (paramObtTienePoder.PersIdentificadorApoderado == null || 
        //                paramObtTienePoder.PersIdentificadorApoderado == int.MinValue || 
        //                paramObtTienePoder.PersIdentificadorApoderado <= 0)
        //            {
        //                err = new Bull.ApplicationFramework.Services.ErrorNegocio();
        //                err.Codigo = "1701";
        //                err.Descripcion = "Apoderado: Persona inexistente";
        //                err.Severidad = 1;
        //                result.ColErrorNegocio.Add(err);
        //                //resultObtHabilitacionCobro.ColErrorNegocio.Add(err); 
        //            }

        //            if (err == null)
        //            {
        //                using (SistemaPoderes sistema = new SistemaPoderes())
        //                {
        //                    result.Resultado = sistema.ObtTienePoder(paramObtTienePoder.PersIdentificadorPoderDante, paramObtTienePoder.PersIdentificadorApoderado,
        //                    paramObtTienePoder.CodGrupo, contexto);
        //                } 
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //documento inactivo
        //        if (ex.Message.Contains("PER-2002"))
        //        {
        //            Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
        //            errAux.Codigo = "1701";
        //            errAux.Descripcion = "Documento no activo en la base de datos";
        //            errAux.Severidad = 1;
        //        }
        //        //persona inactiva (FECHA_BAJA <> null)
        //        else if (ex.Message.Contains("PER-2003"))
        //        {
        //            Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
        //            errAux.Codigo = "1701";
        //            errAux.Descripcion = "Persona no activa en la base de datos";
        //            errAux.Severidad = 1;
        //        }
        //        else if (ex.Message.Contains("Poderdante:"))
        //        {
        //            Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
        //            errAux.Codigo = "1701";
        //            errAux.Descripcion = "Poderdante: Persona inexistente";
        //            errAux.Severidad = 1;
        //        }
        //        else if (ex.Message.Contains("Apoderado:"))
        //        {
        //            Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
        //            errAux.Codigo = "1701";
        //            errAux.Descripcion = "Apoderado: Persona inexistente";
        //            errAux.Severidad = 1;

        //        }
        //        else
        //        {
        //            ApplicationFramework.Utils.HandleException(ex, contexto);
        //            throw;
        //        }
        //    }
        //    finally
        //    {
        //        ApplicationFramework.Utils.LogFinally(MethodBase.GetCurrentMethod(), contexto);
        //    }
        //    return result;

        //    /*
        //    //Contexto contexto = MapContextoWsToContexto(paramObtTienePoder.CtxWS);
        //    Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtTienePoder.UsuarioActual);
        //    using (new Tracer(new object[] { paramObtTienePoder }, contexto))
        //    {
        //        using (ISistemaPoderes sistema = new SistemaPoderes())
        //        {
        //            //El Resultado es String(1), S/N
        //            List<DCApoderado> lstDcApoderado = sistema.ObtApoderados(paramObtTienePoder.PersIdentificadorPoderDante,
        //                                                                     paramObtTienePoder.PersIdentificadorApoderado,
        //                                                                     paramObtTienePoder.CodGrupo,
        //                                                                     contexto);

        //            ResultObtTienePoder retTienePoder = new ResultObtTienePoder();
        //            if (lstDcApoderado.Count == 0)
        //            {
        //                retTienePoder.Resultado = "N";
        //            }
        //            else
        //            {
        //                retTienePoder.Resultado = "S";
        //            }
        //            return retTienePoder;
        //        }
        //    }*/
        //}

        [AutoComplete()]
        public ResultObtTienePoder ObtTienePoder(ParamObtTienePoder paramObtTienePoder)
        {

            //Contexto contexto = MapContextoWsToContexto(paramObtTienePoder.CtxWS);
            Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtTienePoder.UsuarioActual);


            using (new Tracer(new object[] { paramObtTienePoder }, contexto))
            {
                ResultObtTienePoder result = new ResultObtTienePoder();
                using (SistemaPoderes sistema = new SistemaPoderes())
                {
                    result.Resultado = sistema.ObtTienePoder(paramObtTienePoder.PersIdentificadorPoderDante, paramObtTienePoder.PersIdentificadorApoderado,
                        paramObtTienePoder.CodGrupo, contexto);
                }

                return result;
            }
            /*
            //Contexto contexto = MapContextoWsToContexto(paramObtTienePoder.CtxWS);
            Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtTienePoder.UsuarioActual);
            using (new Tracer(new object[] { paramObtTienePoder }, contexto))
            {
                using (ISistemaPoderes sistema = new SistemaPoderes())
                {
                    //El Resultado es String(1), S/N
                    List<DCApoderado> lstDcApoderado = sistema.ObtApoderados(paramObtTienePoder.PersIdentificadorPoderDante,
                                                                             paramObtTienePoder.PersIdentificadorApoderado,
                                                                             paramObtTienePoder.CodGrupo,
                                                                             contexto);

                    ResultObtTienePoder retTienePoder = new ResultObtTienePoder();
                    if (lstDcApoderado.Count == 0)
                    {
                        retTienePoder.Resultado = "N";
                    }
                    else
                    {
                        retTienePoder.Resultado = "S";
                    }
                    return retTienePoder;
                }
            }*/
        }

        [AutoComplete()]
        public ResultObtHabilitacionCobro ObtHabilitacionCobro(ParamObtHabilitacionCobro paramObtHabilitacionCobro)
        {
            Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtHabilitacionCobro.UsuarioActual);
            ResultObtHabilitacionCobro resultObtHabilitacionCobro = new ResultObtHabilitacionCobro();
            Bull.ApplicationFramework.Services.ErrorNegocio err = null;
            try
            {
                using (new Tracer(new object[] { paramObtHabilitacionCobro }, contexto))
                {

                    //Llamar a fachada de persona para obterner los persId de la personas
                    DCPersona apoderado = new DCPersona();
                    DCPersona poderdante = new DCPersona();
                    using (ISistemaPoderes sistema = new SistemaPoderes())
                    {
                        if (paramObtHabilitacionCobro.Poderdante.CodPaisEmisor == int.MinValue || paramObtHabilitacionCobro.Poderdante.CodPaisEmisor <= 0 ||
                             string.IsNullOrEmpty(paramObtHabilitacionCobro.Poderdante.TipoDocumento) ||
                            string.IsNullOrEmpty(paramObtHabilitacionCobro.Poderdante.NroDocumento))
                        {
                            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                            err.Codigo = "1701";
                            err.Descripcion = "Poderdante: Persona inexistente";
                            err.Severidad = 1;
                            resultObtHabilitacionCobro.ColErrorNegocio.Add(err);
                        }

                        if (paramObtHabilitacionCobro.Apoderado.CodPaisEmisor == int.MinValue || paramObtHabilitacionCobro.Apoderado.CodPaisEmisor <= 0 ||
                             string.IsNullOrEmpty(paramObtHabilitacionCobro.Apoderado.TipoDocumento) ||
                            string.IsNullOrEmpty(paramObtHabilitacionCobro.Apoderado.NroDocumento))
                        {
                            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                            err.Codigo = "1701";
                            err.Descripcion = "Apoderado: Persona inexistente";
                            err.Severidad = 1;
                            resultObtHabilitacionCobro.ColErrorNegocio.Add(err);
                        }

                        //Llamada para el Apoderado
                        apoderado = sistema.ObtDatosPersonaPorDocumento(paramObtHabilitacionCobro.Apoderado.CodPaisEmisor,
                                                                        paramObtHabilitacionCobro.Apoderado.TipoDocumento,
                                                                        paramObtHabilitacionCobro.Apoderado.NroDocumento,
                                                                        contexto);
                        //Llamada para el PoderDante
                        poderdante = sistema.ObtDatosPersonaPorDocumento(paramObtHabilitacionCobro.Poderdante.CodPaisEmisor,
                                                                        paramObtHabilitacionCobro.Poderdante.TipoDocumento,
                                                                        paramObtHabilitacionCobro.Poderdante.NroDocumento,
                                                                        contexto);
                    }

                    //Cargo los errores en caso de que alguno de los doc NO exista
                    if (poderdante.PersIdentificador == int.MinValue)
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1701";
                        err.Descripcion = "Poderdante: Persona inexistente";
                        err.Severidad = 1;
                        resultObtHabilitacionCobro.ColErrorNegocio.Add(err);
                    }

                    if (apoderado.PersIdentificador == int.MinValue)
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1701";
                        err.Descripcion = "Apoderado: Persona inexistente";
                        err.Severidad = 1;
                        resultObtHabilitacionCobro.ColErrorNegocio.Add(err);
                    }


                    //Invocar al WS de poderes para los grupos 1, 2, 3, 4
                    if (resultObtHabilitacionCobro.ColErrorNegocio.Count == 0)
                    {
                        ContextoWS coWS = new ContextoWS();
                        ParamObtTienePoder param = new ParamObtTienePoder();
                        param.PersIdentificadorApoderado = apoderado.PersIdentificador;
                        param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
                        param.CodGrupo = 1;
                        param.UsuarioActual = paramObtHabilitacionCobro.UsuarioActual;


                        resultObtHabilitacionCobro.CobroMixto = this.ObtTienePoder(param).Resultado;

                        param = new ParamObtTienePoder();
                        param.PersIdentificadorApoderado = apoderado.PersIdentificador;
                        param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
                        param.CodGrupo = 2;
                        param.UsuarioActual = paramObtHabilitacionCobro.UsuarioActual;


                        resultObtHabilitacionCobro.CobroSoloApoderado = this.ObtTienePoder(param).Resultado;

                        param = new ParamObtTienePoder();
                        param.PersIdentificadorApoderado = apoderado.PersIdentificador;
                        param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
                        param.CodGrupo = 3;
                        param.UsuarioActual = paramObtHabilitacionCobro.UsuarioActual;

                        resultObtHabilitacionCobro.AutorizaCobroAFAM = this.ObtTienePoder(param).Resultado;

                        param = new ParamObtTienePoder();
                        param.PersIdentificadorApoderado = apoderado.PersIdentificador;
                        param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
                        param.CodGrupo = 4;
                        param.UsuarioActual = paramObtHabilitacionCobro.UsuarioActual;

                        resultObtHabilitacionCobro.ActuacionConjunta = this.ObtTienePoder(param).Resultado;

                        return resultObtHabilitacionCobro;
                    }
                    else
                        return resultObtHabilitacionCobro;
                }
            }
            catch (Exception ex)
            {

                //documento inactivo
                if (ex.Message.Contains("PER-2002"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Documento no activo en la base de datos";
                    errAux.Severidad = 1;
                    resultObtHabilitacionCobro.ColErrorNegocio.Add(errAux);
                }
                //persona inactiva (FECHA_BAJA <> null)
                else if (ex.Message.Contains("PER-2003"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Persona no activa en la base de datos";
                    errAux.Severidad = 1;
                    resultObtHabilitacionCobro.ColErrorNegocio.Add(errAux);
                }
                else if (ex.Message.Contains("Persona inexistente"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Persona inexistente";
                    errAux.Severidad = 1;
                    resultObtHabilitacionCobro.ColErrorNegocio.Add(errAux);
                }
                else
                {
                    ApplicationFramework.Utils.HandleException(ex, contexto);
                    throw;
                }


            }
            finally
            {
                ApplicationFramework.Utils.LogFinally(MethodBase.GetCurrentMethod(), contexto);
            }
            return resultObtHabilitacionCobro;
        }

        [AutoComplete()]
        public ResultObtHabilitacionCobroSinApo ObtHabilitacionCobroSinApo(ParamObtHabilitacionCobroSinApo paramObtHabilitacionCobroSinApo)
        {
            //            Contexto contexto = new Contexto(paramObtHabilitacionCobroSinApo.CtxWS.UsuarioActual, DateTime.Now, 0);
            Contexto contexto = Bull.ApplicationFramework.Services.ContextoServicio.ObtenerContextoSeguridad(paramObtHabilitacionCobroSinApo.UsuarioActual);
            ResultObtHabilitacionCobroSinApo result = new ResultObtHabilitacionCobroSinApo();
            try
            {

                using (new Tracer(new object[] { paramObtHabilitacionCobroSinApo }, contexto))
                {



                    //Llamar a fachada de persona para obterner los persId de la personas
                    DCPersona poderdante = new DCPersona();
                    using (ISistemaPoderes sistema = new SistemaPoderes())
                    {
                        //Llamada para el PoderDante
                        poderdante = sistema.ObtDatosPersonaPorDocumento(paramObtHabilitacionCobroSinApo.Poderdante.CodPaisEmisor,
                                                                        paramObtHabilitacionCobroSinApo.Poderdante.TipoDocumento,
                                                                        paramObtHabilitacionCobroSinApo.Poderdante.NroDocumento,
                                                                        contexto);
                    }

                    //Cargo los errores en caso de que alguno de los doc NO exista
                    Bull.ApplicationFramework.Services.ErrorNegocio err = null;
                    if (poderdante.PersIdentificador == int.MinValue)
                    {
                        err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        err.Codigo = "1701";
                        err.Descripcion = "Poderdante: Persona inexistente";
                        err.Severidad = 1;
                        result.ColErrorNegocio.Add(err);
                    }

                    //Invocar al WS de poderes para los grupos 1, 2, 3
                    if (result.ColErrorNegocio.Count == 0)
                    {
                        ContextoWS coWS = new ContextoWS();
                        ParamObtTienePoder param = new ParamObtTienePoder();
                        param.PersIdentificadorApoderado = null;
                        param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
                        param.CodGrupo = 2;
                        param.UsuarioActual = paramObtHabilitacionCobroSinApo.UsuarioActual;
                        //param.CtxWS = paramObtHabilitacionCobroSinApo.CtxWS;
                        result.CobroSoloApoderado = this.ObtTienePoder(param).Resultado;
                        return result;
                    }
                    else
                        return result;
                }
            }
            catch (Exception ex)
            {

                //documento inactivo
                if (ex.Message.Contains("PER-2002"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Documento no activo en la base de datos";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                //persona inactiva (FECHA_BAJA <> null)
                else if (ex.Message.Contains("PER-2003"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Persona no activa en la base de datos";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                else if (ex.Message.Contains("Persona inexistente"))
                {
                    Bull.ApplicationFramework.Services.ErrorNegocio errAux = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    errAux.Codigo = "1701";
                    errAux.Descripcion = "Persona inexistente";
                    errAux.Severidad = 1;
                    result.ColErrorNegocio.Add(errAux);
                }
                else
                {
                    ApplicationFramework.Utils.HandleException(ex, contexto);
                    throw;
                }


            }
            finally
            {
                ApplicationFramework.Utils.LogFinally(MethodBase.GetCurrentMethod(), contexto);
            }
            return result;
        }
        #endregion

        /*
        [AutoComplete]
        public ResultObtListaPoderes ObtListaPoderes(ParamObtListaPoderes paramObtListaPoderes)
        {
            
            Contexto contexto = MapContextoWsToContexto(paramObtListaPoderes.ContextoWS);

            ResultObtListaPoderes result = new ResultObtListaPoderes();
            result.ColErrorNegocio = new List<ApplicationFramework.Services.ErrorNegocio>();
            //Crear los objetos personas para opoderado y poderdante
            //Valilos datos de entrada del WS.

            Bull.ApplicationFramework.Services.ErrorNegocio err = null;
            DCPersona apoderado;
            DCPersona poderdante;

            using (ISistemaPoderes sistema = new SistemaPoderes())
            {
                //Validacion del PersIdApoderado
                apoderado = sistema.ObtDatosPersonaPorPersID(paramObtListaPoderes.PersIdApoderado, contexto);
                //Validacion del PersIDPoderdante
                poderdante = sistema.ObtDatosPersonaPorPersID(paramObtListaPoderes.PersIdPoderdante, contexto);
            }

            //Cargo los errores en caso de que alguno de los doc NO exista
            if (poderdante.PersIdentificador == int.MinValue)
            {
                err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                err.Codigo = "1701";
                err.Descripcion = "Poderdante: Persona inexistente";
                err.Severidad = 1;
                result.ColErrorNegocio.Add(err);
            }

            if (apoderado.PersIdentificador == int.MinValue)
            {
                err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                err.Codigo = "1701";
                err.Descripcion = "Apoderado: Persona inexistente";
                err.Severidad = 1;
                result.ColErrorNegocio.Add(err);
            }

            if (!((paramObtListaPoderes.TipoFacultades == 1) || (paramObtListaPoderes.TipoFacultades == 2) ||
                    (paramObtListaPoderes.TipoFacultades == 3) || (paramObtListaPoderes.TipoFacultades == 4)))
            {
                err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                err.Codigo = "1702";
                err.Descripcion = "EL valor del parametro tipoFacultades puede ser 1(Cobro), 2(Tramite), 3(Prestamo), 4(Todos) .";
                err.Severidad = 1;
                result.ColErrorNegocio.Add(err);
            }

            if (!(paramObtListaPoderes.CobroAFAM.Equals("S") || paramObtListaPoderes.CobroAFAM.Equals("N")))
            {
                err = new Bull.ApplicationFramework.Services.ErrorNegocio();
                err.Codigo = "1703";
                err.Descripcion = "EL valor del parámetro cobroAFAM no puede ser nulo y debe ser S o N.";
                err.Severidad = 1;
                result.ColErrorNegocio.Add(err);
            }

            if (result.ColErrorNegocio.Count == 0)
            {
                using (SistemaPoderes sistema = new SistemaPoderes())
                {
                    result.ColPoderes = sistema.ObtListaPoderes(paramObtListaPoderes.CobroAFAM, paramObtListaPoderes.TipoFacultades, paramObtListaPoderes.PersIdApoderado, paramObtListaPoderes.PersIdPoderdante, contexto);
                }
            }


            return result;
        }*/

        #region ObtenerApoderadosYPoderantes

        /// <summary>
        /// Autor: Martin Rodriguez
        /// Fecha: 25/03/2014
        /// Desc.: Funcion que obtiene los Apoderados y Poderdantes de una persona.
        /// RFC 844
        /// </summary>
        [AutoComplete]
        public ResultObtenerApoderadosYPoderdantes ObtenerApoderadosYPoderdantes(ParamObtenerApoderadosYPoderdantes param)
        {
            //Armo el contexto 
            Bull.ApplicationFramework.Services.ContextoServicio cs = new Bull.ApplicationFramework.Services.ContextoServicio(param.UsuarioActual);
            Contexto co = new Contexto(cs.UsuarioActual, cs.FechaActual, cs.Debug);

            try
            {
                using (new Tracer(new object[] { param }, co))
                {
                    //Variables locales
                    ResultObtenerApoderadosYPoderdantes retorno = null;

                    using (ISistemaPoderes sPoderes = new SistemaPoderes())
                    {
                        //Valido y obtengo los datos de los Apoderados y Poderdantes
                        retorno = sPoderes.ObtenerApoderadosYPoderdantes(param, co);
                    }

                    return retorno;
                }
            }
            catch (Exception ex)
            {
                ApplicationFramework.Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                ApplicationFramework.Utils.LogFinally(MethodBase.GetCurrentMethod(), co);
            }
        }

        #endregion
    }
}


