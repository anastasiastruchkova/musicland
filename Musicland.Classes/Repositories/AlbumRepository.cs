﻿using System.Collections.Generic;
using System.Linq;
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
                        .Include(a => a.Musician)
                        .ToList();
                }
            }
        }

        public void Add(Musician artist, Album album)
        {
            using (var context = new Context())
            {
                context.Albums.Add(album);
                var musicianDB = context.Musicians.Include(m => m.Albums).FirstOrDefault(m => m.Id == artist.Id);
                var albumDB = context.Albums.Find(album.Id);
                musicianDB.Albums.Add(albumDB);
                context.SaveChanges();
            }
        }

        public void Update(Album album, string name, int year, string genre)
        {
            using (var context = new Context())
            {
                context.Albums.Find(album.Id).Name = name;
                context.Albums.Find(album.Id).Year = year;
                context.Albums.Find(album.Id).Genre = genre;
                context.SaveChanges();
            }
        }

        public void Delete(Album album)
        {
            try
            {
                using (var context = new Context())
                {
                    SongRepository songRepository = new SongRepository();
                    foreach (Song song in songRepository.Songs.Where(s => s.Album.Id == album.Id))
                    {
                        context.Entry(song).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                }

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
            catch
            { }

        }
    }
}   

