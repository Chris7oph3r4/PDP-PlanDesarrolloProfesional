using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarRolloProfesional.DataAccess
{
    public class DARol
    {
        private DABitacora bitDA = new DABitacora();

        public DARol() { }

        public async Task<Rol> Agregar(Rol Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    var AgregarObjeto = ContextoBD.Add(Modelo);
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado la Rol con el Id " + Modelo.RolID.ToString(),
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

        public async Task<Rol> Obtener(int IdRol)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Rol SolicitudesBD = await ContextoBD
                        .Rol
                        .FirstOrDefaultAsync(s => s.RolID == IdRol);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Rol>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Rol> Lista = await ContextoBD.Rol.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Rol> Actualizar(Rol Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    ContextoBD.Entry(Modelo).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha actualizado la Rol con el Id " + Modelo.RolID.ToString(),
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

        //public async Task<Rol> Inactivar(int IdRol)
        //{
        //    using (var ContextoBD = new PlanDesarRolloProfesionalContext())
        //        try
        //        {
        //            Rol modelo = await ContextoBD
        //                .Rol
        //                .FirstOrDefaultAsync(s => s.IdRol == IdRol);
        //            modelo.Estado = false;
        //            Rol modeloActualizado = await Actualizar(modelo);
        //            return modeloActualizado;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        //public async Task<IEnumerable<RolViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarRolloProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaRols = await ContextoBD.Rol.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new RolViewModel
        //                {
        //                    IdRol = data.IdRol,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionRol = data.DescripcionRol,
        //                }).ToListAsync();
        //            return ListaRols;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdRol, string nameclaim)
        {

            var Rol = await Obtener(IdRol);

            if (Rol != null)
            {
                Bitacora bitmodel = new Bitacora();
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Rol).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha eliminado la Rol con el Id " + IdRol.ToString(),
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
