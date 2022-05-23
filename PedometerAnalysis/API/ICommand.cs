using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedometerAnalysis.API;
internal interface ICommand
{
    event EventHandler CanExecuteChanged;
    void Execute(object parameter);
    bool CanExecute(object parameter);
}
