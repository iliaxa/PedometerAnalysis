using System.Collections.Generic;

namespace PedometerAnalysis.API.Export;
internal interface IExport
{
    void Export(string path, IEnumerable<UserInfo> infos);
}
