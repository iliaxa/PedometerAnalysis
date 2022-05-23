using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PedometerAnalysis.API;
internal class ApplicationViewModel
{
    private UserInfo selectedUser;
    private RelayCommand selectionChangedCommand;
    public List<UserInfo> Users { get; set; }
    public UserInfo SelectedUser
    {
        get { return selectedUser; }
        set 
        {
            selectedUser = value;
            GrapthMethod();
        }
    }
    public ApplicationViewModel()
    {
        Users = JSONParser.Parse(new string[] {@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day1.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day3.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day4.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day5.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day6.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day7.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day8.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day9.json",
            @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day10.json" }).ToList();
        SelectedUser = Users.First();
        GrapthMethod();

        FillGrid();
    }

    public RelayCommand SelectionChangedCommand
    {
        get
        {
            return selectionChangedCommand ??= new RelayCommand(obj =>
                {
                    GrapthMethod();
                });
        }
    }

    private void FillGrid()
    {
        for (int i = 0; i < Users.Count; i++)
        {
            Users[i].Average = Math.Round(Users[i].Steps.Average());
            Users[i].Min = Users[i].Steps.Min();
            Users[i].Max = Users[i].Steps.Max();
        }
    }

    public PlotModel MyModel { get; set; }
    public void GrapthMethod()
    {
        if (selectedUser == null)
            return;
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
        temp.Series.Add(series2);

        this.MyModel = temp;
    }
}