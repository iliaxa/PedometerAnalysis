using OxyPlot;
using OxyPlot.Series;
using System.Collections.Generic;
using System.Linq;
namespace PedometerAnalysis.API;
internal class ApplicationViewModel
{
    private UserInfo selectedUser;

    public List<UserInfo> Users { get; set; }
    public UserInfo SelectedUser
    {
        get { return selectedUser; }
        set { selectedUser = value; }
    }
    public ApplicationViewModel()
    {
        Users = JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day1.json").ToList();
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day3.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day4.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day5.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day6.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day7.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day8.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day9.json"));
        Users.AddRange(JSONParser.Parse(@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day10.json"));

        GrapthMethod();
    }
    public PlotModel MyModel { get; private set; }
    public void GrapthMethod()
    {
        var temp = new PlotModel
        {
            Title = "Pedometer",
            Subtitle = "using OxyPlot"
        };
        var series1 = new LineSeries
        {
            Title = "Series1",
            Color = OxyColors.Red,
            StrokeThickness = 2
        };
        var s = Users.GroupBy(x => x.User)
            .Select(c => new 
            {
                User = c.Key,
                Count = c.Count(),
                Steps = c.Select(z => z.Steps) 
            }).ToList();
        for (int i = 0; i < s[0].Steps.Count(); i++)
        {
            var list = s[0].Steps.ToList();
            series1.Points.Add(new DataPoint(i + 1, list[i]));
        }
        temp.Series.Add(series1);
        this.MyModel = temp;
    }
}