namespace IRunesNew
{
    using Services;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Collections.Generic;
    using Data;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new IRunesDbContex().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }
    }
}
