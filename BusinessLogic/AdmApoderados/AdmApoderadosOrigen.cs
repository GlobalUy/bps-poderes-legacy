// ===============================================================================
// Disclaimer: this class was created by DOMPRES\sbeguiristain on 09/06/2020 11:06:11
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================


using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Collections.Generic;

using Bull.ApplicationFramework;
using Bull.Comunes.BusinessLogic;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Poderes.Mappers;
using Bull.PRES.Poderes.BusinessEntities;


namespace Bull.PRES.Poderes.BusinessLogic
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("47da4c0d-9538-4568-bff7-5e25f7a191f7"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class AdmApoderadosOrigen : BusinessLogicAbstract
    {

        [AutoComplete]
        public void AgrRprApoderadosOrigen(int secApoderados, DateTime fechaVigDesde, string codOrigenPoder, Contexto co)
        {
            using (new Tracer(new object[] { secApoderados, fechaVigDesde, codOrigenPoder }, co))
            {
                using (MapApoderadosOrigen map = new MapApoderadosOrigen())
                {
                    map.AgrRprApoderadosOrigen(secApoderados, fechaVigDesde, codOrigenPoder, co);
                }
            }
        }

        [AutoComplete()]
        public List<ConfigIngresoPoder> ObtConfigIngresoPoderes(int? codPoder, int? codFacultad, string codOrigenPoder, Contexto co)
        {
            using (new Tracer(new object[] { codPoder, codFacultad, codOrigenPoder }, co))
            {
                using (MapApoderadosOrigen map = new MapApoderadosOrigen())
                {
                    return map.ObtConfigIngresoPoderes(codPoder, codFacultad, codOrigenPoder, co);
                }
            }
        }

        [AutoComplete()]
        public List<OrigenPoder> ObtOrigenesPoderes(string codOrigenPoder, Contexto co)
        {
            using (new Tracer(new object[] { codOrigenPoder }, co))
            {
                using (MapApoderadosOrigen map = new MapApoderadosOrigen())
                {
                    return map.ObtOrigenesPoderes(codOrigenPoder, co);
                }
            }
        }
    }
}