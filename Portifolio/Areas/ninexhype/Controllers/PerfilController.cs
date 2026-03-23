using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Areas.NinexHype.Models;
using System.IO;
using System.Threading.Tasks;
using System;

namespace Portifolio.Areas.NinexHype.Controllers;

[Area("NinexHype")]

[Authorize]
public class PerfilController : Controller
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IWebHostEnvironment _env;

    public PerfilController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IWebHostEnvironment env)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _env = env;
    }

    // GET: /Perfil
    public async Task<IActionResult> Index()
    {
        var usuario = await _userManager.GetUserAsync(User);
        if (usuario == null) return RedirectToAction("Login", "Account");

        return View(usuario);
    }

    // GET: /Perfil/Editar
    public async Task<IActionResult> Editar()
    {
        var usuario = await _userManager.GetUserAsync(User);
        if (usuario == null) return RedirectToAction("Login", "Account");

        return View(usuario);
    }

    // POST: /Perfil/Editar
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Usuario model, IFormFile foto)
    {
        var usuario = await _userManager.GetUserAsync(User);
        if (usuario == null) return RedirectToAction("Login", "Account");

        usuario.Nome = model.Nome;
        usuario.Email = model.Email;
        usuario.UserName = model.Email;

        // Se uma nova foto foi enviada
        if (foto != null && foto.Length > 0)
        {
            var uploadDir = Path.Combine(_env.WebRootPath, "img", "usuarios");
            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            // Gera nome único baseado no ID do usuário
            var fileName = $"{usuario.Id}{Path.GetExtension(foto.FileName)}";
            var filePath = Path.Combine(uploadDir, fileName);

            // Exclui foto antiga se existir
            if (!string.IsNullOrEmpty(usuario.Foto))
            {
                var oldFile = Path.Combine(uploadDir, usuario.Foto);
                if (System.IO.File.Exists(oldFile))
                    System.IO.File.Delete(oldFile);
            }

            // Salva a nova imagem
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await foto.CopyToAsync(stream);
            }

            // Atualiza o campo no banco
            usuario.Foto = fileName;
        }

        var result = await _userManager.UpdateAsync(usuario);

        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(usuario);
            TempData["Sucesso"] = "Perfil atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        foreach (var erro in result.Errors)
            ModelState.AddModelError("", erro.Description);

        return View(model);
    }

    // GET: /Perfil/AlterarSenha
    public IActionResult AlterarSenha() => View();

    // POST: /Perfil/AlterarSenha
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AlterarSenha(string senhaAtual, string novaSenha)
    {
        var usuario = await _userManager.GetUserAsync(User);
        if (usuario == null) return RedirectToAction("Login", "Account");

        var result = await _userManager.ChangePasswordAsync(usuario, senhaAtual, novaSenha);
        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(usuario);
            TempData["Sucesso"] = "Senha alterada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        foreach (var erro in result.Errors)
            ModelState.AddModelError("", erro.Description);

        return View();
    }
}
