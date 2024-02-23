using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DARequisito
    {
        public DARequisito() { }

        public async Task<Requisito> Agregar(Requisito Modelo)
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

        public async Task<Requisito> Obtener(int IdRequisito)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Requisito SolicitudesBD = await ContextoBD
                        .Requisito
                        .FirstOrDefaultAsync(s => s.RequisitoID == IdRequisito);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Requisito>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Requisito> Lista = await ContextoBD.Requisito.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Requisito> Actualizar(Requisito Modelo)
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

        //public async Task<Requisito> Inactivar(int IdRequisito)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            Requisito modelo = await ContextoBD
        //                .Requisito
        //                .FirstOrDefaultAsync(s => s.IdRequisito == IdRequisito);
        //            modelo.Estado = false;
        //            Requisito modeloActualizado = await Actualizar(modelo);
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
        //            var ListaRequisitos = await ContextoBD.Requisito.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new RequisitoViewModel
        //                {
        //                    IdRequisito = data.IdRequisito,
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

        public async Task<bool> Eliminar(int IdRequisito)
        {

            var Requisito = await Obtener(IdRequisito);

            if (Requisito != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Requisito).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
