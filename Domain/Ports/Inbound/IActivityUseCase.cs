public interface IActivityUseCase
{
    Task<List<Activity>> GetActivitiesAsync();
    Task<Activity> AddActivityAsync(Activity activity);
    Task<List<Activity>> GetFriendsActivitiesAsync(int userId);
    Task<List<Activity>> GetCommunityDiscussionsAsync();
}
