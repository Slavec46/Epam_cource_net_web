using DAL.Interfaces;
using BLL;
using BLL.Interfaces;
using Epam.Task_7.DAL.DataBase;


namespace Common
{
    public class DependencyResolver
    {
        public static IDao Dao { get; }

        public static IBll Bll { get; }

        public static IAuthenfication Authentication { get; }

        static DependencyResolver()
        { 
            Dao = new ObjectDao();
            Bll = new ObjectBll(Dao);

            Authentication = new Authentication(Bll.Users);
        }
    }
}
