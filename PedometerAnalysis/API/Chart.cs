using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedometerAnalysis.API;
internal static class Chart
{
    public static PlotModel GrapthMethod(PlotModel model, UserInfo selectedUser)
    {
        if (selectedUser == null)
            return null;
        if (model == null)
            return null;
        model.Series.Clear();
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

        for (int i = 0; i < selectedUser.Steps.Length; i++)
        {
            series1.Points.Add(new DataPoint(i + 1, selectedUser.Steps[i]));
        }
        var series2 = new LineSeries
        {
            Title = "Series2",
            Color = OxyColors.Blue,
            StrokeThickness = 3
        };

        //int Element = selectedUser.Steps.Min();
        //int Index = selectedUser.Steps.Where(c => c == Element).First();
        //series2.Points.Add(new DataPoint(Index, Element));

        //Element = selectedUser.Steps.Max();
        //Index = selectedUser.Steps.Where(c => c == Element).First();
        //series2.Points.Add(new DataPoint(Index, Element));

        temp.Series.Add(series1);
        //temp.Series.Add(series2);
        model.InvalidatePlot(true);
        return temp;
    }
}
