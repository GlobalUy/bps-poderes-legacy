// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 19/04/2020 12:13:31 p.m.
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
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [PrivateComponent, EventTrackingEnabled(true)]
    [Guid("977e82f2-9619-4ff9-a3eb-b3193a0de458"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class DbErroresNegocio : PresDALCAbstract
    {
        [AutoComplete()]
        public IDataReader ObtVsRprErroresBenef02(int codMensaje, Contexto co)
        {
            using (new Tracer(new object[] { codMensaje }, co))
            {
                using (Database database = GetDatabase(co))
                {
                    ParameterCollection selectColumns = new ParameterCollection(new string[] { "COD_MENSAJE", "TEXTO_MENSAJE", "CATEGORIA_MENSAJE", "AUTORIZABLE", "ITF", "UACT", "FACT" });

                    ParameterFilterCollection whereColumnsFilter = new ParameterFilterCollection();
                    whereColumnsFilter.Add("COD_MENSAJE", codMensaje);

                    OrderByCollection orderByCollection = new OrderByCollection();

                    database.CreateSelectCommand("RPR_MENSAJES_ERROR", selectColumns, whereColumnsFilter, orderByCollection);
                    IDataReader reader = database.ExecuteReader();
                    return reader;
                }
            }
        }
    }
}

