using Microsoft.EntityFrameworkCore;
using AplicacionNetMVC.Models;
namespace AplicacionNetMVC.Datos
{
    public class ApplicationDBContex : DbContext
    {
        public ApplicationDBContex(DbContextOptions<ApplicationDBContex> options) : base(options)
        {
        
        }
        //instancias los modelos
        public DbSet<Usuario> Usuario { get; set; }


    }
}
