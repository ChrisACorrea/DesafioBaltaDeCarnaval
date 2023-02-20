using Desafio04;

var finalPurchaseValue = ConsoleHelper.GetNumberValueFromConsole("Valor final da compra: R$ ");
var paymentAmount = ConsoleHelper.GetNumberValueFromConsole("Pagamento: R$ ");
var changeValue = paymentAmount - finalPurchaseValue;

Console.WriteLine("");

if (changeValue < 0)
{
	Console.WriteLine("O valor do pagamento é menor que o valor final da compra.");
	Console.WriteLine($"Nesse caso não há troco e ainda permanece uma dívida de {(changeValue * -1):c2}.");
	Console.WriteLine("");
	Environment.Exit(0);
}

decimal[] values = { 200, 100, 50, 20, 10, 5, 2, 1, 0.50m, 0.25m, 0.10m, 0.05m, 0.01m };
var coinQuantities = new Dictionary<decimal, int>();

foreach (var value in values)
	coinQuantities.Add(value, 0);

CalculateChange(changeValue, 0);

Console.WriteLine($"Troco:\t{changeValue:c2}");

foreach (var coin in coinQuantities.Where((v) => v.Value != 0))
{
	if (coin.Key > 1)
		Console.WriteLine($"\t- {coin.Value} nota{Plural(coin.Value)} de {coin.Key:n0} reais.");
	else if (coin.Key == 1)
		Console.WriteLine($"\t- {coin.Value} moeda{Plural(coin.Value)} de {coin.Key:n0} real.");
	else
		Console.WriteLine($"\t- {coin.Value} moeda{Plural(coin.Value)} de {(coin.Key * 100):n0} centavo{(coin.Key != 0.01m ? "s" : string.Empty)}.");
}

string Plural(int quantity) => quantity > 1 ? "s" : string.Empty;

void CalculateChange(decimal changeValue, int index)
{

	if (index == values.Length)
		return;

	var currentValue = values[index];

	while (changeValue >= currentValue)
	{
		changeValue -= currentValue;
		coinQuantities![currentValue]++;
	}

	CalculateChange(changeValue, index + 1);
}