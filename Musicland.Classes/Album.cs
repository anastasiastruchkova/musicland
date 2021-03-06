﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicland.Classes
{
    public class Album
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public List<Song> Songs { get; set; }

        public string Info
        {
            get { return $"{Name} ({Year})"; }
        }
    }
}
