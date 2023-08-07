using Microsoft.EntityFrameworkCore;

namespace CRUD_ASP7.Datos
{
    public class ApplicationDBContex
    {
        public class ApplicationDbContexto : DbContext
        {
            public ApplicationDbContexto(DbContextOptions<ApplicationDbContexto> options) 
                : base(options)
            {
            }
            public DbSet<CRUD_ASP7.Models.Contacto> Contactos { get; set; }
        }
    }
}
