using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlanDesarrolloProfesionalController : ControllerBase
    {
        #region atributos

        private readonly IPlanDesarrolloProfesional _IPlanDesarrollo;

        #endregion atributos


        public PlanDesarrolloProfesionalController(IPlanDesarrolloProfesional IPlanDesarrollo)
        {
            _IPlanDesarrollo = IPlanDesarrollo;
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<PlanesDesarrolloProfesionalModel> Agregar(PlanesDesarrolloProfesionalModel Modelo)
        {
            var Objeto = await _IPlanDesarrollo.Agregar(Modelo);
            return Objeto;
        }
        [HttpGet]
        [Route("Obtener")]
        public async Task<PlanDesarrolloProfesionalViewModel> Obtener(int IdPlan)
        {
            if (IdPlan == 0 || IdPlan == null) throw new Exception("Código Nulo");
            var Modelo = await _IPlanDesarrollo.Obtener(IdPlan);
            return Modelo;
        }
        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> Listar()
        {
            var Lista = await _IPlanDesarrollo.Listar();
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<PlanesDesarrolloProfesionalModel> Actualizar(PlanesDesarrolloProfesionalModel Modelo)
        {
            if (Modelo == null) throw new Exception("Modelo Nulo");
            var ModeloActualizado = await _IPlanDesarrollo.Actualizar(Modelo);
            return ModeloActualizado;
        }
        [HttpGet]
        [Route("Eliminar")]
        public async Task<bool> Eliminar(int IdPlan)
        {
            if (IdPlan == 0) throw new Exception("Código Nulo");
            var Modelo = await _IPlanDesarrollo.Eliminar(IdPlan);
            return Modelo;
        }

        [HttpGet]
        [Route("ObtenerCantidadPlanesPorUsuario")]
        public async Task<int> ObtenerCantidadPlanesPorUsuario(int idUsuario)
        {
            if (idUsuario == 0) throw new Exception("Id de usuario nulo");

            return await _IPlanDesarrollo.ObtenerCantidadPlanesPorUsuario(idUsuario);
        }

        [HttpGet]
        [Route("ObtenerUltimoRangoPorColaborador")]
        public async Task<string> ObtenerUltimoRangoPorColaborador(int colaboradorId)
        {
            if (colaboradorId == 0) throw new Exception("Id de usuario nulo");

            return await _IPlanDesarrollo.ObtenerUltimoRangoPorColaborador(colaboradorId);
        }


        [HttpGet]
        [Route("ContarPlanesFinalizadosPorColaborador")]
        public async Task<int> ContarPlanesFinalizadosPorColaborador(int colaboradorId)
        {
            if (colaboradorId == 0) throw new Exception("Id de usuario nulo");

            return await _IPlanDesarrollo.ContarPlanesFinalizadosPorColaborador(colaboradorId);
        }


        [HttpGet]
        [Route("ObtenerPlanesPorColaborador")]
        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> ObtenerPlanesPorColaborador(int colaboradorId)
        {
            var Lista = await _IPlanDesarrollo.ObtenerPlanesPorColaborador(colaboradorId);
            if (Lista == null) throw new Exception("Modelo Nulo");

            return Lista;
        }

        [HttpGet]
        [Route("ObtenerNombreRutaPorColaboradorId")]
        public async Task<string> ObtenerNombreRutaPorColaboradorId(int colaboradorId)
        {
            if (colaboradorId == 0) throw new Exception("Id de usuario nulo");

            return await _IPlanDesarrollo.ObtenerNombreRutaPorColaboradorId(colaboradorId);
        }
    }
}
