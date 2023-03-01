using api.Repo.Interface;
namespace api.Repo
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DataContext context;
        public BlogPostRepository (DataContext context)
        {
            this.context = context;
        }
        public void add<T>(T entity) where T : class
        {
            context.Add(entity);
        }
        public async Task<Blogost> AddBlogPost(BlogostPostForCreation field)
        {
            var data = new Blogost

            {
                AuthorId = field.AuthorId,
                Title = field.Title,
                Body = field.Body
            };

            await context.Blogosts.AddAsync(data);
            await SaveAll();
            return data;
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<bool> DeletePost(int id)
        {
            var dataFromRepo = await context.Blogosts.FirstOrDefaultAsync(a=> a.Id == id);
            if(dataFromRepo != null)
            {
                context.Blogosts.Remove(dataFromRepo);
                await SaveAll();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<BlogPost>> GetBlogPosts()
    {
      var dataFromRepo = await context.BlogPosts.ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetBlogPostWithId(int Id)
    {
      var dataFromRepo = await context.BlogPosts.Where(x=> x.Id == Id).ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetBlogPostWithTitle(string title)
    {
      var  dataFromRepo = await context.BlogPosts.Where(x=> x.Title == title).ToListAsync();
      return dataFromRepo;
    }

    public async Task<bool> SaveAll()
    {
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<Blogost> UpdateBlogPost(BlogostForUpdate model){
        var data = await context.Blogosts.FirstOrDefaultAsync(i => i.Id == model.Id);
        if(data == null)
        {
            return null;
        };

        data.Title = model.Title;
        data.Body = model.Body;
        data.TimeStamp = model.TimeStamp;
        await SaveAll();

        return data;
    }
  }
}