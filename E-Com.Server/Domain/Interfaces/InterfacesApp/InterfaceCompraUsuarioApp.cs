using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesApp
{
    public interface InterfaceCompraUsuarioApp : InterfaceGenericaApp<CompraUsuario>
    {
        public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

        public Task<CompraUsuario> CarrinhoCompras(string userId);

        public Task<CompraUsuario> ProdutosComprados(string userId, int? idCompra = null);

        public Task<bool> ConfirmaCompraCarrinhoUsuario(string userId);

        public Task<List<CompraUsuario>> MinhasCompras(string userId);

        public Task AdicionaProdutoCarrinho(string userId, CompraUsuario compraUsuario);

    }
}