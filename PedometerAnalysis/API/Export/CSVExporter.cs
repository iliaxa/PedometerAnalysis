using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace PedometerAnalysis.API.Export;
internal class CSVExporter : IExport
{
    public async void Export(string path, IEnumerable<UserInfo> infos)
    {
        try
        {
            await File.WriteAllTextAsync(
           path,
           string.Join(Environment.NewLine, infos.Select(info => $"{info.User},{info.Rank},{info.Status},{info.Average},{info.Min},{info.Max}")),
           Encoding.UTF8);
            MessageBox.Show("Export successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
