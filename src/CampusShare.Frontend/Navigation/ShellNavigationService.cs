namespace CampusShare.Frontend.Navigation;

public sealed class ShellNavigationService : INavigationService
{
    public Task AllerVers(string route)
    {
        return Shell.Current.GoToAsync(route);
    }

    public Task Revenir()
    {
        return Shell.Current.GoToAsync("..");
    }
}
