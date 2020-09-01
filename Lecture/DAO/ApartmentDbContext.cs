using Microsoft.EntityFrameworkCore;
using Lecture.Models;
namespace Lecture.DAO
{
    public class ApartmentDbContext : DbContext
    {
        public ApartmentDbContext(DbContextOptions<ApartmentDbContext> options) : base(options)
        {
        }
        public DbSet<ResidentModel> residents {get;set;}
    }
}