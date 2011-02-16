using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MoneyPacificService.General
{
    public static class General
    {
        public static string[] GetRoles(object obj, string methodName)
        {
            Type type = obj.GetType();
            return GetRoles(type, methodName);
        }

        public static string[] GetRoles(Type type, string methodName)
        {
            string[] result = null;

            MethodInfo method = type.GetMethod(methodName);
            Authorize[] arrAttr = (Authorize[])method.GetCustomAttributes(typeof(Authorize), true);
            if (arrAttr.Count() == 0)
            {
                return null;
            }
            result = arrAttr[0].GetArrayRoles();

            return result;
        }
    }
}