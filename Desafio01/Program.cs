using System.Text.RegularExpressions;

Console.WriteLine("Digite um texto:");
Console.WriteLine("");

var text = Console.ReadLine() ?? string.Empty;

Console.WriteLine("");
Console.WriteLine($"> {CountCharacters(text)} caracteres, {CountWords(text)} palavras");


int CountCharacters(string text)
{
	return text.Length;
}

int CountWords(string text)
{
	var cleanText = Regex.Replace(text.Trim(), "[\\W\\s]+", " ");
	if (cleanText.Length is not 0)
		return cleanText.Split(" ").Length;

	return 0;
}