namespace BLL.Interfaces
{
    public interface IAuthenfication
    {
        bool CheckAuthentication(string login, string password);

        bool IsLogin(string login);
    }
}
