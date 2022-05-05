using MinimalApis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MinimalApis.Data
{
    public class OrderToppingsConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTopping>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.WaffleId)
                    .IsRequired();

                b.Property(c => c.Price)
                   .HasColumnType("decimal");

             
            });
        }
    }
}
