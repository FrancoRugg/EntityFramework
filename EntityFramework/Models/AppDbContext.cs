using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { 
            
        }
        public DbSet<Login> Login { get; set; } //Acá le ponemos el nombre del objeto de la tabla con el que vamos a trabajar, crear uno por cada tabla o modelo a utilizar.


    }
}
