using Microsoft.EntityFrameworkCore;
using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarRutaloProfesional.DataAccess
{
    public class DARuta
    {
        public DARuta() { }

        public async Task<Ruta> Agregar(Ruta Modelo)
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

        public async Task<Ruta> Obtener(int IdRuta)
        {
            try
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {
                    Ruta SolicitudesBD = await ContextoBD
                        .Ruta
                        .FirstOrDefaultAsync(s => s.RutaID == IdRuta);

                    return SolicitudesBD;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Ruta>> Listar()
        {
            using (var ContextoBD = new PlanDesarrolloProfesionalContext())
            {
                try
                {
                    IEnumerable<Ruta> Lista = await ContextoBD.Ruta.ToListAsync();

                    return Lista;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<Ruta> Actualizar(Ruta Modelo)
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

        //public async Task<Ruta> Inactivar(int IdRuta)
        //{
        //    using (var ContextoBD = new PlanDesarRutaloProfesionalContext())
        //        try
        //        {
        //            Ruta modelo = await ContextoBD
        //                .Ruta
        //                .FirstOrDefaultAsync(s => s.IdRuta == IdRuta);
        //            modelo.Estado = false;
        //            Ruta modeloActualizado = await Actualizar(modelo);
        //            return modeloActualizado;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //}

        //public async Task<IEnumerable<RutaViewModel>> ListarPorUsuario(int IdUsuario)
        //{
        //    using (var ContextoBD = new PlanDesarRutaloProfesionalContext())
        //    {
        //        try
        //        {
        //            var ListaRutas = await ContextoBD.Ruta.Where(
        //                x => x.Fkusuario == IdUsuario).Select(
        //                data => new RutaViewModel
        //                {
        //                    IdRuta = data.IdRuta,
        //                    Usuario = data.FkusuarioNavigation.NombreUsuario,
        //                    Estado = data.Estado == true ? "Activo" : "Inactivo",
        //                    DescripcionRuta = data.DescripcionRuta,
        //                }).ToListAsync();
        //            return ListaRutas;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //    }
        //}

        public async Task<bool> Eliminar(int IdRuta)
        {

            var Ruta = await Obtener(IdRuta);

            if (Ruta != null)
            {
                using (var ContextoBD = new PlanDesarrolloProfesionalContext())
                {

                    ContextoBD.Entry(Ruta).State = EntityState.Deleted;
                    await ContextoBD.SaveChangesAsync();
                }
            }

            return true;

        }

    }
}
