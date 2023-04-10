using System.Linq.Expressions;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

#nullable  disable
namespace Proyecto_Final.BLL
{
  
   public  class FacturaBLL
    {
        private ApplicationDbContext contexto;

         public FacturaBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Facturas.Any(c => c.FacturaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

         public Facturas ExisteNombre(string Nombre)
        {
            Facturas existe;

            try
            {
                existe = contexto.Facturas                
                .Where( p => p.NombreProvedor
                .ToLower() == Nombre.ToLower())
                .AsNoTracking()
                .SingleOrDefault();

            }catch
            {
                throw;
            }
            return existe;
        }

        

        public bool Guardar(Facturas facturas)
        {
             
            if (!Existe(facturas.FacturaId))
                return  Insertar(facturas);
            else
                return  Modificar(facturas);
        }

        

        private bool Insertar(Facturas facturas)
        {
            bool Insertado = false;

            try
            {
                if (contexto.Facturas.Add(facturas) != null)
                {
                    Insertado =  contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Facturas articulo)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                Insertado = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Facturas Buscar(int id)
        {
            return contexto.Facturas
                .Where(a => a.FacturaId == id && a.Estado == true)
                .SingleOrDefault();
        }

        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var facturas = Buscar(id);

                if (facturas!= null)
                {
                    facturas.Estado = false;
                    Eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Facturas> GetList(Expression<Func<Facturas, bool>> facturas)
        {
            List<Facturas> Lista = new List<Facturas>();
            try
            {
                Lista = contexto.Facturas
                .Where(a => a.Estado == true)
                .Where(facturas)
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