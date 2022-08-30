using Microsoft.EntityFrameworkCore;

namespace AplicacionNetMVC.Datos
{
    public class ApplicationDBContex : DbContext
    {
        public ApplicationDBContex(DbContextOptions<ApplicationDBContex>)
        {

        }

    }
}
