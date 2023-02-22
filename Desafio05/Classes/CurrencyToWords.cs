using System.Text;

namespace Desafio05.Classes;

public class CurrencyToWords
{
	public static readonly decimal LIMIT = 1_000_000_000_000_000_000_000m; // 1 Sextilhão
	private decimal _valueToWrite;
	private decimal _valueIntegerPart => ((decimal)Math.Truncate(_valueToWrite));
	private int _valueDecimalPart => ((int)(Math.Truncate(_valueToWrite * 100) % 100));
	private string _currencyName => _valueIntegerPart is 1 or 0 ? "real" : "reais";
	private string _centsName => _valueDecimalPart is 1 or 0 ? "centavo" : "centavos";
	private char _conjunction => 'e';

	public CurrencyToWords(decimal value)
	{
		_valueToWrite = decimal.Round(Math.Abs(value), 2);
	}

	public string Convert()
	{
		if (_valueToWrite == 0)
			return "Zero reais e zero centavos";

		StringBuilder numberInWords = new();

		if (_valueIntegerPart != 0)
		{
			string integerPart = ConvertClassesAboveMillion(_valueIntegerPart);
			numberInWords.Append($"{integerPart} {_currencyName} ");
		}

		if (_valueDecimalPart != 0)
		{
			string decimalPart = ConvertTensClass(_valueDecimalPart);

			if (_valueIntegerPart != 0)
				numberInWords.Append($"{_conjunction} ");

			numberInWords.Append($"{decimalPart} {_centsName}");
		}

		return numberInWords.ToString();
	}

	private string ConvertUnitClass(decimal value)
	{
		if (value == 0)
			return string.Empty;

		return $"{NumberNamesMap.UnitsPlaceValueClass[value]}";
	}

	private string ConvertTensClass(decimal value)
	{
		if (value < 20)
			return ConvertUnitClass(value);
		else
		{
			decimal tensPlace = Math.Truncate(value / 10m) * 10m;
			decimal onesPlace = value % 10m;
			string tensName = NumberNamesMap.TensPlaceValueClass[tensPlace];
			string onesName = onesPlace > 0 ? $" {_conjunction} {ConvertUnitClass(onesPlace)}" : string.Empty;
			return $"{tensName}{onesName}";
		}
	}

	private string ConvertHundredsClass(decimal value)
	{
		const decimal ONE_HUNDRED = 100m;
		if (value < ONE_HUNDRED)
			return ConvertTensClass(value);

		decimal hundredsPlace = Math.Truncate(value / ONE_HUNDRED) * ONE_HUNDRED;
		decimal tensPlace = value % ONE_HUNDRED;
		string hundredsName = NumberNamesMap.HundredsPlaceValueClass[hundredsPlace];
		string tensName = tensPlace > 0 ? $" {_conjunction} {ConvertTensClass(tensPlace)}" : string.Empty;

		if (hundredsPlace == ONE_HUNDRED && tensPlace == 0)
			return NumberNamesMap.HundredName;

		return $"{NumberNamesMap.HundredsPlaceValueClass[hundredsPlace]}{tensName}";
	}

	private string ConvertThousandsClass(decimal value)
	{
		const decimal ONE_THOUSAND = 1_000m;
		if (value < ONE_THOUSAND)
			return ConvertHundredsClass(value);

		decimal thousandsPlace = Math.Truncate(value / ONE_THOUSAND);
		decimal hundredsPlace = value % ONE_THOUSAND;
		string thousandsName = thousandsPlace != 1
			? $"{ConvertHundredsClass(thousandsPlace)} {NumberNamesMap.ThousandsName}"
			: NumberNamesMap.ThousandsName;

		if (hundredsPlace == 0)
			return thousandsName;

		if (NumberNamesMap.HundredsPlaceValueClass.ContainsKey(hundredsPlace))
			thousandsName += $" {_conjunction}";

		return $"{thousandsName} {ConvertHundredsClass(hundredsPlace)}";
	}

	private string ConvertClassesAboveMillion(decimal value)
	{
		const decimal ONE_MILLION = 1_000_000m;
		const decimal MULTIPLIER = 1_000m;

		if (value < ONE_MILLION)
			return ConvertThousandsClass(value);

		StringBuilder convertedValues = new();
		decimal thousandsPlace = value % ONE_MILLION;
		string thousandsName = thousandsPlace > 0
			? $" {ConvertThousandsClass(thousandsPlace)}"
			: " de";
		convertedValues.Insert(0, thousandsName);

		decimal valueWithoutTheThousands = Math.Truncate(value / ONE_MILLION) * ONE_MILLION;
		for (decimal scale = ONE_MILLION; scale < LIMIT; scale *= MULTIPLIER)
		{
			if (valueWithoutTheThousands >= scale)
			{
				decimal scalePlace = Math.Truncate(valueWithoutTheThousands / scale) % MULTIPLIER;

				if (scalePlace == 0)
					continue;

				string scaleName = $"{ConvertHundredsClass(scalePlace)} {NumberNamesMap.NumericScalePrefixes[scale]}{NumberNamesMap.GetSuffixClassName(scalePlace)}";
				convertedValues.Insert(0, $"{scaleName}");
			}
		}

		return convertedValues.ToString();
	}

}