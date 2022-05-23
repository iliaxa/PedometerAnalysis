using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace PedometerAnalysis.API;
internal class JSONParser
{
    private class RootObject
    {
        public int Rank { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }
    }
    public static IEnumerable<UserInfo> Parse(string[] files)
    {
        List<RootObject>? parsedFiles = new List<RootObject>();
        for (int i = 0; i < files.Length; i++)
        {
            using (StreamReader r = new StreamReader(files[i]))
            {
                string json = r.ReadToEnd();
                var rootObjects = JsonConvert.DeserializeObject<List<RootObject>>(json);
                if (rootObjects == null)
                {
                    throw new System.Exception($"Could not parse {files[i]} file into JSON");
                }
                parsedFiles.AddRange(rootObjects);
            }
        }
        var s = parsedFiles.GroupBy(x => x.User)
            .Select(c => new UserInfo
                {
                    User = c.Key,
                    Rank = c.First().Rank,
                    Status = c.First().Status,
                    Steps = c.Select(z => z.Steps).ToArray()
                });
        return s;
    }

}
