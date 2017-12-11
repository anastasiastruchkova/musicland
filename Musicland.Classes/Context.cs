using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicland.Classes
{
    public class Context:DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Song> Songs { get; set; }

        public Context():base("localsql")
        {
                
        }
    }
}
