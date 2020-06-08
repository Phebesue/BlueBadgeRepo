﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MousePark.Models
{
    public enum AttractionType { Eatery, Ride, Show }
    public class AttractionListItem
    {
        public AttractionType AttractionType { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
