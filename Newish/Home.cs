using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

namespace Newish
{
    public static class Home
    {
        private static Func<IEnumerable<int>> GetNumbers = () => new int[] { 1, 2, 3, 4, 5 };

        public static WebApplication RegisterHomeRoutes(this WebApplication app)
        {
            app.MapGet("/", GetNumbers);
            return app;
        }

    }
}
