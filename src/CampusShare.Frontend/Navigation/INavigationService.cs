namespace CampusShare.Frontend.Navigation;

public interface INavigationService
{
    Task AllerVers(string route);

    Task Revenir();
}
