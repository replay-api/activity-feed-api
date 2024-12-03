public class ActivityUseCase : IActivityUseCase
{
    private readonly IActivityRepository _repository;

    public ActivityUseCase(IActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Activity>> GetActivitiesAsync()
    {
        return await _repository.GetActivitiesAsync();
    }

    public async Task<Activity> AddActivityAsync(Activity activity)
    {
        return await _repository.AddActivityAsync(activity);
    }

    public async Task<List<Activity>> GetFriendsActivitiesAsync(int userId)
    {
        return await _repository.GetFriendsActivitiesAsync(userId);
    }

    public async Task<List<Activity>> GetCommunityDiscussionsAsync()
    {
        return await _repository.GetCommunityDiscussionsAsync();
    }
}
