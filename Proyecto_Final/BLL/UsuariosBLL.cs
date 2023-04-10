using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

namespace Proyecto_Final.BLL
{
     public class UsuariosBLL
    {
        private ApplicationDbContext contexto;

        public UsuariosBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public async Task<List<Usuarios>> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            try
            {
                Lista = await contexto.Usuarios
                .Where(usuario)
                .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}