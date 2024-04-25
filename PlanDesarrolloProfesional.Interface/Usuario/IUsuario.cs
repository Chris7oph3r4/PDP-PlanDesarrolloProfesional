using PlanDesarrolloProfesional.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanDesarrolloProfesional.Interface
{

public interface IUsuario
        {
            Task<UsuarioModel> Agregar(List<object> Modelo);
            Task<UsuarioAgregarViewModel> AgregarUsuarioAreaJerarquia(List<object> Modelo);
            Task<UsuarioModel> Obtener(int IdUsuario);
            Task<UsuarioAgregarViewModel> ObtenerUA(int IdUsuario);
            Task<UsuarioModel> ObtenerPorCorreo(string correo);
            //Task<UsuarioModel> Inactivar(int IdPedido);
            Task<UsuarioAgregarViewModel> Actualizar(List<object> Modelo);
            //Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario);
            Task<IEnumerable<UsuarioModel>> Listar();
            Task<IEnumerable<UsuarioModel>> ListarPorSupervisor(int idSupervisor);
            Task<IEnumerable<UsuarioViewModel>> ListarVM();

            Task<string> ObtenerUltimaAreaPorUsuario(int IdUsuario);

            Task<IEnumerable<UsuarioViewModel>> ListarAreasPorUsuario(int IdUsuario);

            Task<IEnumerable<UsuarioRuta>> RutaPorUsuario(int IdUsuario);
    
            Task<bool> Eliminar(int IdPedido, string nameclaim);
        }
}

