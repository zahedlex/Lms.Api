﻿using Lms.Data.Data;
using Lms.Api;
using Microsoft.EntityFrameworkCore;

namespace Lms.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<LmsApiContext>();

                //db.Database.EnsureDeleted();
                //db.Database.Migrate();

                try
                {
                    await SeedData.InitAsync(db);
                }
                catch (Exception e)
                {

                    throw;
                }
            }

            return app;

        }
    }
}
