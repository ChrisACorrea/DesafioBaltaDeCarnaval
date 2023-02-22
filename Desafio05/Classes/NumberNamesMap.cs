namespace Desafio05.Classes;

public static class NumberNamesMap
{
	public static Dictionary<decimal, string> UnitsPlaceValueClass => new()
	{
		{0m, "zero"},
		{1m, "um"},
		{2m, "dois"},
		{3m, "três"},
		{4m, "quatro"},
		{5m, "cinco"},
		{6m, "seis"},
		{7m, "sete"},
		{8m, "oito"},
		{9m, "nove"},
		{10m, "dez"},
		{11m, "onze"},
		{12m, "doze"},
		{13m, "treze"},
		{14m, "quatorze"},
		{15m, "quinze"},
		{16m, "dezesseis"},
		{17m, "dezessete"},
		{18m, "dezoito"},
		{19m, "dezenove"}
	};
	public static Dictionary<decimal, string> TensPlaceValueClass => new()
	{
		{20m, "vinte"},
		{30m, "trinta"},
		{40m, "quarenta"},
		{50m, "cinquenta"},
		{60m, "sessenta"},
		{70m, "setenta"},
		{80m, "oitenta"},
		{90m, "noventa"}
	};
	public static Dictionary<decimal, string> HundredsPlaceValueClass => new()
	{
		{100m, "cento"},
		{200m, "duzentos"},
		{300m, "trezentos"},
		{400m, "quatrocentos"},
		{500m, "quinhentos"},
		{600m, "seiscentos"},
		{700m, "setecentos"},
		{800m, "oitocentos"},
		{900m, "novecentos"}
	};

	public static string HundredName => "cem";
	public static string ThousandsName => "mil";
	public static Dictionary<decimal, string> NumericScalePrefixes => new()
	{
		{1_000_000m, "milh"},
		{1_000_000_000m, "bilh"},
		{1_000_000_000_000m, "trilh"},
		{1_000_000_000_000_000m, "quadrilh"},
		{1_000_000_000_000_000_000m, "quintilh"}
	};
	public static string SuffixSingularClassName => "ão";
	public static string SuffixPluralClassName => "ões";

	public static string GetSuffixClassName(decimal value)
		=> value == 1m ? SuffixSingularClassName : SuffixPluralClassName;
}