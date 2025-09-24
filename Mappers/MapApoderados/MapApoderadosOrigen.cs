using Bull.PRES.Poderes;
using Bull.PRES.Poderes.BusinessEntities;
// ===============================================================================
// Disclaimer: this class was created by DOMPRES\sbeguiristain on 09/06/2020 10:59:24
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
    [Guid("4bc1d020-097f-433e-8d95-0eb3a7e90ee6"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class MapApoderadosOrigen : MappersAbstract
    {
        [AutoComplete(true)]
        public void AgrRprApoderadosOrigen(int secApoderados, DateTime fechaVigDesde, string codOrigenPoder, Contexto co)
        {
            using (new Tracer(new object[] { secApoderados, fechaVigDesde, codOrigenPoder }, co))
            {
                using (DbApoderadosOrigen db = new DbApoderadosOrigen())
                {
                    db.AgrRprApoderadosOrigen(secApoderados, fechaVigDesde, codOrigenPoder, co);

                }
            }
        }

        [AutoComplete(true)]
        public List<ConfigIngresoPoder> ObtConfigIngresoPoderes(int? codPoder, int? codFacultad, string codOrigenPoder, Contexto co)
        {
            using (new Tracer(new object[] { codPoder, codFacultad, codOrigenPoder }, co))
            {
                List<ConfigIngresoPoder> list = new List<ConfigIngresoPoder>();
                using (DbApoderadosOrigen db = new DbApoderadosOrigen())
                {
                    using (IDataReader reader = db.ObtConfigIngresoPoderes(codPoder, codFacultad, codOrigenPoder, null, co))
                    {
                        list = Utils.GetListFromDataReader<ConfigIngresoPoder>(reader);
                    }
                }
                return list;
            }
        }

        [AutoComplete(true)]
        public List<OrigenPoder> ObtOrigenesPoderes(string codOrigenPoder, Contexto co)
        {
            using (new Tracer(new object[] { codOrigenPoder }, co))
            {
                List<OrigenPoder> list;
                using (DbApoderadosOrigen db = new DbApoderadosOrigen())
                {
                    using (IDataReader reader = db.ObtOrigenesPoderes(codOrigenPoder, null, co))
                    {
                        list = Utils.GetListFromDataReader<OrigenPoder>(reader);
                    }
                }
                return list;
            }
        }
    }
}

