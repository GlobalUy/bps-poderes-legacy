// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 11/08/2008 06:16:07 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.0.19
//
// ==============================================================================
#region Declaraciones Using
using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;
using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;
using Bull.PRES.Poderes.BusinessEntities;
using Bull.PRES.Poderes.BusinessLogic;
using System.Collections.Generic;
using Bull.ApplicationFramework;
using Bull.PRES.Poderes.ServiceAgents;
using System.ServiceModel;
using wsFuncionarioEntity = Bull.PRES.Poderes.BusinessEntities.wsFuncionario;
using wsFuncionarioFacade = Bull.PRES.Poderes.Facades.wsFuncionario;
#endregion

namespace Bull.PRES.Poderes.Facades
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true), JustInTimeActivation(true)]
    [Guid("3135c1ba-4278-48ad-982d-d2618ba9e4a9"), ClassInterface(ClassInterfaceType.AutoDual)]
    [ServiceBehavior(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class SistemaPoderes : FacadeAbstract, ISistemaPoderes
    {

        #region ObtTienePoder
        public string ObtTienePoder(int persIdentificadorPoderdante, int? persIdentificadorApoderado, int codGrupo, Contexto co)
        {
            using (new Tracer(new object[] { persIdentificadorPoderdante, persIdentificadorApoderado, codGrupo }, co))
            {
                try
                {
                    using (ISistemaPoderes sistema = new SistemaPoderes())
                    {
                        //El Resultado es String(1), S/N
                        List<DCApoderado> lstDcApoderado = ObtApoderados(persIdentificadorPoderdante, persIdentificadorApoderado, codGrupo, co);

                        string result = null;

                        if (lstDcApoderado.Count == 0)
                        {
                            result = "N";
                        }
                        else
                        {
                            result = "S";
                        }

                        return result;
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
        }

        #endregion

        #region ObtApoderados
        [AutoComplete]
        public List<DCApoderado> ObtApoderados(int persIdPoderdante, int? persIdApoderado, int codGrupo, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdApoderado, codGrupo }, co))
            {
                try
                {
                    //Retorno AdmPoderes.ObtApoderados(PersID1, PersID2) 
                    using (AdmPoderes admPoderes = new AdmPoderes())
                    {
                        List<Apoderado> lstApo = new List<Apoderado>();

                        lstApo = admPoderes.ObtApoderados(persIdPoderdante, persIdApoderado, codGrupo, co);

                        List<DCApoderado> lstDCApo = new List<DCApoderado>();

                        foreach (Apoderado apo in lstApo)
                        {
                            DCApoderado dcApo = new DCApoderado();
                            dcApo.Afam = apo.Afam;
                            dcApo.CodFacultad = apo.CodFacultad;
                            dcApo.DescFacultad = apo.DescFacultad;
                            dcApo.DescTipo = apo.DescTipo;
                            dcApo.Instituto = apo.Instituto;
                            dcApo.Persona.PersIdentificador = apo.Persona.PersIdentificador;
                            dcApo.PoderDante.PersIdentificador = apo.PoderDante.PersIdentificador;
                            dcApo.Tipo = apo.Tipo;

                            lstDCApo.Add(dcApo);
                        }

                        return lstDCApo;
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
        }
        #endregion


        #region ObtDatosPersonaPorDocumento
        public DCPersona ObtDatosPersonaPorDocumento(int codPaisEmisor, string codTipoDocumento, string nroDocumento, Contexto co)
        {
            using (new Tracer(new object[] { codPaisEmisor, codTipoDocumento, nroDocumento }, co))
            {
                DCPersona per = new DCPersona();
                using (SAPoderes saPoderes = new SAPoderes())
                {
                    Persona perAux = saPoderes.ObtenerPersonaPorDocumento(codPaisEmisor, codTipoDocumento, nroDocumento, co);

                    per.PersIdentificador = perAux.PersIdentificador;

                    return per;
                }
            }
        }


        #endregion

        #region ObtDatosPersonaPorPersID
        public DCPersona ObtDatosPersonaPorPersID(int persId, Contexto co)
        {
            using (new Tracer(new object[] { persId }, co))
            {
                using (new Tracer(new object[] { persId }, co))
                {
                    DCPersona per = new DCPersona();
                    using (SAPoderes saPoderes = new SAPoderes())
                    {
                        Persona perAux = saPoderes.ObtDatosPersonaPorPersID(persId, co);

                        per.PersIdentificador = perAux.PersIdentificador;

                        return per;
                    }
                }
            }
        }
        #endregion


        /*
        #region ObtApoderados
        [AutoComplete]
        public List<DCApoderado> ObtApoderados(int? persIdPoderdante, int persIdApoderado, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdApoderado}, co))
            {
                try 
                {
                    //Retorno AdmPoderes.ObtApoderados(PersID1, PersID2) 
                    using (AdmPoderes admPoderes = new AdmPoderes ())
                    {
                        List<Apoderado> lstApo = new List<Apoderado>();

                        lstApo = admPoderes.ObtApoderados( persIdPoderdante, persIdApoderado, co);
                        
                        List<DCApoderado> lstDCApo = new List<DCApoderado>();
                        
                        foreach(Apoderado apo in lstApo)
                        {
                            DCApoderado dcApo = new DCApoderado();
                            dcApo.Afam = apo.Afam;
                            dcApo.CodFacultad = apo.CodFacultad;
                            dcApo.DescFacultad = apo.DescFacultad;
                            dcApo.DescTipo = apo.DescTipo;
                            dcApo.Instituto = apo.Instituto;
                            dcApo.Persona.PersIdentificador = apo.Persona.PersIdentificador;
                            dcApo.PoderDante.PersIdentificador = apo.PoderDante.PersIdentificador;
                            dcApo.Tipo = apo.Tipo;

                            lstDCApo.Add( dcApo );
                        }

                        return lstDCApo;
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
        }
        #endregion 
        */
        #region ObtApoderadosAFAM
        public List<DCApoderado> ObtApoderadosAFAM(int persIdPoderdante, int? persIdApoderado, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdApoderado }, co))
            {
                try
                {
                    //Retorno AdmPoderes.ObtApoderadosAFAM(PersID1, PersID2) 
                    using (AdmPoderes admPoderes = new AdmPoderes())
                    {
                        List<Apoderado> lstApo = new List<Apoderado>();

                        lstApo = admPoderes.ObtApoderadosAFAM(persIdPoderdante, persIdApoderado, co);

                        List<DCApoderado> lstDCApo = new List<DCApoderado>();
                        foreach (Apoderado apo in lstApo)
                        {
                            DCApoderado dcApo = new DCApoderado();
                            dcApo.Afam = apo.Afam;
                            dcApo.CodFacultad = apo.CodFacultad;
                            dcApo.DescFacultad = apo.DescFacultad;
                            dcApo.DescTipo = apo.DescTipo;
                            dcApo.Instituto = apo.Instituto;
                            dcApo.Persona.PersIdentificador = apo.Persona.PersIdentificador;
                            dcApo.PoderDante.PersIdentificador = apo.PoderDante.PersIdentificador;
                            dcApo.Tipo = apo.Tipo;

                            lstDCApo.Add(dcApo);
                        }
                        return lstDCApo;
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
        }
        #endregion

        #region ObtApoderadosInst
        [AutoComplete]
        public List<DCApoderado> ObtApoderadosInst(int persIdPoderdante, int? persIdApoderado, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdApoderado }, co))
            {
                try
                {
                    //Retorno AdmPoderes.ObtApoderadosInst(PersID1, PersID2) 
                    using (AdmPoderes admPoderes = new AdmPoderes())
                    {
                        List<Apoderado> lstApo = new List<Apoderado>();

                        lstApo = admPoderes.ObtApoderadosInst(persIdPoderdante, persIdApoderado, co);

                        List<DCApoderado> lstDCApo = new List<DCApoderado>();
                        foreach (Apoderado apo in lstApo)
                        {
                            DCApoderado dcApo = new DCApoderado();
                            dcApo.Afam = apo.Afam;
                            dcApo.CodFacultad = apo.CodFacultad;
                            dcApo.DescFacultad = apo.DescFacultad;
                            dcApo.DescTipo = apo.DescTipo;
                            dcApo.Instituto = apo.Instituto;
                            dcApo.Persona.PersIdentificador = apo.Persona.PersIdentificador;
                            dcApo.PoderDante.PersIdentificador = apo.PoderDante.PersIdentificador;
                            dcApo.Tipo = apo.Tipo;

                            lstDCApo.Add(dcApo);
                        }
                        return lstDCApo;
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
        }
        #endregion

        #region ObtListaPoderes
        public List<DCResultConsPoder> ObtListaPoderes(string cobroAFAM, int tipoFacultades, int persIdApoderado, int persIdPoderdante, Contexto co)
        {
            using (new Tracer(new object[] { cobroAFAM, tipoFacultades, persIdApoderado, persIdPoderdante }, co))
            {
                using (AdmPoderes admPoderes = new AdmPoderes())
                {
                    List<ResultConsPoder> ret;

                    ret = admPoderes.ObtListaPoderes(cobroAFAM, tipoFacultades, persIdApoderado, persIdPoderdante, co);

                    List<DCResultConsPoder> lstDCResultConsPoder = new List<DCResultConsPoder>();

                    //Mapeo el retorno del dominio a entidades de fachada para los distintos tipos de poderes
                    foreach (ResultConsPoder paux in ret)
                    {
                        DCResultConsPoder p = new DCResultConsPoder();
                        p.CodPoder = paux.CodPoder;
                        p.DescTipoPoder = paux.DescTipoPoder;
                        p.CodFacultad = paux.CodFacultad;
                        p.DescFacultad = paux.DescFacultad;

                        lstDCResultConsPoder.Add(p);
                    }

                    return lstDCResultConsPoder;
                }
            }


        }

        [AutoComplete]
        public List<ResultPoderPersonaControlCant> ValidarCantPoderesExt(int codFacultad, int codPoder, string estado, string origen, int persIdApoderado, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, persIdApoderado, estado, origen, persIdApoderado }, co))
            {
                try
                {
                    using (AdmGestionPoderes adm = new AdmGestionPoderes())
                    {
                        GestionPoderes.ErrorNegocio en = new GestionPoderes.ErrorNegocio();
                        List<ResultPoderPersonaControlCant> PoderResult = new List<ResultPoderPersonaControlCant>();
                        List<PoderPersonaControlCant> ret = new List<PoderPersonaControlCant>();


                        ret = adm.ValidarCantPoderesExt(codFacultad, codPoder, estado, origen, persIdApoderado, co);

                        foreach (PoderPersonaControlCant podEntidad in ret)
                        {
                            ResultPoderPersonaControlCant p = new ResultPoderPersonaControlCant();
                            p.SecApoderados = podEntidad.SecApoderados;
                            p.FechaVigDesde = podEntidad.FechaVigDesde;
                            p.PersIdentificador_1 = podEntidad.PersIdentificador_1;
                            p.CodPoder = podEntidad.CodPoder;
                            p.Estado = podEntidad.Estado;
                            p.CodVinculo = podEntidad.CodVinculo;
                            p.CodFacultad = podEntidad.CodFacultad;
                            p.Comentarios = podEntidad.Comentarios;
                            p.FechaPerDesde = podEntidad.FechaPerDesde;
                            p.FechaPerHasta = podEntidad.FechaPerHasta;
                            p.FechaRenRev = podEntidad.FechaRenRev;
                            p.FechaVigHasta = podEntidad.FechaVigHasta;

                            if (podEntidad.ErroresNegocio != null && podEntidad.ErroresNegocio.Count > 0)
                            {
                                en.codigo = podEntidad.ErroresNegocio[0].Codigo;
                                en.descripcion = podEntidad.ErroresNegocio[0].Descripcion;
                                p.ErroresNegocio.Add(en);
                            }
                            else
                            { p.ErroresNegocio = null; }


                                PoderResult.Add(p);
                        }
                        return PoderResult;
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
        }

        public List<ResultPoderPersonaControlCant> ValidarCantPoderesExtModif(int codFacultad, int codPoder, string estado, string origen, int persIdApoderado, int codFacultadAnt, int codPoderAnt, string estadoAnt, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, persIdApoderado, estado, origen, persIdApoderado, codFacultadAnt, codFacultadAnt, codPoderAnt }, co))
            {
                try
                {
                    using (AdmGestionPoderes adm = new AdmGestionPoderes())
                    {
                        GestionPoderes.ErrorNegocio en = new GestionPoderes.ErrorNegocio();
                        List<ResultPoderPersonaControlCant> PoderResult = new List<ResultPoderPersonaControlCant>();
                        List<PoderPersonaControlCant> ret = new List<PoderPersonaControlCant>();


                        ret = adm.ValidarCantPoderesExtModif(codFacultad, codPoder, estado, origen, persIdApoderado, codFacultadAnt, codPoderAnt, estadoAnt, co);

                        foreach (PoderPersonaControlCant podEntidad in ret)
                        {
                            ResultPoderPersonaControlCant p = new ResultPoderPersonaControlCant();
                            p.SecApoderados = podEntidad.SecApoderados;
                            p.FechaVigDesde = podEntidad.FechaVigDesde;
                            p.PersIdentificador_1 = podEntidad.PersIdentificador_1;
                            p.CodPoder = podEntidad.CodPoder;
                            p.Estado = podEntidad.Estado;
                            p.CodVinculo = podEntidad.CodVinculo;
                            p.CodFacultad = podEntidad.CodFacultad;
                            p.Comentarios = podEntidad.Comentarios;
                            p.FechaPerDesde = podEntidad.FechaPerDesde;
                            p.FechaPerHasta = podEntidad.FechaPerHasta;
                            p.FechaRenRev = podEntidad.FechaRenRev;
                            p.FechaVigHasta = podEntidad.FechaVigHasta;

                            if (podEntidad.ErroresNegocio != null && podEntidad.ErroresNegocio.Count > 0)
                            {
                                en.codigo = podEntidad.ErroresNegocio[0].Codigo;
                                en.descripcion = podEntidad.ErroresNegocio[0].Descripcion;
                                p.ErroresNegocio.Add(en);
                            }
                            else 
                            { p.ErroresNegocio = null; }

                            
                            PoderResult.Add(p);
                        }
                        return PoderResult;
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
        }

        public List<ResultPoderPersonaControlCant> ValidarCantPoderesEspeciales(string secApoderado, int codPoder, int codFacultad, string estado, bool esModificacion, int codVinculo, int persIdApoderado, Contexto co)
        {
            using (new Tracer(new object[] { secApoderado, codPoder, codFacultad, estado, esModificacion, codVinculo, persIdApoderado }, co))
            {
                try
                {
                    using (AdmGestionPoderes adm = new AdmGestionPoderes())
                    {
                        GestionPoderes.ErrorNegocio en = new GestionPoderes.ErrorNegocio();
                        List<ResultPoderPersonaControlCant> PoderResult = new List<ResultPoderPersonaControlCant>();
                        List<PoderPersonaControlCant> ret = new List<PoderPersonaControlCant>();


                        ret = adm.ValidarCantPoderesEspeciales(secApoderado, codFacultad, codPoder, estado, codVinculo, persIdApoderado, esModificacion, co);

                        foreach (PoderPersonaControlCant podEntidad in ret)
                        {
                            ResultPoderPersonaControlCant p = new ResultPoderPersonaControlCant();
                            p.SecApoderados = podEntidad.SecApoderados;
                            p.FechaVigDesde = podEntidad.FechaVigDesde;
                            p.PersIdentificador_1 = podEntidad.PersIdentificador_1;
                            p.CodPoder = podEntidad.CodPoder;
                            p.Estado = podEntidad.Estado;
                            p.CodVinculo = podEntidad.CodVinculo;
                            p.CodFacultad = podEntidad.CodFacultad;
                            p.Comentarios = podEntidad.Comentarios;
                            p.FechaPerDesde = podEntidad.FechaPerDesde;
                            p.FechaPerHasta = podEntidad.FechaPerHasta;
                            p.FechaRenRev = podEntidad.FechaRenRev;
                            p.FechaVigHasta = podEntidad.FechaVigHasta;

                            if (podEntidad.ErroresNegocio != null && podEntidad.ErroresNegocio.Count > 0)
                            {
                                en.codigo = podEntidad.ErroresNegocio[0].Codigo;
                                en.descripcion = podEntidad.ErroresNegocio[0].Descripcion;
                                p.ErroresNegocio.Add(en);
                            }
                            else
                            { p.ErroresNegocio = null; }


                            PoderResult.Add(p);
                        }
                        return PoderResult;
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
        }
        #endregion



        #region ObtenerApoderadosYPoderantes

        /// <summary>
        /// Autor: Martin Rodriguez
        /// Fecha: 25/03/2014
        /// Desc.: Funcion que obtiene los Apoderados y Poderdantes de una persona.
        /// RFC 844
        /// </summary>
        [AutoComplete]
        public ResultObtenerApoderadosYPoderdantes ObtenerApoderadosYPoderdantes(ParamObtenerApoderadosYPoderdantes param, Contexto co)
        {
            using (Tracer tracer = new Tracer(new object[] { param }, co))
            {
                try
                {
                    using (BusinessLogic.AdmPoderes businessLogic = new BusinessLogic.AdmPoderes())
                    {
                        BusinessEntities.ResultObtenerApoderadosYPoderdantes retorno = businessLogic.AdmObtenerApoderadosYPoderdantes(param.PersIdentificador, param.RegitrosVigentes, param.IncluirDatosPersonas, co);

                        return ConvertToFacadeEntity(retorno, co);
                    }
                }
                catch (Exception ex)
                {
                    ApplicationFramework.Utils.HandleException(ex, co);
                    throw;
                }
                finally
                {
                    ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
                }
            }
        }

        [AutoComplete]
        private ResultObtenerApoderadosYPoderdantes ConvertToFacadeEntity(BusinessEntities.ResultObtenerApoderadosYPoderdantes result, Contexto co)
        {
            try
            {
                using (Tracer tracer = new Tracer(new object[] { result }, co))
                {
                    ResultObtenerApoderadosYPoderdantes retorno = new ResultObtenerApoderadosYPoderdantes();

                    if (result != null)
                    {
                        foreach (BusinessEntities.PoderPersona aPersona in result.ApoderadosPersona)
                        {
                            retorno.ApoderadosPersona.Add(ConvertToFacadeEntity(aPersona, co));
                        }

                        foreach (BusinessEntities.PoderPersona pPersona in result.PoderdantesPersona)
                        {
                            retorno.PoderdantesPersona.Add(ConvertToFacadeEntity(pPersona, co));
                        }

                        retorno.ErroresNegocio = new List<ErrorNegocio>(ConvertToFacadeEntity(result.ErroresNegocio, co));
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
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        [AutoComplete]
        private PoderPersona ConvertToFacadeEntity(BusinessEntities.PoderPersona result, Contexto co)
        {
            try
            {
                using (Tracer tracer = new Tracer(new object[] { result }, co))
                {
                    PoderPersona retorno = new PoderPersona();

                    if (result != null)
                    {
                        retorno.CodPoder = result.CodPoder;
                        retorno.DescPoder = result.DescPoder;
                        retorno.PersIdentificador = result.PersIdentificador_1;
                        retorno.FechaPerDesde = result.FechaPerDesde;
                        retorno.FechaPerHasta = result.FechaPerHasta;
                        retorno.Nombre1 = result.Nombre1;
                        retorno.Nombre2 = result.Nombre2;
                        retorno.Apellido1 = result.Apellido1;
                        retorno.Apellido2 = result.Apellido2;
                        retorno.CodFacultad = result.CodFacultad;
                        retorno.DescFacultad = result.DescFacultad;

                        if (!String.IsNullOrEmpty(result.NroDocumento))
                        {
                            retorno.Documento = new Documento();
                            retorno.Documento.PersIdentificador = result.PersIdentificador;
                            retorno.Documento.CodPaisEmisor = result.CodPaisEmisor;
                            retorno.Documento.CodTipoDocumento = result.CodTipoDocumento;
                            retorno.Documento.NroDocumento = result.NroDocumento;
                        }
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
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }


        [AutoComplete]
        private Documento ConvertToFacadeEntity(BusinessEntities.Documento documento, Contexto co)
        {
            try
            {
                using (Tracer tracer = new Tracer(new object[] { documento }, co))
                {
                    Documento retorno = null;

                    if (documento != null)
                    {
                        retorno = new Documento();
                        retorno.CodPaisEmisor = documento.CodPaisEmisor;
                        retorno.CodTipoDocumento = documento.CodTipoDocumento;
                        retorno.NroDocumento = documento.NroDocumento;
                        retorno.PersIdentificador = documento.PersIdentificador;
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
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        [AutoComplete]
        private Bull.PRES.Poderes.Facades.wsFuncionario.Documento ConvertToFacadeEntity(BusinessEntities.wsFuncionario.Documento documento, Contexto co)
        {
            try
            {
                using (Tracer tracer = new Tracer(new object[] { documento }, co))
                {
                    Bull.PRES.Poderes.Facades.wsFuncionario.Documento retorno = null;

                    if (documento != null)
                    {
                        retorno = new Bull.PRES.Poderes.Facades.wsFuncionario.Documento();
                        //retorno. = documento.CodPaisEmisor;
                        retorno.CodTipoDocumento = documento.CodTipoDocumento;
                        retorno.NroDocumento = documento.NroDocumento;
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
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        [AutoComplete]
        private wsFuncionarioFacade.ResultObtenerFuncionarios ConvertToFacadeEntity(wsFuncionarioEntity.ResultObtenerFuncionarios result, Contexto co)
        {
            try
            {
                using (Tracer tracer = new Tracer(new object[] { result }, co))
                {
                    Bull.PRES.Poderes.Facades.wsFuncionario.ResultObtenerFuncionarios retorno = new wsFuncionarioFacade.ResultObtenerFuncionarios();
                    wsFuncionarioFacade.ResultObtenerFuncionarios resultObtenerFuncionarios = new wsFuncionarioFacade.ResultObtenerFuncionarios();

                    if (result.Funcionarios != null)
                    {
                        resultObtenerFuncionarios.Funcionarios = new List<wsFuncionarioFacade.IdentificadorFuncionario>();
                        foreach (var funcionario in result.Funcionarios)
                        {
                            wsFuncionarioFacade.Funcionario funcionarioAux = new wsFuncionarioFacade.Funcionario();
                            wsFuncionarioFacade.IdentificadorFuncionario identificadorFuncionario = new wsFuncionarioFacade.IdentificadorFuncionario();
                            wsFuncionarioFacade.Documento doc = new wsFuncionarioFacade.Documento();

                            funcionarioAux.Antiguedad = funcionario.Funcionario.Antiguedad;
                            funcionarioAux.Apellido1 = funcionario.Funcionario.Apellido1;
                            funcionarioAux.Apellido2 = funcionario.Funcionario.Apellido2;
                            funcionarioAux.CargoCobro = funcionario.Funcionario.CargoCobro;
                            funcionarioAux.CargoProsupuestal = funcionario.Funcionario.CargoProsupuestal;
                            funcionarioAux.CodLugarFisico = funcionario.Funcionario.CodLugarFisico;
                            funcionarioAux.CodPaisEmisor = Convert.ToInt32(funcionario.Funcionario.CodPaisEmisor);
                            funcionarioAux.CodRelacionFuncional = funcionario.Funcionario.CodRelacionFuncional;
                            funcionarioAux.CodSexo = Convert.ToInt32(funcionario.Funcionario.CodSexo);
                            funcionarioAux.CodUnidad = funcionario.Funcionario.CodUnidad;
                            funcionarioAux.EMailExterno = funcionario.Funcionario.EMailExterno;
                            funcionarioAux.EscalafonCobro = funcionario.Funcionario.EscalafonCobro;
                            funcionarioAux.EscalafonPresupuestal = funcionario.Funcionario.EscalafonPresupuestal;
                            funcionarioAux.Estado = funcionario.Funcionario.Estado;
                            funcionarioAux.FechaEgreso = funcionario.Funcionario.FechaEgreso;
                            funcionarioAux.FechaIngreso = funcionario.Funcionario.FechaIngreso;
                            funcionarioAux.FechaNacimiento = funcionario.Funcionario.FechaNacimiento;
                            funcionarioAux.FechaVencimientoCarnetSalud = funcionario.Funcionario.FechaVencimientoCarnetSalud;
                            funcionarioAux.GradoCobro = Convert.ToInt32(funcionario.Funcionario.GradoCobro);
                            funcionarioAux.GradoPresupuestal = Convert.ToInt32(funcionario.Funcionario.GradoPresupuestal);
                            funcionarioAux.LugarFisico = funcionario.Funcionario.LugarFisico;
                            funcionarioAux.Nombre1 = funcionario.Funcionario.Nombre1;
                            funcionarioAux.Nombre2 = funcionario.Funcionario.Nombre2;
                            funcionarioAux.NroDocumento = funcionario.Funcionario.NroDocumento;
                            funcionarioAux.NroFuncionario = Convert.ToInt32(funcionario.Funcionario.NroFuncionario);
                            funcionarioAux.NumeroCC = funcionario.Funcionario.NumeroCC;
                            funcionarioAux.PaisEmisor = funcionario.Funcionario.PaisEmisor;
                            funcionarioAux.RelacionFuncional = funcionario.Funcionario.RelacionFuncional;
                            funcionarioAux.SerieCC = funcionario.Funcionario.SerieCC;
                            funcionarioAux.Sexo = funcionario.Funcionario.Sexo;
                            funcionarioAux.TipoDocumento = funcionario.Funcionario.TipoDocumento;
                            funcionarioAux.Unidad = funcionario.Funcionario.Unidad;
                            funcionarioAux.UsuarioRed = funcionario.Funcionario.UsuarioRed;

                            // Convierto los datos del documento
                            doc.CodPaisEmisor = funcionario.Documento.CodPaisEmisor;
                            doc.CodTipoDocumento = funcionario.Documento.CodTipoDocumento;
                            doc.NroDocumento = funcionario.Documento.NroDocumento;

                            // Los igualo
                            identificadorFuncionario.Funcionario = funcionarioAux;
                            identificadorFuncionario.Documento = doc;

                            resultObtenerFuncionarios.Funcionarios.Add(identificadorFuncionario);
                        }
                    }

                    if (result.Errores != null)
                    {
                        resultObtenerFuncionarios.Errores = new List<wsFuncionarioFacade.ErroresNegocio>();
                        foreach (var itemError in result.Errores)
                        {
                            wsFuncionarioFacade.ErroresNegocio error = new wsFuncionarioFacade.ErroresNegocio();

                            error.Codigo = itemError.Codigo;
                            error.Descripcion = itemError.Descripcion;
                            error.Detalle = itemError.Detalle;

                            resultObtenerFuncionarios.Errores.Add(error);
                        }
                    }

                    return resultObtenerFuncionarios;
                }
            }
            catch (Exception ex)
            {
                ApplicationFramework.Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        [AutoComplete]
        private List<ErrorNegocio> ConvertToFacadeEntity(List<Bull.ApplicationFramework.Services.ErrorNegocio> result, Contexto co)
        {
            try
            {
                using (Tracer tracer = new Tracer(new object[] { result }, co))
                {
                    List<ErrorNegocio> retorno = new List<ErrorNegocio>();

                    foreach (Bull.ApplicationFramework.Services.ErrorNegocio error in result)
                    {
                        ErrorNegocio en = new ErrorNegocio();
                        en.Codigo = error.Codigo;
                        en.Descripcion = error.Descripcion;

                        retorno.Add(en);
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
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        #endregion

        #region EsFuncionario
        /// <summary>
        /// fmacri RFC 1935
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="co"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool EsFuncionario(string documento, string tipoDoc, string codPaisEmisor, string UACT, DateTime fechaOpera, int vDebug)
        {
            Contexto co = new Contexto();
            co.FechaOpera = fechaOpera;
            co.Debug = vDebug;
            co.UsuarioActual = UACT;
            try
            {
                using (AdmPoderes admPoderes = new AdmPoderes())
                {
                    return admPoderes.EsFuncionario(documento, tipoDoc, codPaisEmisor, co);
                }
            }
            catch (Exception ex)
            {
                ApplicationFramework.Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }

        #endregion

        #region Obtener Fucnionarios por cedula

        /// <summary>
        /// fmacri 
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="tipoDoc"></param>
        /// <param name="codPaisEmisor"></param>
        /// <param name="co"></param>
        /// <returns></returns>
        [AutoComplete]
        public wsFuncionario.ResultObtenerFuncionarios ObtFuncionario(string documento, string tipoDoc, string codPaisEmisor, Contexto co)
        {
            using (new Tracer(new object[] { documento, tipoDoc, codPaisEmisor }, co))
            {
                using (AdmPoderes admPoderes = new AdmPoderes())
                {
                    wsFuncionarioEntity.ResultObtenerFuncionarios funcionariosEntity = admPoderes.ObtFuncionario(documento, tipoDoc, codPaisEmisor, co);
                    return ConvertToFacadeEntity(funcionariosEntity, co);
                }
            }
        }

        #endregion

        [AutoComplete()]
        public void AgrRprApoderadosOrigen(int secApoderados, DateTime fechaVigDesde, string codOrigenPoder, Contexto co)
        {
            try
            {
                using (new Tracer(new object[] { secApoderados, fechaVigDesde, codOrigenPoder }, co))
                {
                    using (AdmApoderadosOrigen adm = new AdmApoderadosOrigen())
                    {
                        adm.AgrRprApoderadosOrigen(secApoderados, fechaVigDesde, codOrigenPoder, co);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("secApoderados", secApoderados);
                ex.Data.Add("fechaVigDesde", fechaVigDesde);
                ex.Data.Add("codOrigenPoder", codOrigenPoder);
                Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }


        [AutoComplete()]
        public List<ConfigIngresoPoder> ObtConfigIngresoPoderes(int? codPoder, int? codFacultad, string codOrigenPoder, Contexto co)
        {
            try
            {
                using (new Tracer(new object[] { codPoder, codFacultad, codOrigenPoder }, co))
                {
                    using (AdmApoderadosOrigen adm = new AdmApoderadosOrigen())
                    {
                        return adm.ObtConfigIngresoPoderes(codPoder, codFacultad, codOrigenPoder, co);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("codPoder", codPoder);
                ex.Data.Add("codFacultad", codFacultad);
                ex.Data.Add("codOrigenPoder", codOrigenPoder);
                Utils.HandleException(ex, co);
                throw;
            }
            finally
            {
                Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co);
            }
        }


        [AutoComplete()]
        public List<OrigenPoder> ObtOrigenesPoderes(string codOrigenPoder, Contexto co)
        {
            try
            {
                using (new Tracer(new object[] { codOrigenPoder }, co))
                {
                    using (AdmApoderadosOrigen adm = new AdmApoderadosOrigen())
                    {
                        return adm.ObtOrigenesPoderes(codOrigenPoder, co);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("codOrigenPoder", codOrigenPoder);
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