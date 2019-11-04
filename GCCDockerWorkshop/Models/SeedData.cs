using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GCCDockerWorkshop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GCCDockerWorkshopDB(
                serviceProvider.GetRequiredService<DbContextOptions<GCCDockerWorkshopDB>>()))
            {
                // Look for any movies.
                if (context.Orders.Any())
                {
                    return;   // DB has been seeded
                }

                #region snippet1
                context.Orders.AddRange(
                    new Order
                    {
                        OrderNumber = 1001,
                        OrderDate = DateTime.Parse("2019-10-12"),
                        OrderTotal = 7.99M
                    },
                #endregion

                    new Order
                    {
                        OrderNumber = 1002,
                        OrderDate = DateTime.Parse("2019-10-15"),
                        OrderTotal = 10.99M
                    },

                     new Order
                     {
                         OrderNumber = 1003,
                         OrderDate = DateTime.Parse("2019-10-18"),
                         OrderTotal = 15.99M
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
