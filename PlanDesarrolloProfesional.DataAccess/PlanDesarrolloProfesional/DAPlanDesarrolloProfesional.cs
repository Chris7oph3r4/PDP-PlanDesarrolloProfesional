﻿using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
