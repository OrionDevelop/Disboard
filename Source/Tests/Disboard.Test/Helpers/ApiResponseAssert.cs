using System;
using System.Collections.Generic;
using System.Linq;

using Disboard.Models;

using Xunit;

namespace Disboard.Test.Helpers
{
    public static class ApiResponseAssert
    {
        public static void CheckRecursively(this ApiResponse obj, params string[] ignores)
        {
            foreach (var property in obj.GetType().GetProperties().Where(w => w.GetValue(obj) != null))
            {
                // normal type
                if (property.PropertyType.IsSubclassOf(typeof(ApiResponse)))
                    (property.GetValue(obj) as ApiResponse)?.CheckRecursively();

                // IEnumerable
                if (property.PropertyType.IsGenericType && property.PropertyType.GenericTypeArguments.Any(w => w.IsSubclassOf(typeof(ApiResponse))))
                    if (property.PropertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(IEnumerable<>)))
                    {
                        var items = property.GetValue(obj) as IEnumerable<ApiResponse> ?? throw new InvalidOperationException();
                        foreach (var item in items)
                            item.CheckRecursively();
                    }
            }

            if (ignores == null)
            {
                obj.Extends.IsNull();
            }
            else
            {
                ignores.ToList().ForEach(w => obj.Extends?.Remove(w));
                obj.Extends?.Count.Is(0); // equals to null
            }
        }
    }
}