using System.Collections.Generic;
using System.Text;
using SpaceTrucker.Models;

namespace SpaceTrucker.ViewModel
{
	class MenuFactory
	{
		internal Menu CreateTravelMenu(Dictionary<Planet, Trip> closestPlanets)
		{
			var options = new List<IOption>();

			foreach (var planet in closestPlanets)
			{
                var tripInforOffSet = 25;
                var sb = new StringBuilder();
                var str = $"{planet.Key.Name} ({planet.Key.ShortName})";
                sb.Append(str);
                sb.Append(' ', tripInforOffSet - sb.Length);
                str = $"{planet.Value.distance} ly";
                sb.Append(' ', 6 - str.Length).Append($"{str} | ");
                str = $"{planet.Value.fuelUsage}%";
                sb.Append(' ', 4 - str.Length).Append($"{str} | ");
                sb.Append($"{planet.Value.duration} days");

                options.Add(new Option(sb.ToString(), OptionType.Planet, false));
			}

            if (closestPlanets?.Count > 0)
            {
                options[0].IsSelected = true;
            }

			return new Menu("Select a planet to travel to...", options);
		}

		internal Menu CreateMainMenu()
		{
			var options = new List<IOption>
			{
				new Option("Continue Game", OptionType.Continue, true),
				new Option("New Game", OptionType.NewGame, false),
				new Option("Quit", OptionType.Quit,false),
			};

			return new Menu("Main Menu", options);
		}

		internal Menu CreateGameMenu()
		{
			var options = new List<IOption>
			{
				new Option("Travel to a different planet", OptionType.GoToTravel,true),
				new Option("Trade with the planet's market", OptionType.GoToTradeMarket,false),
				new Option("Purchase more fuel cells", OptionType.PurchaseFuel,false),
				new Option("Main Menu", OptionType.BackMainMenu,false),
			};

			return new Menu("Select an option below", options);
		}

		internal Menu CreateBuySellMenu()
		{
			var options = new List<IOption>
			{
				new Option("Buy", OptionType.GoToBuy, true),
				new Option("Sell", OptionType.GoToSell, false),
			};

			return new Menu("Trade Market", options);
		}

		internal Menu CreateOreMenu(string prompt, List<string> ores, OptionType optionType)
		{
			var options = new List<IOption>();

			foreach (var ore in ores)
			{
				options.Add(new Option(ore, optionType, false));
			}

			options[0].IsSelected = true;

			return new Menu(prompt, options);
		}

		internal Menu CreateConfirmationMenu(string prompt)
		{
			var options = new List<IOption>
			{
				new Option("Yes", OptionType.Yes, true),
				new Option("No", OptionType.No, false),
			};

			return new Menu(prompt, options);
		}

        internal Menu CreateTravelConfirmationMenu(string prompt, string customYes, string customNo)
        {
            var options = new List<IOption>
            {
                new Option(customYes, OptionType.Yes, true),
                new Option(customNo, OptionType.No, false),
            };

            return new Menu(prompt, options);
        }
    }
}
