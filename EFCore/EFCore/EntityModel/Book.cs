﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.EntityModel
{
    public class Book
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }
}
