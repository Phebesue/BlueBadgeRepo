﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MousePark.Models
{
    public class RatingEdit
    {
        public int RatingId { get; set; }
        public int Score { get; set; }
        public int? EateryId { get; set; }
        public int? RideId { get; set; }
        public int? ShowId { get; set; }
    }
}
