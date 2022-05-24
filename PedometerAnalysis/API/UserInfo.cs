using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PedometerAnalysis.API;
internal class UserInfo : INotifyPropertyChanged
{
    private int rank;
    private int[] steps;
    private string user;
    private string status;
    private double average;
    private int min;
    private int max;
    
    public int Rank { 
        get { return rank; }
        set
        {
            rank = value;
            OnPropertyChanged();
        }
            
    }
    public string User
    {
        get { return user; }
        set
        {
            user = value;
            OnPropertyChanged();
        }
    }
    public string Status
    {
        get { return status; }
        set
        {
            status = value;
            OnPropertyChanged();
        }
    }
    public int[] Steps
    {
        get { return steps; }
        set
        {
            steps = value;
            OnPropertyChanged();
        }
    }
    public double Average
    {
        get { return average; }
        set
        {
            average = value;
            OnPropertyChanged();
        }
    }
    public int Max
    {
        get { return max; }
        set
        {
            max = value;
            OnPropertyChanged();
        }
    }
    public int Min
    {
        get { return min; }
        set
        {
            min = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
