using BigDeckPlays.ApplicationCore.Services;
using NTrospection.CLI.Attributes;

namespace BigDeckPlays.Console.Controllers
{
    [CliController("scryfall", "")]
    public static class ScryfallController
    {
        [CliCommand("sets", "")]
        public static void OutputAllSets()
        {
            var scryfall = new ScryfallService();
            var sets = scryfall.GetSets();

            foreach(var s in sets)
            {
                System.Console.WriteLine($"{s.Name} ({s.Code})");
            }
        }

        
        [CliCommand("cards", "")]
        public static void GetAllCardsForSet(string setCode)
        {
            var scryfall = new ScryfallService();
            var cards = scryfall.GetBySet(setCode);

            foreach(var card in cards)
            {
                System.Console.WriteLine($"{card.Name} ({card.Cmc})");
            }
        }
    }
}
