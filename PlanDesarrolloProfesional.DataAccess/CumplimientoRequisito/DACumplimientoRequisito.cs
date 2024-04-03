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
        public DACumplimientoRequisito() { }

        public async Task<CumplimientoRequisito> Agregar(CumplimientoRequisito Modelo)
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

        public async Task<CumplimientoRequisito> Obtener(int IdCumplimientoRequisito)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    CumplimientoRequisito SolicitudesBD = await ContextoBD
                        .CumplimientoRequisito
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
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<CumplimientoRequisito> Lista = await ContextoBD.CumplimientoRequisito.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<CumplimientoRequisito> Actualizar(CumplimientoRequisito Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    ContextoBD.Entry(Modelo).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        //public async Task<CumplimientoRequisito> Inactivar(int IdCumplimientoRequisito)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            CumplimientoRequisito modelo = await ContextoBD
        //                .CumplimientoRequisito
        //                .FirstOrDefaultAsync(s => s.IdCumplimientoRequisito == IdCumplimientoRequisito);
        //            modelo.Estado = false;
        //            CumplimientoRequisito modeloActualizado = await Actualizar(modelo);
        //            return modeloActualizado;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        //public async Task<IEnumerable<RequisitoViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaRequisitos = await ContextoBD.CumplimientoRequisito.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new RequisitoViewModel
        //                {
        //                    IdCumplimientoRequisito = data.IdCumplimientoRequisito,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionRequisito = data.DescripcionRequisito,
        //                }).ToListAsync();
        //            return ListaRequisitos;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {

            var CumplimientoRequisito = await Obtener(IdCumplimientoRequisito);

            if (CumplimientoRequisito != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(CumplimientoRequisito).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
