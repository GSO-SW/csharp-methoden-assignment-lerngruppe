using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Leitet Konsole um und erklärt Fehlschläge so, dass Lernende
/// sehen, welche Zeile oder welchen Rückgabewert die Aufgabe erwartet.
/// </summary>
internal sealed class KonsolenTest : IDisposable
{
    private readonly TextReader _vorherigesIn;
    private readonly TextWriter _vorherigesOut;
    private readonly CultureInfo _vorherigeKultur;
    private readonly CultureInfo _vorherigeUiKultur;

    public StringWriter Ausgabe { get; }

    public KonsolenTest(string eingabe)
    {
        _vorherigesIn = Console.In;
        _vorherigesOut = Console.Out;
        _vorherigeKultur = CultureInfo.CurrentCulture;
        _vorherigeUiKultur = CultureInfo.CurrentUICulture;

        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
        Environment.SetEnvironmentVariable("IsTesting", "true");

        Ausgabe = new StringWriter();
        Console.SetOut(Ausgabe);
        Console.SetIn(new StringReader(eingabe ?? string.Empty));
    }

    public void Dispose()
    {
        Console.SetIn(_vorherigesIn);
        Console.SetOut(_vorherigesOut);
        CultureInfo.CurrentCulture = _vorherigeKultur;
        CultureInfo.CurrentUICulture = _vorherigeUiKultur;
        Environment.SetEnvironmentVariable("IsTesting", null);
        Ausgabe.Dispose();
    }

    public IReadOnlyList<string> NichtleereZeilen()
    {
        return Ausgabe.GetStringBuilder()
            .ToString()
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
            .Select(zeile => zeile.Trim())
            .Where(zeile => zeile.Length > 0)
            .ToList();
    }

    public void MussZeileEnthalten(string erwarteteZeile, string tipp)
    {
        IReadOnlyList<string> zeilen = NichtleereZeilen();
        if (zeilen.Contains(erwarteteZeile))
        {
            return;
        }

        Assert.Fail(BaueHinweis(
            "Die erwartete Ausgabezeile fehlt oder weicht ab.",
            tipp,
            $"Erwartete Zeile:{Environment.NewLine}  {erwarteteZeile}",
            $"Deine Konsolenausgabe:{Environment.NewLine}{FormatiereZeilen(zeilen)}"));
    }

    public void DarfZeileNichtEnthalten(string verboteneZeile, string tipp)
    {
        IReadOnlyList<string> zeilen = NichtleereZeilen();
        if (!zeilen.Contains(verboteneZeile))
        {
            return;
        }

        Assert.Fail(BaueHinweis(
            "Bei einer gültigen Eingabe darf diese Fehlermeldung nicht erscheinen.",
            tipp,
            $"Unerwartete Zeile:{Environment.NewLine}  {verboteneZeile}",
            $"Deine Konsolenausgabe:{Environment.NewLine}{FormatiereZeilen(zeilen)}"));
    }

    private static string FormatiereZeilen(IReadOnlyList<string> zeilen)
    {
        if (zeilen.Count == 0)
        {
            return "  (keine Ausgabe)";
        }

        StringBuilder builder = new StringBuilder();
        foreach (string zeile in zeilen)
        {
            builder.Append("  • ");
            builder.AppendLine(zeile);
        }

        return builder.ToString().TrimEnd();
    }

    private static string BaueHinweis(string titel, string tipp, string erwartet, string tatsaechlich)
    {
        return $"{titel}{Environment.NewLine}{Environment.NewLine}" +
               $"{erwartet}{Environment.NewLine}{Environment.NewLine}" +
               $"{tatsaechlich}{Environment.NewLine}{Environment.NewLine}" +
               $"Tipp: {tipp}";
    }
}

internal static class RueckgabePruefung
{
    public static void IstGleich<T>(T erwartet, T erhalten, string kontext, string tipp)
    {
        if (Equals(erwartet, erhalten))
        {
            return;
        }

        Assert.AreEqual(
            erwartet,
            erhalten,
            $"{kontext}{Environment.NewLine}{Environment.NewLine}" +
            $"Erwarteter Rückgabewert: {FormatWert(erwartet)}{Environment.NewLine}" +
            $"Dein Rückgabewert:       {FormatWert(erhalten)}{Environment.NewLine}{Environment.NewLine}" +
            $"Tipp: {tipp}");
    }

    public static void IstGleich(double erwartet, double erhalten, string kontext, string tipp)
    {
        if (Math.Abs(erwartet - erhalten) < 0.0001)
        {
            return;
        }

        Assert.AreEqual(
            erwartet,
            erhalten,
            0.0001,
            $"{kontext}{Environment.NewLine}{Environment.NewLine}" +
            $"Erwarteter Rückgabewert: {erwartet}{Environment.NewLine}" +
            $"Dein Rückgabewert:       {erhalten}{Environment.NewLine}{Environment.NewLine}" +
            $"Tipp: {tipp}");
    }

    private static string FormatWert<T>(T wert)
    {
        if (wert is null)
        {
            return "(null)";
        }

        if (wert is string text)
        {
            return $"\"{text}\"";
        }

        return wert.ToString() ?? "(null)";
    }
}
