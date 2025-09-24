// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 07/08/2008 03:18:55 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.0.19
//
// ==============================================================================
#region Declaraciones Using
using System;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Text;

using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Comunes.DALCS;
using Bull.Seguridad.BusinessEntity;
using Bull.ApplicationFramework.Legacy;
using Bull.ApplicationFramework.DALCS;
#endregion

namespace Bull.PRES.Poderes.Dalcs
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [PrivateComponent, EventTrackingEnabled(true), JustInTimeActivation(true)]
    [Guid("72acaccb-3ee6-419e-8e96-ce4de9f14c54"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class DbApoderados : PresDALCAbstract
    {
        #region ObtApoderados
        [AutoComplete()]
        public IDataReader ObtApoderados(int persIdPoderdante, int? persIdentificadorApo, int?[] codPoder, string estado, ParamDb<int?> codVinculo, int?[] codFacultad, DateTime? fechaPerHasta, string[] orderBy, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, codPoder, estado, codVinculo, codFacultad, fechaPerHasta, orderBy }, co))
            {
                using (Database database = GetDatabase(co))
                {
                    ParameterCollection selectColumns = new ParameterCollection(new string[] { "SEC_APODERADOS", "FECHA_VIG_DESDE", "PERS_IDENTIFICADOR_1", "PERS_IDENTIFICADOR_2", "COD_PODER", "ESTADO", "COD_VINCULO", "COD_FACULTAD", "COMENTARIOS", "FECHA_PER_DESDE", "FECHA_PER_HASTA", "FECHA_REN_REV", "FECHA_VIG_HASTA", "SUEP", "ITF", "UACT", "FACT" });

                    ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();

                    whereColumnsFilter.Add("PERS_IDENTIFICADOR_1", persIdPoderdante);

                    if (persIdentificadorApo != null)
                    {
                        whereColumnsFilter.Add("PERS_IDENTIFICADOR_2", persIdentificadorApo);
                    }
                    if (codPoder != null)
                    {
                        whereColumnsFilter.Add("COD_PODER", codPoder);
                    }
                    whereColumnsFilter.Add("ESTADO", estado);
                    if (codVinculo != null)
                    {
                        whereColumnsFilter.Add("COD_VINCULO", codVinculo);
                    }
                    if (codFacultad != null)
                        whereColumnsFilter.Add("COD_FACULTAD", codFacultad);

                    if (fechaPerHasta != null)
                    {
                        whereColumnsFilter.Add("FECHA_PER_HASTA", CompareOperator.GreaterThanEqual, fechaPerHasta, true);
                    }
                    whereColumnsFilter.Add("FECHA_VIG_DESDE", CompareOperator.LessThanEqual, co.FechaOpera);
                    whereColumnsFilter.Add("FECHA_VIG_HASTA", CompareOperator.GreaterThanEqual, co.FechaOpera, true);

                    OrderByCollection orderByCollection = new OrderByCollection(orderBy);

                    database.CreateSelectCommand("VS_RPR_APODERADOS_01", selectColumns, whereColumnsFilter, orderByCollection);
                    IDataReader reader = database.ExecuteReader();
                    return reader;
                }
            }
        }

        #endregion

        #region ObtenerApoderadosYPoderdantes

        [AutoComplete]
        public IDataReader DbObtenerApoderadosYPoderdantes(int persIdentificador, string registrosVigentes, string[] orderBy, Contexto co)
        {
            using (new Tracer(new object[] { persIdentificador, registrosVigentes, orderBy }, co))
            {
                using (Database db = GetDatabase(co))
                {
                    IDataReader retorno;
                    string selectFrom = String.Empty;

                    selectFrom = "SELECT PERS_IDENTIFICADOR_1, PERS_IDENTIFICADOR_2, COD_PODER, DESC_PODER, COD_FACULTAD, DESC_FACULTAD, FECHA_PER_DESDE, FECHA_PER_HASTA FROM ";
                    selectFrom += "VS_RPR_APODERADOS_03 ";
                    selectFrom += "WHERE ";
                    selectFrom += "(PERS_IDENTIFICADOR_1 = ? ";
                    selectFrom += "OR PERS_IDENTIFICADOR_2 = ? ) ";
                    selectFrom += "AND ESTADO = 'O' ";

                    //Si hay que retornar los registros vigentes, filtro las vigencias, 
                    //sino cargo todo
                    if (registrosVigentes.Equals("S"))
                    {
                        selectFrom += "AND (FECHA_PER_HASTA IS NULL OR FECHA_PER_HASTA >= ? )";
                    }

                    selectFrom += "AND FECHA_VIG_HASTA IS NULL ";

                    db.CreateSQLCommand(selectFrom);

                    db.AddInParameter("PERS_IDENTIFICADOR_1", DbType.Int32, persIdentificador);
                    db.AddInParameter("PERS_IDENTIFICADOR_2", DbType.Int32, persIdentificador);

                    if (registrosVigentes.Equals("S"))
                    {
                        db.AddInParameter("FECHA_PER_HASTA", DbType.DateTime, co.FechaOpera.Date);
                    }

                    retorno = db.ExecuteReader();

                    return retorno;
                }
            }
        }

        [AutoComplete]
        public IDataReader DbObtenerPoderesApoderado(int persIdApoderlo, int? codPoder, int? codFacultad, string strEstado, DateTime? fechaPerHasta, object orderBy, Contexto co)
        {
            using (new Tracer(new object[] { persIdApoderlo, codPoder,  codFacultad, strEstado, fechaPerHasta, orderBy }, co))

            using (Database database = GetDatabase(co))
            {
                ParameterCollection selectColumns = new ParameterCollection(new string[] { "SEC_APODERADOS", "FECHA_VIG_DESDE", "PERS_IDENTIFICADOR_1", "PERS_IDENTIFICADOR_2", "COD_PODER", "ESTADO", "COD_VINCULO", "COD_FACULTAD", "COMENTARIOS", "FECHA_PER_DESDE", "FECHA_PER_HASTA", "FECHA_REN_REV", "FECHA_VIG_HASTA", "SUEP", "ITF", "UACT", "FACT" });

                ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();

                whereColumnsFilter.Add("PERS_IDENTIFICADOR_2", persIdApoderlo);


                if (codPoder != null)
                {
                    whereColumnsFilter.Add("COD_PODER", codPoder);
                }


                if (codFacultad != null)
                    whereColumnsFilter.Add("COD_FACULTAD", codFacultad);

                if (strEstado != null)
                {
                    whereColumnsFilter.Add("COD_VINCULO", strEstado);
                }

                if (fechaPerHasta != null)
                {
                    whereColumnsFilter.Add("FECHA_PER_HASTA", CompareOperator.GreaterThanEqual, fechaPerHasta, true);
                }
                whereColumnsFilter.Add("FECHA_VIG_DESDE", CompareOperator.LessThanEqual, co.FechaOpera);
                whereColumnsFilter.Add("FECHA_VIG_HASTA", CompareOperator.GreaterThanEqual, co.FechaOpera, true);

                OrderByCollection orderByCollection = new OrderByCollection(null);

                database.CreateSelectCommand("VS_RPR_APODERADOS_01", selectColumns, whereColumnsFilter, orderByCollection);
                IDataReader reader = database.ExecuteReader();
                return reader;
            }
        }
    }

    #endregion
}