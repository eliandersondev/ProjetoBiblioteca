using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult RegistrarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario l)
        {
            UsuarioService usuarioService = new UsuarioService();

            if (l.Id == 0)
            {
                usuarioService.incluirUsuario(l);
            }
            else
            {
                usuarioService.Atualizar(l);
            }

            return RedirectToAction("ListaDeUsuarios");
        }

        public IActionResult ListaDeUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            UsuarioService usuarioService = new UsuarioService();
            return View(usuarioService.ListarTodos());
        }

        public IActionResult editarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            UsuarioService us = new UsuarioService();
            Usuario user = us.Listar(id);
            return View(user);
        }

        public IActionResult ExcluirUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            UsuarioService us = new UsuarioService();
            us.excluirUsuario(id);
            return RedirectToAction("ListaDeUsuarios");

        }

        public IActionResult NeedAdmin(){
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Sair(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }



    }
}