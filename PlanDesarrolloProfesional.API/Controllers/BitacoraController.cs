using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/")]
    public class BitacoraController : ControllerBase
    {
        #region atributos

        private readonly IBitacora _IBitacora;

        #endregion atributos

        public BitacoraController(IBitacora IBitacora)
        {
            _IBitacora = IBitacora;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<BitacoraModel>> Listar()
        {
            var Lista = await _IBitacora.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }
    }
}
