using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Musicland.Classes
{
    public class ConcertRepository 
    { 
        public IEnumerable<Concert> Concerts
        {
            get
            {
                using (var context = new Context())
                {
                    return context.Concerts.Include(c=>c.Musician).ToList();
                }
            }
        } 

        public void BuyTicket(Concert concert)
        {
            using (var context = new Context())
            {
                context.Concerts.Find(concert.Id).Tickets--;
                context.SaveChanges();
            }
        }

        public List<Concert> SearchCity(string city)
        {
            List<Concert> concerts = new List<Concert>();
            foreach(Concert concert in Concerts)
            {
                if (concert.City == city) concerts.Add(concert);
            }
            return concerts;
        }

        public List<Concert> SearchMonth(string month)
        {
            List<Concert> concerts = new List<Concert>();
            foreach (Concert concert in Concerts)
            {
                if (concert.Date.Month == int.Parse(month))
                    concerts.Add(concert);
            }
            return concerts;
        }

        public List<Concert> SearchYear(string year)
        {
            List<Concert> concerts = new List<Concert>();
            foreach (Concert concert in Concerts)
            {
                if (concert.Date.Year == int.Parse(year))
                    concerts.Add(concert);
            }
            return concerts;
        }

    }
}
