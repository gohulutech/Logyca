using BusinessRules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MyWebApiContext : DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Code> Codes { get; set; }
    }
}
