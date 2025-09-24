// ===============================================================================
// Disclaimer: this class was created by DOMPRES\fmacri on 28/08/2019 02:39:52 PM
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

namespace Bull.PRES.Poderes.Dalcs
{
    [Transaction(TransactionOption.Supported)]
    [PrivateComponent, EventTrackingEnabled(true)]
    [Guid("b436583e-f420-4235-b60d-232c17ae1af7"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class DbParametrosGral : PresDALCAbstract
    {
        [AutoComplete]
        public IDataReader ObtValoresParametroGeneral(int? codParametro, string descAbreviada, int? codBeneficio, int? codTipoSolicitud, string[] orderBy, Contexto co)
        {
            using (new Tracer(new object[] { codParametro, descAbreviada, codBeneficio, codTipoSolicitud, orderBy }, co))
            {
                using (Database database = GetDatabase(co))
                {
                    ParameterCollection selectColumns = new ParameterCollection(new string[] {  "COD_PARAMETRO",
                                                                                                "DESCRIPCION",
                                                                                                "DESC_ABREVIADA",
                                                                                                "COD_BENEFICIO",
                                                                                                "COD_TIPO_SOLICITUD",
                                                                                                "HABILITADO",
                                                                                                "TIPO_DATO",
                                                                                                "VALOR" });

                    ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();

                    if (codParametro.HasValue)
                        whereColumnsFilter.Add("COD_PARAMETRO", codParametro.Value);

                    if (descAbreviada != null && !descAbreviada.Equals(string.Empty))
                        whereColumnsFilter.Add("DESC_ABREVIADA", descAbreviada);

                    if (codBeneficio.HasValue)
                        whereColumnsFilter.Add("COD_BENEFICIO", codBeneficio.Value);

                    if (codTipoSolicitud.HasValue)
                        whereColumnsFilter.Add("COD_TIPO_SOLICITUD", codTipoSolicitud.Value);

                    whereColumnsFilter.Add("FECHA_VIG_HASTA", null);

                    OrderByCollection orderByCollection = new OrderByCollection(orderBy);

                    database.CreateSelectCommand("VS_RPR_PARAM_GRALES_VALORES_01", selectColumns, whereColumnsFilter, orderByCollection);

                    IDataReader reader = database.ExecuteReader();

                    return reader;
                }
            }
        }
    }
}