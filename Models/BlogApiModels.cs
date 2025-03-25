namespace blogapicontroller.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<Post> Posts { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Report> Reports { get; set; }
    public ICollection<ActivityLog> ActivityLogs { get; set; }
}

public class Post
{
    [Key]
    public int PostId { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Slug { get; set; }
    public string Status { get; set; } // published, draft, archived
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("AuthorId")]
    public User Author { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<PostTag> PostTags { get; set; }
    public ICollection<Like> Likes { get; set; }
    public ICollection<Report> Reports { get; set; }
}

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public int? UserId { get; set; }
    public int? ParentCommentId { get; set; }
    public string Content { get; set; }
    public string Status { get; set; } // approved, pending, spam
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("PostId")]
    public Post Post { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("ParentCommentId")]
    public Comment ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; }
    public ICollection<Like> Likes { get; set; }
}

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int? ParentCategoryId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("ParentCategoryId")]
    public Category ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; }
}

public class Tag
{
    [Key]
    public int TagId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public ICollection<PostTag> PostTags { get; set; }
}

public class PostTag
{
    public int PostTagId { get; set; }
    public int PostId { get; set; }
    public int TagId { get; set; }
    
    [ForeignKey("PostId")]
    public Post Post { get; set; }
    [ForeignKey("TagId")]
    public Tag Tag { get; set; }
}

public class Like
{
    [Key]
    public int LikeId { get; set; }
    public int UserId { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public string ReactionType { get; set; } // like, dislike
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("PostId")]
    public Post Post { get; set; }
    [ForeignKey("CommentId")]
    public Comment Comment { get; set; }
}

public class Report
{
    [Key]
    public int ReportId { get; set; }
    public int ReportedBy { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; } // pending, reviewed, resolved
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("ReportedBy")]
    public User Reporter { get; set; }
    [ForeignKey("PostId")]
    public Post Post { get; set; }
    [ForeignKey("CommentId")]
    public Comment Comment { get; set; }
}

public class ActivityLog
{
    [Key]
    public int LogId { get; set; }
    public int UserId { get; set; }
    public string ActionType { get; set; } // created_post, deleted_comment, etc.
    public int? TargetId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    [ForeignKey("UserId")]
    public User User { get; set; }
}
