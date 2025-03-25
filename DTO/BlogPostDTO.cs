namespace blogapicontroller.DTO;

public class UserDTO
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PostDTO
{
    public int PostId { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Slug { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CommentDTO
{
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public int? UserId { get; set; }
    public int? ParentCommentId { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CategoryDTO
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int? ParentCategoryId { get; set; }
}

public class TagDTO
{
    public int TagId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}

public class PostTagDTO
{
    public int PostTagId { get; set; }
    public int PostId { get; set; }
    public int TagId { get; set; }
}

public class LikeDTO
{
    public int LikeId { get; set; }
    public int UserId { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public string ReactionType { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ReportDTO
{
    public int ReportId { get; set; }
    public int ReportedBy { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ActivityLogDTO
{
    public int LogId { get; set; }
    public int UserId { get; set; }
    public string ActionType { get; set; }
    public int? TargetId { get; set; }
    public DateTime Timestamp { get; set; }
}
