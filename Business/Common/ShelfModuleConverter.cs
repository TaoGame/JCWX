using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model;

namespace WX.Common
{
    public class ShelfModuleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(ShelfModule));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            ShelfModuleFactory value = new ShelfModuleFactory();
            if (value == null)
                throw new JsonSerializationException("No object created.");

            serializer.Populate(reader, value);
            return value.BuildModule();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    }
}
