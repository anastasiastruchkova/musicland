using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicland.Classes
{
    public class Song
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        //lyrics

        public string Info
        {
            get
            { return $"{Title} - {Duration}sec"; }
        }
        
    }

}
