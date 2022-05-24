using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
namespace PedometerAnalysis.API.Export;
internal class JSONExporter : IExport
{
    public async void Export(string path, IEnumerable<UserInfo> infos)
    {
        try
        {
            var json = JsonConvert.SerializeObject(infos, Formatting.Indented);
            await System.IO.File.WriteAllTextAsync(path, json);
            MessageBox.Show("Export successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }
}
