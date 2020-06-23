using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KevinAndJustinsBookStore.Shared
{
    public class BookDto
    {
        [Range(1, int.MaxValue)]
        public string Title { get; set; }
        [Range(1, int.MaxValue)]
        public string Authors { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int ISBN { get; set; }
        public int DewyDec { get; set; }
        public int Count { get; set; }
    }
}
