using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DABitacora
    {
        public DABitacora() { }

        public async Task<Bitacora> Agregar(Bitacora Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    var AgregarObjeto = ContextoBD.Add(Modelo);
                    await ContextoBD.SaveChangesAsync();
                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async Task<IEnumerable<Bitacora>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Bitacora> Lista = await ContextoBD.Bitacora.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
    }
}
