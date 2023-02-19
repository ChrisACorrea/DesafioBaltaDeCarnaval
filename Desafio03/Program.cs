var alcoholPrice = GetValueFromConsole("Informe o preço do Álcool: R$ ");
var gasolinePrice = GetValueFromConsole("Informe o preço da Gasolina: R$ ");

var priceRatio = alcoholPrice / gasolinePrice;

Console.Clear();
Console.WriteLine($"Preço do Álcool: {alcoholPrice:c2}");
Console.WriteLine($"Preço da Gasolina: {gasolinePrice:c2}");
Console.WriteLine($"Relação: {priceRatio:P}");
Console.WriteLine("");

if (priceRatio <= 0.72m)
	Console.WriteLine("Compensa abastecer com álcool.");
else
	Console.WriteLine("Compensa abastecer com gasolina.");

Console.WriteLine("");

decimal GetValueFromConsole(string displayText)
{
	bool success;
	decimal value;
	do
	{
		Console.Write(displayText);
		success = decimal.TryParse(Console.ReadLine(), out value);
		if (!success)
		{
			Console.WriteLine("");
			Console.Write("Você passou um valor inválido. Pressione qualquer tecla para tentar novamente");
			Console.ReadKey();
			Console.Clear();
		}
	} while (!success);

	return value;
}