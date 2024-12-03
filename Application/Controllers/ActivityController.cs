using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityUseCase _activityUseCase;

    public ActivityController(IActivityUseCase activityUseCase)
    {
        _activityUseCase = activityUseCase;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetActivities()
    {
        var activities = await _activityUseCase.GetActivitiesAsync();
        return Ok(activities);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddActivity(Activity newActivity)
    {
        var activity = await _activityUseCase.AddActivityAsync(newActivity);
        return CreatedAtAction(nameof(GetActivities), new { id = activity.Id }, activity);
    }

    [HttpGet("users/{userId}/friends-activities")]
    [Authorize]
    public async Task<IActionResult> GetFriendsActivities(int userId)
    {
        var activities = await _activityUseCase.GetFriendsActivitiesAsync(userId);
        if (activities == null)
        {
            return NotFound();
        }
        return Ok(activities);
    }

    [HttpGet("community-discussions")]
    [Authorize]
    public async Task<IActionResult> GetCommunityDiscussions()
    {
        var discussions = await _activityUseCase.GetCommunityDiscussionsAsync();
        return Ok(discussions);
    }
}

