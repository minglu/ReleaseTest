using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseTest
{
    internal class AccountConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Account) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var builder = serializer.Deserialize<Account.Builder>(reader);
            return new Account(builder);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
#pragma warning disable RECS0083
            throw new NotImplementedException();
#pragma warning restore RECS0083
        }

        public override bool CanRead { get { return true; } }

        public override bool CanWrite { get { return false; } }
    }
}

