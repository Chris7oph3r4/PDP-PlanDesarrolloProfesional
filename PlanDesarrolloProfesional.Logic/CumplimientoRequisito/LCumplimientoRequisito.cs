using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Interface;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Logic
{
    public class LCumplimientoRequisito : ICumplimientoRequisito
    {
        private DACumplimientoRequisito _DACumplimiento;

        public LCumplimientoRequisito()
        {
            _DACumplimiento = new DACumplimientoRequisito();
        }

        public async Task<CumplimientoRequisitoModel> Agregar(CumplimientoRequisitoModel modelo)
        {
            try
            {
                var respuesta = await _DACumplimiento.Agregar(modelo.ConvertBD());
                modelo = new CumplimientoRequisitoModel(respuesta);
                return modelo;
            }
            catch (Exception e)
            {
                // Manejo de errores
                return null;
            }
        }

        public async Task<CumplimientoRequisitoModel> Obtener(int IdCumplimientoRequisito)
        {
            try
            {
                var respuesta = await _DACumplimiento.Obtener(IdCumplimientoRequisito);
                var modelo = new CumplimientoRequisitoModel(respuesta);
                return modelo;
            }
            catch (Exception e)
            {
                // Manejo de errores
                return null;
            }
        }

        public async Task<IEnumerable<CumplimientoRequisitoModel>> Listar()
        {
            try
            {
                var lista = await _DACumplimiento.Listar();
                var listaModelo = lista.Select(c => new CumplimientoRequisitoModel(c)).ToList();
                return listaModelo;
            }
            catch (Exception e)
            {
                // Manejo de errores
                return new List<CumplimientoRequisitoModel>().AsEnumerable();
            }
        }

        public async Task<CumplimientoRequisitoModel> Actualizar(CumplimientoRequisitoModel modelo)
        {
            try
            {
                var respuesta = await _DACumplimiento.Actualizar(modelo.ConvertBD());
                modelo = new CumplimientoRequisitoModel(respuesta);
                return modelo;
            }
            catch (Exception e)
            {
                // Manejo de errores
                return null;
            }
        }

        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            try
            {
                bool resultado = await _DACumplimiento.Eliminar(IdCumplimientoRequisito);
                return resultado;
            }
            catch (Exception e)
            {
                // Manejo de errores
                return false;
            }
        }
    }
}
