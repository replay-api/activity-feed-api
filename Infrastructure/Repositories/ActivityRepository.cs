using Microsoft.EntityFrameworkCore;

public class ActivityRepository : IActivityRepository
{
    private readonly ActivityDbContext _context;

    public ActivityRepository(ActivityDbContext context)
    {
        _context = context;
    }

    public async Task<List<Activity>> GetActivitiesAsync()
    {
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activity> AddActivityAsync(Activity activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
        return activity;
    }

    public async Task<List<Activity>> GetFriendsActivitiesAsync(int userId)
    {
        var user = await _context.Users
            .Include(u => u.Friendships)
            .ThenInclude(f => f.Friend)
            .Include(u => u.Activities)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return user?.Friendships.SelectMany(f => f.Friend.Activities).ToList();
    }

    public async Task<List<Activity>> GetCommunityDiscussionsAsync()
    {
        return await _context.Activities.Where(a => a.Type == "community_discussion").ToListAsync();
    }
}

