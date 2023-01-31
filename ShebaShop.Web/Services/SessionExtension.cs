using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using ShebaShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ShebaShop.Web.Services
{
    public static class SessionExtension
    {
        //public static string CurrentUserName { get; set; }
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);            

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static BasketViewModel GetBASKET(this ISession session)
        {
            string key = "BASKET";
            var value = session.GetString("BASKET");

            return GetObjectFromJson<BasketViewModel>(session, key);
        }

        public static void UpdateBasket(this ISession session,BasketViewModel basketVM)
        {
            string key = "BASKET";

            session.SetString(key, JsonConvert.SerializeObject(basketVM));
        }
        public static void EmptyCart(this ISession session)
        {
            string key = "BASKET";
            session.SetString(key, JsonConvert.SerializeObject(default(BasketViewModel)));
        }
    }
}
