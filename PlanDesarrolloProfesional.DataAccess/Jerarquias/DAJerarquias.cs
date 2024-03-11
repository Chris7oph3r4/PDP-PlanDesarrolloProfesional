using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlanDesarrolloProfesional.DataAccess;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarJerarquiasloProfesional.DataAccess
{
    public class DAJerarquias
    {
        private DABitacora bitDA = new DABitacora();

        public DAJerarquias() { }

        public async Task<Jerarquias> Agregar(Jerarquias Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    var AgregarObjeto = ContextoBD.Add(Modelo);
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha agregado la Jerarquia con el Id " + Modelo.JerarquiaID.ToString(),
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

        public async Task<Jerarquias> Obtener(int IdJerarquias)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Jerarquias SolicitudesBD = await ContextoBD
                        .Jerarquias
                        .FirstOrDefaultAsync(s => s.JerarquiaID == IdJerarquias);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Jerarquias>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Jerarquias> Lista = await ContextoBD.Jerarquias.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Jerarquias> Actualizar(Jerarquias Modelo, string nameclaim)
        {
            Bitacora bitmodel = new Bitacora();
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                try
                {
                    ContextoBD.Entry(Modelo).State = EntityState.Modified;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha actualizado la Jerarquia con el Id " + Modelo.JerarquiaID.ToString(),
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

        //public async Task<Jerarquias> Inactivar(int IdJerarquias)
        //{
        //    using (var ContextoBD = new PlanDesarJerarquiasloProfesionalContext())
        //        try
        //        {
        //            Jerarquias modelo = await ContextoBD
        //                .Jerarquias
        //                .FirstOrDefaultAsync(s => s.IdJerarquias == IdJerarquias);
        //            modelo.Estado = false;
        //            Jerarquias modeloActualizado = await Actualizar(modelo);
        //            return modeloActualizado;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        //public async Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarJerarquiasloProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaJerarquiass = await ContextoBD.Jerarquias.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new JerarquiasViewModel
        //                {
        //                    IdJerarquias = data.IdJerarquias,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionJerarquias = data.DescripcionJerarquias,
        //                }).ToListAsync();
        //            return ListaJerarquiass;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdJerarquias, string nameclaim)
        {

            var Jerarquias = await Obtener(IdJerarquias);

            if (Jerarquias != null)
            {
                Bitacora bitmodel = new Bitacora();
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Jerarquias).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();

                    bitmodel = new Bitacora()
                    {
                        Descripcion = "Se ha eliminado la Jerarquia con el Id " + IdJerarquias.ToString(),
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
