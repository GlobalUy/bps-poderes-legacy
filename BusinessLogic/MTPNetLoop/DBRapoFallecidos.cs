using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework.Legacy;
using Bull.Comunes.DALCS;
using Bull.Seguridad.BusinessEntity;
using Bull.ApplicationFramework;
using System.Data;
using Bull.ApplicationFramework.Diagnostics;

namespace Bull.PRES.Poderes.BusinessLogic
{
    [Transaction(TransactionOption.NotSupported)]
    [EventTrackingEnabled(true)]
    [Guid("60E4395C-6D79-492F-837A-76A2E996792D"), ClassInterface(ClassInterfaceType.AutoDual)]
    [JustInTimeActivation(true)]
    public class DBRapoFallecidos: PresDALCAbstract 
    {

        [AutoComplete()]
        public IDataReader  fnarr2ObtPoderesFallecidos([DefaultParameterValue("")] [Optional] object arr1OrderBy, Contexto co)
        {
            using (new Tracer(new object[] { arr1OrderBy , co }, co))
            {
                object[,] parr2Datos = new object[1, 1];

                //string strDummy;
                object arr1Campos;
                //object plngrecordcount;

                arr1Campos = VB60Utils.CreateArray("APO_SEC_APODERADOS", "APO_FECHA_VIG_DESDE", "APO_PERS_IDENTIFICADOR_1", "APO_PERS_IDENTIFICADOR_2", "APO_COD_PODER", "APO_ESTADO", "APO_COD_VINCULO", "APO_COD_FACULTAD", "APO_COMENTARIOS", "APO_FECHA_PER_DESDE", "APO_FECHA_PER_HASTA", "APO_FECHA_REN_REV", "APO_FECHA_VIG_HASTA", "APO_SUEP", "APO_ITF", "APO_UACT", "APO_FACT", "CUR_SEC_APODERADOS", "CUR_FECHA_VIG_DESDE", "CUR_TIPO_CURATELA", "CUR_FECHA_VIG_HASTA", "CUR_ITF", "CUR_UACT", "CUR_FACT");
                Database database = GetDatabase(Convert.ToString(co.UsuarioActual ), co.Debug );
                try
                {

                    database.CreateStoreProcedureCommand("K_RPR_PODERES_FALLECIDOS.P_PODERES_FALLECIDOS", 67000);

                    database.AddOutParameter("APO_SEC_APODERADOS", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_FECHA_VIG_DESDE", System.Data.DbType.DateTime);
                    database.AddOutParameter("APO_PERS_IDENTIFICADOR_1", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_PERS_IDENTIFICADOR_2", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_COD_PODER", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_ESTADO", System.Data.DbType.String, 1);
                    database.AddOutParameter("APO_COD_VINCULO", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_COD_FACULTAD", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_COMENTARIOS", System.Data.DbType.String, 250);
                    database.AddOutParameter("APO_FECHA_PER_DESDE", System.Data.DbType.DateTime);
                    database.AddOutParameter("APO_FECHA_PER_HASTA", System.Data.DbType.DateTime);
                    database.AddOutParameter("APO_FECHA_REN_REV", System.Data.DbType.DateTime);
                    database.AddOutParameter("APO_FECHA_VIG_HASTA", System.Data.DbType.DateTime);
                    database.AddOutParameter("APO_SUEP", System.Data.DbType.String, 1);
                    database.AddOutParameter("APO_ITF", System.Data.DbType.Int32);
                    database.AddOutParameter("APO_UACT", System.Data.DbType.String, 30);
                    database.AddOutParameter("APO_FACT", System.Data.DbType.DateTime);
                    database.AddOutParameter("CUR_SEC_APODERADOS", System.Data.DbType.Int32);
                    database.AddOutParameter("CUR_FECHA_VIG_DESDE", System.Data.DbType.DateTime);
                    database.AddOutParameter("CUR_TIPO_CURATELA", System.Data.DbType.Int32);
                    database.AddOutParameter("CUR_FECHA_VIG_HASTA", System.Data.DbType.DateTime);
                    database.AddOutParameter("CUR_ITF", System.Data.DbType.Int32);
                    database.AddOutParameter("CUR_UACT", System.Data.DbType.String, 30);
                    database.AddOutParameter("CUR_FACT", System.Data.DbType.DateTime);


                    database.ExecuteNonQuery();

                    DataView dv = database.GetResult(arr1Campos, arr1OrderBy);
                    //return Utils.GetComFromDataView(dv);
                    IDataReader dtreader = dv.ToTable().CreateDataReader();

                    return dtreader;


                }
                catch (Exception ex)
                {
                    Utils.ThrowException(ex, TracePolicy.DbPolicy, System.Reflection.MethodBase.GetCurrentMethod(), co.UsuarioActual ,co.Debug );
                    throw;
                }
                finally
                {
                    Utils.LogFinally(TracePolicy.DbPolicy, System.Reflection.MethodBase.GetCurrentMethod(), co.UsuarioActual , co.Debug );
                    database.Dispose();
                }
            }
        }
    }
}
