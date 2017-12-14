namespace Musicland.Classes.Migrations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Musicland.Classes.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Musicland.Classes.Context context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Song[] Songs =
                {
                new Song { Title="Poker Face", Duration=240 },
                new Song { Title="Paparazzi", Duration=200 },
                new Song { Title="Million Reasons", Duration=233 },
                new Song { Title="Joanne", Duration=210 },

                new Song { Title="Yellow Submarine", Duration=264 },
                new Song { Title="Hey, Jude", Duration=214 },

                new Song { Title="Mother", Duration=300 },
                new Song { Title="Another one brick in the wall", Duration=320 },
                new Song { Title="Wish you were here", Duration=350 },
                new Song { Title="Brain Damage", Duration=274 },

                new Song { Title="Right here, right now", Duration=310 },
                new Song { Title="Love Island", Duration=269 },
                new Song { Title="Praise you", Duration=320 }
            };

            Album[] Albums =
                {
                        new Album
                        {
                            Name ="The Fame",
                            Year =2008,
                            Genre ="Pop",
                            Songs=new List<Song>{Songs[0],Songs[1]}
                        },
                        new Album
                        {
                            Name ="Joanne",
                            Year =2016,
                            Genre ="Pop",
                            Songs=new List<Song>{Songs[2],Songs[3]}
                        },

                        new Album
                        {
                            Name ="Let it be",
                            Year =1970,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[4],Songs[5]}
                        },

                        new Album
                        {
                            Name ="The wall",
                            Year =1979,
                            Genre ="Psychodelic Rock",
                            Songs=new List<Song>{Songs[6],Songs[7]}
                        },

                        new Album
                        {
                            Name ="The dark side of the moon",
                            Year =1982,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[8],Songs[9]}
                        },

                        new Album
                        {
                            Name ="You've come a long way, baby",
                            Year =1998,
                            Genre ="Electro",
                            Songs=new List<Song>{Songs[10],Songs[11],Songs[12]}
                        }
            };

            Concert[] Concerts =
                {
                new Concert
            {
                City = "Moscow",
                Date = new DateTime(2017, 11, 1,19,30,0),
                Tickets = 123,
                Album = Albums[0]
            },
                new Concert
                {
                  City = "Las Vegas",
                  Date = new DateTime(2017, 10, 11,20,15,0),
                  Tickets = 54,
                  Album = Albums[1]
                },

                new Concert
                {
                  City = "London ",
                  Date = new DateTime(1970, 05, 1,21,30,0),
                  Tickets = 10,
                  Album = Albums[2]
                },

                new Concert
                {
                  City = "Paris",
                  Date = new DateTime(1983, 10, 3, 19, 0, 0),
                  Tickets = 100,
                  Album = Albums[3]
                },

                new Concert
                {
                  City = "Amsterdam",
                  Date = new DateTime(2010, 01, 10, 20,0,0),
                  Tickets = 78,
                  Album = Albums[5]
                }
            };

            Musician[] Musicians =
                {
                new Musician
                {
                    Name = "Lady Gaga",
                    Albums=new List<Album>{Albums[0],Albums[1]},
                    Concerts=new List<Concert>{Concerts[0],Concerts[1]}

                },
                new Musician
                {
                    Name = "The Beatles",
                    Albums=new List<Album>{Albums[2]},
                    Concerts=new List<Concert>{Concerts[2]}

                },
                new Musician
                {
                    Name = "Pink Floyd",
                    Albums=new List<Album>{Albums[3],Albums[4]},
                    Concerts=new List<Concert>{Concerts[3]}

                },
                new Musician
                {
                    Name = "FatBoy Slim",
                    Albums=new List<Album>{Albums[5]},
                    Concerts=new List<Concert>{Concerts[4]}

                }
            };

            context.Musicians.AddOrUpdate(m => m.Name, Musicians);
            context.Songs.AddOrUpdate(s => s.Title, Songs);
            context.Albums.AddOrUpdate(a => a.Name, Albums);
            context.Concerts.AddOrUpdate(c => c.Date, Concerts);
        }
    }
}
