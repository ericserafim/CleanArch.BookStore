using System.Collections.Generic;

namespace BookStore.Core.Entities
{
    public class Author : EntityBase
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public string Name { get; set; }
        public string Origin { get; set; }
        public ICollection<Book> Books { get; private set; }
    }
}
