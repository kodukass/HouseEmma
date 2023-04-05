using Microsoft.EntityFrameworkCore;
using HouseEmma.Core.Domain;

namespace HouseEmma.Data
{
    public class HouseEmmaContext : DbContext
    {
        public HouseEmmaContext(DbContextOptions<HouseEmmaContext> options)
        : base(options) { }

        public DbSet<House> Houses { get; set; }
    }
}
