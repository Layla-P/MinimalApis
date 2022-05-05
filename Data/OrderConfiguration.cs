using MinimalApis.Entities;
using Microsoft.EntityFrameworkCore;

namespace MinimalApis.Data
{
    public class OrderConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.UserId)
                    .IsRequired();

                b.Property(c => c.Price)
                   .HasColumnType("decimal");
            });
        }
    }
}
