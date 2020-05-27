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

        [CliCommand("syncSets", "")]
        public static void SyncSets()
        {
            var service = new SyncService();
            service.SyncSets();
        }

        [CliCommand("syncCards", "")]
        public static void SyncCards()
        {
            var service = new SyncService();
            service.SyncCards();
        }
    }
}
