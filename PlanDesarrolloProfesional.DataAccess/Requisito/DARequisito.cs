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

        //public async Task<IEnumerable<RequisitoModel>> RequisitoPorRango(int IdRango)
        //{
        //    try
        //    {
        //        using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        {
        //            // Obtener todos los Requisitos para el rango dado que no han sido aprobados o no tienen registro de aprobación.
        //            var listaRequisitos = await ContextoBD.Requisito
        //                .Where(Requisito => Requisito.RangoID == IdRango)
        //                // Unirse con CumplimientoRequisito para filtrar los no aprobados o sin registro
        //                .GroupJoin(ContextoBD.CumplimientoRequisito, // La tabla con la que hacer join
        //                           Requisito => Requisito.RequisitoID, // Clave primaria de la tabla origen
        //                           Cumplimiento => Cumplimiento.RequisitoID, // Clave foránea en la tabla de destino
        //                           (Requisito, Cumplimientos) => new { Requisito, Cumplimientos })
        //                // De los grupos formados, seleccionar solo aquellos donde todos los registros de cumplimiento asociados no están aprobados o no existen registros de cumplimiento
        //                .SelectMany(
        //                    rc => rc.Cumplimientos.DefaultIfEmpty(), // Esto maneja el caso de que no haya registros de cumplimiento asociados
        //                    (rc, Cumplimiento) => new { rc.Requisito, Cumplimiento }
        //                )
        //                .Where(rc => rc.Cumplimiento == null || rc.Cumplimiento.AprobadoPorSupervisor != 1)
        //                .Select(rc => new RequisitoModel
        //                {
        //                    RequisitoID = rc.Requisito.RequisitoID,
        //                    NombreRequisito = rc.Requisito.NombreRequisito,
        //                    // Más mapeos aquí
        //                })
        //                .Distinct()
        //                .ToListAsync();

        //            return listaRequisitos;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // Considera usar un mecanismo de registro de errores aquí
        //        return null;
        //    }
        //}
        public async Task<IEnumerable<RequisitoModel>> RequisitoPorRango(int IdRango, int PlanDesarrolloID)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    // Primero, verifica si hay algún requisito aprobado para el PlanDesarrolloID específico
                    bool hayRequisitosAprobados = await ContextoBD.CumplimientoRequisito
                        .AnyAsync(cumplimiento => cumplimiento.PlanDesarrolloID == PlanDesarrolloID && cumplimiento.AprobadoPorSupervisor == 1);

                    if (!hayRequisitosAprobados)
                    {
                        // Si no hay requisitos aprobados para el PlanDesarrolloID, muestra todos los requisitos del rango
                        return await ContextoBD.Requisito
                            .Where(requisito => requisito.RangoID == IdRango)
                            .Select(requisito => new RequisitoModel
                            {
                                RequisitoID = requisito.RequisitoID,
                                NombreRequisito = requisito.NombreRequisito,
                                // Agrega aquí más propiedades según sea necesario
                            })
                            .ToListAsync();
                    }
                    else
                    {
                        // Si hay requisitos aprobados, filtra para no incluir esos requisitos aprobados para el PlanDesarrolloID
                        return await ContextoBD.Requisito
                            .Where(requisito => requisito.RangoID == IdRango)
                            .GroupJoin(ContextoBD.CumplimientoRequisito,
                                       requisito => requisito.RequisitoID,
                                       cumplimiento => cumplimiento.RequisitoID,
                                       (requisito, cumplimientos) => new { requisito, cumplimientos })
                            .SelectMany(
                                rc => rc.cumplimientos.DefaultIfEmpty(), // Permite requisitos sin cumplimientos
                                (rc, cumplimiento) => new { rc.requisito, cumplimiento }
                            )
                            // Excluir los requisitos aprobados para el PlanDesarrolloID específico
                            .Where(rc => rc.cumplimiento == null || rc.cumplimiento.PlanDesarrolloID != PlanDesarrolloID || rc.cumplimiento.AprobadoPorSupervisor != 1)
                            .Select(rc => new RequisitoModel
                            {
                                RequisitoID = rc.requisito.RequisitoID,
                                NombreRequisito = rc.requisito.NombreRequisito,
                                // Más propiedades según sea necesario
                            })
                            .Distinct()
                            .ToListAsync();
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de errores
                return null;
            }
        }


    }
}
