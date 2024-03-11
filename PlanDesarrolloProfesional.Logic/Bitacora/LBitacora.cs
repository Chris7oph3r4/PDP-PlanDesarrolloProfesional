using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using PlanDesarRutaloProfesional.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Logic
{
    public class LBitacora : IBitacora
    {
        private DABitacora _DABitacora;


        public LBitacora(IConfiguration configuration)
        {
            _DABitacora = new DABitacora();

        }
        public async Task<IEnumerable<BitacoraModel>> Listar()
        {
            try
            {
                var ListaObjetoBD = await _DABitacora.Listar();
                IEnumerable<BitacoraModel> ListaRespuestaModel = ListaObjetoBD.Select(ObjetoBD => new BitacoraModel(ObjetoBD)).ToList();

                return ListaRespuestaModel;
            }
            catch (Exception e)
            {
                //await LRegistro_Error.AgregarInterno(e.ToString(), "", e.InnerException != null ? e.InnerException.HResult.ToString() : "", "0");

                return new List<BitacoraModel>().AsEnumerable();
            }
        }
    }
}
