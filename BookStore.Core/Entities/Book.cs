namespace BookStore.Core.Entities
{
    public class Book : EntityBase
    {        
        public string Title { get; set; }
        public int NumPages { get; set; }
        public Author Author { get; set; }
    }
}
