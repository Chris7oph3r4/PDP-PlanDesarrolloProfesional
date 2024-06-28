using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class CumplimientoRequisitoController : ControllerBase
    {
        #region atributos

        private readonly ICumplimientoRequisito _ICumplimientoRequisito;

        #endregion atributos

        public CumplimientoRequisitoController(ICumplimientoRequisito ICumplimientoRequisito)
        {
            _ICumplimientoRequisito = ICumplimientoRequisito;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel Modelo)
        {
            var Objeto = await _ICumplimientoRequisito.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<CumplimientoRequisitoViewModel> Obtener(int IdCumplimientoRequisito)
        {
            if (IdCumplimientoRequisito == 0 || IdCumplimientoRequisito == null) throw new Exception("Código Nulo");
            var Modelo = await _ICumplimientoRequisito.Obtener(IdCumplimientoRequisito);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<CumplimientoRequisitoViewModel>> Listar()
        {
            var Lista = await _ICumplimientoRequisito.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        [HttpGet]
        [Route("ListarPorPlanDesarrolloID")]
        public async Task<ActionResult<IEnumerable<CumplimientoRequisitoViewModel>>> ListarPorPlanDesarrolloID(int planDesarrolloID, int colaboradorID, string rolID)
        {

            var Lista = await _ICumplimientoRequisito.ListarPorPlanDesarrolloID(planDesarrolloID, colaboradorID, rolID);
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Ok  (Lista);
        }
                [HttpGet]
        [Route("ObtenerAprobadosPorSupervisor")]
        public async Task<ActionResult<IEnumerable<CumplimientoRequisitoViewModel>>> ObtenerAprobadosPorSupervisor(int supervisorID)
        {

            var Lista = await _ICumplimientoRequisito.ObtenerAprobadosPorSupervisor(supervisorID);
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Ok  (Lista);
        }


        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<CumplimientoRequisitoModel> Inactivar(int IdCumplimientoRequisito)
        //{
        //    if (IdCumplimientoRequisito == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _ICumplimientoRequisito.Inactivar(IdCumplimientoRequisito);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _ICumplimientoRequisito.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _ICumplimientoRequisito.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            if (IdCumplimientoRequisito == 0) throw new Exception("Código Nulo");
            var Modelo = await _ICumplimientoRequisito.Eliminar(IdCumplimientoRequisito);
            return Modelo;
        }
    }
}
