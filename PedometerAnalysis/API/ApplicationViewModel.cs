using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PedometerAnalysis.API.Extensions;
namespace PedometerAnalysis.API;
internal class ApplicationViewModel : INotifyPropertyChanged
{
    private UserInfo selectedUser;
    private LineSeries series;
    private RelayCommand selectionChangedCommand;
    private RelayCommand openFileCommand;


    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    public ObservableCollection<UserInfo> Users { get; set; }
    public UserInfo SelectedUser
    {
        get { return selectedUser; }
        set 
        {
            selectedUser = value;
            OnPropertyChanged("SelectedUser");
        }
    }
    public ApplicationViewModel()
    {
        //Users = JSONParser.Parse(new string[] {@"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day1.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day3.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day4.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day5.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day6.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day7.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day8.json",
        //    @"D:\Projects\Pedometer\PedometerAnalysis\PedometerAnalysis\Data\day9.json"
        //});
        Users = new ObservableCollection<UserInfo>();
        this.MyModel = new PlotModel()
        {
            Title = "Pedometer",
            Subtitle = "using OxyPlot"
        };
        this.series = new LineSeries
        {
            Title = "Series1",
            Color = OxyColors.Red,
            StrokeThickness = 2
        };
        MyModel.Series.Add(this.series);
    }

    public RelayCommand SelectionChangedCommand
    {
        get
        {
            return selectionChangedCommand ??= new RelayCommand(obj =>
                {
                    UpdateChart();
                });
        }
    }
    public RelayCommand OpenFileCommand
    {
        get
        {
            return openFileCommand ??= new RelayCommand(obj =>
                {
                    var openFileDialog = new Microsoft.Win32.OpenFileDialog { 
                        Multiselect = true,
                        Filter = "JSON files (*.json)|*.json"
                    };
                    if (openFileDialog.ShowDialog() == true)
                    {
                        Users.Clear();
                        Users.AddRange(JSONParser.Parse(openFileDialog.FileNames));
                        SelectedUser = Users.First();
                        FillGrid();
                        UpdateChart();
                    }
                });
        }
    }
    private void FillGrid()
    {
        if (Users == null)
        {
            return;
        }
        for (int i = 0; i < Users.Count; i++)
        {
            Users[i].Average = Math.Round(Users[i].Steps.Average());
            Users[i].Min = Users[i].Steps.Min();
            Users[i].Max = Users[i].Steps.Max();
        }
    }

    public PlotModel MyModel { get; private set; }

    public void UpdateChart()
    {
        if (selectedUser == null)
            return;
        if (MyModel == null)
            return;

        series.Points.Clear();
        for (int i = 0; i < selectedUser.Steps.Length; i++)
        {
            series.Points.Add(new DataPoint(i + 1, selectedUser.Steps[i]));
        }
        MyModel.InvalidatePlot(true);
        
        //var series2 = new LineSeries
        //{
        //    Title = "Series2",
        //    Color = OxyColors.Blue,
        //    StrokeThickness = 3
        //};
        
        //int Element = selectedUser.Steps.Min();
        //int Index = selectedUser.Steps.Where(c => c == Element).First();
        //series2.Points.Add(new DataPoint(Index, Element));

        //Element = selectedUser.Steps.Max();
        //Index = selectedUser.Steps.Where(c => c == Element).First();
        //series2.Points.Add(new DataPoint(Index, Element));

        //temp.Series.Add(series1);
        ////temp.Series.Add(series2);
        //model.InvalidatePlot(true);
        //return temp;
    }

}