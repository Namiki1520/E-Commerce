using Domain.Interfaces.Genericas;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceProduto
{
    public interface IProduct : IGeneric<Produto>
    {
        Task<List<Produto>> ListarProdutosUsuario(string userId);

        Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto);

        Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId);

        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);

        Task<List<Produto>> ListarProdutosVendidos(string userId, string filtro);
    }
}