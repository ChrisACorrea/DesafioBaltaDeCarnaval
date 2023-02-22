
namespace Desafio05;

public static class ConsoleHelper
{
	public static decimal GetNumberValueFromConsole(string displayText)
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
				CleanConsoleLine(2);
			}
		} while (!success);

		return value;
	}

	public static void CleanConsoleLine(int quantitiesToClean)
	{
		for (int i = 0; i < quantitiesToClean; i++)
		{
			Console.Write(string.Empty.PadRight(Console.WindowWidth));
			Console.SetCursorPosition(0, Console.CursorTop - 1);
		}
	}
}