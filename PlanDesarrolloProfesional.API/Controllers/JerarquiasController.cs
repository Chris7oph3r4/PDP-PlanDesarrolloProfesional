using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class JerarquiasController : ControllerBase
    {
        #region atributos

        private readonly IJerarquias _IJerarquias;

        #endregion atributos

        public JerarquiasController(IJerarquias IJerarquias)
        {
            _IJerarquias = IJerarquias;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<JerarquiasModel> Agregar(List<object> Modelo)
        {
            var Objeto = await _IJerarquias.Agregar(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<JerarquiasModel> Obtener(int IdJerarquias)
        {
            if (IdJerarquias == 0) throw new Exception("Código Nulo");
            var Modelo = await _IJerarquias.Obtener(IdJerarquias);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<JerarquiasModel>> Listar()
        {
            var Lista = await _IJerarquias.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<JerarquiasModel> Inactivar(int IdJerarquias)
        //{
        //    if (IdJerarquias == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IJerarquias.Inactivar(IdJerarquias);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<JerarquiasModel> Actualizar(List<object> Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IJerarquias.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IJerarquias.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdJerarquias, string nameclaim)
        {
            if (IdJerarquias == 0) throw new Exception("Código Nulo");
            var Modelo = await _IJerarquias.Eliminar(IdJerarquias, nameclaim);
            return Modelo;
        }
    }
}

