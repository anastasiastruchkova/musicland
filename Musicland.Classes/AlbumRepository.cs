using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Musicland.Classes
{
    public class AlbumRepository
    {
        public IEnumerable<Album> Albums
        {
            get
            {
                using (var context = new Context())
                {
                    return context.Albums.Include(a => a.Songs).ToList();
                }
            }
        }
    }
}
