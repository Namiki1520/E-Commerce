using Entities.Entidades;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesApp
{
    public interface InterfaceUsuarioApp : InterfaceGenericaApp<ApplicationUser>
    {
        Task<ApplicationUser> ObterUsuarioPeloID(string userID);
        Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario);
        Task<List<ApplicationUser>> ListarUsuarioSomenteParaAdministradores(string userID);
    }
}