// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 19/04/2020 12:09:47 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================

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


namespace Bull.PRES.Poderes.Mappers
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("afe36f40-b630-401e-bf0c-01118a84173b"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class MapErroresNegocio : MappersAbstract
    {
        [AutoComplete]
        public BusinessEntities.ErrorNegocio ObtenerErrorNegocio(int codError, Contexto co)
        {
            using (new Tracer(new object[] { codError }, co))
            {
                BusinessEntities.ErrorNegocio error = null;

                using (Dalcs.DbErroresNegocio db = new Dalcs.DbErroresNegocio())
                {
                    using (IDataReader reader = db.ObtVsRprErroresBenef02(codError, co))
                    {
                        while (reader.Read())
                        {
                            error = new BusinessEntities.ErrorNegocio();
                            error.Codigo = Convert.ToInt32(reader["COD_MENSAJE"]);
                            error.Descripcion = Convert.ToString(reader["TEXTO_MENSAJE"]);
                        }
                    }
                }

                return error;
            }
        }
    }
}

