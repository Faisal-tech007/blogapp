namespace api.Dto
{
    public class BlogPostForCreation
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
    }
}