using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Musicland.Classes
{
    public class SongRepository
    {
        public IEnumerable<Song> Songs
        {
            get
            {
                using (var context = new Context())
                    return context.Songs.Include(s=>s.Album).ToList();
            }
        }

        public void Add(Album album, Song song)
        {
            using (var context = new Context())
            {
                context.Songs.Add(song);
                var albumDB = context.Albums.Include(a => a.Songs).FirstOrDefault(a => a.Id == album.Id);
                var songDB = context.Songs.Find(song.Id);
                albumDB.Songs.Add(songDB);
                context.SaveChanges();
            }
        }

        public void Update(Song song, string title, int duration)
        {
            using (var context = new Context())
            {
                context.Songs.Find(song.Id).Title = title;
                context.Songs.Find(song.Id).Duration = duration;
                context.SaveChanges();
            }
        }

        public void Delete(Song song)
        {
            using (var context = new Context())
            {
                bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;
                try
                {
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.Songs.Attach(song);
                    context.Entry(song).State = EntityState.Deleted;
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
