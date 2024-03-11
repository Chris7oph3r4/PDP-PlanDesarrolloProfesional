using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class RutaController : ControllerBase
    {
        #region atributos

        private readonly IRuta _IRuta;

        #endregion atributos

        public RutaController(IRuta IRuta)
        {
            _IRuta = IRuta;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<RutaModel> Agregar(List<object> Modelo)
        {
            var Objeto = await _IRuta.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<RutaModel> Obtener(int IdRuta)
        {
            if (IdRuta == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRuta.Obtener(IdRuta);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<RutaModel>> Listar()
        {
            var Lista = await _IRuta.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<RutaModel> Inactivar(int IdRuta)
        //{
        //    if (IdRuta == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IRuta.Inactivar(IdRuta);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<RutaModel> Actualizar(List<object> Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IRuta.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IRuta.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdRuta, string nameclaim)
        {
            if (IdRuta == 0) throw new Exception("Código Nulo");
            var Modelo = await _IRuta.Eliminar(IdRuta, nameclaim);
            return Modelo;
        }
    }
}

