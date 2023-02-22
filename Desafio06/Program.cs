Console.WriteLine("");
Console.WriteLine("Texto a ser criptografado:");
var text = Console.ReadLine()?.Trim().ToLower();

if (string.IsNullOrEmpty(text))
{
	Console.WriteLine("Nenhum texto para encriptar.");
	Environment.Exit(0);
}

var encryptedText = ApplyCaesarCipher(text!);

Console.WriteLine("");
Console.WriteLine(encryptedText.ToUpper());
Console.WriteLine("");

string ApplyCaesarCipher(string text)
{
	const int STEP = 3;
	const int RANGE = 26;
	const int AlPHABET_START = 'a';
	string encryptedText = string.Empty;

	foreach (var letter in text)
	{
		if (!char.IsAsciiLetter(letter))
		{
			encryptedText += letter;
			continue;
		}

		var encryptedLetter = (char)(((letter - AlPHABET_START + STEP) % RANGE) + AlPHABET_START);
		encryptedText += encryptedLetter;
	}

	return encryptedText;
}