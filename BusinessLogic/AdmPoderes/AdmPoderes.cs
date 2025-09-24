// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 11/08/2008 03:29:05 p.m.
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
using System.Runtime.Serialization;
using Bull.ApplicationFramework;
using Bull.Comunes.BusinessLogic;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Poderes.BusinessEntities;
using wsFuncionarioEntity = Bull.PRES.Poderes.BusinessEntities.wsFuncionario;
using Bull.PRES.Poderes.Mappers;
using Bull.PRES.Comunes.BusinessEntity;
using System.Collections.Generic;
using Bull.Comunes.DALCS;
using Bull.PRES.Poderes.ServiceAgents;
using Bull.ApplicationFramework.Services;
using wssFucnionario = Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios;
//using Bull.PRES.Poderes.ServiceAgents.Servicios.wsFuncionarios;
#endregion


namespace Bull.PRES.Poderes.BusinessLogic
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true), JustInTimeActivation(true)]
    [Guid("1d2e3782-afd3-42ce-a540-1d4944c8fd3f"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class AdmPoderes : BusinessLogicAbstract
    {

        #region ObtApoderados
        [AutoComplete]
        public List<Apoderado> ObtApoderados(int persIdPoderdante, int? persIdentificadorApo, int codGrupo, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, codGrupo }, co))
            {
                //Levanto Parámetros Generales con Beneficio 0
                string arrFacu = "";
                ParamBenef paramBenef = new ParamBenef();
                using (SAPoderes saPoderes = new SAPoderes())
                {
                    paramBenef = saPoderes.ObtParamBenef(0, 0, co);
                    arrFacu = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_PODERES_FACULT_COBRO);
                }

                List<int?> l = new List<int?>();
                foreach (string n in arrFacu.Replace("(", "").Replace(")", "").Split(','))
                {
                    l.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrFacultades = l.ToArray();

                //Defino e inicializo colPoderesRetorno
                List<Apoderado> colPoderesRetorno = new List<Apoderado>();
                List<Apoderado> colPoderes = new List<Apoderado>();
                //Esta lógica se pasara a una tabla de configuración en un próxima SCM
                //Selecciono Caso CodGrupo
                switch (codGrupo)
                {
                    //Mixto
                    case 1:

                        string strCodPodMixto = "";
                        strCodPodMixto = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_PODERES_COBRO_MIXTO);

                        List<int?> p = new List<int?>();
                        foreach (string n in strCodPodMixto.Replace("(", "").Replace(")", "").Split(','))
                        {
                            p.Add((int?)(Convert.ToInt32(n)));
                        }
                        int?[] arrCodPoderMixto = p.ToArray();

                        string strEstado = "O";
                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            colPoderes = mapPoderes.ObtApoderados(persIdPoderdante, persIdentificadorApo, arrCodPoderMixto, arrFacultades, strEstado, co.FechaOpera, co);
                        }

                        colPoderesRetorno = colPoderes;
                        colPoderes = new List<Apoderado>();

                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            colPoderes = mapPoderes.ObtApoderadoIns(persIdPoderdante, persIdentificadorApo, arrFacultades, co);
                        }
                        foreach (Apoderado apo in colPoderes)
                        {
                            colPoderesRetorno.Add(apo);
                        }
                        break;
                    //Solo Apoderado
                    case 2:

                        string strCodPoderSoloApo = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_PODERES_COBRO_SOLO_APO);

                        List<int?> k = new List<int?>();
                        foreach (string n in strCodPoderSoloApo.Replace("(", "").Replace(")", "").Split(','))
                        {
                            k.Add((int?)(Convert.ToInt32(n)));
                        }
                        int?[] arrCodPoderSoloApo = k.ToArray();

                        strEstado = "O";

                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            colPoderesRetorno = mapPoderes.ObtApoderados(persIdPoderdante, persIdentificadorApo, arrCodPoderSoloApo, arrFacultades, strEstado, co.FechaOpera, co);
                            //colPoderesRetorno.Agrego (colPoderes);
                        }
                        break;
                    //Autoriza AFAM
                    case 3:

                        DateTime? dtmFechaRevocacion = null;//'Que traiga las tuplas en NULL;
                        DateTime? dtmFechaPerDesde = null; //'No filtro;
                        DateTime? dtmFechaPerHasta = co.FechaOpera;//'No filtro;
                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            colPoderes = mapPoderes.ObtApoderadosAFAM(persIdPoderdante, persIdentificadorApo, dtmFechaPerDesde, dtmFechaPerHasta, dtmFechaRevocacion, co);
                        }
                        colPoderesRetorno = colPoderes;
                        break;
                    //Titular con asistencia
                    case 4:
                        string strCodPoderTitularConAsistencia = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_ACTUACION_CONJUNTA);

                        List<int?> t = new List<int?>();
                        foreach (string n in strCodPoderTitularConAsistencia.Replace("(", "").Replace(")", "").Split(','))
                        {
                            t.Add((int?)(Convert.ToInt32(n)));
                        }
                        int?[] arrCodPoderTitularConAsistencia = t.ToArray();

                        strEstado = "O";

                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            colPoderesRetorno = mapPoderes.ObtApoderados(persIdPoderdante, persIdentificadorApo, arrCodPoderTitularConAsistencia, null, strEstado, co.FechaOpera, co);
                        }
                        break;
                    default:
                        break;


                }

                return colPoderesRetorno;
            }
        }
        #endregion

        #region ObtApoderados
        [AutoComplete]
        public List<Apoderado> ObtApoderados(int persIdPoderdante, int? persIdentificadorApo, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo }, co))
            {
                //Levanto Parámetros Generales con Beneficio 0
                string arrFacu = "";
                using (SAPoderes saPoderes = new SAPoderes())
                {
                    ParamBenef paramBenef = saPoderes.ObtParamBenef(0, 0, co);
                    arrFacu = paramBenef.ObtValorParametroxDescAbreviada("PODERES_FACULT_COBRO");
                }

                List<int?> l = new List<int?>();
                foreach (string n in arrFacu.Replace("(", "").Replace(")", "").Split(','))
                {
                    l.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrFacultades = l.ToArray();
                using (MapPoderes mapPoderes = new MapPoderes())
                {
                    return mapPoderes.ObtApoderados(persIdPoderdante, persIdentificadorApo, null, arrFacultades, "O", co.FechaOpera, co);
                }
            }
        }
        #endregion

        #region ObtApoderadosAFAM
        [AutoComplete]
        public List<Apoderado> ObtApoderadosAFAM(int persIdPoderdante, int? persIdentificadorApo, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo }, co))
            {
                using (MapPoderes mapPoderes = new MapPoderes())
                {
                    return mapPoderes.ObtApoderadosAFAM(persIdPoderdante, persIdentificadorApo, null, null, null, co);
                }
            }
        }
        #endregion

        #region ObtApoderadosInst
        [AutoComplete]
        public List<Apoderado> ObtApoderadosInst(int persIdPoderdante, int? persIdentificadorApo, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo }, co))
            {
                //Levanto Parámetros Generales con Beneficio 0
                string arrFacu = "";
                using (SAPoderes saPoderes = new SAPoderes())
                {
                    ParamBenef paramBenef = saPoderes.ObtParamBenef(0, 0, co);
                    arrFacu = paramBenef.ObtValorParametroxDescAbreviada("PODERES_FACULT_COBRO");
                }
                List<int?> l = new List<int?>();
                foreach (string n in arrFacu.Replace("(", "").Replace(")", "").Split(','))
                {
                    l.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrFacultades = l.ToArray();

                using (MapPoderes mapPoderes = new MapPoderes())
                {
                    return mapPoderes.ObtApoderadoIns(persIdPoderdante, persIdentificadorApo, arrFacultades, co);
                }
            }
        }
        #endregion

        #region ObtListaPoderes
        [AutoComplete]
        public List<ResultConsPoder> ObtListaPoderes(string cobroAFAM, int tipoFacultades, int persIdApoderado, int persIdPoderdante, Contexto co)
        {
            using (new Tracer(new object[] { cobroAFAM, tipoFacultades, persIdApoderado, persIdPoderdante }, co))
            {
                //Levanto Parámetros Generales con Beneficio 0
                string arrFacu = "";
                ParamBenef paramBenef = new ParamBenef();

                //tipoFacultades: 1 Cobro , 2 Tramite, 3 Prestamo, 4 Todos  
                //PODERES_FACULTAD_COBRO = ( 1, 4, 5, 6 )
                //PODERES_FACULT_TRAMITE = ( 2, 4, 6, 7 )
                //PODERES_FACULT_PRESTAMO = ( 3, 4, 6, 7 )
                //PODERES_FACULT_TODOS = (1, 2, 3, 4, 5, 6, 7 )

                string tipoPoder = "";
                switch (tipoFacultades)
                {
                    case 1:
                        tipoPoder = "PODERES_FACULTAD_COBRO";
                        break;
                    case 2:
                        tipoPoder = "PODERES_FACULT_TRAMITE";
                        break;
                    case 3:
                        tipoPoder = "PODERES_FACULT_PRESTAMO";
                        break;
                    case 4:
                        tipoPoder = "PODERES_FACULT_TODOS";
                        break;
                    default:
                        break;
                }

                using (SAPoderes saPoderes = new SAPoderes())
                {
                    paramBenef = saPoderes.ObtParamBenef(0, 0, co);
                    arrFacu = paramBenef.ObtValorParametroxDescAbreviada(tipoPoder);
                }

                List<int?> l = new List<int?>();
                foreach (string n in arrFacu.Replace("(", "").Replace(")", "").Split(','))
                {
                    l.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrFacultades = l.ToArray();

                //Defino e inicializo colPoderesRetorno
                List<PApoderado> colPoderesApo;
                List<PAfam> colPoderesAfam;
                List<PInstituto> colPoderesInst;
                List<ResultConsPoder> colResult = new List<ResultConsPoder>();

                //Retorno
                ResultConsPoder ret = new ResultConsPoder();

                //Mixtos
                string strCodPodMixto = "";
                strCodPodMixto = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_PODERES_COBRO_MIXTO);

                List<int?> p = new List<int?>();
                foreach (string n in strCodPodMixto.Replace("(", "").Replace(")", "").Split(','))
                {
                    p.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrCodPoderMixto = p.ToArray();

                string strEstado = "O";
                List<TipoPoder> listaTiposPoder;
                List<TipoFacultad> listaTiposFacultad;

                using (MapPoderes mapPoderes = new MapPoderes())
                {
                    colPoderesApo = mapPoderes.ObtListaApoderados(persIdPoderdante, persIdApoderado, arrCodPoderMixto, arrFacultades, strEstado, co.FechaOpera, co);
                    listaTiposPoder = mapPoderes.ObtTipoPoderes(co);
                    listaTiposFacultad = mapPoderes.ObtTipoFacultades(co);

                    foreach (PApoderado pa in colPoderesApo)
                    {
                        ResultConsPoder resultConsPoder = new ResultConsPoder();
                        resultConsPoder.CodPoder = pa.CodPoder;
                        resultConsPoder.DescTipoPoder = this.descCodPoder(listaTiposPoder, pa.CodPoder, co);
                        resultConsPoder.CodFacultad = pa.CodFacultad;
                        resultConsPoder.DescFacultad = this.descCodFacultad(listaTiposFacultad, pa.CodFacultad, co);

                        colResult.Add(resultConsPoder);
                    }

                }

                using (MapPoderes mapPoderes = new MapPoderes())
                {
                    colPoderesInst = mapPoderes.ObtListaApoderadoIns(persIdPoderdante, persIdApoderado, arrFacultades, co);

                    foreach (PInstituto pi in colPoderesInst)
                    {
                        ResultConsPoder pconsPoder = new ResultConsPoder();

                        pconsPoder.CodPoder = "I";
                        pconsPoder.DescTipoPoder = "Instituto";
                        pconsPoder.CodFacultad = pi.CodFacultad;
                        pconsPoder.DescFacultad = this.descCodFacultad(listaTiposFacultad, pi.CodFacultad, co);

                        colResult.Add(pconsPoder);
                    }

                }

                //Solo apoderados
                string strCodPoderSoloApo = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_PODERES_COBRO_SOLO_APO);

                List<int?> k = new List<int?>();
                foreach (string n in strCodPoderSoloApo.Replace("(", "").Replace(")", "").Split(','))
                {
                    k.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrCodPoderSoloApo = k.ToArray();

                using (MapPoderes mapPoderes = new MapPoderes())
                {

                    List<PApoderado> listaApoderadosAux = mapPoderes.ObtListaApoderados(persIdPoderdante, persIdApoderado, arrCodPoderSoloApo, arrFacultades, strEstado, co.FechaOpera, co);
                    colPoderesApo = new List<PApoderado>();

                    foreach (PApoderado apoAux in listaApoderadosAux)
                    {
                        colPoderesApo.Add(apoAux);
                    }

                    foreach (PApoderado pa in colPoderesApo)
                    {
                        ResultConsPoder resultConsPoder = new ResultConsPoder();
                        resultConsPoder.CodPoder = pa.CodPoder;
                        resultConsPoder.DescTipoPoder = this.descCodPoder(listaTiposPoder, pa.CodPoder, co);
                        resultConsPoder.CodFacultad = pa.CodFacultad;
                        resultConsPoder.DescFacultad = this.descCodFacultad(listaTiposFacultad, pa.CodFacultad, co);

                        colResult.Add(resultConsPoder);
                    }
                }

                //Actuacion conjunta
                string strCodPoderActuacionConjunta = paramBenef.ObtValorParametroxDescAbreviada(BusinessEntities.Constantes.GRUPO_ACTUACION_CONJUNTA);

                List<int?> a = new List<int?>();
                foreach (string n in strCodPoderActuacionConjunta.Replace("(", "").Replace(")", "").Split(','))
                {
                    a.Add((int?)(Convert.ToInt32(n)));
                }
                int?[] arrCodPoderActuacionConjunta = a.ToArray();

                using (MapPoderes mapPoderes = new MapPoderes())
                {

                    List<PApoderado> listaApoderadosAsistentesAux = mapPoderes.ObtListaApoderados(persIdPoderdante, persIdApoderado, arrCodPoderActuacionConjunta, arrFacultades, strEstado, co.FechaOpera, co);
                    colPoderesApo = new List<PApoderado>();

                    foreach (PApoderado apoAux in listaApoderadosAsistentesAux)
                    {
                        colPoderesApo.Add(apoAux);
                    }

                    foreach (PApoderado pa in colPoderesApo)
                    {
                        ResultConsPoder resultConsPoder = new ResultConsPoder();
                        resultConsPoder.CodPoder = pa.CodPoder;
                        resultConsPoder.DescTipoPoder = this.descCodPoder(listaTiposPoder, pa.CodPoder, co);
                        resultConsPoder.CodFacultad = pa.CodFacultad;
                        resultConsPoder.DescFacultad = this.descCodFacultad(listaTiposFacultad, pa.CodFacultad, co);

                        colResult.Add(resultConsPoder);
                    }
                }

                //AFAM
                if (cobroAFAM == "S")
                {
                    DateTime? dtmFechaRevocacion = null;//'Que traiga las tuplas en NULL;
                    DateTime? dtmFechaPerDesde = null; //'No filtro;
                    DateTime? dtmFechaPerHasta = co.FechaOpera;//'No filtro;
                    using (MapPoderes mapPoderes = new MapPoderes())
                    {
                        colPoderesAfam = mapPoderes.ObtListaApoderadosAFAM(persIdPoderdante, persIdApoderado, dtmFechaPerDesde, dtmFechaPerHasta, dtmFechaRevocacion, co);

                        foreach (PAfam pa in colPoderesAfam)
                        {
                            ResultConsPoder resultConsPoder = new ResultConsPoder();
                            resultConsPoder.CodPoder = "A";
                            resultConsPoder.DescTipoPoder = "AFAM";
                            resultConsPoder.CodFacultad = 1;
                            resultConsPoder.DescFacultad = "Cobro";

                            colResult.Add(resultConsPoder);
                        }
                    }

                }

                //Recorro la lista de poderes y cargo las descripciones para la facultad y cod poder

                return colResult;
            }

        }
        #endregion

        #region Métodos Auxiliares
        [AutoComplete]
        private string descCodPoder(List<TipoPoder> listaPoder, string codigo, Contexto co)
        {
            using (new Tracer(new object[] { listaPoder, codigo }, co))
            {
                string descripcion = "";
                foreach (TipoPoder tipoAux in listaPoder)
                {
                    if (tipoAux.CodPoder.ToString().Equals(codigo))
                    {
                        descripcion = tipoAux.Descripcion;
                        break;
                    }
                }
                return descripcion;
            }

        }

        [AutoComplete]
        private string descCodFacultad(List<TipoFacultad> listaTiposFacultad, int? codigo, Contexto co)
        {
            using (new Tracer(new object[] { listaTiposFacultad, codigo }, co))
            {
                string descripcion = "";
                foreach (TipoFacultad tipoAux in listaTiposFacultad)
                {
                    if (tipoAux.CodFacultad == codigo)
                    {
                        descripcion = tipoAux.Descripcion;
                        break;
                    }
                }
                return descripcion;
            }
        }
        #endregion

        #region ObtenerApoderadosYPoderantes

        /// <summary>
        /// Autor: Martin Rodriguez
        /// Fecha: 25/03/2014
        /// Desc.: Funcion que obtiene los Apoderados y Ponderantes de una persona.
        /// RFC 844
        /// </summary>
        [AutoComplete]
        public ResultObtenerApoderadosYPoderdantes AdmObtenerApoderadosYPoderdantes(int persIdentificador, string registrosVigentes, string incluirDatosPersona, Contexto co)
        {
            using (new Tracer(new object[] { persIdentificador, registrosVigentes, incluirDatosPersona }, co))
            {
                ResultObtenerApoderadosYPoderdantes retorno = new ResultObtenerApoderadosYPoderdantes();
                List<Bull.ApplicationFramework.Services.ErrorNegocio> errores = null;

                //Por defecto si NO viene el datos, agrego "N"
                registrosVigentes = (String.IsNullOrEmpty(registrosVigentes)) ? "N" : registrosVigentes;
                incluirDatosPersona = (String.IsNullOrEmpty(incluirDatosPersona)) ? "N" : incluirDatosPersona;

                errores = ValParamEntrada(persIdentificador, registrosVigentes, incluirDatosPersona, co);

                //Verifico si ocurrieron errores
                if (errores.Count.Equals(0))
                {
                    using (MapPoderes mapPoderes = new MapPoderes())
                    {
                        List<PoderPersona> poderesPersonas;
                        PoderPersona datoPersona = null;
                        //Obtengo los datos de los poderes de la persona
                        poderesPersonas = mapPoderes.MapObtenerApoderadosYPoderdantes(persIdentificador, registrosVigentes, co);

                        if (poderesPersonas != null)
                        {
                            using (ServiceAgents.SAPoderes saPoderes = new SAPoderes())
                            {
                                foreach (PoderPersona pPersona in poderesPersonas)
                                {
                                    //Si la persona es Poderdante
                                    if (pPersona.PersIdentificador_1 == persIdentificador)
                                    {
                                        pPersona.PersIdentificador_1 = pPersona.PersIdentificador_2;

                                        //Verifico si hay que incluir los datos de la persona
                                        if (incluirDatosPersona.ToUpper().Equals("S"))
                                        {
                                            pPersona.PersIdentificador = pPersona.PersIdentificador_1;

                                            //Cargo los datos de la persona
                                            datoPersona = saPoderes.ObtDatosPersonaPorPersID(pPersona, co);
                                        }
                                        else
                                        {
                                            datoPersona = pPersona;
                                        }

                                        //Cargo en la coleccion de retorno
                                        retorno.ApoderadosPersona.Add(datoPersona);
                                    }
                                    //Si la persona es Apoderado
                                    else if (pPersona.PersIdentificador_2 == persIdentificador)
                                    {
                                        //Verifico si hay que incluir los datos de la persona
                                        if (incluirDatosPersona.ToUpper().Equals("S"))
                                        {
                                            pPersona.PersIdentificador = pPersona.PersIdentificador_1;

                                            //Cargo los datos de la persona
                                            datoPersona = saPoderes.ObtDatosPersonaPorPersID(pPersona, co);
                                        }
                                        else
                                        {
                                            datoPersona = pPersona;
                                        }

                                        //Cargo en la coleccion de retorno
                                        retorno.PoderdantesPersona.Add(datoPersona);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Cargo la coleccion de errores en el retorno
                    retorno.ErroresNegocio = errores;
                }

                return retorno;
            }
        }

        [AutoComplete]
        public List<Bull.ApplicationFramework.Services.ErrorNegocio> ValParamEntrada(int? persIdentificador, string registrosVigentes, string incluirDatosPersona, Contexto co)
        {
            using (Tracer tracer = new Tracer(new object[] { persIdentificador, registrosVigentes, incluirDatosPersona }, co))
            {
                List<Bull.ApplicationFramework.Services.ErrorNegocio> retorno = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
                Bull.ApplicationFramework.Services.ErrorNegocio error = null;

                if (persIdentificador.Equals(0))
                {
                    error = new Bull.ApplicationFramework.Services.ErrorNegocio();
                    error.Codigo = "3747";
                    error.Severidad = 1;
                    error.Descripcion = "Parámetros incorrectos.";
                    retorno.Add(error);
                }

                if (!String.IsNullOrEmpty(registrosVigentes))
                {
                    if (!(registrosVigentes.ToUpper().Equals("S") || registrosVigentes.ToUpper().Equals("N")))
                    {
                        error = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        error.Codigo = "1";
                        error.Severidad = 1;
                        error.Descripcion = "Parámetro [RegitrosVigentes] debe contener valores S/N";
                        retorno.Add(error);
                    }
                }

                if (!String.IsNullOrEmpty(incluirDatosPersona))
                {
                    if (!(incluirDatosPersona.ToUpper().Equals("S") || incluirDatosPersona.ToUpper().Equals("N")))
                    {
                        error = new Bull.ApplicationFramework.Services.ErrorNegocio();
                        error.Codigo = "2";
                        error.Severidad = 1;
                        error.Descripcion = "Parámetro [IncluirDatosPersonas] debe contener valores S/N";
                        retorno.Add(error);
                    }
                }

                return retorno;
            }
        }

        #endregion

        #region EsFuncionarios
        /// <summary>
        /// fmacri RFC 1935
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="co"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool EsFuncionario(string documento, string tipoDoc, string codPaisEmisor, Contexto co)
        {
            bool noFuncionario = true;
            using (new Tracer(new object[] { documento, tipoDoc, codPaisEmisor }, co))
            {
                using (SAFuncionarios saFuncionario = new SAFuncionarios())
                {
                    wssFucnionario.ResultObtenerFuncionarios resultObtenerFuncionario = saFuncionario.ObtFuncionario(documento, tipoDoc, codPaisEmisor, co);
                    if (resultObtenerFuncionario.funcionarios != null)
                    {
                        if (resultObtenerFuncionario.funcionarios[0].funcionario != null)
                        {
                            if (resultObtenerFuncionario.funcionarios[0].funcionario.estado == "ACTIVO")
                            {
                                noFuncionario = false;
                            }
                        }
                    }
                }
            }
            return noFuncionario;
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
        public wsFuncionarioEntity.ResultObtenerFuncionarios ObtFuncionario(string documento, string tipoDoc, string codPaisEmisor, Contexto co)
        {
            using (new Tracer(new object[] { documento, tipoDoc, codPaisEmisor }, co))
            {
                using (SAFuncionarios saFuncionario = new SAFuncionarios())
                {
                    wsFuncionarioEntity.ResultObtenerFuncionarios resultObtenerFuncionarios = new wsFuncionarioEntity.ResultObtenerFuncionarios();
                    wssFucnionario.ResultObtenerFuncionarios funcionarios = saFuncionario.ObtFuncionario(documento, tipoDoc, codPaisEmisor, co);

                    if (funcionarios.funcionarios != null && funcionarios.funcionarios[0].funcionario != null)
                    {
                        resultObtenerFuncionarios.Funcionarios = new List<wsFuncionarioEntity.IdentificadorFuncionario>();
                        foreach (var funcionario in funcionarios.funcionarios)
                        {
                            wsFuncionarioEntity.IdentificadorFuncionario identificadorFuncionario = new wsFuncionarioEntity.IdentificadorFuncionario();
                            wsFuncionarioEntity.Funcionario funcionarioAux = new wsFuncionarioEntity.Funcionario();
                            wsFuncionarioEntity.Documento doc = new wsFuncionarioEntity.Documento();

                            // Convierto datos de funcionario
                            funcionarioAux.Antiguedad = funcionario.funcionario.antiguedad;
                            funcionarioAux.Apellido1 = funcionario.funcionario.apellido1;
                            funcionarioAux.Apellido2 = funcionario.funcionario.apellido2;
                            funcionarioAux.CargoCobro = funcionario.funcionario.cargoCobro;
                            funcionarioAux.CargoProsupuestal = funcionario.funcionario.cargoPresupuestal;
                            funcionarioAux.CodLugarFisico = funcionario.funcionario.codLugarFisico;
                            funcionarioAux.EMailExterno = funcionario.funcionario.eMailExterno;
                            funcionarioAux.EscalafonCobro = funcionario.funcionario.escalafonCobro;
                            funcionarioAux.EscalafonPresupuestal = funcionario.funcionario.escalafonPresupuestal;
                            funcionarioAux.Estado = funcionario.funcionario.estado;
                            funcionarioAux.FechaEgreso = funcionario.funcionario.fechaEgreso;
                            funcionarioAux.FechaIngreso = funcionario.funcionario.fechaIngreso;
                            funcionarioAux.FechaNacimiento = funcionario.funcionario.fechaNacimiento;
                            funcionarioAux.FechaVencimientoCarnetSalud = funcionario.funcionario.fechaVencimientoCarnetSalud;
                            funcionarioAux.LugarFisico = funcionario.funcionario.lugarFisico;
                            funcionarioAux.Nombre1 = funcionario.funcionario.nombre1;
                            funcionarioAux.Nombre2 = funcionario.funcionario.nombre2;
                            funcionarioAux.NroDocumento = funcionario.funcionario.nroDocumento;
                            funcionarioAux.PaisEmisor = funcionario.funcionario.paisEmisor;
                            funcionarioAux.RelacionFuncional = funcionario.funcionario.relacionFuncional;
                            funcionarioAux.SerieCC = funcionario.funcionario.serieCC;
                            funcionarioAux.Sexo = funcionario.funcionario.sexo;
                            funcionarioAux.TipoDocumento = funcionario.funcionario.tipoDocumento;
                            funcionarioAux.Unidad = funcionario.funcionario.unidad;
                            funcionarioAux.UsuarioRed = funcionario.funcionario.usuarioRed;

                            funcionarioAux.CodSexo = funcionario.funcionario.codSexo;
                            funcionarioAux.CodUnidad = funcionario.funcionario.codUnidad == null ? null : (int?)Convert.ToInt32(funcionario.funcionario.codUnidad);
                            funcionarioAux.CodPaisEmisor = funcionario.funcionario.codPaisEmisor;
                            funcionarioAux.CodRelacionFuncional = funcionario.funcionario.codRelacionFuncional == null ? null : (int?)Convert.ToInt32(funcionario.funcionario.codRelacionFuncional);
                            funcionarioAux.NroFuncionario = Convert.ToInt32(funcionario.funcionario.nroFuncionario);
                            funcionarioAux.NumeroCC = funcionario.funcionario.numeroCC;
                            funcionarioAux.GradoCobro = funcionario.funcionario.gradoCobro;
                            funcionarioAux.GradoPresupuestal = funcionario.funcionario.gradoPresupuestal;

                            // Convierto los datos del documento
                            doc.CodPaisEmisor = funcionario.identificadorFuncionario.documento.codPaisEmisor;
                            doc.CodTipoDocumento = funcionario.identificadorFuncionario.documento.tipoDocumento;
                            doc.NroDocumento = funcionario.identificadorFuncionario.documento.nroDocumento;

                            // Los igualo
                            identificadorFuncionario.Funcionario = funcionarioAux;
                            identificadorFuncionario.Documento = doc;

                            resultObtenerFuncionarios.Funcionarios.Add(identificadorFuncionario);
                        }
                    }

                    if (funcionarios.funcionarios[0].erroresNegocio != null && funcionarios.funcionarios[0].erroresNegocio.Length > 0)
                    {
                        resultObtenerFuncionarios.Errores = new List<wsFuncionarioEntity.ErroresNegocio>();

                        foreach (var itemError in funcionarios.funcionarios[0].erroresNegocio)
                        {
                            wsFuncionarioEntity.ErroresNegocio error = new wsFuncionarioEntity.ErroresNegocio();
                            error.Codigo = itemError.codigo;
                            error.Descripcion = itemError.descripcion;
                            error.Detalle = itemError.detalle;
                            resultObtenerFuncionarios.Errores.Add(error);
                        }
                    }

                    return resultObtenerFuncionarios;
                }
            }
        }
        #endregion

    }
}