namespace BLL.Interfaces
{
    public interface IAuthentification
    {
        bool CheckAuthentification(string login, string password);

        bool IsLogin(string login);
    }
}
