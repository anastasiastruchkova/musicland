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

                new Song { Title="Come together", Duration=264 },
                new Song { Title="Something", Duration=214 },
                new Song { Title="Here comes the sun", Duration=237 },

                new Song { Title="Ticket to Ride", Duration=250 },
                new Song { Title="Another girl", Duration=218 },

                new Song { Title="Mother", Duration=280 },
                new Song { Title="Another one brick in the wall", Duration=215 },
                new Song { Title="Wish you were here", Duration=257 },
                new Song { Title="Brain Damage", Duration=274 },

                new Song { Title="Right here, right now", Duration=201 },
                new Song { Title="Love Island", Duration=269 },
                new Song { Title="Praise you", Duration=236 },

                new Song { Title="Honey,honey", Duration=201 },
                new Song { Title="Waterloo", Duration=269 },

                new Song { Title="Dancing Queen", Duration=236 },
                new Song { Title="Money,money,money", Duration=236 },

                new Song { Title="Too much love will kill you", Duration=201 },
                new Song { Title="It's a butiful day", Duration=269 },

                new Song { Title="Breakthru", Duration=236 },
                new Song { Title="The invisible man", Duration=236 }

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
                            Name ="Abbey Road",
                            Year =1969,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[4],Songs[5], Songs[6]}
                        },

                        new Album
                        {
                            Name ="Help!",
                            Year =1965,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[7],Songs[8]}
                        },

                        new Album
                        {
                            Name ="The wall",
                            Year =1979,
                            Genre ="Psychodelic Rock",
                            Songs=new List<Song>{Songs[9],Songs[10]}
                        },

                        new Album
                        {
                            Name ="The dark side of the moon",
                            Year =1982,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[11],Songs[12]}
                        },

                        new Album
                        {
                            Name ="You've come a long way, baby",
                            Year =1998,
                            Genre ="Electro",
                            Songs=new List<Song>{Songs[13],Songs[14],Songs[15]}
                        },
                        new Album
                        {
                            Name ="Waterloo",
                            Year =1974,
                            Genre ="Pop",
                            Songs=new List<Song>{Songs[16],Songs[17]}
                        },
                        new Album
                        {
                            Name ="Arrival",
                            Year =1976,
                            Genre ="Pop",
                            Songs=new List<Song>{Songs[18],Songs[19]}
                        },
                        new Album
                        {
                            Name ="Made in heaven",
                            Year =1995,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[20],Songs[21]}
                        },
                        new Album
                        {
                            Name ="The miracle",
                            Year =1989,
                            Genre ="Rock",
                            Songs=new List<Song>{Songs[22],Songs[23]}
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
                },
                new Concert
                {
                  City = "New-York",
                  Date = new DateTime(2010, 10, 15, 20,30,0),
                  Tickets = 15,
                  Album = Albums[0]
                },
                new Concert
                {
                  City = "Viena",
                  Date = new DateTime(1995, 03, 20, 21,0,0),
                  Tickets = 78,
                  Album = Albums[10]
                },
                new Concert
                {
                  City = "Amsterdam",
                  Date = new DateTime(1989, 03, 28, 14,10,0),
                  Tickets = 3,
                  Album = Albums[9]
                },
                new Concert
                {
                  City = "Geneva",
                  Date = new DateTime(1975, 04, 21, 18,0,0),
                  Tickets = 29,
                  Album = Albums[8]
                },
                new Concert
                {
                  City = "Milan",
                  Date = new DateTime(1989, 07, 19, 21,30,0),
                  Tickets = 100,
                  Album = Albums[7]
                }
            };

            Musician[] Musicians =
                {
                new Musician
                {
                    Name = "Lady Gaga",
                    Albums=new List<Album>{Albums[0],Albums[1]},
                    Concerts=new List<Concert>{Concerts[0],Concerts[1],Concerts[5]}

                },
                new Musician
                {
                    Name = "The Beatles",
                    Albums=new List<Album>{Albums[2],Albums[3]},
                    Concerts=new List<Concert>{Concerts[2]}

                },
                new Musician
                {
                    Name = "Pink Floyd",
                    Albums=new List<Album>{Albums[4],Albums[5]},
                    Concerts=new List<Concert>{Concerts[3]}

                },
                new Musician
                {
                    Name = "FatBoy Slim",
                    Albums=new List<Album>{Albums[6]},
                    Concerts=new List<Concert>{Concerts[4]}

                },
                 new Musician
                {
                    Name = "ABBA",
                    Albums=new List<Album>{Albums[7], Albums[8]},
                    Concerts=new List<Concert>{Concerts[8],Concerts[9]}
                    
                },

                new Musician
                {
                    Name = "Queen",
                    Albums=new List<Album>{Albums[9], Albums[10]},
                    Concerts=new List<Concert>{Concerts[6],Concerts[7]}
                }
            };

            context.Musicians.AddOrUpdate(m => m.Name, Musicians);
            context.Songs.AddOrUpdate(s => s.Title, Songs);
            context.Albums.AddOrUpdate(a => a.Name, Albums);
            context.Concerts.AddOrUpdate(c => c.Date, Concerts);
        }
    }
}
