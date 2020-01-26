using System;
using System.Collections.Generic;

namespace BigDeckPlays.Shared.Models
{
    public class ScryfallContainer<T>
    {
        public string Object { get; set; }
        public bool Has_More { get; set; }
        public List<T> Data { get; set; }
    }
}
