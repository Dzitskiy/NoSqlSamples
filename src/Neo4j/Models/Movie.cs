﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4j.Models
{
    public class Movie
    {
        public string title { get; set; }
        public int released { get; set; }
        public string tagline { get; set; }
    }
}
