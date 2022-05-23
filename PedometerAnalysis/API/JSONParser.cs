using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
namespace PedometerAnalysis.API;
internal class JSONParser
{
    public static IEnumerable<UserInfo> Parse(string file)
    {
        
        using (StreamReader r = new StreamReader(file))
        {
            string json = r.ReadToEnd();
            IEnumerable<UserInfo>? userInfos = JsonConvert.DeserializeObject<IEnumerable<UserInfo>>(json);
            return userInfos;
        }
    }

}
