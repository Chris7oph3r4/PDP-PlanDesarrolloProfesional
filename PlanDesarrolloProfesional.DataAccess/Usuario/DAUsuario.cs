using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        private DABitacora bitDA = new DABitacora();
        public DAUsuario() { }

        public async Task<Usuario> Agregar(Usuario Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    var AgregarObjeto = ContextoBD.Add(Modelo);
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado el usuario con el Id " + Modelo.UsuarioID.ToString(),
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


        public async Task<UsuarioAgregarViewModel> AgregarAreas(UsuarioAgregarViewModel Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
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

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado areas al usuario con el Id " + Modelo.UsuarioID.ToString(),
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
        public async Task<UsuarioAgregarViewModel> AgregarNuevasAreas(UsuarioAgregarViewModel Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
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

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado areas al usuario con el Id " + Modelo.UsuarioID.ToString(),
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
        public async Task<UsuarioAgregarViewModel> AgregarSupervisor(UsuarioAgregarViewModel Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    UsuarioJerarquias Supervisor = new UsuarioJerarquias { 
                        UsuarioID= Modelo.UsuarioID,
                        SupervisorID = Modelo.SupervisorID,
                    };
                    var AgregarSupervisor = ContextoBD.Add(Supervisor);
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado el supervisor al usuario con el Id " + Modelo.UsuarioID.ToString(),
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

        public async Task<IEnumerable<UsuarioModel>> ListarPorSupervisor(int idSupervisor)
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<UsuarioModel> Lista = await ContextoBD.Usuario
                                                            .Where(us => us.Eliminado != true &&  us.UsuarioJerarquiasUsuario.Any(usuarioJerarquia => usuarioJerarquia.SupervisorID == idSupervisor))
                                                            .Select(u => new UsuarioModel
                                                            {
                                                                UsuarioID = u.UsuarioID,
                                                                Nombre = u.Nombre,
                                                                Descripcion = u.Descripcion,
                                                                RolID = u.RolID,
                                                                JerarquiaID = u.JerarquiaID,
                                                                CodigoDaloo = u.CodigoDaloo,
                                                                Correo = u.Correo,
                                                            })
                                                            .ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    // Manejo de excepciones
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

        public async Task<Usuario> ActualizarUsuario(Usuario Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    ContextoBD.Entry(Modelo).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha actualizado el usuario con el Id " + Modelo.UsuarioID.ToString(),
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
        public async Task<bool> ActualizarSupervisorUsuario(UsuarioAgregarViewModel Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
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

                        bitmodel = new Bitacora()
                        {
                            Descripcion = "Se ha actualizado el supervisor al usuario con el Id " + Modelo.UsuarioID.ToString(),
                            Usuario = nameclaim,
                            Fecha = DateTime.Now
                        };

                        await bitDA.Agregar(bitmodel);

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

        public async Task<bool> Eliminar(int IdUsuario, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
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

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha eliminado el usuario con el Id " + IdUsuario.ToString(),
                        Usuario = nameclaim,
                        Fecha = DateTime.Now
                    };

                    await bitDA.Agregar(bitmodel);

                    return true;
                }
            }

            return false;

        }

        public async Task<bool> EliminarUsuarioArea(List<int> areasPorEliminar, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
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

                            bitmodel = new Bitacora()
                            {
                                Descripcion = "Se ha eliminado la area con el Id " + usuarioArea.AreaID + " del usuario con el Id " + usuarioArea.UsuarioID,
                                Usuario = nameclaim,
                                Fecha = DateTime.Now
                            };

                            await bitDA.Agregar(bitmodel);

                        }
                    }

                    await ContextoBD.SaveChangesAsync();

                    
                }
            }

            return true;

        }

        public async Task<string> ObtenerUltimaAreaPorUsuario(int usuarioId)
        {
            try
            {
                using (var contextoBD = new PlanDesarrolloProfesionalContext())
                {
                    var ultimaArea = await contextoBD.UsuarioArea
                    .Where(ua => ua.UsuarioID == usuarioId)
                    .OrderByDescending(ua => ua.UsuarioAreaID)
                    .Select(ua => ua.Area.Nombre)
                .FirstOrDefaultAsync();

                    return ultimaArea;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la última área registrada para el usuario.", ex);
            }
        }

        public async Task<IEnumerable<UsuarioViewModel>> ListarAreasPorUsuario(int usuarioId)
        {
            using (var contextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    var lista = await contextoBD.Usuario
                        .Where(u => u.UsuarioID == usuarioId)
                        .Select(s => new UsuarioViewModel
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
                        })
                        .ToListAsync();

                    return lista;
                }
                catch (Exception e)
                {
                    // Manejo de excepciones
                    return null;
                }
            }
        }


        public async Task<IEnumerable<UsuarioRuta>> RutaPorUsuario(int usuarioId)
        {
            using (var contextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    var lista = await contextoBD.UsuarioArea
                        .Where(ua => ua.UsuarioID == usuarioId)
                        .Select(ua => ua.AreaID)
                        .FirstOrDefaultAsync();

                    if (lista != null)
                    {
                        var ruta = await contextoBD.Ruta
                            .Where(r => r.AreaID == lista)
                            .Select(r => new UsuarioRuta
                            {
                                UsuarioID = usuarioId,
                                NombreRuta = r.NombreRuta,
                                DescripcionRuta = r.Descripcion
                            })
                            .FirstOrDefaultAsync();

                        return ruta != null ? new List<UsuarioRuta> { ruta } : new List<UsuarioRuta>();
                    }
                    else
                    {
                        return new List<UsuarioRuta>();
                    }
                }
                catch (Exception e)
                {

                    return null;
                }
            }
        }




    }
}
