using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void incluirUsuario(Usuario user)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(user);
                bc.SaveChanges();
            }
        }

        public void editarUsuario(Usuario user)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(user.Id);
                usuario.Nome = user.Nome;
                usuario.Login = user.Login;
                usuario.Senha = user.Senha;
                usuario.Tipo = user.Tipo;
                bc.SaveChanges();
            }
        }

        public void excluirUsuario(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Remove(bc.Usuarios.Find(id));
                bc.SaveChanges();
            }
        }
        public List<Usuario> ListarTodos()
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }
        }

        public void Atualizar(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(user.Id);
                usuario.Nome = user.Nome;
                usuario.Login = user.Login;
                usuario.Senha = user.Senha;
                usuario.Tipo = user.Tipo;

                bc.SaveChanges();
            }
        }


        public Usuario Listar(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
    }
}