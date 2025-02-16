using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) :DbContext(options)
    {
        public DbSet<ProductEntity> Products { get; set; }

    }
}
