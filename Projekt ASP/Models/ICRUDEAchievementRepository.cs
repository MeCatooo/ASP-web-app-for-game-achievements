using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt_ASP.Models
{
    public interface ICRUDEAchievementRepository
    {
        Achievement Add(Achievement achievement);
        void Delete(int id);
        Achievement Update(Achievement achievement);
        Achievement FindAchievementById(int id);
        IList<Achievement> FindAll();
        IList<Achievement> FindPage(int page, int size);
        void AddPostToAchievement(int PostId, int AchievementId);
        Post Add(Post post);
        List<Post> FindPosts(int id);
        Post Update(Post Post);
        void DeletePost(int id);
        Post FindPostById(int id);
        void AddCommentToPost(int CommentId, int PostId);
        Comment Add(Comment comment);
        IList<Comment> FindComments(int id);
        Comment Update(Comment comment);
        void DeleteComment(int id);

    }
    //public class EFCRUDECommentRepository : ICRUDCommentRepository
    //{
    //    private ApplicationDbContext _context;

    //    public EFCRUDECommentRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public Comment Add(Comment comment)
    //    {
    //        EntityEntry<Comment> entityEntry = _context.Comments.Add(comment);
    //        _context.SaveChanges();
    //        return entityEntry.Entity;
    //    }
    //    public Comment Update(Comment comment)
    //    {
    //        EntityEntry<Comment> entity = _context.Comments.Update(comment);
    //        _context.SaveChanges();
    //        return entity.Entity;
    //    }

    //    public IList<Comment> FindComments(int id)
    //    {
    //        IEnumerable<Comment> commentsQuery = from Comment in _context.Comments where Comment.Post.Id == id select Comment;
    //        return commentsQuery.ToList();
    //    }
    //    public void Delete(int id)
    //    {
    //        _context.Comments.Remove(_context.Comments.Find(id));
    //        _context.SaveChanges();
    //    }
    //}
    //public class EFCRUDEPostRepository : ICRUDPostRepository
    //{
    //    private ApplicationDbContext _context;
    //    public EFCRUDEPostRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public Post Add(Post post)
    //    {
    //        EntityEntry<Post> entityEntry = _context.Posts.Add(post);
    //        _context.SaveChanges();
    //        return entityEntry.Entity;
    //    }

    //    public List<Post> FindPosts(int id)
    //    {
    //        IEnumerable<Post> postsQuery = from Post in _context.Posts where Post.Achievement.Id == id select Post;
    //        return postsQuery.ToList();
    //    }

    //    public Post Update(Post Post)
    //    {
    //        EntityEntry<Post> entity = _context.Posts.Update(Post);
    //        _context.SaveChanges();
    //        return entity.Entity;
    //    }
    //    public void Delete(int id)
    //    {
    //        _context.Posts.Remove(_context.Posts.Find(id));
    //        _context.SaveChanges();
    //    }

    //    public Post FindById(int id)
    //    {
    //        return _context.Posts.Find(id);
    //    }
    //    public void AddCommentToPost(int CommentId, int PostId)
    //    {
    //        var post = _context.Posts.Find(PostId);
    //        var comment = _context.Comments.Find(CommentId);
    //        post.Comments.Add(comment);
    //        Update(post);
    //    }
    //}

}
