using Microsoft.EntityFrameworkCore;


namespace KevinAndJustinsBookStore.Shared
{
    [Owned]
    public class Book
    {
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int ISBN { get; set; }
        public int DewyDec { get; set; }
        public int Count { get; set; }
    }
}
