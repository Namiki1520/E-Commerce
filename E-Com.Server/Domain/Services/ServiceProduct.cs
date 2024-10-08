﻿using Domain.Interfaces.InterfaceProduto;
using Domain.Interfaces.InterfaceServices;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {

        private readonly IProduct _IProduct;

        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        public async Task AddProduct(Produto produto)
        {
            var validaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            var validaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && validaValor && validaQtdEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _IProduct.Add(produto);
            }
        }

        public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                return await _IProduct.ListarProdutos(p => p.QtdEstoque > 0);
            else
            {
                return await _IProduct.ListarProdutos(p => p.QtdEstoque > 0
                && p.Nome.ToUpper().Contains(descricao.ToUpper()));
            }
        }

        public async Task UpdateProduct(Produto produto)
        {
            var validaNome = produto.ValidarPropriedadeString(produto.Nome, "Nome");

            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");

            var validaQtdEstoque = produto.ValidarPropriedadeInt(produto.QtdEstoque, "QtdEstoque");

            if (validaNome && validaValor && validaQtdEstoque)
            {
                produto.DataAlteracao = DateTime.Now;

                await _IProduct.Update(produto);
            }
        }
    }
}