using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedometerAnalysis.API.Export;
internal interface IExport
{
    void Export(List<UserInfo> infos);
}
