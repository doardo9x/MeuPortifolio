using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portifolio.Areas.NinexHype.Data;
using Portifolio.Areas.NinexHype.Models;

namespace Portifolio.Areas.NinexHype.Controllers;

[Area("NinexHype")]

    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // -------------------------- FUNÇÃO PARA REMOVER ACENTOS --------------------------
        private string Normalizar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";

            return new string(
                texto.Normalize(NormalizationForm.FormD)
                     .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                     .ToArray()
            ).ToLower();
        }

        // -------------------------------- LISTAGEM --------------------------------------
        public async Task<IActionResult> Index()
        {
            var produtos = _context.Produtos
                .Include(p => p.Categoria)
                    .ThenInclude(c => c.TipoRoupa)
                .Include(p => p.Fotos);

            return View(await produtos.ToListAsync());
        }

        // -------------------------------- PESQUISA GLOBAL --------------------------------
        public async Task<IActionResult> Pesquisar(string termo)
        {
            if (string.IsNullOrWhiteSpace(termo))
                return View("Pesquisar", new List<Produto>());

            string termoNormalizado = Normalizar(termo);

            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .ThenInclude(c => c.TipoRoupa)
                .Include(p => p.Fotos)
                .Where(p => p.CategoriaId != 8)   // ⬅ EXCLUI produto destaque
                .ToListAsync();


            var resultados = produtos.Where(p =>
                Normalizar(p.Nome).Contains(termoNormalizado) ||
                Normalizar(p.Marca).Contains(termoNormalizado) ||
                Normalizar(p.Descricao).Contains(termoNormalizado) ||
                Normalizar(p.Cor).Contains(termoNormalizado) ||

                // Categoria (Camisa, Jaqueta, Calça...)
                Normalizar(p.Categoria.Nome).Contains(termoNormalizado) ||

                // Tipo de roupa (Roupa, Tênis...)
                Normalizar(p.Categoria.TipoRoupa.Nome).Contains(termoNormalizado) ||

                // Gênero (Masculino, Feminino, Unissex)
                Normalizar(p.Genero.ToString()).Contains(termoNormalizado)

            ).ToList();

            return View("Pesquisar", resultados);
        }

        // -------------------------------- DETALHES ---------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        // -------------------------------- CRIAR ----------------------------------------
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,CategoriaId,Nome,Descricao,QtdeEstoque,ValorCusto,ValorVenda,Destaque,Genero,Marca,Cor,Material,AtividadeRecomendada")]
            Produto produto,
            List<IFormFile> Fotos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();

                if (Fotos != null && Fotos.Count > 0)
                {
                    var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "produtos");
                    if (!Directory.Exists(pastaDestino))
                        Directory.CreateDirectory(pastaDestino);

                    foreach (var foto in Fotos)
                    {
                        if (foto.Length > 0)
                        {
                            var nomeArquivo = Guid.NewGuid() + Path.GetExtension(foto.FileName);
                            var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

                            using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                            await foto.CopyToAsync(stream);

                            _context.ProdutoFoto.Add(new ProdutoFoto
                            {
                                ProdutoId = produto.Id,
                                ArquivoFoto = "/NinexHype.-img/produtos/" + nomeArquivo
                            });
                        }
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)), produto.Genero);
            return View(produto);
        }

        // -------------------------------- EDITAR ----------------------------------------
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos
                .Include(p => p.Fotos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) return NotFound();

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)), produto.Genero);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,CategoriaId,Nome,Descricao,QtdeEstoque,ValorCusto,ValorVenda,Destaque,Genero,Marca,Cor,Material,AtividadeRecomendada")]
            Produto produto)
        {
            if (id != produto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Produtos.Any(e => e.Id == produto.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)), produto.Genero);
            return View(produto);
        }

        // -------------------------------- ADICIONAR FOTO --------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarFoto(int produtoId, List<IFormFile> novasFotos)
        {
            if (novasFotos != null && novasFotos.Count > 0)
            {
                var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "produtos");
                if (!Directory.Exists(pastaDestino))
                    Directory.CreateDirectory(pastaDestino);

                foreach (var foto in novasFotos)
                {
                    if (foto.Length > 0)
                    {
                        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(foto.FileName);
                        var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await foto.CopyToAsync(stream);

                        _context.ProdutoFoto.Add(new ProdutoFoto
                        {
                            ProdutoId = produtoId,
                            ArquivoFoto = "/NinexHype.-img/produtos/" + nomeArquivo
                        });
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Edit", new { id = produtoId });
        }

        // -------------------------------- EXCLUIR FOTO ----------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirFoto(int fotoId)
        {
            var foto = await _context.ProdutoFoto.FindAsync(fotoId);
            if (foto != null)
            {
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", foto.ArquivoFoto.TrimStart('/'));
                if (System.IO.File.Exists(caminho))
                    System.IO.File.Delete(caminho);

                _context.ProdutoFoto.Remove(foto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Edit", new { id = foto?.ProdutoId });
        }

        // -------------------------------- DELETAR ----------------------------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
                _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
