using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections;
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


        public async Task<UsuarioAgregarViewModel> AgregarAreas(UsuarioAgregarViewModel Modelo)
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
        public async Task<UsuarioAgregarViewModel> AgregarNuevasAreas(UsuarioAgregarViewModel Modelo)
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
        public async Task<Usuario> ObtenerPorCorreo(string correo)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Usuario usuarioActual = await ContextoBD
                        .Usuario
                        .FirstOrDefaultAsync(s => s.Correo == correo);

                    return usuarioActual;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<int>> ObtenerAreasActuales(int IdUsuario)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    List<int> ListaAreas = await ContextoBD.UsuarioArea
                                               .Where(ua => ua.UsuarioID == IdUsuario && ua.Eliminado != true)
                                               .Select(au => au.AreaID)
                                               .ToListAsync();

                    return ListaAreas;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<UsuarioAgregarViewModel> ObtenerUA(int IdUsuario)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Usuario UsuarioObtener = await ContextoBD
                        .Usuario
                        .FirstOrDefaultAsync(s => s.UsuarioID == IdUsuario);
                    List<UsuarioArea> ListaAreas = await ContextoBD.UsuarioArea
                                                .Where(ua => ua.UsuarioID == IdUsuario && ua.Eliminado != true)
                                                .Select(au => new UsuarioArea
                                                {
                                                    UsuarioID = au.UsuarioID,
                                                    AreaID = au.AreaID,
                                                    UsuarioAreaID = au.UsuarioAreaID,
                                                    Eliminado = au.Eliminado
                                                })
                                                .ToListAsync();
                    UsuarioJerarquias Supervisor = await ContextoBD
                        .UsuarioJerarquias
                        .FirstOrDefaultAsync(su => su.UsuarioID == IdUsuario);
                    UsuarioAgregarViewModel ModificarUsuario = new UsuarioAgregarViewModel
                    {
                        UsuarioID = UsuarioObtener.UsuarioID,
                        Nombre = UsuarioObtener.Nombre,
                        Descripcion = UsuarioObtener.Descripcion,
                        RolID = UsuarioObtener.RolID,
                        JerarquiaID = UsuarioObtener.JerarquiaID,
                        SupervisorID = Supervisor.SupervisorID,
                        AreasID = ListaAreas.Select(ua => ua.AreaID).ToList(),
                        CodigoDaloo = UsuarioObtener.CodigoDaloo,
                        Correo = UsuarioObtener.Correo
                    };


                    return ModificarUsuario;
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
                                                .Where(u => u.Eliminado != true)
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
        public async Task<bool> ActualizarSupervisorUsuario(UsuarioAgregarViewModel Modelo)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    // Buscar la entidad existente
                    UsuarioJerarquias supervisorAsignado = await ContextoBD
                        .UsuarioJerarquias
                        .FirstOrDefaultAsync(su => su.UsuarioID == Modelo.UsuarioID);

                    if (supervisorAsignado != null && supervisorAsignado.SupervisorID != Modelo.SupervisorID)
                    {
                        // Modificar la entidad existente
                        supervisorAsignado.SupervisorID = Modelo.SupervisorID;

                        // No es necesario cambiar el estado a EntityState.Modified
                        // ContextoBD.Entry(supervisorAsignado).State = EntityState.Modified;

                        await ContextoBD.SaveChangesAsync();
                        return true;
                    }

                    return false;
                }
                catch (Exception e)
                {
                    // Manejar la excepción de manera adecuada
                    throw e;
                }
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
                    //List<UsuarioAreaModel> Lista = await ContextoBD.UsuarioArea
                    //                            .Where(ua => ua.UsuarioID == IdUsuario)
                    //                            .Select(au => new UsuarioAreaModel
                    //                            {
                    //                                UsuarioID = au.UsuarioID,
                    //                                AreaID = au.AreaID,
                    //                                UsuarioAreaID = au.UsuarioAreaID,
                    //                                Eliminado = au.Eliminado
                    //                            })
                    //                            .ToListAsync();
                    Usuario.Eliminado = true;
                    ContextoBD.Entry(Usuario).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();
                    return true;
                }
            }

            return false;

        }

        public async Task<bool> EliminarUsuarioArea(List<int> areasPorEliminar)
        {

            if (areasPorEliminar != null && areasPorEliminar.Any())
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    
                    foreach (var areaId in areasPorEliminar)
                    {
                        var usuarioArea = await ContextoBD.UsuarioArea
                        .Where(u => u.AreaID == areaId && u.Eliminado != true)
                        .FirstOrDefaultAsync();

                        if (usuarioArea != null)
                        {
                            usuarioArea.Eliminado = true;
                        }
                    }

                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
