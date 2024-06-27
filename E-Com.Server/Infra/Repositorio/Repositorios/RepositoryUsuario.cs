using Domain.Interfaces.InterfaceUsuario;
using Entities.Entidades;
using Entities.Enums;
using Infra.Configuracao;
using Infra.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio.Repositorios
{
    public class RepositoryUsuario : RepositoryGenerics<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<ContextBase> _optionsbuilder;
        public RepositoryUsuario()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var usuario = await banco.ApplicationUser.FirstOrDefaultAsync(u => u.Id.Equals(userID));
                if (usuario != null)
                {
                    usuario.Tipo = tipoUsuario;
                    banco.ApplicationUser.Update(usuario);
                    await banco.SaveChangesAsync();
                }
            }
        }

        public async Task<ApplicationUser> ObterUsuarioPeloID(string userID)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.ApplicationUser.FirstOrDefaultAsync(u => u.Id.Equals(userID));
            }
        }
    }
}