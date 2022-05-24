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
    public static void UpdateChart(PlotModel model, UserInfo selectedUser, LineSeries lineSeries, ScatterSeries scatterSeries)
    {
        if (selectedUser == null)
            return;
        if (model == null)
            return;
        lineSeries.Points.Clear();
        scatterSeries.Points.Clear();
        for (int i = 0; i < selectedUser.Steps.Length; i++)
        {
            lineSeries.Points.Add(new DataPoint(i + 1, selectedUser.Steps[i]));

            if (selectedUser.Steps[i] == selectedUser.Min ||
                selectedUser.Steps[i] == selectedUser.Max)
            {
                scatterSeries.Points.Add(new ScatterPoint(i + 1, selectedUser.Steps[i]));
            }
        }
        model.InvalidatePlot(true);
    }
}
