using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class RangoController : ControllerBase
    {
        #region atributos

        private readonly IRango _IRango;

        #endregion atributos

        public RangoController(IRango IRango)
        {
            _IRango = IRango;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<RangoModel> Agregar(RangoModel Modelo)
        {
            var Objeto = await _IRango.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<RangoModel> Obtener(int IdRango)
        {
            if (IdRango == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRango.Obtener(IdRango);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<RangoModel>> Listar()
        {
            var Lista = await _IRango.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<RangoModel> Inactivar(int IdRango)
        //{
        //    if (IdRango == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IRango.Inactivar(IdRango);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<RangoModel> Actualizar(RangoModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IRango.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IRango.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdRango)
        {
            if (IdRango == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRango.Eliminar(IdRango);
            return Modelo;
        }
    }
}

