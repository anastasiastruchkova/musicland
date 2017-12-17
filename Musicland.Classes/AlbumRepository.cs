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
                    return context.Albums
                        .Include(a => a.Songs)
                        .Include(a=>a.Musician)
                        .ToList();
                }
            }
        }

        public void Add(Album album)
        {
            using (var context = new Context())
            {
                context.Albums.Add(album);
                context.SaveChanges();
            }
        }

        public void Update(Album album, string name, int year, string genre)
        {
            using (var context = new Context())
            {
                context.Albums.Find(album.Id).Name=name;
                context.Albums.Find(album.Id).Year=year;
                context.Albums.Find(album.Id).Genre=genre;
                context.SaveChanges();
            }
        }

        public void Delete(Album album)
        {
            using (var context = new Context())
            {
                bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;
                try
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.Albums.Attach(album);
                    context.Entry(album).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                finally
                {
                    context.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                }
            }
        }


    }
}
