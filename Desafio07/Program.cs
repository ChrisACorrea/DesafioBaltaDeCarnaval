using Desafio07;

Console.Clear();
var message = "Digite o termo máximo da sequência de Fibonacci (min: 3, max: 48): ";
var maximumTerm = ConsoleHelper.GetNumberValueFromConsole(message);

List<int> fibonacciSequence = new() { 0, 1 };

for (int i = 0; i < maximumTerm - 2; i++)
{
	var nextTerm = fibonacciSequence[^2] + fibonacciSequence[^1];
	fibonacciSequence.Add(nextTerm);
}

for (int i = 0; i < fibonacciSequence.Count; i++)
{
	for (int j = 0; j < i; j++)
	{
		Console.Write($"{fibonacciSequence[j]}".PadRight(fibonacciSequence[^1].ToString().Length + 1));
	}
	Console.WriteLine("");
}

Console.WriteLine("");
