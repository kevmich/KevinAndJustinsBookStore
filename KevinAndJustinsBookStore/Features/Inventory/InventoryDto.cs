using KevinAndJustinsBookStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinAndJustinsBookStore.Features
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public BookDto Book { get; set; }
        public string Movies { get; set; }
        public string Puzzels { get; set; }
        public string Toys { get; set; }
    }
}
