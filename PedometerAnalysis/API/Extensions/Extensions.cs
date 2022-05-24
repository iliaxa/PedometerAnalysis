using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PedometerAnalysis.API.Extensions;
internal static class Extensions
{
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
    {
        return new ObservableCollection<T>(source);
    }
    public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
        return collection;
    }
}
