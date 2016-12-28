using System;
using System.Linq;

using CookComputing.XmlRpc;

namespace WordPressSharp.Extensions
{
    static class ParsingExtensions
    {
        public static T ToObject<T>(this XmlRpcStruct source)
        where T : class, new()
        {
            try
            {
                T someObject = new T();
                Type someObjectType = someObject.GetType();

                foreach (var propertyInfo in someObjectType.GetProperties())
                {
                    var xmlRpcAtt = propertyInfo.CustomAttributes.SingleOrDefault(att => att.AttributeType == typeof(CookComputing.XmlRpc.XmlRpcMemberAttribute));
                    if (xmlRpcAtt == null || !xmlRpcAtt.ConstructorArguments.Any())
                    {
                        continue;
                    }

                    string xmlRpcAttName = xmlRpcAtt.ConstructorArguments[0].Value.ToString();
                    if (!source.ContainsKey(xmlRpcAttName))
                    {
                        continue;
                    }

                    var childStruct = source[xmlRpcAttName] as XmlRpcStruct;
                    if (childStruct != null)
                    {
                        var method = typeof(ParsingExtensions).GetMethod("ToObject");
                        var genericMethod = method.MakeGenericMethod(propertyInfo.PropertyType);
                        var convertedChild = genericMethod.Invoke(null, new object[] { childStruct });

                        propertyInfo.SetValue(someObject, convertedChild, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(someObject, source[xmlRpcAttName], null);
                    }
                }

                return someObject;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
