using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Areas.NinexHype.Models;
using Portifolio.Areas.NinexHype.Data;
using Microsoft.EntityFrameworkCore;
using Portifolio.Areas.NinexHype.ViewModels;

namespace Portifolio.Areas.NinexHype.Controllers;

[Area("NinexHype")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var produtos = _db.Produtos
                .Where(p => p.CategoriaId != 8)
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .ToList();

            var destaques = _db.Produtos
                .Where(p => p.CategoriaId == 8)
                .OrderBy(p => EF.Functions.Random())
                .Include(p => p.Fotos)
                .Take(4)
                .ToList();

            var tiposRoupa = _db.TiposRoupa
                .Include(t => t.Categorias)
                .ThenInclude(c => c.Produtos)
                .ToList();

            // Filtrar produtos de cada categoria, removendo destaques
            foreach (var tipo in tiposRoupa)
            {
                foreach (var categoria in tipo.Categorias)
                {
                    categoria.Produtos = categoria.Produtos
                        .Where(p => p.CategoriaId != 8)
                        .ToList();
                }
            }
            var indexVM = new IndexVM
            {
                Produtos = produtos,
                Destaques = destaques,
                TiposRoupa = tiposRoupa
            };

            return View(indexVM);
        }


        public IActionResult Produto(int id)
        {
            Produto produto = _db.Produtos
                .Where(p => p.Id == id)
                .Where(p => p.CategoriaId != 8)
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .SingleOrDefault();

            List<Produto> semelhantes = _db.Produtos
                .Where(p => p.Id != id && p.CategoriaId == produto.CategoriaId)
                .Where(p => p.CategoriaId != 8)
                .OrderBy(p => EF.Functions.Random())
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .Take(4)
                .ToList();

            ProdutoVM produtoVM = new()
            {
                Produto = produto,
                Semelhantes = semelhantes
            };

            return View(produtoVM);
        }

        public IActionResult PagHomem()
        {
            // Carregar todos os produtos masculinos, incluindo categoria e fotos
            var produtos = _db.Produtos
                .Where(p => p.Genero == Genero.Masculino)
                .Where(p => p.CategoriaId != 8)
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .ToList();

            // Carregar tipos de roupa com categorias e produtos masculinos
            var tiposRoupa = _db.TiposRoupa
                .Include(t => t.Categorias)
                    .ThenInclude(c => c.Produtos)
                .ToList();

            // Filtrar produtos masculinos de cada categoria, evitando nulos
            foreach (var tipo in tiposRoupa)
            {
                if (tipo.Categorias == null) continue;

                foreach (var categoria in tipo.Categorias)
                {
                    categoria.Produtos = categoria.Produtos?
                        .Where(p => p.Genero == Genero.Masculino)
                        .ToList() ?? new List<Produto>();
                }
            }

            // Criar ViewModel
            var indexVM = new IndexVM
            {
                Produtos = produtos,
                TiposRoupa = tiposRoupa
            };

            return View(indexVM);
        }
        public IActionResult PagMulher()
        {
            var produtos = _db.Produtos
                .Where(p => p.Genero == Genero.Feminino)
                .Where(p => p.CategoriaId != 8)
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .ToList();

            var tiposRoupa = _db.TiposRoupa
                .Include(t => t.Categorias)
                    .ThenInclude(c => c.Produtos)
                .ToList();

            // Filtrar produtos femininos de cada categoria, evitando nulos
            foreach (var tipo in tiposRoupa)
            {
                if (tipo.Categorias == null) continue;

                foreach (var categoria in tipo.Categorias)
                {
                    categoria.Produtos = categoria.Produtos?
                        .Where(p => p.Genero == Genero.Feminino)
                        .ToList() ?? new List<Produto>();
                }
            }

            var indexVM = new IndexVM
            {
                Produtos = produtos,
                TiposRoupa = tiposRoupa
            };

            return View(indexVM);
        }
        public IActionResult Unissex()
        {
            var produtos = _db.Produtos
                .Where(p => p.CategoriaId != 8)
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .ToList();

            if (produtos == null || !produtos.Any())
            {
                ViewBag.Mensagem = "Nenhum produto disponível no momento.";
                return View(new List<Produto>());
            }

            return View(produtos);
        }


        // Filtros de produtoss
        public async Task<IActionResult> Filtro(string categoria)
        {
            if (string.IsNullOrEmpty(categoria))
                return RedirectToAction("Index");

            // Busca produtos que pertençam à categoria informada
            var produtos = await _db.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .Where(p => p.Categoria.Nome.ToLower() == categoria.ToLower())
                .ToListAsync();

            ViewBag.Categoria = categoria;
            return View("Filtro", produtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
