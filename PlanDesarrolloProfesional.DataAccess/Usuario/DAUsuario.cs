using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.DataAccess
{
    public class DAUsuario
    {
        public DAUsuario() { }

        public async Task<Usuario> Agregar(Usuario Modelo)
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


        public async Task<UsuarioAgregarViewModel> AgregarConAreas(UsuarioAgregarViewModel Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                 

                    foreach (int areaID in Modelo.AreasID)
                    {
                        UsuarioArea usuarioArea = new UsuarioArea
                        {
                            UsuarioID = Modelo.UsuarioID,
                            AreaID = areaID

                        };
                        var AgregarAreas = ContextoBD.Add(usuarioArea);

                    }
                    await ContextoBD.SaveChangesAsync();
                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }
        public async Task<UsuarioAgregarViewModel> AgregarSupervisor(UsuarioAgregarViewModel Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    UsuarioJerarquias Supervisor = new UsuarioJerarquias { 
                        UsuarioID= Modelo.UsuarioID,
                        SupervisorID = Modelo.SupervisorID,
                    };
                    var AgregarSupervisor = ContextoBD.Add(Supervisor);
                    await ContextoBD.SaveChangesAsync();


                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async Task<Usuario> Obtener(int IdUsuario)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Usuario SolicitudesBD = await ContextoBD
                        .Usuario
                        .FirstOrDefaultAsync(s => s.UsuarioID == IdUsuario);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Usuario>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Usuario> Lista = await ContextoBD.Usuario.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public async Task<IEnumerable<UsuarioViewModel>> ListarVM()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<UsuarioViewModel> Lista = ContextoBD.Usuario
                                                .Select(s=> new UsuarioViewModel()
                                                {
                                                    UsuarioID = s.UsuarioID,
                                                    Nombre = s.Nombre,
                                                    AreaString = string.Join(", ", s.UsuarioArea.Select(ua => ua.Area.Nombre)),
                                                    Rol = s.Rol.NombreRol,
                                                    RolID = s.RolID,
                                                    Jerarquia = s.Jerarquia.Nombre,
                                                    JerarquiaID = s.JerarquiaID,
                                                    Descripcion = s.Descripcion,
                                                    Correo = s.Correo,
                                                    CodigoDaloo = s.CodigoDaloo
                                               
                                                }).ToList();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Usuario> ActualizarUsuario(Usuario Modelo)
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
        //public async Task<UsuarioAgregarViewModel> ActualizarAreasUsuario(UsuarioAgregarViewModel Modelo)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            foreach (int areaID in Modelo.AreasID)
        //            {
        //                UsuarioArea usuarioArea = new UsuarioArea
        //                {
        //                    UsuarioID = Modelo.UsuarioID,
        //                    AreaID = areaID

        //                };
        //                ContextoBD.Entry(Modelo).State = EntityState.Modified;

        //            }
                    
        //            await ContextoBD.SaveChangesAsync();
        //            return Modelo;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}
        public async Task<UsuarioAgregarViewModel> ActualizarSupervisorUsuario(UsuarioAgregarViewModel Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    UsuarioJerarquias Supervisor = new UsuarioJerarquias
                    {
                        UsuarioID = Modelo.UsuarioID,
                        SupervisorID = Modelo.SupervisorID,
                    };
                    ContextoBD.Entry(Supervisor).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return Modelo;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        //public async Task<Usuario> Inactivar(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //        try
        //        {
        //            Usuario modelo = await ContextoBD
        //                .Usuario
        //                .FirstOrDefaultAsync(s => s.IdUsuario == IdUsuario);
        //            modelo.Estado = false;
        //            Usuario modeloActualizado = await Actualizar(modelo);
        //            return modeloActualizado;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        //public async Task<IEnumerable<UsuarioViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarrolloProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaUsuarios = await ContextoBD.Usuario.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new UsuarioViewModel
        //                {
        //                    IdUsuario = data.IdUsuario,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionUsuario = data.DescripcionUsuario,
        //                }).ToListAsync();
        //            return ListaUsuarios;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdUsuario)
        {

            var Usuario = await Obtener(IdUsuario);

            if (Usuario != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Usuario).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
