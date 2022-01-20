using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_ASP.Models
{
    public class MemoryAchievementRepository : ICRUDAchievementRepository
    {
        private int AchivementIndex = 0;
        private int PostIndex = 0;
        private int CommentIndex = 0;
        private Dictionary<int, Achievement> achievements = new Dictionary<int, Achievement>();
        private Dictionary<int, Post> posts = new Dictionary<int, Post>();
        private Dictionary<int, Comment> comments = new Dictionary<int, Comment>();
        public MemoryAchievementRepository()
        {
            var achievement = new Achievement() { Game = "Skyrim", Name = "Tutorial" };
            this.Add(achievement);
            var post = new Post()
            {
                Title = "First time to the game",
                Text = "It's very hard",
                PostTime = DateTime.Now,
                AchievementId = achievement.Id
            };
            this.Add(post);
            this.AddPostToAchievement(post.Id, achievement.Id);
            var comment = new Comment() { Text = "Lower difficulty level", PostTime = DateTime.Now, PostId = post.Id };
            this.Add(comment);
            this.AddCommentToPost(comment.Id, post.Id);
        }
        public Achievement Add(Achievement achievement)
        {
            ++AchivementIndex;
            achievement.Id = AchivementIndex;
            achievements.Add(achievement.Id, achievement);
            return achievement;
        }

        public Post Add(Post post)
        {
            ++PostIndex;
            post.Id = PostIndex;
            posts.Add(post.Id, post);
            return post;
        }

        public Comment Add(Comment comment)
        {
            ++CommentIndex;
            comment.Id = CommentIndex;
            comments.Add(comment.Id, comment);
            return comment;
        }

        public void AddCommentToPost(int CommentId, int PostId)
        {
            posts.TryGetValue(PostId, out var post);
            comments.TryGetValue(CommentId, out var comment);
            post.Comments.Add(comment);
        }

        public void AddPostToAchievement(int PostId, int AchievementId)
        {
            posts.TryGetValue(PostId, out var post);
            achievements.TryGetValue(AchievementId, out var achievement);
            achievement.Posts.Add(post);
        }

        public void DeleteAchievement(int id)
        {
            achievements.Remove(id);
        }

        public void DeleteComment(int id)
        {
            comments.Remove(id);
        }

        public void DeletePost(int id)
        {
            posts.Remove(id);
        }

        public Achievement FindAchievementById(int id)
        {
            achievements.TryGetValue(id, out var achievement);
            return achievement;
        }

        public List<Achievement> FindAll()
        {
            return achievements.Values.ToList();
        }

        public List<Comment> FindComments(int id)
        {
            List<Comment> Comments = comments.Values.ToList();
            IEnumerable<Comment> CommentQuery = from Comment in Comments where Comment.PostId == id select Comment ;
            return CommentQuery.ToList();
        }

        public List<Achievement> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Post FindPostById(int id)
        {
            posts.TryGetValue(id, out var post);
            return post;
        }

        public List<Post> FindPosts(int id)
        {
            List<Post> Posts = posts.Values.ToList();
            IEnumerable<Post> postsQuery = from Post in Posts where Post.AchievementId == id select Post;
            return postsQuery.ToList();
        }

        public Achievement Update(Achievement achievement)
        {
            achievements[achievement.Id] = achievement;
            return achievement;
        }

        public Post Update(Post Post)
        {
            posts[Post.Id] = Post;
            return Post;
        }

        public Comment FindCommnetById(int id)
        {
            comments.TryGetValue(id, out var comment);
            return comment;
        }
    }
}
