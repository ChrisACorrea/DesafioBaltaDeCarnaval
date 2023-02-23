
namespace Desafio07;

public static class ConsoleHelper
{
	public static int GetNumberValueFromConsole(string displayText)
	{
		bool success;
		int value;
		do
		{
			Console.Write(displayText);
			success = int.TryParse(Console.ReadLine(), out value);
			if (success && (value < 3 || value > 48))
				success = false;

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