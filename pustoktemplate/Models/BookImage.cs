namespace pustoktemplate.Models
{
    public class BookImage
    {
        public int Id { get; set; } 
        public string ?Image { get; set; }
        public bool Ismain { get; set; }
        public int BookId { get; set; }
        public Book? books { get; set; }

    }
}
