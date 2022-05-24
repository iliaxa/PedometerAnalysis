using System.Collections.Generic;

namespace PedometerAnalysis.API.Export;
internal class ExportSevice
{
    private IExport _export;
    public ExportSevice(IExport export)
    {
        _export = export;
    }
    public void SetExport(IExport export)
    {
        this._export = export;
    }
    public void Export(string fileName, IEnumerable<UserInfo> content)
    {
        _export.Export(fileName, content);
    }
}
