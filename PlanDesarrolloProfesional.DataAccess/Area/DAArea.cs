using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DAArea
    {
        public DAArea() { }

        public async Task<Area> Agregar(Area Modelo)
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

        public async Task<Area> Obtener(int IdArea)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Area SolicitudesBD = await ContextoBD
                        .Area
                        .FirstOrDefaultAsync(s => s.AreaID == IdArea);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Area>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Area> Lista = await ContextoBD.Area.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Area> Actualizar(Area Modelo)
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

        //public async Task<Area> Inactivar(int IdArea)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            Area modelo = await ContextoBD
        //                .Area
        //                .FirstOrDefaultAsync(s => s.IdArea == IdArea);
        //            modelo.Estado = false;
        //            Area modeloActualizado = await Actualizar(modelo);
        //            return modeloActualizado;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        //public async Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaJerarquiass = await ContextoBD.Area.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new JerarquiasViewModel
        //                {
        //                    IdArea = data.IdArea,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionJerarquias = data.DescripcionJerarquias,
        //                }).ToListAsync();
        //            return ListaJerarquiass;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdArea)
        {

            var Area = await Obtener(IdArea);

            if (Area != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Area).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
