using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusinessLogicLayer.Tests
{
    public class JsonSerializedComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T first, T second)
        {
            var serializeFirstObject = JsonConvert.SerializeObject(first);
            var serializeSecondObject = JsonConvert.SerializeObject(second);

            return serializeSecondObject == serializeFirstObject;
        }

        public int GetHashCode(T obj)
        {
            return JsonConvert.SerializeObject(obj).GetHashCode();
        }
    }
}