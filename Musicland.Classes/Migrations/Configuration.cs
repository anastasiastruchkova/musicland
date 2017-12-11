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
                new Song { Title="Joanne", Duration=210 }
            };

            Album[] Albums ={
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
                        } };

            Concert[] Concerts =
                {
                new Concert
            {
                City = "Moscow",
                Date = new DateTime(2017, 11, 1),
                Tickets = 123,
                Album = Albums[0]
            },
                new Concert
                {
                  City = "Las Vegas",
                  Date = new DateTime(2017, 10, 11),
                  Tickets = 54,
                  Album = Albums[1]
                }};

            Musician[] Musicians =
                {
                new Musician
                {
                    Name = "Lady Gaga",
                    Albums=new List<Album>{Albums[0],Albums[1]},
                    Concerts=new List<Concert>{Concerts[0],Concerts[1]}

                }
            };

            context.Musicians.AddOrUpdate(m => m.Name, Musicians);
            context.Songs.AddOrUpdate(s => s.Title, Songs);
            context.Albums.AddOrUpdate(a => a.Name, Albums);
        }

    }
}
