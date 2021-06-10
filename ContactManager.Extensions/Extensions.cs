using System;
using System.Linq;
using System.Reflection;

namespace ContactManager.Extensions
{
    public static class Extensions
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Mapped<T>(this object query)
        {
            if (query != null)
            {
                Type TargetType = typeof(T);
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Mapped<T>(this object query, object obj)
        {
            if (query != null)
            {
                Type TargetType = obj.GetType();
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }

        /// <summary>
        /// this is extension for mapped extend IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Mapped<T>(this IQueryable<T> query)
        {
            if (query != null)
            {
                Type TargetType = query.GetType();
                Type SoruceType = query.GetType();
                T soruces = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = TargetType.GetProperties();
                foreach (var item in SoruceType.GetProperties())
                {
                    var target = TargetType.GetProperties()
                           .FirstOrDefault(x => x.Name.ToUpper() == item.Name.ToUpper());
                    if (target != null)
                    {
                        object data = item.GetValue(query);
                        target.SetValue(soruces, data);
                    }
                }
                return soruces;
            }
            return default(T);
        }
    }
}