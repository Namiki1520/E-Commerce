﻿using Domain.Interfaces.Genericas;
using Entities.Entidades;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceCompraUsuario
{
    public interface ICompraUsuario : IGeneric<CompraUsuario>
    {
        public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

        public Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EnumEstadoCompra estado, int? idCompra = null);

        public Task<List<CompraUsuario>> MinhasComprasPorEstado(string userId, EnumEstadoCompra estado);

        public Task<bool> ConfirmaCompraCarrinhoUsuario(string userId);
    }
}