namespace AuthDemo.Application.Abstractions.Application;

public interface IUserResolverService
{
    int GetUserId();
    string GetUserEmail();
    bool IsUserAuthenticated();
}
