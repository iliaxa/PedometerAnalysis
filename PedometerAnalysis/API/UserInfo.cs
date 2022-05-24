using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace PedometerAnalysis.API;

[DataContract]
public class UserInfo : INotifyPropertyChanged
{
    private int rank;
    private int[] steps;
    private string user;
    private string status;
    private double average;
    private int min;
    private int max;
    
    [DataMember]
    public int Rank {
        get { return rank; }
        set
        {
            rank = value;
            OnPropertyChanged();
        }

    }
    [DataMember]
    public string User
    {
        get { return user; }
        set
        {
            user = value;
            OnPropertyChanged();
        }
    }
    [DataMember]
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
    [DataMember]
    public double Average
    {
        get { return average; }
        set
        {
            average = value;
            OnPropertyChanged();
        }
    }
    [DataMember]
    public int Max
    {
        get { return max; }
        set
        {
            max = value;
            OnPropertyChanged();
        }
    }
    [DataMember]
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
