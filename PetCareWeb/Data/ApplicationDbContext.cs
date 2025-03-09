using Microsoft.EntityFrameworkCore;
using PetCareWeb.Models;
namespace PetCareWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DichVu> DichVus { get; set; }
    }
}
