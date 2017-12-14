using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    return context.Concerts.ToList();
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
    }
}
