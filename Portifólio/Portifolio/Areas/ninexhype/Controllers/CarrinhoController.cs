using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Areas.NinexHype.Data;
using Portifolio.Areas.NinexHype.Models;

namespace Portifolio.Areas.NinexHype.Controllers;

[Area("NinexHype")]

    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public CarrinhoController(AppDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Carrinho/
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null) return RedirectToAction("Login", "Account");

            var carrinho = await ObterCarrinho(usuario.Id);

            ViewBag.Total = carrinho.Itens.Sum(i => i.Produto.ValorVenda * i.Quantidade);
            await AtualizarCarrinhoCount(usuario.Id);

            return View(carrinho);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(int produtoId, int quantidade = 1)
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null) return Unauthorized();

            var produto = await _context.Produtos.FindAsync(produtoId);
            if (produto == null) return NotFound();

            var carrinho = await ObterCarrinho(usuario.Id);

            var itemExistente = carrinho.Itens.FirstOrDefault(i => i.ProdutoId == produtoId);
            if (itemExistente != null)
            {
                itemExistente.Quantidade += quantidade;
                _context.CarrinhoItens.Update(itemExistente);
            }
            else
            {
                var novoItem = new CarrinhoItem
                {
                    ProdutoId = produtoId,
                    Quantidade = quantidade,
                    CarrinhoId = carrinho.Id
                };
                _context.CarrinhoItens.Add(novoItem);
            }

            await _context.SaveChangesAsync();
            await AtualizarCarrinhoCount(usuario.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remover(int itemId)
        {
            var item = await _context.CarrinhoItens.FindAsync(itemId);
            if (item == null) return NotFound();

            _context.CarrinhoItens.Remove(item);
            await _context.SaveChangesAsync();

            var usuario = await _userManager.GetUserAsync(User);
            await AtualizarCarrinhoCount(usuario.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarQuantidade(int itemId, int novaQuantidade)
        {
            var item = await _context.CarrinhoItens
                .Include(i => i.Carrinho)
                .FirstOrDefaultAsync(i => i.Id == itemId);

            if (item == null) return NotFound();

            if (novaQuantidade <= 0)
            {
                _context.CarrinhoItens.Remove(item);
            }
            else
            {
                item.Quantidade = novaQuantidade;
                _context.CarrinhoItens.Update(item);
            }

            await _context.SaveChangesAsync();

            var usuario = await _userManager.GetUserAsync(User);
            await AtualizarCarrinhoCount(usuario.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Limpar()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var carrinho = await ObterCarrinho(usuario.Id);

            if (carrinho != null)
            {
                _context.CarrinhoItens.RemoveRange(carrinho.Itens);
                await _context.SaveChangesAsync();
            }

            await AtualizarCarrinhoCount(usuario.Id);

            return RedirectToAction("Index");
        }

        // =============================
        // Métodos auxiliares
        // =============================

        private async Task<Carrinho> ObterCarrinho(string usuarioId)
        {
            var carrinho = await _context.Carrinhos
                .Include(c => c.Itens)
                    .ThenInclude(i => i.Produto)
                        .ThenInclude(p => p.Fotos) // ✅ Adicionado para carregar as fotos do produto
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);

            if (carrinho == null)
            {
                carrinho = new Carrinho { UsuarioId = usuarioId };
                _context.Carrinhos.Add(carrinho);
                await _context.SaveChangesAsync();
            }

            return carrinho;
        }

        private async Task AtualizarCarrinhoCount(string usuarioId)
        {
            var carrinho = await _context.Carrinhos
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);

            ViewBag.CarrinhoCount = carrinho?.Itens.Sum(i => i.Quantidade) ?? 0;
        }
    }
