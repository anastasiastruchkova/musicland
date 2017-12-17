using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Musicland.Classes
{
    public class MusicianRepository
    {
        public IEnumerable<Musician> Musicians
        {
            get
            {
                using (var context = new Context())
                {
                    return context.Musicians
                        .Include(m => m.Albums)
                        .Include(m=>m.Concerts)
                        .ToList();
                }
            }
        }
            

    }
}
