using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class AreaController : ControllerBase
    {
        #region atributos

        private readonly IArea _IArea;

        #endregion atributos

        public AreaController(IArea IArea)
        {
            _IArea = IArea;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<AreaModel> Agregar(AreaModel Modelo)
        {
            var Objeto = await _IArea.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<AreaModel> Obtener(int IdArea)
        {
            if (IdArea == 0) throw new Exception("Código Nulo");
            var Modelo = await _IArea.Obtener(IdArea);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<AreaModel>> Listar()
        {
            var Lista = await _IArea.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<AreaModel> Inactivar(int IdArea)
        //{
        //    if (IdArea == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IArea.Inactivar(IdArea);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<AreaModel> Actualizar(AreaModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IArea.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IArea.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdArea)
        {
            if (IdArea == 0) throw new Exception("Código Nulo");
            var Modelo = await _IArea.Eliminar(IdArea);
            return Modelo;
        }
    }
}
