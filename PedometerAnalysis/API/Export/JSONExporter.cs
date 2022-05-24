using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PedometerAnalysis.API.Export;
internal class JSONExporter : IExport
{
    public void Export(string path, IEnumerable<UserInfo> infos)
    {
        throw new NotImplementedException();
    }
}
