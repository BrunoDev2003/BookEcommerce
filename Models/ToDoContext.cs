using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookEcommerceAPI.Models
{
    public class ToDoContext: DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option)
        : base(option) { 

        }

        public DbSet<Produto> todoProducts { get; set; }
    }
}