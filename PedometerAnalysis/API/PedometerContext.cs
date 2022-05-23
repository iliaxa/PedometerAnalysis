using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PedometerAnalysis.API;
internal class PedometerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    public DbSet<UserInfo> Users => Set<UserInfo>();
    public DbSet<Status> Statuses => Set<Status>();
    public PedometerContext() => Database.EnsureCreated();
}
