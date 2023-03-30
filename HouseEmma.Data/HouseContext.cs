﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HouseEmma.Data
{
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions<HouseContext> options)
        : base(options) { }

        public DbSet<House> Houses { get; set; }
    }
}