using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

using Common;
using Common.Entities;
using BLL.Interfaces;
using BLL;

namespace Epam.Task_7.PL.Web.Hendlers
{
    public class UserHandler : IHttpHandler
    {
        private static IBll _bll = DependencyResolver.Bll;

        private static IEnumerator<User> _enumerable;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["updateUser"] != null)
            {
                UpdateUser(context);
            }
            else if (context.Request["DeleteUser"] != null)
            {
                DeleteUser(context);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        private void UpdateUser(HttpContext context)
        {
            string jsonStr;

            context.Response.ContentType = "application/json";

            if (_enumerable == null)
            {
                _enumerable = _bll.Users.GetAllUsers().GetEnumerator();
            }

            if (_enumerable.MoveNext())
            {
                var objUser = new BonusedUser(
                    _enumerable.Current.Id,
                    _enumerable.Current.Name,
                    _enumerable.Current.DateOfBirth,
                    _enumerable.Current.Login,
                    _enumerable.Current.Password,
                    _enumerable.Current.Role
                    );

                foreach (var item in _enumerable.Current.BonusList)
                {
                    objUser.BonusList.Add(_bll.Awards.GetBonus(item));
                }

                jsonStr = JsonConvert.SerializeObject(objUser);

                context.Response.Write(jsonStr);
            }
            else
            {
                context.Response.Write(null);

                _enumerable = null;
            }
        }
        private void DeleteUser(HttpContext context)
        {
            _bll.Users.DeleteUser(Guid.Parse(context.Request["DeleteUser"]), _bll);
        }
    }
}