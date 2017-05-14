﻿using System;
using System.Collections.Generic;

namespace XtoJ.Core.Entities
{
    public class Catalog : Entity
    {
        public List<Book> Books { get; set; }

        public Catalog()
        {
            Books = new List<Book>();
        }
    }

    public class Book
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string Description { get; set; }
    }
}
