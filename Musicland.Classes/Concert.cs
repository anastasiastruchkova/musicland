using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicland.Classes
{
    public class Concert
    {
        public string City { get; set; }
        public Album Album { get; set; }
        public DateTime Date { get; set; }
        public int Tickets { get; set; }
    }
}
