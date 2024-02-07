using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class RolController : ControllerBase
    {
        #region atributos

        private readonly IRol _IRol;

        #endregion atributos

        public RolController(IRol IRol)
        {
            _IRol = IRol;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<RolModel> Agregar(RolModel Modelo)
        {
            var Objeto = await _IRol.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<RolModel> Obtener(int IdRol)
        {
            if (IdRol == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRol.Obtener(IdRol);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<RolModel>> Listar()
        {
            var Lista = await _IRol.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<RolModel> Inactivar(int IdRol)
        //{
        //    if (IdRol == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IRol.Inactivar(IdRol);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<RolModel> Actualizar(RolModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IRol.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IRol.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdRol)
        {
            if (IdRol == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRol.Eliminar(IdRol);
            return Modelo;
        }
    }
}

