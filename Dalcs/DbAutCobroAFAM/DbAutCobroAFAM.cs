// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 07/08/2008 03:58:37 p.m.
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
#endregion 

namespace Bull.PRES.Poderes.Dalcs
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [PrivateComponent, EventTrackingEnabled(true), JustInTimeActivation(true)]
    [Guid("3677a585-b741-4e58-a67d-fc1d7aa40416"), ClassInterface(ClassInterfaceType.AutoDual)]
	public class DbAutCobroAFAM : PresDALCAbstract
    {

        #region ObtApoderado
        [AutoComplete()]
        public IDataReader ObtApoderado(int persIdPoderdante, int? persIdentificadorApo, DateTime? fechaPerDesde, ParamDb<int?> zona, DateTime? fechaRevocacion, DateTime? fechaPerHasta, string[] orderBy, Contexto co)
        {
            using (new Tracer(new object[] { persIdPoderdante, persIdentificadorApo, fechaPerDesde, zona, fechaRevocacion, fechaPerHasta, orderBy }, co))
            {
                using (Database database = GetDatabase(co))
                {
                    ParameterCollection selectColumns = new ParameterCollection(new string[] { "PERS_IDENTIFICADOR_1", "FECHA_VIG_DESDE", "PERS_IDENTIFICADOR_2", "FECHA_PER_DESDE", "ZONA", "COMENTARIOS", "FECHA_REVOCACION", "FECHA_PER_HASTA", "FECHA_VIG_HASTA", "ITF", "UACT", "FACT", "NRO_SESION" });

                    ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();

                
                    whereColumnsFilter.Add("PERS_IDENTIFICADOR_1", persIdPoderdante);

                    if (persIdentificadorApo != null)
                    {
                        whereColumnsFilter.Add("PERS_IDENTIFICADOR_2", persIdentificadorApo);
                    }
                    if (fechaPerDesde != null)
                    {
                        whereColumnsFilter.Add("FECHA_PER_DESDE", CompareOperator.LessThanEqual, fechaPerDesde);
                    }
                    if (zona != null)
                    {
                        whereColumnsFilter.Add("ZONA", zona);
                    }
                    if (fechaRevocacion != null)
                    {
                        whereColumnsFilter.Add("FECHA_REVOCACION", CompareOperator.LessThanEqual, fechaRevocacion);
                    }
                    else 
                    {
                        whereColumnsFilter.Add("FECHA_REVOCACION", DBNull.Value);
                    }
                    if (fechaPerHasta != null)
                    {
                        whereColumnsFilter.Add("FECHA_PER_HASTA", CompareOperator.GreaterThanEqual, fechaPerHasta,true);
                    }
                    whereColumnsFilter.Add("FECHA_VIG_DESDE", CompareOperator.LessThanEqual, co.FechaOpera);
                    whereColumnsFilter.Add("FECHA_VIG_HASTA", CompareOperator.GreaterThanEqual, co.FechaOpera, true);

                    OrderByCollection orderByCollection = new OrderByCollection(orderBy);

                    database.CreateSelectCommand("VS_RPR_AUT_COBRO_AFAM_01", selectColumns, whereColumnsFilter, orderByCollection);
                    IDataReader reader = database.ExecuteReader();
                    return reader;
                }
            }
        }
        #endregion 

    }
}
