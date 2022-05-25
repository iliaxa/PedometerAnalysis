using Newtonsoft.Json;
using PedometerAnalysis.API.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

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
    public static ObservableCollection<UserInfo> Parse(string[] files)
    {
        var resultCollection = new ObservableCollection<UserInfo>();
        try
        {
            List<RootObject>? parsedFiles = new List<RootObject>();
            for (int i = 0; i < files.Length; i++)
            {
                using (StreamReader r = new StreamReader(files[i]))
                {
                    string json = r.ReadToEnd();
                    var rootObjects = JsonConvert.DeserializeObject<IEnumerable<RootObject>>(json);
                    if (rootObjects == null || rootObjects.All(c=>c.Steps == 0))
                    {
                        throw new System.Exception("Error parsing file: " + files[i]);
                    }
                    parsedFiles.AddRange(rootObjects);
                }
            }
            resultCollection = parsedFiles.GroupBy(x => x.User)
                .Select(c => new UserInfo
                {
                    User = c.Key,
                    Rank = c.First().Rank,
                    Status = c.First().Status,
                    Steps = c.Select(z => z.Steps).ToArray()
                }).ToObservableCollection();
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        return resultCollection;
    }

}
