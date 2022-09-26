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


    }
}
