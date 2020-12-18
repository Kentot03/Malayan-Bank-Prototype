using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ReadJson
    {
        public static bool IsNetCore(string path)
        {
            return File.Exists(path);
        }


        public static JsonFile ParseJson(string path)
        {
            var jsonText = File.ReadAllText(path);
            var results = JsonConvert.DeserializeObject<JsonFile>(jsonText);

            return results;

        }
    }

    public class JsonFile
    {
        public AppSettings appSettings { get; set; }
    }

    public class AppSettings
    {
        public string MongoConnectionString { get; set; }
        public string MongoDatabaseName { get; set; }
    }
}
