﻿using MousePark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MousePark.Models
{
    public class RideDetail
    {
        public string RideName { get; set; }
        public string RideDescription { get; set; }
        public int HeightReq { get; set; }
        public RideType RideType { get; set; }
    }
}