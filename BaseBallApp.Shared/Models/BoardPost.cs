namespace BaseBallApp.Shared.Models;

public class BoardPost
{
    public int Id { get; set; }
    public bool IsNotice { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int ViewCount { get; set; }
    public DateTime CreatedAt { get; set; }
}
