﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosClassLibrary
{
    public class BoughtItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
