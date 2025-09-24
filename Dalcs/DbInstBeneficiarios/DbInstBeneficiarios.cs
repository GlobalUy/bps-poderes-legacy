// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 07/08/2008 04:38:48 p.m.
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
    [Guid("077c3c8e-c0bd-4234-ba56-fc5cdda53bcf"), ClassInterface(ClassInterfaceType.AutoDual)]
	public class DbInstBeneficiarios : PresDALCAbstract
    {

        #region ObtApoderado
        [AutoComplete()]
        public IDataReader ObtApoderado(int persIdentificadorBen, int? persIdentificadorApo, int?[] codFacultad, string[] orderBy, Contexto co)
        {
            using (new Tracer(new object[] { persIdentificadorBen, persIdentificadorApo, codFacultad, orderBy }, co))
            {
                using (Database database = GetDatabase(co))
                {
                    ParameterCollection selectColumns = new ParameterCollection(new string[] { "SEC_INSTITUTO", "PERS_IDENTIFICADOR_APO", "PERS_IDENTIFICADOR_BEN", "FECHA_VIG_DESDE", "FECHA_VIG_DESDE_APO", "COD_FACULTAD", "FECHA_VIG_HASTA", "ITF", "UACT", "FACT", "NRO_SESION" });

                    ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();

                    if (persIdentificadorApo != null)
                    {
                        whereColumnsFilter.Add("PERS_IDENTIFICADOR_APO", persIdentificadorApo);
                    }
                    whereColumnsFilter.Add("PERS_IDENTIFICADOR_BEN", persIdentificadorBen);
                    whereColumnsFilter.Add("COD_FACULTAD", codFacultad);
                    whereColumnsFilter.Add("FECHA_VIG_DESDE", CompareOperator.LessThanEqual, co.FechaOpera);
                    whereColumnsFilter.Add("FECHA_VIG_HASTA", CompareOperator.GreaterThanEqual, co.FechaOpera, true);

                    OrderByCollection orderByCollection = new OrderByCollection(orderBy);

                    database.CreateSelectCommand("VS_RPR_INST_BENEFICIARIOS_01", selectColumns, whereColumnsFilter, orderByCollection);
                    IDataReader reader = database.ExecuteReader();
                    return reader;
                }
            }
        }
        #endregion 

    }
}
