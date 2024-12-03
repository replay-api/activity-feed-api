public class Activity
{
    public int Id { get; set; }
    public required string Type { get; set; } // e.g., "achievement", "replay_analysis", "community_discussion"
    public required string Content { get; set; }
    public DateTime Timestamp { get; set; }

    // Foreign Key
    public int UserId { get; set; }
    public required User User { get; set; }
}
