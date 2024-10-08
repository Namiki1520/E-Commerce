﻿using Domain.Interfaces.InterfacesApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.v1.Controllers
{
    public class ProdutoController : Controller
    {
        [Authorize]
        public class ProdutoAPIController : Controller
        {

            public readonly InterfaceProductApp _InterfaceProductApp;
            public readonly InterfaceCompraUsuarioApp _InterfaceCompraUsuarioApp;

            public ProdutoAPIController(InterfaceProductApp InterfaceProductApp, InterfaceCompraUsuarioApp InterfaceCompraUsuarioApp)
            {
                _InterfaceProductApp = InterfaceProductApp;
                _InterfaceCompraUsuarioApp = InterfaceCompraUsuarioApp;
            }


            [HttpGet("/api/ListaProdutos")]
            public async Task<JsonResult> ListaProdutos(string descricao)
            {
                return Json(await _InterfaceProductApp.ListarProdutosComEstoque(descricao));
            }

        }
    }