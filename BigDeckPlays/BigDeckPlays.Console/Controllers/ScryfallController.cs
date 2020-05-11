using System.Linq;
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
            var sets = scryfall.GetSets().OrderBy(s => s.ReleasedAt);

            foreach(var s in sets)
            {
                System.Console.WriteLine($"{s.Id} : {s.Name} ({s.Code})");
                System.Console.WriteLine($"Set Type = {s.SetType}");
                System.Console.WriteLine($"Release At = {s.ReleasedAt}");
                System.Console.WriteLine($"Block = {s.Block} ({s.BlockCode})");
                System.Console.WriteLine($"Card Count = {s.CardCount}");
                System.Console.WriteLine($"Digital = {s.Digital}");
                System.Console.WriteLine($"Foil = {s.FoilOnly}");
                System.Console.WriteLine("");
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
