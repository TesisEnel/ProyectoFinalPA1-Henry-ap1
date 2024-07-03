using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models;
using Microsoft.AspNetCore.Identity;


namespace Proyecto_Final.Data;
#nullable disable
public class ApplicationDbContext : IdentityDbContext<Usuarios,IdentityRole<int>,int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Suplidor> Suplidor { get; set; }
    public DbSet<Facturas> Facturas { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Pago> Pago { get; set; }


    

 protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Categoria>().HasData(

        new Categoria { CategoriaId = 1, Descripcion = "Consumidor final"},
        new Categoria { CategoriaId = 2, Descripcion = "Comprovante fiscal"}       // Categorias de facturas
      
        );
      
       
      }

}
