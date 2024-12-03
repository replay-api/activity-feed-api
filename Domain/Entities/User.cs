public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public required ICollection<Activity> Activities { get; set; }
    public required ICollection<Friendship> Friendships { get; set; }
}
