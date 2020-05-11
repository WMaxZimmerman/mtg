using BigDeckPlays.ApplicationCore.Services;
using NTrospection.CLI.Attributes;

namespace BigDeckPlays.Console.Controllers
{
    [CliController("cards", "")]
    public static class CardController
    {
        [CliCommand("list", "")]
        public static void GetAllCards()
        {
            var service = new CardService();
            var cards = service.GetFromDatabase();

            foreach(var card in cards)
            {
                System.Console.WriteLine($"{card.Name} ({card.Cmc})");
            }
        }
    }
}
