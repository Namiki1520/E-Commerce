﻿using Domain.Interfaces.InterfacesApp;
using Entities.Entidades;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.v1.Controllers
{
    public class CompraUsuarioController : Controller
    {

        public readonly UserManager<ApplicationUser> _userManager;
        public readonly InterfaceCompraUsuarioApp _InterfaceCompraUsuarioApp;
        private IWebHostEnvironment _environment;


        public CompraUsuarioController(UserManager<ApplicationUser> userManager, InterfaceCompraUsuarioApp InterfaceCompraUsuarioApp)
        {
            _userManager = userManager;
            _InterfaceCompraUsuarioApp = InterfaceCompraUsuarioApp;
        }

        [HttpGet("v1/api/FinalizarCompra")]
        [Produces("application/json")]
        public async Task<IActionResult> FinalizarCompra()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _InterfaceCompraUsuarioApp.CarrinhoCompras(usuario.Id);
            return Ok(compraUsuario);
        }



        public async Task<IActionResult> MinhasCompras(bool mensagem = false)
        {
            var usuario = await _userManager.GetUserAsync(User);
            var compraUsuario = await _InterfaceCompraUsuarioApp.MinhasCompras(usuario.Id);

            if (mensagem)
            {
                ViewBag.Sucesso = true;
                ViewBag.Mensagem = "Compra efetivada com sucesso. Pague o boleto para garantir sua compra!";
            }

            return View(compraUsuario);
        }


        //public async Task<IActionResult> ConfirmaCompra()
        //{
        //    var usuario = await _userManager.GetUserAsync(User);

        //    var sucesso = await _InterfaceCompraUsuarioApp.ConfirmaCompraCarrinhoUsuario(usuario.Id);

        //    if (sucesso)
        //    {
        //        return RedirectToAction("MinhasCompras", new { mensagem = true });
        //    }
        //    else
        //        return RedirectToAction("FinalizarCompra");
        //}

        //public async Task<IActionResult> Imprimir(int id)
        //{
        //    var usuario = await _userManager.GetUserAsync(User);

        //    var compraUsuario = await _InterfaceCompraUsuarioApp.ProdutosComprados(usuario.Id, id);

        //    return await Download(compraUsuario, _environment);

        //}


        //[HttpPost("/api/AdicionarProdutoCarrinho")]
        //public async Task<JsonResult> AdicionarProdutoCarrinho(string id, string nome, string qtd)
        //{
        //    var usuario = await _userManager.GetUserAsync(User);

        //    if (usuario != null)
        //    {
        //        await _InterfaceCompraUsuarioApp.AdicionaProdutoCarrinho(usuario.Id, new CompraUsuario
        //        {
        //            IdProduto = Convert.ToInt32(id),
        //            QtdCompra = Convert.ToInt32(qtd),
        //            Estado = EnumEstadoCompra.Produto_Carrinho,
        //            UserId = usuario.Id
        //        });
        //        return Json(new { sucesso = true });
        //    }

        //    return Json(new { sucesso = false });

        //}

        //[HttpGet("/api/QtdProdutosCarrinho")]
        //public async Task<JsonResult> QtdProdutosCarrinho()
        //{
        //    var usuario = await _userManager.GetUserAsync(User);

        //    var qtd = 0;

        //    if (usuario != null)
        //    {
        //        qtd = await _InterfaceCompraUsuarioApp.QuantidadeProdutoCarrinhoUsuario(usuario.Id);

        //        return Json(new { sucesso = true, qtd = qtd });
        //    }

        //    return Json(new { sucesso = false, qtd = qtd });

        //}

    }
}