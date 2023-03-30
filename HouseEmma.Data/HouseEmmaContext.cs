using HouseEmma.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HouseEmma.Data
{
    public class HouseEmmaContext : DbContext
    {
        public HouseEmmaContext(DbContextOptions<HouseEmmaContext> options)
        : base(options) { }

        public DbSet<House> Houses { get; set; }
    }
}
