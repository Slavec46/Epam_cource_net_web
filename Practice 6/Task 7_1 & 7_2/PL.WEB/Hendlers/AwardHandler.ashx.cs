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
    public class AwardHandler : IHttpHandler
    {
        private static IBll _bll = DependencyResolver.Bll;

        private static IEnumerator<Bonus> _enumerable;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["updateBonus"] != null)
            {
                UpdateBonus(context);
            }
            else if (context.Request["deleteBonus"] != null)
            {
                DeleteBonus(context);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        private void UpdateBonus(HttpContext context)
        {
            string jsonStr;

            context.Response.ContentType = "application/json";

            if (_enumerable == null)
            {
                _enumerable = _bll.Bonus.GetAllBonuses().GetEnumerator();
            }

            if (_enumerable.MoveNext())
            {
                var objAward = new CustomBonus(
                    _enumerable.Current.Id,
                    _enumerable.Current.Title
                    );

                foreach (var item in _enumerable.Current.OwnerList)
                {
                    objAward.OwnerList.Add(_bll.Users.GetUser(item));
                }

                jsonStr = JsonConvert.SerializeObject(objAward);

                context.Response.Write(jsonStr);
            }
            else
            {
                context.Response.Write(null);

                _enumerable = null;
            }
        }
        private void RemoveAward(HttpContext context)
        {
            _bll.Bonus.DeleteBonus(Guid.Parse(context.Request["DeleteBonus"]), _bll);
        }
    }
}