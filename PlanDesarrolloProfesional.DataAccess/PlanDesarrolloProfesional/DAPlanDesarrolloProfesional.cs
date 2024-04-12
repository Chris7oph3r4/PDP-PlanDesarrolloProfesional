using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DAPlanDesarrolloProfesional
    {
      

        public DAPlanDesarrolloProfesional()
        {
      
        }
        public async Task<PlanesDesarrolloProfesional> Agregar(PlanesDesarrolloProfesional Modelo)
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

        public async Task<PlanDesarrolloProfesionalViewModel> Obtener(int IdPlanesDesarrolloProfesional)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    PlanDesarrolloProfesionalViewModel PlanDesarrollo = await ContextoBD
                        .PlanesDesarrolloProfesional
                        .Where(p => p.PlanDesarrolloID == IdPlanesDesarrolloProfesional)
                                                .Select(s => new PlanDesarrolloProfesionalViewModel()
                                                {
                                                    PlanDesarrolloID = s.PlanDesarrolloID,
                                                    NombreColaborador = s.Colaborador.Nombre,
                                                    ColaboradorID = s.ColaboradorID,
                                                    FechaInicio = s.FechaInicio,
                                                    NombreRango = s.Rango.NombreRango,
                                                    RangoID = s.RangoID,
                                                    Finalizado = s.Finalizado,
                                                    NombreRuta = s.Rango.Ruta.NombreRuta,
                                                    RutaID = s.Rango.RutaID

                                                }).FirstAsync();

                    return PlanDesarrollo;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    //IEnumerable<PlanesDesarrolloProfesional> Lista = 
                    //    await ContextoBD.PlanesDesarrolloProfesional.ToListAsync();

                    IEnumerable<PlanDesarrolloProfesionalViewModel> ListaVM = ContextoBD.PlanesDesarrolloProfesional
                                                .Where(u => u.Estado != 1)
                                                .Select(s => new PlanDesarrolloProfesionalViewModel()
                                                {
                                                    PlanDesarrolloID = s.PlanDesarrolloID,
                                                    NombreColaborador = s.Colaborador.Nombre,
                                                    ColaboradorID = s.ColaboradorID,
                                                    FechaInicio = s.FechaInicio,
                                                    NombreRango = s.Rango.NombreRango,
                                                    RangoID = s.RangoID,
                                                    Finalizado = s.Finalizado,
                                                    NombreRuta = s.Rango.Ruta.NombreRuta,
                                                    RutaID = s.Rango.RutaID                                                    

                                                }).ToList();
                    return ListaVM;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<PlanesDesarrolloProfesional> Actualizar(PlanesDesarrolloProfesional Modelo)
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

        public async Task<bool> Eliminar(int IdPlanDesarrolloProfesional)
        {

            var PlanDesarrolloProfesional = await Obtener(IdPlanDesarrolloProfesional);

            if (PlanDesarrolloProfesional != null)
            {
                PlanesDesarrolloProfesional PlanDesarrollo = new PlanesDesarrolloProfesional
                {
                    PlanDesarrolloID = PlanDesarrolloProfesional.PlanDesarrolloID,
                    ColaboradorID = PlanDesarrolloProfesional.ColaboradorID,
                    FechaInicio = PlanDesarrolloProfesional.FechaInicio,
                    Estado = 1,
                    RangoID = PlanDesarrolloProfesional.RangoID,
                    Finalizado = PlanDesarrolloProfesional.Finalizado
                };
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    ContextoBD.Entry(PlanDesarrollo).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return true;
                }
            }

            return false;

        }

        public async Task<int> ObtenerCantidadPlanesPorUsuario(int idUsuario)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    var cantidadPlanes = await ContextoBD
                        .Set<PlanesDesarrolloProfesional>()
                 .Where(plan => plan.ColaboradorID == idUsuario)
                 .CountAsync();

                    return cantidadPlanes;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async Task<string> ObtenerUltimoRangoPorColaborador(int colaboradorId)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    var ultimoRango = await ContextoBD.PlanesDesarrolloProfesional
                        .Where(p => p.ColaboradorID == colaboradorId)
                        .OrderByDescending(p => p.FechaInicio)
                        .Select(p => p.Rango.NombreRango)
                        .FirstOrDefaultAsync();

                    return ultimoRango;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*AQUI VAMOS*/

        public async Task<int> ContarPlanesFinalizadosPorColaborador(int colaboradorId)
        {
            try
            {
                using (var contextoBD = new PlanDesarrolloProfesionalContext())
                {
                    int cantidadPlanesFinalizados = await contextoBD.PlanesDesarrolloProfesional
                        .CountAsync(p => p.ColaboradorID == colaboradorId && p.Finalizado);

                    return cantidadPlanesFinalizados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los planes finalizados por colaborador.", ex);
            }
        }


        public async Task<IEnumerable<PlanDesarrolloProfesionalViewModel>> ObtenerPlanesPorColaborador(int colaboradorId)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<PlanDesarrolloProfesionalViewModel> ListaVM = ContextoBD.PlanesDesarrolloProfesional
                        .Where(u => u.ColaboradorID == colaboradorId)
                        .Select(s => new PlanDesarrolloProfesionalViewModel()
                        {
                            PlanDesarrolloID = s.PlanDesarrolloID,
                            NombreColaborador = s.Colaborador.Nombre,
                            ColaboradorID = s.ColaboradorID,
                            FechaInicio = s.FechaInicio,
                            NombreRango = s.Rango.NombreRango,
                            RangoID = s.RangoID,
                            Finalizado = s.Finalizado,
                            NombreRuta = s.Rango.Ruta.NombreRuta,
                            RutaID = s.Rango.RutaID
                        })
                        .ToList();

                    return ListaVM;
                }
                catch (Exception e)
                {
                    throw new Exception("Error al listar los planes para el colaborador.", e);
                }
            }
        }

        public async Task<string> ObtenerNombreRutaPorColaboradorId(int colaboradorId)
        {
            using (var contextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    // Obtener el rangoID del colaborador
                    int? rangoId = await contextoBD.PlanesDesarrolloProfesional
                        .Where(plan => plan.ColaboradorID == colaboradorId)
                        .Select(plan => plan.RangoID)
                        .FirstOrDefaultAsync().ConfigureAwait(false);

                    if (rangoId.HasValue)
                    {
                        // Obtener el nombre de la ruta asociada al rangoID
                        string nombreRuta = await contextoBD.Rango
                            .Where(rango => rango.RangoID == rangoId)
                            .Select(rango => rango.Ruta.NombreRuta) // Obtener solo el nombre de la ruta
                            .FirstOrDefaultAsync().ConfigureAwait(false);

                        return nombreRuta;
                    }
                    else
                    {
                        // No se encontró un rango asociado al colaborador
                        return null;
                    }
                }
                catch (Exception e)
                {
                    // Manejo de excepciones
                    return null;
                }
            }
        }

    }


}

