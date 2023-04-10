using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

#nullable disable
namespace Proyecto_Final.BLL
{
  public   class CategoriaBLL
    {   
                private ApplicationDbContext contexto;

        public CategoriaBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public Categoria Buscar(int id)
        {
            Categoria categoria = new Categoria();

            try
            {
                categoria = contexto.Categoria
                .Where(p => p.CategoriaId == id && p.Estado == true)
                .AsNoTracking()
                .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }


        public List<Categoria> GetList(Expression<Func<Categoria, bool>> categoria)
        {
            List<Categoria> Lista = new List<Categoria>();
            try
            {
                Lista = contexto.Categoria
                .Where(c => c.Estado == true)
                .Where(categoria)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


    }
}