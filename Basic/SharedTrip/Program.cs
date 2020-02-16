namespace SharedTrip
{
    using SIS.MvcFramework;
    using System.Threading.Tasks;

    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
