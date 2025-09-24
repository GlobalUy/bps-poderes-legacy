// ===============================================================================
// Disclaimer: this class was created by DOMPRES\fmacri on 28/08/2019 02:42:15 PM
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
using Bull.PRES.Poderes.BusinessEntities;
using Bull.PRES.Poderes.Dalcs;

namespace Bull.PRES.Poderes.Mappers
{
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("12ac4d25-ee9a-41f8-b202-0fcac5ffa2ac"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class MapParametrosGral : MappersAbstract
    {
        [AutoComplete]
        public List<ParametrosGenerales> ObtValoresParametroGeneral(int? codParametro, string descAbreviada, int? codBeneficio, int? codTipoSolicitud, Contexto co)
        {
            using (new Tracer(new object[] { codParametro, descAbreviada, codBeneficio, codTipoSolicitud }, co))
            {
                List<ParametrosGenerales> list;

                using (DbParametrosGral db = new DbParametrosGral())
                {
                    using (IDataReader reader = db.ObtValoresParametroGeneral(codParametro, descAbreviada, codBeneficio, codTipoSolicitud, null, co))
                    { list = Utils.GetListFromDataReader<ParametrosGenerales>(reader); }
                }

                return list;
            }
        }
    }
}