﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDeEekhoorn.Models
{
    public class Year
    {
        public IList<Item> Items { get; set; }

        public Year()
        {
            Items = new List<Item>();
        }
    }
}