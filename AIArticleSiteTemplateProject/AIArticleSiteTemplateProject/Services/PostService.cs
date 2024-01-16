using Microsoft.EntityFrameworkCore;
using AIArticleSiteTemplateProject.Data;
using AIArticleSiteTemplateProject.Objects;

namespace AIArticleSiteTemplateProject.Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetRecentPosts(int amountToReturn)
        {
            return await _context.Posts
                .Where(p => p.StatusId == 1)
                .OrderByDescending(p => p.PostSysDate)
                .Take(amountToReturn)
                .ToListAsync();
        }

        public async Task<Post> GetPostById(int id)
        {
            var post = await _context!.Posts
                .Where(p => p.PostId == id)
                .FirstOrDefaultAsync()!;
            return post!;
        }



        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId && c.ParentCommentId == null) // Only get top-level comments
                .Include(c => c.Replies) // Include replies
                .ToListAsync();
        }

        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task IncrementPageViews(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                post.PageViews++;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }


        public async Task IncrementTotalComments(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                post.TotalComments++;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DecrementTotalComments(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                post.TotalComments--;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetTrendingPosts(int amountToReturn, int daysToGoBack)
        {
            var dateLimit = DateTime.Now.AddDays(-daysToGoBack); // posts from the last 45 days

            return await _context.Posts
                .Where(p => p.PostSysDate >= dateLimit && p.StatusId == 1)
                .OrderByDescending(p => p.PageViews + (p.TotalComments * 2))
                .Take(amountToReturn)
                .ToListAsync();
        }

        public async Task<List<Post>> GetPostsByCategory(int categoryId)
        {
            return await _context.Posts
                                 .Where(p => p.CategoryId == categoryId && p.StatusId == 1)
                                 .ToListAsync();
        }

        public async Task<List<Post>> GetRecentPostsByCategory(int amountToReturn, int categoryId)
        {
            return await _context.Posts
                                 .Where(p => p.CategoryId == categoryId && p.StatusId == 1)
                                 .OrderByDescending(p => p.PostSysDate)
                                 .Take(amountToReturn)
                                 .ToListAsync();
        }

        public async Task<List<Post>> GetTrendingPostsByCategory(int amountToReturn, int daysToGoBack, int categoryId)
        {
            var dateLimit = DateTime.Now.AddDays(-daysToGoBack); // posts from the last 45 days

            return await _context.Posts
                                 .Where(p => p.CategoryId == categoryId && p.PostSysDate >= dateLimit && p.StatusId == 1)
                                 .OrderByDescending(p => p.PageViews + (p.TotalComments * 2))
                                 .Take(amountToReturn)
                                 .ToListAsync();
        }

        public IQueryable<Comment> GetCommentsByUserId(string userId)
        {
            return _context.Comments
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CommentSysDate);
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _context.Comments.Include(c => c.Replies).FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
            {
                throw new ArgumentException("Comment not found");
            }

            _context.Comments.RemoveRange(comment.Replies!);
            _context.Comments.Remove(comment);

            await DecrementTotalComments(comment.PostId);

            await _context.SaveChangesAsync();
        }


        }
    }
