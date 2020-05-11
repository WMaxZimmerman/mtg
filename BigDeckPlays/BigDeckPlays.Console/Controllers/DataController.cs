using BigDeckPlays.ApplicationCore.Services;
using NTrospection.CLI.Attributes;

namespace BigDeckPlays.Console.Controllers
{
    [CliController("data", "")]
    public static class DataController
    {
        [CliCommand("sync", "")]
        public static void SyncData()
        {
            System.Console.WriteLine("Method not yet implemented");
        }
    }
}
