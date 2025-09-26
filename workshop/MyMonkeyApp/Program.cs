
using MyMonkeyApp;

var random = new Random();
var asciiArts = new[]
{
	@"  (o\_/o)",
	@"  (='.'=)",
	"  (\")_(\\\")",
	@"  (o.o)",
	@"  ( : )",
	@"  ( ^.^ )",
	@"  (>'-')> <('-'<) ^(' - ')^ v(' - ')v (>'-')> <('-'<)"
};

void ShowRandomAsciiArt()
{
	var art = asciiArts[random.Next(asciiArts.Length)];
	Console.WriteLine(art);
	Console.WriteLine();
}

while (true)
{
	ShowRandomAsciiArt();
	Console.WriteLine("===== Monkey App Menu =====");
	Console.WriteLine("1. List all monkeys");
	Console.WriteLine("2. Get details for a specific monkey by name");
	Console.WriteLine("3. Get a random monkey");
	Console.WriteLine("4. Exit app");
	Console.Write("Select an option: ");
	var input = Console.ReadLine();
	Console.WriteLine();

	switch (input)
	{
		case "1":
			var monkeys = await MonkeyHelper.GetMonkeysAsync();
			Console.WriteLine("Name                 | Location                | Population");
			Console.WriteLine("---------------------+-------------------------+-----------");
			foreach (var m in monkeys)
			{
				Console.WriteLine($"{m.Name,-20} | {m.Location,-23} | {m.Population,9}");
			}
			Console.WriteLine();
			break;
		case "2":
			Console.Write("Enter monkey name: ");
			var name = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("Name cannot be empty.\n");
				break;
			}
			var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name);
			if (monkey == null)
			{
				Console.WriteLine($"Monkey '{name}' not found.\n");
			}
			else
			{
				Console.WriteLine($"Name: {monkey.Name}");
				Console.WriteLine($"Location: {monkey.Location}");
				Console.WriteLine($"Population: {monkey.Population}");
				Console.WriteLine($"Details: {monkey.Details}");
				Console.WriteLine($"Image: {monkey.Image}");
				Console.WriteLine($"Coordinates: {monkey.Latitude}, {monkey.Longitude}\n");
			}
			break;
		case "3":
			var randomMonkey = await MonkeyHelper.GetRandomMonkeyAsync();
			if (randomMonkey == null)
			{
				Console.WriteLine("No monkeys available.\n");
			}
			else
			{
				Console.WriteLine($"Random Monkey: {randomMonkey.Name}");
				Console.WriteLine($"Location: {randomMonkey.Location}");
				Console.WriteLine($"Population: {randomMonkey.Population}");
				Console.WriteLine($"Details: {randomMonkey.Details}");
				Console.WriteLine($"Image: {randomMonkey.Image}");
				Console.WriteLine($"Coordinates: {randomMonkey.Latitude}, {randomMonkey.Longitude}");
				Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomAccessCount()} times.\n");
			}
			break;
		case "4":
			Console.WriteLine("Goodbye!");
			return;
		default:
			Console.WriteLine("Invalid option. Please try again.\n");
			break;
	}
}
