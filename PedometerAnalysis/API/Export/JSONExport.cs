using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PedometerAnalysis.API.Export;
internal class JSONExport : IExport
{
    public void Export(List<UserInfo> infos)
    {
        //OpenFileDialog
        JsonConvert.SerializeObject(infos);
    }
}
