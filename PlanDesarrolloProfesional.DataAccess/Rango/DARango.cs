using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DARango
    {
        public DARango() { }

        public async Task<Rango> Agregar(Rango Modelo)
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

        public async Task<Rango> Obtener(int IdRango)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Rango SolicitudesBD = await ContextoBD
                        .Rango
                        .FirstOrDefaultAsync(s => s.RangoID == IdRango);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Rango>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Rango> Lista = await ContextoBD.Rango.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<RangoModel>> RangosPorRuta(int IdRuta)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<RangoModel> Lista = (IEnumerable<RangoModel>)await ContextoBD.Rango
                    .Where(rango => rango.RutaID == IdRuta)
                    .ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Rango> Actualizar(Rango Modelo)
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

        //public async Task<Rango> Inactivar(int IdRango)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            Rango modelo = await ContextoBD
        //                .Rango
        //                .FirstOrDefaultAsync(s => s.IdRango == IdRango);
        //            modelo.Estado = false;
        //            Rango modeloActualizado = await Actualizar(modelo);
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
        //            var ListaJerarquiass = await ContextoBD.Rango.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new JerarquiasViewModel
        //                {
        //                    IdRango = data.IdRango,
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

        public async Task<bool> Eliminar(int IdRango)
        {

            var Rango = await Obtener(IdRango);

            if (Rango != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Rango).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
