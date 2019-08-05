using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedTaskScheduler.GUI
{
    public class JsonHelper
    {
        public static string SerializeObject(object dataObj)
        {
            JsonSerializerSettings settings = JsonHelper.GetSettings(false);
            return JsonConvert.SerializeObject(dataObj, settings);
        }

        private static JsonSerializerSettings GetSettings(bool indented = false)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.Formatting = JsonHelper.GetFormatting(indented);
            //serializerSettings.Converters.Add((JsonConverter)new ColorConverter());
            return serializerSettings;
        }

        private static Formatting GetFormatting(bool indented = false)
        {
            return !indented ? Formatting.None : Formatting.Indented;
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
