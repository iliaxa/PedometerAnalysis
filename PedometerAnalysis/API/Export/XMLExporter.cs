using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
namespace PedometerAnalysis.API.Export;
internal class XMLExporter : IExport
{
    public void Export(string path, IEnumerable<UserInfo> infos)
    {
        try
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Users",
                    from info in infos
                    select
                        new XElement("UserInfo",
                        new XElement("User", info.User),
                        new XElement("Rank", info.Rank),
                        new XElement("Status", info.Status),
                        new XElement("Average", info.Average),
                        new XElement("Min", info.Min),
                        new XElement("Max", info.Max)
                    )));
            doc.Save(path);
            MessageBox.Show("Export successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
