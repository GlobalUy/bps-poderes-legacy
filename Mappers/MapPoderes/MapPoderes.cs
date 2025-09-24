
// ===============================================================================
// Disclaimer: this class was created by 
//
// Development platform was: $Platform$
//
// ==============================================================================

#region  Declaraciones Using
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Text;

using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Comunes.Mappers;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Poderes.BusinessEntities;
using Bull.PRES.Poderes.Dalcs;
using Bull.Comunes.DALCS;
#endregion

namespace Bull.PRES.Poderes.Mappers
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true), JustInTimeActivation(true)]
    [Guid("dc3fc854-9402-460f-925b-54aae4818bfd"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class MapPoderes : MappersAbstract
    {

        #region ObtApoderadosAFAM
        [AutoComplete(true)]
        public List<Apoderado> ObtApoderadosAFAM(int persIdPoderdante, int? persIdentificadorApo, DateTime? dtmFechaPerDesde, DateTime? dtmFechaPerHasta, DateTime? dtmFechaRevocacion, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, dtmFechaPerDesde, dtmFechaPerHasta, dtmFechaRevocacion }, co))
            {
                List<ApoBase> list;
                List<Apoderado> lstRet = new List<Apoderado>();
                using (DbAutCobroAFAM db = new DbAutCobroAFAM())
                {
                    using (IDataReader reader = db.ObtApoderado(persIdPoderdante, persIdentificadorApo, dtmFechaPerDesde, null, dtmFechaRevocacion, dtmFechaPerHasta, null, co))
                    {
                        list = Utils.GetListFromDataReader<ApoBase>(reader);
                    }
                }

                foreach (ApoBase apo in list)
                {
                    Apoderado ap = new Apoderado();
                    ap.Afam = "S";
                    ap.CodFacultad = apo.CodFacultad;
                    ap.Instituto = "N";
                    ap.Persona = new Persona();
                    ap.Persona.PersIdentificador = apo.PersIdentificador2;
                    ap.PoderDante = new Persona();
                    ap.PoderDante.PersIdentificador = apo.PersIdentificador1;

                    //Lo agrego a la lista
                    lstRet.Add(ap);
                }

                return lstRet;
            }
        }
        #endregion

        #region ObtApoderados
        [AutoComplete(true)]
        public List<Apoderado> ObtApoderados(int persIdPoderdante, int? persIdentificadorApo, int?[] codPoder, int?[] codFacultad, string strEstado, DateTime? fechaPerHasta, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, codPoder, codFacultad, strEstado, fechaPerHasta }, co))
            {
                List<ApoBase> list;
                List<Apoderado> lstRet = new List<Apoderado>();
                using (DbApoderados db = new DbApoderados())
                {
                    if (fechaPerHasta.HasValue)
                    {
                        fechaPerHasta = new DateTime(fechaPerHasta.Value.Year, fechaPerHasta.Value.Month, fechaPerHasta.Value.Day);
                    }

                    using (IDataReader reader = db.ObtApoderados(persIdPoderdante, persIdentificadorApo, codPoder, strEstado, null, codFacultad, fechaPerHasta, null, co))
                    {
                        list = Utils.GetListFromDataReader<ApoBase>(reader);

                        foreach (ApoBase apo in list)
                        {
                            Apoderado ap = new Apoderado();
                            ap.Afam = "N";
                            ap.CodFacultad = apo.CodFacultad;
                            ap.Instituto = "N";
                            ap.Persona = new Persona();
                            ap.Persona.PersIdentificador = apo.PersIdentificador2;
                            ap.PoderDante = new Persona();
                            ap.PoderDante.PersIdentificador = apo.PersIdentificador1;

                            //Lo agrego a la lista
                            lstRet.Add(ap);
                        }
                    }
                }
                return lstRet;
            }
        }
        #endregion

        #region ObtApoderadoIns
        [AutoComplete(true)]
        public List<Apoderado> ObtApoderadoIns(int persIdPoderdante, int? persIdentificadorApo, int?[] codFacultad, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, codFacultad }, co))
            {
                List<ApoInstitutos> list;
                List<Apoderado> lstRet = new List<Apoderado>();
                using (DbInstBeneficiarios db = new DbInstBeneficiarios())
                {
                    using (IDataReader reader = db.ObtApoderado(persIdPoderdante, persIdentificadorApo, codFacultad, null, co))
                    {
                        list = Utils.GetListFromDataReader<ApoInstitutos>(reader);
                    }
                }

                foreach (ApoInstitutos apo in list)
                {
                    Apoderado ap = new Apoderado();
                    ap.Afam = "N";
                    ap.CodFacultad = apo.CodFacultad;
                    ap.Instituto = "S";
                    ap.Persona = new Persona();
                    ap.Persona.PersIdentificador = apo.PersIdentificadorApo;
                    ap.PoderDante = new Persona();
                    ap.PoderDante.PersIdentificador = apo.PersIdentificadorBen;

                    //Lo agrego a la lista
                    lstRet.Add(ap);
                }
                return lstRet;
            }
        }
        #endregion

        #region ObtListaApoderadoIns
        [AutoComplete(true)]
        public List<PInstituto> ObtListaApoderadoIns(int persIdPoderdante, int? persIdentificadorApo, int?[] codFacultad, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, codFacultad }, co))
            {
                List<PInstituto> listRet = new List<PInstituto>(); 
                using (DbInstBeneficiarios db = new DbInstBeneficiarios())
                {
                    using (IDataReader reader = db.ObtApoderado(persIdPoderdante, persIdentificadorApo, codFacultad, null, co))
                    {

                        listRet = Utils.GetListFromDataReader<PInstituto>(reader);
                    }
                }
                return listRet; 
            }
        }
        #endregion

        #region ObtListaApoderados
        [AutoComplete(true)]
        public List<PApoderado> ObtListaApoderados(int persIdPoderdante, int? persIdentificadorApo, int?[] arrCodPoderMixto, int?[] arrFacultades, string strEstado, DateTime? fechaPerHasta, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, arrCodPoderMixto, arrFacultades, strEstado, fechaPerHasta }, co))
            {
                List<PApoderado> listRet = new List<PApoderado>();
                using (DbApoderados db = new DbApoderados())
                {

                    if (fechaPerHasta.HasValue) 
                    {
                        fechaPerHasta = new DateTime(fechaPerHasta.Value.Year, fechaPerHasta.Value.Month, fechaPerHasta.Value.Day); 
                    }
                    using (IDataReader reader = db.ObtApoderados(persIdPoderdante, persIdentificadorApo, arrCodPoderMixto, strEstado, null, arrFacultades, fechaPerHasta, null, co))
                    {
                        listRet = Utils.GetListFromDataReader<PApoderado>(reader);
                    }
                }
                return listRet;
            }
        }
        #endregion

        #region ObtTipoPoder
        [AutoComplete(true)]
        public List<TipoPoder> ObtTipoPoderes(Contexto co)
        {
            using (new Tracer(new object[] { }, co))
            {
                List<TipoPoder> listaRet = new List<TipoPoder>();
                using (DbComunes db = new DbComunes())
                {
                    using (IDataReader reader = db.ObtTipoPoderes(co))
                    {
                        listaRet = Utils.GetListFromDataReader<TipoPoder>(reader);
                    }
                }

                return listaRet; 
            }
        }
        #endregion

        #region ObtTipoFacultad
        [AutoComplete(true)]
        public List<TipoFacultad> ObtTipoFacultades(Contexto co)
        {
            using (new Tracer(new object[] { }, co))
            {
                List<TipoFacultad> listaRet = new List<TipoFacultad>();
                using (DbComunes db = new DbComunes())
                {
                    using (IDataReader reader = db.ObtTipocFacultades(co))
                    {
                        listaRet = Utils.GetListFromDataReader<TipoFacultad>(reader);
                    }
                }
                return listaRet; 
            }
        }
        #endregion

        #region ObtListaApoderadosAFAM
        [AutoComplete(true)]
        public List<PAfam> ObtListaApoderadosAFAM(int persIdPoderdante, int? persIdentificadorApo, DateTime? dtmFechaPerDesde, DateTime? dtmFechaPerHasta, DateTime? dtmFechaRevocacion, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, dtmFechaPerDesde, dtmFechaPerHasta, dtmFechaRevocacion }, co))
            {
                List<PAfam> listRet = new List<PAfam>();
                using (DbAutCobroAFAM db = new DbAutCobroAFAM())
                {
                    using (IDataReader reader = db.ObtApoderado(persIdPoderdante, persIdentificadorApo, dtmFechaPerDesde, null, dtmFechaRevocacion, dtmFechaPerHasta, null, co))
                    {
                        listRet = Utils.GetListFromDataReader<BusinessEntities.PAfam>(reader);
                    }
                }
                return listRet;
            }
        }


        #endregion

        #region ObtenerApoderadosYPoderantes

        [AutoComplete(true)]
        public List<PoderPersona> MapObtenerApoderadosYPoderdantes(int persIdentificador, string registrosVigentes, Contexto co)
        {
            using (new Tracer(new object[] { persIdentificador, registrosVigentes }, co))
            {
                List<PoderPersona> listRet = new List<PoderPersona>();
                using (DbApoderados db = new DbApoderados())
                {
                    using (IDataReader reader = db.DbObtenerApoderadosYPoderdantes(persIdentificador, registrosVigentes, null, co))
                    {
                        listRet = Utils.GetListFromDataReader<BusinessEntities.PoderPersona>(reader);
                    }
                }
                return listRet;
            }
        }

        #endregion


        #region Obtener Apoderado info completa
        [AutoComplete(true)]
        public List<PoderPersonaControlCant> MapObtenerPoderesApoderado(int persIdApoderlo, int? codPoder, int? codFacultad, string strEstado, DateTime? fechaPerHasta, Contexto co)
        {
            using (new Tracer(new object[] { persIdApoderlo, codPoder, codFacultad, strEstado, fechaPerHasta}, co))
            {
                List<PoderPersonaControlCant> listRet = new List<PoderPersonaControlCant>();
                using (DbApoderados db = new DbApoderados())
                {
                    using (IDataReader reader = db.DbObtenerPoderesApoderado(persIdApoderlo, codPoder, codFacultad, strEstado, fechaPerHasta, null, co))
                    {
                        listRet = Utils.GetListFromDataReader<BusinessEntities.PoderPersonaControlCant>(reader);
                    }
                }
                return listRet;
            }
        }

        #endregion
    }
}
