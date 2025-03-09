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
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<ThuCung> ThuCung { get; set; }
    }
}
