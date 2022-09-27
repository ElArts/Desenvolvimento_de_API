using Chapter.Contexts;
using Chapter.Models;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

namespace Chapter.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;
        public LivroRepository(SqlContext context)
        {
            _context = context;

        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }


        public void Cadastrar(Livro LivroNovo)
        {
            _context.Livros.Add(LivroNovo);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livro = _context.Livros.Find(id);

            _context.Livros.Remove(livro);

            _context.SaveChanges();
        }

        public void Alterar(int id, Livro livro)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;

                _context.Livros.Update(livroBuscado);

                _context.SaveChanges();
            }
        }
    }
}
