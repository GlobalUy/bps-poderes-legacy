// ===============================================================================
// Disclaimer: this class was created by DOMPRES\sbeguiristain on 09/06/2020 10:51:26
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================

using System;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Text;

using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Comunes.DALCS;
using Bull.Seguridad.BusinessEntity;

namespace Bull.PRES.Poderes
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [PrivateComponent, EventTrackingEnabled(true)]
    [Guid("9d70f39a-6c80-4ab3-9343-3c9bc4dcd2b7"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class DbApoderadosOrigen : PresDALCAbstract
    {
        [AutoComplete()]
        public void AgrRprApoderadosOrigen(int secApoderados, DateTime fechaVigDesde, string codOrigenPoder, Contexto co)
        {
            try
            {
                using (new Tracer(new object[] { secApoderados, fechaVigDesde, codOrigenPoder }, co))
                {
                    using (Database database = GetDatabase(co))
                    {
                        ParameterCollection insertValues = new ParameterCollection();
                        insertValues.Add("SEC_APODERADOS", secApoderados);
                        insertValues.Add("A_FECHA_VIG_DESDE", fechaVigDesde);
                        insertValues.Add("COD_ORIGEN_PODER", codOrigenPoder.ToUpper());
                        insertValues.Add("ITF", null);
                        insertValues.Add("UACT", co.UsuarioActual);
                        insertValues.Add("FACT", co.FechaOpera);
                        insertValues.Add("NRO_SESION", null);

                        database.CreateInsertCommand("RPR_APODERADOS_ORIGEN", insertValues);
                        database.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex, co); throw;
            }
        }

        [AutoComplete()]
        public IDataReader ObtConfigIngresoPoderes(int? codPoder, int? codFacultad, string codOrigenPoder, string[] orderBy, Contexto co)
        {
            try
            {
                using (new Tracer(new object[] { codPoder, codFacultad, codOrigenPoder, orderBy }, co))
                {
                    using (Database database = GetDatabase(co))
                    {
                        ParameterCollection selectColumns = new ParameterCollection(new string[] { "COD_PODER", "COD_FACULTAD", "FECHA_VIG_DESDE", "COD_ORIGEN_PODER", "PLAZO", "UNIDAD_PLAZO", "PODER_INCOMP", "FACULTAD_INCOMP", "PER_COMPATIBLE", "UNIDAD_PER_COMPATIBLE", "ITF", "UACT", "FACT", "NRO_SESION" });

                        ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();
                        if (codPoder != null)
                        {
                            whereColumnsFilter.Add("COD_PODER", CompareOperator.Equal, codPoder);
                        }
                        if (codFacultad != null)
                        {
                            whereColumnsFilter.Add("COD_FACULTAD", CompareOperator.Equal, codFacultad);
                        }
                        if (codOrigenPoder != null)
                        {
                            whereColumnsFilter.Add("COD_ORIGEN_PODER", CompareOperator.Equal, codOrigenPoder, true);
                        }

                        whereColumnsFilter.Add("FECHA_VIG_DESDE", CompareOperator.LessThanEqual, co.FechaOpera);

                        OrderByCollection orderByCollection = new OrderByCollection(orderBy);

                        database.CreateSelectCommand("VS_RPR_CONFIG_INGRESO_PODER_01", selectColumns, whereColumnsFilter, orderByCollection);
                        IDataReader reader = database.ExecuteReader();
                        return reader;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex, co); throw;
            }
        }

        [AutoComplete()]
        public IDataReader ObtOrigenesPoderes(string codOrigenPoder, string[] orderBy, Contexto co)
        {
            try
            {
                using (new Tracer(new object[] { codOrigenPoder, orderBy }, co))
                {
                    using (Database database = GetDatabase(co))
                    {
                        ParameterCollection selectColumns = new ParameterCollection(new string[] { "COD_ORIGEN_PODER", "DESCRIPCION", "ITF", "UACT", "FACT", "NRO_SESION" });

                        ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();
                        whereColumnsFilter.Add("COD_ORIGEN_PODER", CompareOperator.Equal, codOrigenPoder.ToUpper());

                        OrderByCollection orderByCollection = new OrderByCollection(orderBy);

                        database.CreateSelectCommand("VS_RPR_COD_ORIGENES_PODERES_01", selectColumns, whereColumnsFilter, orderByCollection);
                        IDataReader reader = database.ExecuteReader();
                        return reader;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.HandleException(ex, co); throw;
            }
        }
    }
}

