using Desafio05;
using Desafio05.Classes;

Console.WriteLine("");
var value = ConsoleHelper.GetNumberValueFromConsole("Valor final da compra: R$ ");
Console.WriteLine("");

if (value >= CurrencyToWords.LIMIT)
{
	Console.WriteLine("Uau!!! Pra que um valor desse tamanho? Tá comprando algo ou pesando a mãe do Renan?");
	Environment.Exit(0);
}

var numberInWords = new CurrencyToWords(value).Convert();

Console.WriteLine(numberInWords.ToUpperInvariant());
Console.WriteLine("");