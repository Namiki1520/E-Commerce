using Domain.Interfaces.InterfaceCompra;
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
    public class RepositoryCompra : RepositoryGenerics<Compra>, ICompra
    {

        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryCompra()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }


        public async Task<Compra> CompraPorEstado(string userId, EnumEstadoCompra estado)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Compra.FirstOrDefaultAsync(c => c.Estado == estado && c.UserId == userId);
            }
        }
    }
}