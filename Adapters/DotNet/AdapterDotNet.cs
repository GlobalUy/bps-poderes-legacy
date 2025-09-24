// ===============================================================================
// Disclaimer: this class was created by DOMPRES\fmacri on 03/09/2019 10:55:12 AM
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================

using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Legacy;
using Bull.Comunes.BusinessLogic;
using System.Collections.Generic;

using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Poderes.Facades.wsFuncionario;
using System.Reflection;
using System.Linq;
using Bull.PRES.Poderes.BusinessEntities;
using Bull.PRES.Poderes.Facades;

namespace Bull.PRES.Poderes.Adapters
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [EventTrackingEnabled(true)]
    [Guid("88914730-864e-4767-ad1b-ed8e0bc1213d"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class AdapterDotNet : BusinessLogicAbstract
    {
        [AutoComplete()]
        public object ObtFuncionarioNuevo(string documento, string tipoDoc, string codPaisEmisor, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, FECHAOPERA, vDebug);
            using (new Tracer(new object[] { documento, tipoDoc, codPaisEmisor, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                    string _nroDocumento = VB60Utils.ConvertToNetValue<string>(documento, "documento");
                    string _TipoDoc = VB60Utils.ConvertToNetValue<string>(tipoDoc, "tipoDoc");
                    string _codPaisEmisor = VB60Utils.ConvertToNetValue<string>(codPaisEmisor, "codPaisEmisor");

                    _nroDocumento = _nroDocumento.Replace("-", "");
                    _nroDocumento = _nroDocumento.Replace(".", "");

                    ResultObtenerFuncionarios resultFuncionarios = new ResultObtenerFuncionarios();
                    object retorno = Utils.CreateCom(new object[] { "FUNCIONARIOS", "ERRORES" });

                    object comFuncionarios;
                    object comErrores;
                    using (Facades.SistemaPoderes sistemaPoderes = new Facades.SistemaPoderes())
                    {
                        resultFuncionarios = sistemaPoderes.ObtFuncionario(_nroDocumento, _TipoDoc, _codPaisEmisor, co);
                    }

                    comErrores = null;
                    comFuncionarios = null;

                    if (resultFuncionarios.Errores != null && resultFuncionarios.Errores.Count > 0)
                    {
                        comErrores = Utils.GetComFromList<Bull.PRES.Poderes.Facades.wsFuncionario.ErroresNegocio>(resultFuncionarios.Errores);
                    }

                    if (resultFuncionarios.Funcionarios != null && resultFuncionarios.Funcionarios.Count > 0)
                    {
                        comFuncionarios = Utils.GetComFromList<Bull.PRES.Poderes.Facades.wsFuncionario.IdentificadorFuncionario>(resultFuncionarios.Funcionarios);

                        List<Facades.wsFuncionario.Documento> listaDocAux = new List<Bull.PRES.Poderes.Facades.wsFuncionario.Documento>();
                        listaDocAux.Add(resultFuncionarios.Funcionarios[0].Documento);

                        List<Facades.wsFuncionario.Funcionario> listaFuncAux = new List<Bull.PRES.Poderes.Facades.wsFuncionario.Funcionario>();
                        listaFuncAux.Add(resultFuncionarios.Funcionarios[0].Funcionario);

                        Utils.SetValue("DOCUMENTO", ref comFuncionarios, Utils.GetComFromList<Bull.PRES.Poderes.Facades.wsFuncionario.Documento>(listaDocAux));
                        Utils.SetValue("FUNCIONARIO", ref comFuncionarios, Utils.GetComFromList<Bull.PRES.Poderes.Facades.wsFuncionario.Funcionario>(listaFuncAux));
                    }

                    Utils.SetValue("FUNCIONARIOS", ref retorno, comFuncionarios);
                    Utils.SetValue("ERRORES", ref retorno, comErrores);

                    return retorno;
                }

                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                {
                    Bull.ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
                }
            }
        }

        [AutoComplete()]
        public object ObtFuncionario(string documento, string tipoDoc, string codPaisEmisor, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, FECHAOPERA, vDebug);
            using (new Tracer(new object[] { documento, tipoDoc, codPaisEmisor, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                    string _nroDocumento = VB60Utils.ConvertToNetValue<string>(documento, "documento");
                    string _TipoDoc = VB60Utils.ConvertToNetValue<string>(tipoDoc, "tipoDoc");
                    string _codPaisEmisor = VB60Utils.ConvertToNetValue<string>(codPaisEmisor, "codPaisEmisor");

                    _nroDocumento = _nroDocumento.Replace("-", "");
                    _nroDocumento = _nroDocumento.Replace(".", "");

                    ResultObtenerFuncionarios resultFuncionarios = new ResultObtenerFuncionarios();

                    using (Facades.SistemaPoderes sistemaPoderes = new Facades.SistemaPoderes())
                    {
                        resultFuncionarios = sistemaPoderes.ObtFuncionario(_nroDocumento, _TipoDoc, _codPaisEmisor, co);
                    }

                    object retorno = Utils.CreateCom(new object[] { "FUNIDNRO", "UNIESTID2", "FUNNOM1", "FUNNOM2", "FUNAPE1", "FUNAPE2", "FUNDOCID", "RELFUNID", "FUNBAJFCH", "FUNSTSESTA" });

                    if (resultFuncionarios.Funcionarios != null && resultFuncionarios.Funcionarios.Count != 0)
                    {
                        Bull.PRES.Poderes.Facades.wsFuncionario.Funcionario funcionario = new Bull.PRES.Poderes.Facades.wsFuncionario.Funcionario();
                        funcionario = resultFuncionarios.Funcionarios.First().Funcionario;

                        Utils.SetValue("FUNIDNRO", ref retorno, funcionario.NroFuncionario);
                        Utils.SetValue("UNIESTID2", ref retorno, funcionario.CodUnidad);
                        Utils.SetValue("FUNNOM1", ref retorno, funcionario.Nombre1);
                        Utils.SetValue("FUNNOM2", ref retorno, funcionario.Nombre2);
                        Utils.SetValue("FUNAPE1", ref retorno, funcionario.Apellido1);
                        Utils.SetValue("FUNAPE2", ref retorno, funcionario.Apellido2);
                        Utils.SetValue("FUNDOCID", ref retorno, funcionario.NroDocumento != null ? funcionario.NroDocumento.Insert((funcionario.NroDocumento.Length - 1), "-") : null); // Se le agrega guion al documento para que conserve la misma estrucutra de datos que el mantfuncio
                        Utils.SetValue("RELFUNID", ref retorno, funcionario.CodRelacionFuncional);
                        Utils.SetValue("FUNBAJFCH", ref retorno, funcionario.FechaEgreso);
                        Utils.SetValue("FUNSTSESTA", ref retorno, funcionario.Estado.Substring(0, 1)); // Devuelvo solo la primera letra del estado, asi queda igual a la estructura de datos de la mantfuncio
                    }

                    return retorno;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                {
                    Utils.LogFinally(MethodBase.GetCurrentMethod(), co);
                }


            }
        }


        [AutoComplete]
        public void AgrRprApoderadosOrigen(int vdblSecApoderados, DateTime vdtmFechaVigDesde, string vstrCodOrigenPoder, [DefaultParameterValue("")] [Optional] object UACT, [DefaultParameterValue("")] [Optional] object FECHAOPERA, [DefaultParameterValue("")] [Optional] object UANT, [DefaultParameterValue("")] [Optional] object FANT, [DefaultParameterValue(0)] [Optional] object vDebug)
        {
            Contexto co = new Contexto(UACT, FECHAOPERA, vDebug);
            try
            {
                using (new Tracer(new object[] { vdblSecApoderados, vdtmFechaVigDesde, vstrCodOrigenPoder, UACT, FECHAOPERA, UANT, FANT, vDebug }, co))
                {
                    #region sist
                    co.CodAgencia = 300000;
                    co.CodAgenciaSpecified = true;
                    co.Sistema = 368;
                    co.SistemaSpecified = true;
                    co.SubSistema = 285;
                    co.SubSistemaSpecified = true;
                    #endregion
                    int secApoderados = Convert.ToInt32(vdblSecApoderados);
                    DateTime fechaVigDesde = Convert.ToDateTime(vdtmFechaVigDesde);
                    string codOrigenPoder = Convert.ToString(vstrCodOrigenPoder);

                    using (SistemaPoderes sist = new SistemaPoderes())
                    {
                        sist.AgrRprApoderadosOrigen(secApoderados, fechaVigDesde, codOrigenPoder, co);
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
        public object ObtConfigIngresoPoderes(object codPoder, object codFacultad, string codOrigenPoder, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, FECHAOPERA, vDebug);

            using (new Tracer(new object[] { codPoder, codFacultad, codOrigenPoder, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                    List<ConfigIngresoPoder> listConfigIngPoderes = new List<ConfigIngresoPoder>();

                    using (SistemaPoderes facade = new SistemaPoderes())
                    {
                        listConfigIngPoderes = facade.ObtConfigIngresoPoderes(Convert.ToInt32(codPoder), Convert.ToInt32(codFacultad), codOrigenPoder, co);

                    }

                    //Creo la com de CONFIG.
                    object[] header = { "COD_PODER", "COD_FACULTAD", "FECHA_VIG_DESDE", "COD_ORIGEN_PODER", "PLAZO", "UNIDAD_PLAZO", "PODER_INCOMP", "FACULTAD_INCOMP", "PER_COMPATIBLE", "UNIDAD_PER_COMPATIBLE" };
                    object comVincProv = Utils.CreateCom(header, listConfigIngPoderes.Count);

                    if (listConfigIngPoderes.Count > 0)
                    {
                        for (int i = 0; i < listConfigIngPoderes.Count; i++)
                        {
                            Utils.SetValue("COD_PODER", ref comVincProv, listConfigIngPoderes[i].CodPoder, i);
                            Utils.SetValue("COD_FACULTAD", ref comVincProv, listConfigIngPoderes[i].CodFacultad, i);
                            Utils.SetValue("FECHA_VIG_DESDE", ref comVincProv, listConfigIngPoderes[i].FechaVigDesde, i);
                            Utils.SetValue("COD_ORIGEN_PODER", ref comVincProv, listConfigIngPoderes[i].CodOrigenPoder, i);
                            Utils.SetValue("PLAZO", ref comVincProv, listConfigIngPoderes[i].Plazo, i);
                            Utils.SetValue("UNIDAD_PLAZO", ref comVincProv, listConfigIngPoderes[i].UnidadPlazo, i);
                            Utils.SetValue("PODER_INCOMP", ref comVincProv, listConfigIngPoderes[i].PoderIncomp, i);
                            Utils.SetValue("FACULTAD_INCOMP", ref comVincProv, listConfigIngPoderes[i].FacultadIncomp, i);
                            Utils.SetValue("PER_COMPATIBLE", ref comVincProv, listConfigIngPoderes[i].PerCompatible, i);
                            Utils.SetValue("UNIDAD_PER_COMPATIBLE", ref comVincProv, listConfigIngPoderes[i].UnidadPerCompatible, i);
                        }
                    }
                    return comVincProv;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                { Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co); }
            }
        }

        // 2134 -RFC control cantidad de poderes.
        #region RFC 2134 - Control cantidad de poderes externos
        [AutoComplete]
        public object ValidarCantPoderesExt(object codFacultad, object codPoder, string estado, string origen, object persIdApoderado, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, DateTime.Now, vDebug);
            using (new Tracer(new object[] { codFacultad, codPoder,estado, origen, persIdApoderado, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                   
                    List<ResultPoderPersonaControlCant> listPoderesExt = new List<ResultPoderPersonaControlCant>();
                    int _codFacultad = Convert.ToInt32(codFacultad);
                    int _codPoder = Convert.ToInt32(codPoder);
                    int _persIdApoderado = Convert.ToInt32(persIdApoderado);

                   
                    using (SistemaPoderes facade = new SistemaPoderes())
                    {
                        listPoderesExt = facade.ValidarCantPoderesExt(_codFacultad, _codPoder, estado, origen, _persIdApoderado, co);
                    }

                    object[] header = { "CODIGO", "DESCRIPCION"};
                    object comRetorno = Utils.CreateCom(header, listPoderesExt.Count);


                    if (listPoderesExt.Count > 0)
                    {

                        if (listPoderesExt[0].ErroresNegocio != null)
                        {
                            Utils.SetValue("CODIGO", ref comRetorno, listPoderesExt[0].ErroresNegocio[0].codigo, 0);
                            Utils.SetValue("DESCRIPCION", ref comRetorno, listPoderesExt[0].ErroresNegocio[0].descripcion, 0);
                        }
                    }
                    else
                    {
                        Utils.SetValue("CODIGO", ref comRetorno,null, 0);
                        Utils.SetValue("DESCRIPCION", ref comRetorno, null, 0);
                    }
                    return comRetorno;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                { Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co); }
            }
        }



        [AutoComplete]
        public object ValidarCantPoderesExtModif(object codFacultad, object codPoder, string estado, string origen, object persIdApoderado, object codFacultadAnt, object codPoderAnt, string estadoAnt, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, DateTime.Now, vDebug);
            using (new Tracer(new object[] { codFacultad, codPoder, estado, origen, persIdApoderado, codFacultadAnt, codPoderAnt, estadoAnt, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                    List<ResultPoderPersonaControlCant> listPoderesExt = new List<ResultPoderPersonaControlCant>();
                    int _codFacultad = Convert.ToInt32(codFacultad);
                    int _codPoder = Convert.ToInt32(codPoder);
                    int _persIdApoderado = Convert.ToInt32(persIdApoderado);

                    int _codFacultadAnt = Convert.ToInt32(codFacultadAnt);
                    int _codPoderAnt = Convert.ToInt32(codPoderAnt);



                    using (SistemaPoderes facade = new SistemaPoderes())
                    {
                        listPoderesExt = facade.ValidarCantPoderesExtModif(_codFacultad, _codPoder, estado, origen, _persIdApoderado, _codFacultadAnt, _codPoderAnt, estadoAnt, co);
                    }

                    object[] header = { "CODIGO", "DESCRIPCION" };
                    object comRetorno = Utils.CreateCom(header, listPoderesExt.Count);


                    if (listPoderesExt.Count > 0)
                    {
                        if (listPoderesExt[0].ErroresNegocio != null )
                        {
                            Utils.SetValue("CODIGO", ref comRetorno, listPoderesExt[0].ErroresNegocio[0].codigo, 0);
                            Utils.SetValue("DESCRIPCION", ref comRetorno, listPoderesExt[0].ErroresNegocio[0].descripcion, 0);
                        }
                    }
                    else
                    {
                        Utils.SetValue("CODIGO", ref comRetorno, null, 0);
                        Utils.SetValue("DESCRIPCION", ref comRetorno, null, 0);
                    }

                    return comRetorno;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                { Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co); }
            }
        }
        #endregion

        #region RFC 151517 cambio en poderes (maximo para poderes especiales)
        [AutoComplete]
        public object ValidarCantPoderesEspeciales(object secApoderado, object codFacultad, object codPoder, string estado, object codVinculo, object persIdApoderado, object esModifiacion, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, DateTime.Now, vDebug);
            using (new Tracer(new object[] { secApoderado, codFacultad, codPoder, estado, codVinculo, persIdApoderado, esModifiacion, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                    List<ResultPoderPersonaControlCant> listaPoderesEspeciales = new List<ResultPoderPersonaControlCant>();
                    string _secApoderado = String.IsNullOrEmpty(secApoderado.ToString()) ? string.Empty : secApoderado.ToString();
                    int _codFacultad = Convert.ToInt32(codFacultad);
                    int _codPoder = Convert.ToInt32(codPoder);
                    int _codVinculo = Convert.ToInt32(codVinculo);
                    int _persIdApoderado = Convert.ToInt32(persIdApoderado);
                    bool _esModificacion = Convert.ToBoolean(esModifiacion);

                    using (SistemaPoderes facade = new SistemaPoderes())
                    {
                        listaPoderesEspeciales = facade.ValidarCantPoderesEspeciales(_secApoderado, _codPoder, _codFacultad, estado, _esModificacion, _codVinculo, _persIdApoderado, co);
                    }

                    object[] header = { "CODIGO", "DESCRIPCION" };
                    object comRetorno = Utils.CreateCom(header, listaPoderesEspeciales.Count);

                    if (listaPoderesEspeciales.Count > 0)
                    {
                        if (listaPoderesEspeciales[0].ErroresNegocio != null)
                        {
                            Utils.SetValue("CODIGO", ref comRetorno, listaPoderesEspeciales[0].ErroresNegocio[0].codigo, 0);
                            Utils.SetValue("DESCRIPCION", ref comRetorno, listaPoderesEspeciales[0].ErroresNegocio[0].descripcion, 0);
                        }
                    }
                    else
                    {
                        Utils.SetValue("CODIGO", ref comRetorno, null, 0);
                        Utils.SetValue("DESCRIPCION", ref comRetorno, null, 0);
                    }
                    return comRetorno;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                { Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co); }
            }
        }
        #endregion

        [AutoComplete]
        public object ObtOrigenesPoderes(string codOrigenPoder, object UACT, object FECHAOPERA, object vDebug)
        {
            Contexto co = new Contexto(UACT, FECHAOPERA, vDebug);

            using (new Tracer(new object[] { codOrigenPoder, UACT, FECHAOPERA, vDebug }, co))
            {
                try
                {
                    List<OrigenPoder> listOrigenPoder = new List<OrigenPoder>();

                    using (SistemaPoderes facade = new SistemaPoderes())
                    {
                        listOrigenPoder = facade.ObtOrigenesPoderes(codOrigenPoder, co);

                    }

                    //Creo la com de CONFIG.
                    object[] header = { "COD_ORIGEN_PODER", "DESCRIPCION" };
                    object comVincProv = Utils.CreateCom(header, listOrigenPoder.Count);

                    if (listOrigenPoder.Count > 0)
                    {
                        for (int i = 0; i < listOrigenPoder.Count; i++)
                        {
                            Utils.SetValue("COD_ORIGEN_PODER", ref comVincProv, listOrigenPoder[i].CodOrigenPoder, i);
                            Utils.SetValue("DESCRIPCION", ref comVincProv, listOrigenPoder[i].Descripcion, i);
                        }
                    }
                    return comVincProv;
                }
                catch (Exception ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
                finally
                { Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co); }
            }
        }
    }
}
