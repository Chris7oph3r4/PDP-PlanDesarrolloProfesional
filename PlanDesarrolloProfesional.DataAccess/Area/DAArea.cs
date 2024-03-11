using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarArealoProfesional.DataAccess
{
    public class DAArea
    {
        private DABitacora bitDA = new DABitacora();

        public DAArea() { }

        public async Task<Area> Agregar(Area Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    var AgregarObjeto = ContextoBD.Add(Modelo);
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado la Area con el Id " + Modelo.AreaID.ToString(),
                        Usuario = nameclaim,
                        Fecha = DateTime.Now

                    };

                    await bitDA.Agregar(bitmodel);

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

        public async Task<Area> Actualizar(Area Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    ContextoBD.Entry(Modelo).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha actualizado la Area con el Id " + Modelo.AreaID.ToString(),
                        Usuario = nameclaim,
                        Fecha = DateTime.Now
                    };

                    await bitDA.Agregar(bitmodel);

                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        //public async Task<Area> Inactivar(int IdArea)
        //{
        //    using (var ContextoBD = new PlanDesarArealoProfesionalContext())
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

        //public async Task<IEnumerable<AreaViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarArealoProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaAreas = await ContextoBD.Area.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new AreaViewModel
        //                {
        //                    IdArea = data.IdArea,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionArea = data.DescripcionArea,
        //                }).ToListAsync();
        //            return ListaAreas;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdArea, string nameclaim)
        {

            var Area = await Obtener(IdArea);

            if (Area != null)
            {
                Bitacora bitmodel = new Bitacora();
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Area).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha eliminado la Area con el Id " + IdArea.ToString(),
                        Usuario = nameclaim,
                        Fecha = DateTime.Now
                    };

                    await bitDA.Agregar(bitmodel);

                }
            }

            return true;

        }

    }
}
