using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Users.Add(new UserInfo { Rank = 1, Status = "11", Steps = 11, User = "11" });
        SelectedUser = Users.Last();
    }
}