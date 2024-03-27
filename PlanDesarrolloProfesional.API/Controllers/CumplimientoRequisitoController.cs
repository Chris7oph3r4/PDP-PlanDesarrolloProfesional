using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;

namespace PlanDesarrolloProfesional.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CumplimientoRequisitoController : ControllerBase
    {
        private readonly ICumplimientoRequisito _ICumplimientoRequisito;

        public CumplimientoRequisitoController(ICumplimientoRequisito ICumplimientoRequisito)
        {
            _ICumplimientoRequisito = ICumplimientoRequisito;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel modelo)
        {
            
            var objeto = await _ICumplimientoRequisito.Agregar(modelo);
            return objeto;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<CumplimientoRequisitoModel> Obtener(int IdCumplimientoRequisito)
        {
            if (IdCumplimientoRequisito == 0 || IdCumplimientoRequisito == null) throw new Exception("Codigo Nulo");
            var modelo = await _ICumplimientoRequisito.Obtener(IdCumplimientoRequisito);     
            return modelo;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<CumplimientoRequisitoModel>> Listar()
        {
            var lista = await _ICumplimientoRequisito.Listar();
            if (lista == null) throw new Exception("Modelo Nulo");
            return lista;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo)
        {
            if (modelo == null) throw new Exception ("Modelo nulo");
            var modeloActualizado = await _ICumplimientoRequisito.Actualizar(modelo);
            return modeloActualizado;
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            if (IdCumplimientoRequisito <= 0) throw new Exception("ID inválido");
            var resultado = await _ICumplimientoRequisito.Eliminar(IdCumplimientoRequisito);
            return resultado;
        }
    }
}
