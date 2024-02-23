using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class RequisitoController : ControllerBase
    {
        #region atributos

        private readonly IRequisito _IRequisito;

        #endregion atributos

        public RequisitoController(IRequisito IRequisito)
        {
            _IRequisito = IRequisito;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<RequisitoModel> Agregar(RequisitoModel Modelo)
        {
            var Objeto = await _IRequisito.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<RequisitoModel> Obtener(int IdRequisito)
        {
            if (IdRequisito == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRequisito.Obtener(IdRequisito);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<RequisitoModel>> Listar()
        {
            var Lista = await _IRequisito.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<RequisitoModel> Inactivar(int IdRequisito)
        //{
        //    if (IdRequisito == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IRequisito.Inactivar(IdRequisito);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<RequisitoModel> Actualizar(RequisitoModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IRequisito.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IRequisito.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdRequisito)
        {
            if (IdRequisito == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRequisito.Eliminar(IdRequisito);
            return Modelo;
        }
    }
}
