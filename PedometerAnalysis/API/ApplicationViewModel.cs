using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PedometerAnalysis.API.Export;
using PedometerAnalysis.API.Extensions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
namespace PedometerAnalysis.API;
internal class ApplicationViewModel : INotifyPropertyChanged
{
    private UserInfo selectedUser;
    private LineSeries lineSeries;
    private ScatterSeries scatterSeries;
    private RelayCommand selectionChangedCommand;
    private RelayCommand openFileCommand;
    private RelayCommand exportCommand;
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

    public event PropertyChangedEventHandler PropertyChanged;
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
    public RelayCommand SelectionChangedCommand
    {
        get
        {
            return selectionChangedCommand ??= new RelayCommand(obj =>
                {
                    Chart.UpdateChart(MyModel, SelectedUser, lineSeries, scatterSeries);
                });
        }
    }
    public RelayCommand OpenFileCommand
    {
        get
        {
            return openFileCommand ??= new RelayCommand(obj =>
                {
                    var openFileDialog = new Microsoft.Win32.OpenFileDialog
                    {
                        InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                        Multiselect = true,
                        Filter = "JSON files (*.json)|*.json"
                    };
                    if (openFileDialog.ShowDialog() == true)
                    {
                        Users.Clear();
                        Users.AddRange(JSONParser.Parse(openFileDialog.FileNames));
                        FillGrid();
                        Chart.UpdateChart(MyModel, SelectedUser, lineSeries, scatterSeries);
                    }
                });
        }
    }
    public RelayCommand ExportCommand
    {
        get
        {
            return exportCommand ??= new RelayCommand(obj =>
                {
                    IExport exporter;
                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
                    };
                    if (obj is JSONExporter)  { exporter = obj as JSONExporter; saveFileDialog.Filter = "JSON files | *.json"; }
                    else if (obj is CSVExporter) { exporter = obj as CSVExporter; saveFileDialog.Filter = "CSV files | *.csv"; }
                    else if (obj is XMLExporter) { exporter = obj as XMLExporter; saveFileDialog.Filter = "XML files | *.xml"; }
                    else { return; }
                    ExportSevice sevice = new ExportSevice(exporter);
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        sevice.Export(saveFileDialog.FileName, Users);
                    }
                });
        }
    }
    public PlotModel MyModel { get; private set; }
    public ApplicationViewModel()
    {
        Users = new ObservableCollection<UserInfo>();
        this.MyModel = new PlotModel()
        {
            Title = "Steps Analysis"
        };
        MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Day", FontSize = 14 });
        MyModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Steps", FontSize = 14 });
        this.lineSeries = new LineSeries
        {
            Color = OxyColors.Red,
            StrokeThickness = 2,
            FontSize = 14
        };
        this.scatterSeries = new ScatterSeries
        {
            MarkerFill = OxyColors.Blue,
            MarkerSize = 5,
            MarkerType = MarkerType.Circle
        };
        MyModel.Series.Add(this.lineSeries);
        MyModel.Series.Add(this.scatterSeries);
    }
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}