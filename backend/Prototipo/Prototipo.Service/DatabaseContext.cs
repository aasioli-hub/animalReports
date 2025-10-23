using Microsoft.EntityFrameworkCore;
using Prototipo.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
                
        }





        public DbSet<Category> Categories { get; set; }

    }
}
