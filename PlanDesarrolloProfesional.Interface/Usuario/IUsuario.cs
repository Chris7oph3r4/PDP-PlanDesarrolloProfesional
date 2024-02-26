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
            Task<UsuarioModel> Agregar(UsuarioModel Modelo);
            Task<UsuarioAgregarViewModel> AgregarUsuarioAreaJerarquia(UsuarioAgregarViewModel Modelo);
            Task<UsuarioModel> Obtener(int IdUsuario);
            Task<UsuarioAgregarViewModel> ObtenerUA(int IdUsuario);
            Task<UsuarioModel> ObtenerPorCorreo(string correo);
            //Task<UsuarioModel> Inactivar(int IdPedido);
            Task<UsuarioAgregarViewModel> Actualizar(UsuarioAgregarViewModel modelo);
            //Task<IEnumerable<JerarquiasViewModel>> ListarPorUsuario(int IdUsuario);
            Task<IEnumerable<UsuarioModel>> Listar();
            Task<IEnumerable<UsuarioViewModel>> ListarVM();
            Task<bool> Eliminar(int IdPedido);
        }
}

