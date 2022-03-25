using CRUDDatatableAjax.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDDatatableAjax.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; } //Persons es el nombre de la tabla
    }
}
