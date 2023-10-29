using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sighiartau_Adriana_Lab2.Models;

namespace Sighiartau_Adriana_Lab2.Data
{
    public class Sighiartau_Adriana_Lab2Context : DbContext
    {
        public Sighiartau_Adriana_Lab2Context (DbContextOptions<Sighiartau_Adriana_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Sighiartau_Adriana_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Sighiartau_Adriana_Lab2.Models.Publisher>? Publisher { get; set; }
    }
}
