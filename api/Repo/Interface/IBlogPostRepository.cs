namespace api.Repo.Interface
{
    public interface IBlogPostRepository
    {
         void add<T>(T entity) where T  : class;
         void Delete<T>(T entity) where T  : class;
         Task<bool> SaveAll();

         Task<Blogost> AddBlogPost(BlogostPostForCreation field);

         Task<IEnumerable<Blogost>> GetBlogPost();

         Task<IEnumerable<object>> GetBlogPostWithId(Int Id);

         Task<IEnumerable<object>> GetBlogPostWithTitle(string title);

         Task<Blogpost> UpdateBlogPost(BlogostForUpdate Model);

         Task<bool> DeletePost(int id);

    }
}