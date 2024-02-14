using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class UsuarioController : Controller
    {
        #region atributos

        private readonly IUsuario _IUsuario;

        #endregion atributos

        public UsuarioController(IUsuario IUsuario)
        {
            _IUsuario = IUsuario;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<UsuarioModel> Agregar(UsuarioModel Modelo)
        {
            var Objeto = await _IUsuario.Agregar(Modelo);
            return Objeto;
        }
        [HttpPost]
        [Route("AgregarViewModel")]
        public async Task<UsuarioAgregarViewModel> AgregarViewModel(UsuarioAgregarViewModel Modelo)
        {
            var Objeto = await _IUsuario.AgregarUsuarioAreaJerarquia(Modelo);
            return Objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<UsuarioModel> Obtener(int IdUsuario)
        {
            if (IdUsuario == 0) throw new Exception("Código Nulo");
            var Modelo = await _IUsuario.Obtener(IdUsuario);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<UsuarioModel>> Listar()
        {
            var Lista = await _IUsuario.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }
        [HttpGet]
        [Route("ListarVM")]
        public async Task<IEnumerable<UsuarioViewModel>> ListarVM()
        {
            var Lista = await _IUsuario.ListarVM();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }


        //[HttpGet]
        //[Route("Inactivar")]
        //public async Task<UsuarioModel> Inactivar(int IdUsuario)
        //{
        //    if (IdUsuario == 0) throw new Exception("Código Nulo");
        //    var Modelo = await _IUsuario.Inactivar(IdUsuario);
        //    return Modelo;
        //}

        [HttpPost]
        [Route("Actualizar")]
        public async Task<UsuarioModel> Actualizar(UsuarioModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IUsuario.Actualizar(Modelo);
            return ModeloActualizado;
        }

        //[HttpGet]
        //[Route("ListarPorUsuario")]
        //public async Task<IEnumerable<UsuarioViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    var Lista = await _IUsuario.ListarPorUsuario(IdUsuario);
        //    if (Lista == null) throw new Exception("Modelo Nulo");

        //    return Lista;
        //}


        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdUsuario)
        {
            if (IdUsuario == 0) throw new Exception("Código Nulo");
            var Modelo = await _IUsuario.Eliminar(IdUsuario);
            return Modelo;
        }
    }
}
