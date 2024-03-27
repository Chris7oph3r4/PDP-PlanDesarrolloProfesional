using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DACumplimientoRequisito
    {
        public DACumplimientoRequisito()
        {

        }

        public async Task<CumplimientoRequisito> Agregar(CumplimientoRequisito modelo)
        {
            using (var contextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    var agregarObjeto = contextoBD.Add(modelo);
                    await contextoBD.SaveChangesAsync();
                    return modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task<CumplimientoRequisito> Obtener(int IdCumplimientoRequisito)
        {
            try
            {
                using (var contextoBD = new PlanDesarrolloProfesionalContext())
                {
                    CumplimientoRequisito SolicitudesBD = await contextoBD.CumplimientoRequisito
                        .FirstOrDefaultAsync(s => s.CumplimientoRequisitoID == IdCumplimientoRequisito);
                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<CumplimientoRequisito>> Listar()
        {
            using (var contextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<CumplimientoRequisito> lista = await contextoBD.CumplimientoRequisito.ToListAsync();
                    return lista;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task<CumplimientoRequisito> Actualizar(CumplimientoRequisito modelo)
        {
            using (var contextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    contextoBD.Entry(modelo).State = EntityState.Modified;
                    await contextoBD.SaveChangesAsync();
                    return modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            try
            {
                using (var contextoBD = new PlanDesarrolloProfesionalContext())
                {
                    var cumplimiento = await contextoBD.CumplimientoRequisito
                        .Include(c => c.PlanDesarrollo) // Asegúrate de que esta propiedad de navegación exista y esté correctamente configurada
                        .FirstOrDefaultAsync(c => c.CumplimientoRequisitoID == IdCumplimientoRequisito);

                    if (cumplimiento != null && cumplimiento.PlanDesarrollo != null)
                    {
                        // Aquí actualizas el estado del plan de desarrollo profesional asociado
                        cumplimiento.PlanDesarrollo.Estado = 1; // Asumiendo que 'Estado' es un campo que indica si el plan está activo o no
                        contextoBD.Entry(cumplimiento.PlanDesarrollo).State = EntityState.Modified;

                        await contextoBD.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }




}
}
