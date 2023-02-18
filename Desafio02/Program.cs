var height = GetValueFromConsole("Informe sua altura (m): ");
var weight = GetValueFromConsole("Informe seu peso (kg): ");
var bmi = CalculateBMI(height, weight);
(var rating, var risk) = CalculateBMIRating(bmi);

Console.Clear();
Console.WriteLine($"Altura informada: {height:n2}");
Console.WriteLine($"Peso informado: {weight:n2}");
Console.WriteLine("");
Console.WriteLine($"> Seu IMC é {bmi:n1}");
Console.WriteLine($"> {rating}");
Console.WriteLine($"> Risco: {risk}");
Console.WriteLine("");

double CalculateBMI(double height, double weight) => weight / (height * height);

(string rating, string risk) CalculateBMIRating(double bmi)
{
	if (bmi < 16) return ("Magreza Grau III", "-");
	if (bmi < 17) return ("Magreza Grau II", "-");
	if (bmi < 18.5) return ("Magreza Grau I", "-");
	if (bmi < 25) return ("Eutrofia", "-");
	if (bmi < 30) return ("Sobrepeso", "Aumentado");
	if (bmi < 35) return ("Obesidade Grau I", "Moderado");
	if (bmi <= 40) return ("Obesidade Grau II", "Grave");

	return ("Obesidade Grau III", "Muito Grave");
}

double GetValueFromConsole(string displayText)
{
	bool success;
	double value;
	do
	{
		Console.Write(displayText);
		success = double.TryParse(Console.ReadLine(), out value);
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