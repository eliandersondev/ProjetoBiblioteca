using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario user)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(user);
                bc.SaveChanges();
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

        public ICollection<Usuario> ListarTodos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                query = bc.Usuarios;
                
                //ordenação padrão
                return query.OrderBy(user => user.Nome).ToList();
            }
        }
       


        public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
    }
}