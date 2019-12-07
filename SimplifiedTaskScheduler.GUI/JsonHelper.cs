using Newtonsoft.Json;
using System;

namespace SimplifiedTaskScheduler.GUI
{
    public static class JsonHelper
    {
        private static JsonSerializerSettings GetSettings(bool indented = false)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = JsonHelper.GetFormatting(indented)
            };
            return serializerSettings;
        }

        private static Formatting GetFormatting(bool indented = false)
        {
            return !indented ? Formatting.None : Formatting.Indented;
        }

        public static string SerializeObject(object dataObj)
        {
            JsonSerializerSettings settings = JsonHelper.GetSettings(false);
            return JsonConvert.SerializeObject(dataObj, settings);
        }

        public static string SerializeObject(object dataObj, bool indented)
        {
            JsonSerializerSettings settings = JsonHelper.GetSettings(indented);
            return JsonConvert.SerializeObject(dataObj, settings);
        }

        public static T DeserializeObject<T>(string jsonData)
        {
            JsonSerializerSettings settings = JsonHelper.GetSettings(false);
            return JsonConvert.DeserializeObject<T>(jsonData, settings);
        }

        public static T DeserializeObject<T>(string jsonData, bool indented)
        {
            JsonSerializerSettings settings = JsonHelper.GetSettings(indented);
            return JsonConvert.DeserializeObject<T>(jsonData, settings);
        }

        public static object DeserializeObject(string jsonData, Type type)
        {
            JsonSerializerSettings settings = JsonHelper.GetSettings(false);
            return JsonConvert.DeserializeObject(jsonData, type, settings);
        }
    }
}
