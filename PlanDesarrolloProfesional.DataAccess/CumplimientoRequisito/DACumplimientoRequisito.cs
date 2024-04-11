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

        //public async Task<CumplimientoRequisito> Agregar(CumplimientoRequisito Modelo)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            bool planExists = await ContextoBD.PlanesDesarrolloProfesional
        //                                              .AnyAsync(p => p.PlanDesarrolloID == Modelo.PlanDesarrolloID);
        //            if (!planExists)
        //            {
        //                throw new InvalidOperationException("El PlanDesarrollo especificado no existe.");
        //            }
        //            var AgregarObjeto = ContextoBD.Add(Modelo);
        //            await ContextoBD.SaveChangesAsync();
        //            return Modelo;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        public async Task<CumplimientoRequisito> Agregar(CumplimientoRequisito Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    bool planExists = await ContextoBD.PlanesDesarrolloProfesional
                                                      .AnyAsync(p => p.PlanDesarrolloID == Modelo.PlanDesarrolloID);
                    if (!planExists)
                    {
                        throw new InvalidOperationException("El PlanDesarrollo especificado no existe.");
                    }
                    var AgregarObjeto = ContextoBD.Add(Modelo);
                    await ContextoBD.SaveChangesAsync();
                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async Task<CumplimientoRequisitoViewModel> Obtener(int IdCumplimientoRequisito)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    CumplimientoRequisitoViewModel SolicitudesBD = await ContextoBD
                        .CumplimientoRequisito
                        .Where(p => p.CumplimientoRequisitoID == IdCumplimientoRequisito)
                                                      .Select(s => new CumplimientoRequisitoViewModel()
                                                      {
                                                          CumplimientoRequisitoID = s.CumplimientoRequisitoID,
                                                          RequisitoID = s.RequisitoID,
                                                          NombreRequisito = s.Requisito.NombreRequisito,
                                                          RangoID = s.PlanDesarrollo.RangoID,
                                                          NombreRango = s.Requisito.Rango.NombreRango,
                                                          NombreRuta = s.Requisito.Rango.Ruta.NombreRuta,
                                                          RutaID = s.Requisito.Rango.RutaID,
                                                          NombreColaborador = s.PlanDesarrollo.Colaborador.Nombre,
                                                          ColaboradorID = s.ColaboradorID,
                                                          FechaRegistro = s.FechaRegistro,
                                                          FechaObtencion = s.FechaObtencion,
                                                          URLEvidencia = s.URLEvidencia,
                                                          AprobadoPorSupervisor = s.AprobadoPorSupervisor,
                                                          PlanDesarrolloID = s.PlanDesarrolloID,
                                                          FechaArpobacion = s.FechaArpobacion,
                                                          RequisitoSeleccionado = s.RequisitoID

                                                      }).FirstAsync();
                        //.FirstOrDefaultAsync(s => s.CumplimientoRequisitoID == IdCumplimientoRequisito);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public async Task<CumplimientoRequisitoViewModel> ObtenerAprobado(int IdCumplimientoRequisito)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    CumplimientoRequisitoViewModel SolicitudesBD = await ContextoBD
                        .CumplimientoRequisito
                        .Where(p => p.CumplimientoRequisitoID == IdCumplimientoRequisito)
                                                      .Select(s => new CumplimientoRequisitoViewModel()
                                                      {
                                                          CumplimientoRequisitoID = s.CumplimientoRequisitoID,
                                                          RequisitoID = s.RequisitoID,
                                                          NombreRequisito = s.Requisito.NombreRequisito,
                                                          RangoID = s.PlanDesarrollo.RangoID,
                                                          NombreRango = s.Requisito.Rango.NombreRango,
                                                          NombreRuta = s.Requisito.Rango.Ruta.NombreRuta,
                                                          RutaID = s.Requisito.Rango.RutaID,
                                                          NombreColaborador = s.PlanDesarrollo.Colaborador.Nombre,
                                                          ColaboradorID = s.ColaboradorID,
                                                          FechaRegistro = s.FechaRegistro,
                                                          FechaObtencion = s.FechaObtencion,
                                                          URLEvidencia = s.URLEvidencia,
                                                          AprobadoPorSupervisor = s.AprobadoPorSupervisor,
                                                          PlanDesarrolloID = s.PlanDesarrolloID,
                                                          FechaArpobacion = s.FechaArpobacion
                                                          

                                                      }).FirstAsync();
                    //.FirstOrDefaultAsync(s => s.CumplimientoRequisitoID == IdCumplimientoRequisito);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<CumplimientoRequisitoViewModel>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    //IEnumerable<CumplimientoRequisito> Lista = await ContextoBD.CumplimientoRequisito.ToListAsync();

                    IEnumerable<CumplimientoRequisitoViewModel> Lista = ContextoBD.CumplimientoRequisito
                        .Select(s => new CumplimientoRequisitoViewModel()
                        {
                            CumplimientoRequisitoID = s.CumplimientoRequisitoID,
                            RequisitoID = s.RequisitoID,
                            NombreRequisito = s.Requisito.NombreRequisito,
                            RangoID = s.PlanDesarrollo.RangoID,
                            NombreRango = s.Requisito.Rango.NombreRango,
                            NombreRuta = s.Requisito.Rango.Ruta.NombreRuta,
                            RutaID = s.Requisito.Rango.RutaID,
                            NombreColaborador = s.PlanDesarrollo.Colaborador.Nombre,
                            ColaboradorID = s.ColaboradorID,
                            FechaRegistro = s.FechaRegistro,
                            FechaObtencion = s.FechaObtencion,
                            URLEvidencia = s.URLEvidencia,
                            AprobadoPorSupervisor = s.AprobadoPorSupervisor,
                            PlanDesarrolloID = s.PlanDesarrolloID,
                            FechaArpobacion = s.FechaArpobacion

                        }).ToList();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<CumplimientoRequisitoViewModel>> ListarPorPlanDesarrolloID(int planDesarrolloID)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    // Directamente esperamos la ejecución de la consulta ToListAsync y retornamos su resultado
                    var lista = await ContextoBD.CumplimientoRequisito
                        .Where(c => c.PlanDesarrolloID == planDesarrolloID) // Asegúrate que este campo exista en el modelo
                        .Select(s => new CumplimientoRequisitoViewModel
                        {
                            CumplimientoRequisitoID = s.CumplimientoRequisitoID,
                            RequisitoID = s.RequisitoID,
                            NombreRequisito = s.Requisito.NombreRequisito,
                            RangoID = s.PlanDesarrollo.RangoID,
                            NombreRango = s.Requisito.Rango.NombreRango,
                            NombreRuta = s.Requisito.Rango.Ruta.NombreRuta,
                            RutaID = s.Requisito.Rango.RutaID,
                            NombreColaborador = s.PlanDesarrollo.Colaborador.Nombre,
                            ColaboradorID = s.ColaboradorID,
                            FechaRegistro = s.FechaRegistro,
                            FechaObtencion = s.FechaObtencion,
                            URLEvidencia = s.URLEvidencia,
                            AprobadoPorSupervisor = s.AprobadoPorSupervisor,
                            PlanDesarrolloID = s.PlanDesarrolloID,
                            FechaArpobacion = s.FechaArpobacion
                        })
                        .ToListAsync();

                    return lista;
                }
                catch (Exception e)
                {
                    // Aquí deberías manejar la excepción de forma más adecuada, quizás registrando el error en un log.
                    // Retornamos una lista vacía en caso de error
                    return new List<CumplimientoRequisitoViewModel>();
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

        //public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        //{

        //    var cumplimientoRequisito = await Obtener(IdCumplimientoRequisito);

        //    if (cumplimientoRequisito != null)
        //    {
        //        CumplimientoRequisito CumplimientoRequisito = new CumplimientoRequisito
        //        {
        //            CumplimientoRequisitoID = cumplimientoRequisito.CumplimientoRequisitoID,
        //            PlanDesarrolloID = cumplimientoRequisito.PlanDesarrolloID,
        //            ColaboradorID = cumplimientoRequisito.ColaboradorID,
        //            FechaRegistro = cumplimientoRequisito.FechaRegistro,
        //            FechaObtencion = cumplimientoRequisito.FechaObtencion,
        //            URLEvidencia = cumplimientoRequisito.URLEvidencia,
        //            AprobadoPorSupervisor = cumplimientoRequisito.AprobadoPorSupervisor,
        //            FechaArpobacion = cumplimientoRequisito.FechaArpobacion,

        //        };
        //        using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        {
        //            ContextoBD.Entry(cumplimientoRequisito).State = EntityState.Modified;
        //            await ContextoBD.SaveChangesAsync();
        //            return true;
        //        }
        //    }

        //    return false;

        //}

        public async Task<bool> Eliminar(int IdCumplimientoRequisito)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                // Intentamos encontrar la entidad en la base de datos.
                var entidadAEliminar = await ContextoBD.CumplimientoRequisito
                                                       .FindAsync(IdCumplimientoRequisito);

                // Verificamos si la entidad existe y si AprobadoPorSupervisor es igual a 2.
                if (entidadAEliminar != null && entidadAEliminar.AprobadoPorSupervisor == 2)
                {
                    // Si existe y cumple la condición, la marcamos para eliminación.
                    ContextoBD.CumplimientoRequisito.Remove(entidadAEliminar);

                    // Guardamos los cambios en la base de datos.
                    await ContextoBD.SaveChangesAsync();
                    return true; // Retornamos true indicando que la eliminación fue exitosa.
                }
            }

            return false; // Si la entidad no se encontró o no cumple la condición, no se elimina.
        }



    }
}
