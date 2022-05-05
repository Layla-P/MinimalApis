using MinimalApis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinimalApis.Data
{
    public class WaffleConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Waffle>(b =>
            {
                b.HasKey(c => c.Id);
            });

        }
    }
}
