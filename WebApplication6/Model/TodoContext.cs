using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Model
{
    public class TodoContext :DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
        //public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
