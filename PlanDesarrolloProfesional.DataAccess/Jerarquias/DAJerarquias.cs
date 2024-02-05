using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DAJerarquias
    {
        public DAJerarquias() { }

        public async Task<Jerarquias> Agregar(Jerarquias Modelo)
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

        public async Task<Jerarquias> Obtener(int IdJerarquias)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Jerarquias SolicitudesBD = await ContextoBD
                        .Jerarquias
                        .FirstOrDefaultAsync(s => s.JerarquiaID == IdJerarquias);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Jerarquias>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Jerarquias> Lista = await ContextoBD.Jerarquias.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Jerarquias> Actualizar(Jerarquias Modelo)
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

        //public async Task<Jerarquias> Inactivar(int IdJerarquias)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            Jerarquias modelo = await ContextoBD
        //                .Jerarquias
        //                .FirstOrDefaultAsync(s => s.IdJerarquias == IdJerarquias);
        //            modelo.Estado = false;
        //            Jerarquias modeloActualizado = await Actualizar(modelo);
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
        //            var ListaJerarquiass = await ContextoBD.Jerarquias.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new JerarquiasViewModel
        //                {
        //                    IdJerarquias = data.IdJerarquias,
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

        public async Task<bool> Eliminar(int IdJerarquias)
        {

            var Jerarquias = await Obtener(IdJerarquias);

            if (Jerarquias != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Jerarquias).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
