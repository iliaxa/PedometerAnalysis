using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PedometerAnalysis.API;
internal class UserInfo
{
    public int Rank { get; set; }
    public string User { get; set; }
    public string Status { get; set; }
    public int[] Steps { get; set; }
    public double Average { get; set; }
    public int Max { get; set; }
    public int Min { get; set; }
}
