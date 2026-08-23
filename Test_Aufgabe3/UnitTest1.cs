using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Task3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Timeout(3000)]
        [TestCategory("Task3")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avina$h", "@", "$", "Der Input beinhaltet einen ungültigen Charakter: $. Versuchen Sie es erneut.", DisplayName = "Überladung string: ungültiges Zeichen $")]
        [DataRow("Avin@sh", "@", "$", "Der Input beinhaltet einen ungültigen Charakter: @. Versuchen Sie es erneut.", DisplayName = "Überladung string: ungültiges Zeichen @")]
        [DataRow("", "@", "$", "Keine Eingabe registriert. Versuchen Sie es erneut.", DisplayName = "Überladung string: leere Eingabe")]
        public void Test_String(string input, string p1, string p2, string fehlermeldung)
        {
            using KonsolenTest konsole = new KonsolenTest(input + Environment.NewLine + "Avinash");

            string ausgabe = Aufgabe_3.EingabeRoutine(p1, p2);

            RueckgabePruefung.IstGleich(
                "Avinash",
                ausgabe,
                $"EingabeRoutine(\"{p1}\", \"{p2}\") ist die string-Überladung und hat nach \"{BeschreibeEingabe(input)}\" \"Avinash\" bekommen.",
                "Benenne die Methode EingabeRoutine (nicht mehr EingabeRoutineString). Die Parameter bleiben params string[] invalids.");

            konsole.MussZeileEnthalten(
                fehlermeldung,
                "Das Verhalten bleibt wie in Aufgabe 2. Nur der Methodenname ändert sich durch die Überladung.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task3")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0, 150, "Keine ganze Zahl! Versuchen Sie es erneut.", DisplayName = "Überladung int: Text statt Zahl")]
        [DataRow("-10", 0, 150, "Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.", DisplayName = "Überladung int: unter Minimum")]
        [DataRow("121", 0, 120, "Eingabe größer als Grenzwert: 120. Versuchen Sie es erneut.", DisplayName = "Überladung int: über Maximum")]
        public void Test_GanzeZahl(string input, int min, int max, string fehler)
        {
            using KonsolenTest konsole = new KonsolenTest(input + Environment.NewLine + "17");

            int ausgabe = Aufgabe_3.EingabeRoutine(min, max);

            RueckgabePruefung.IstGleich(
                17,
                ausgabe,
                $"EingabeRoutine({min}, {max}) ist die int-Überladung und hat nach \"{input}\" die gültige Eingabe 17 bekommen.",
                "Erstelle eine zweite Methode namens EingabeRoutine mit den Parametern int min, int max.");

            konsole.MussZeileEnthalten(
                fehler,
                "Die int-Überladung prüft wie in Aufgabe 2 den Bereich und wiederholt ungültige Eingaben.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task3")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0.0, 300.0, "Keine reelle Zahl! Versuchen Sie es erneut.", DisplayName = "Überladung double: Text statt Zahl")]
        [DataRow("-10.23", 0.0, 300.0, "Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.", DisplayName = "Überladung double: unter Minimum")]
        [DataRow("301.1", 0.0, 300.0, "Eingabe größer als Grenzwert: 300. Versuchen Sie es erneut.", DisplayName = "Überladung double: über Maximum")]
        public void Test_ReelleZahl(string input, double min, double max, string fehler)
        {
            using KonsolenTest konsole = new KonsolenTest(input + Environment.NewLine + "170.12");

            double ausgabe = Aufgabe_3.EingabeRoutine(min, max);

            RueckgabePruefung.IstGleich(
                170.12,
                ausgabe,
                $"EingabeRoutine({min}, {max}) ist die double-Überladung und hat nach \"{input}\" die gültige Eingabe 170.12 bekommen.",
                "Erstelle eine dritte Methode namens EingabeRoutine mit den Parametern double min, double max. C# unterscheidet sie an den Parametertypen.");

            konsole.MussZeileEnthalten(
                fehler,
                "Die double-Überladung prüft wie in Aufgabe 2 den Bereich und wiederholt ungültige Eingaben.");
        }

        private static string BeschreibeEingabe(string input)
        {
            return string.IsNullOrEmpty(input) ? "(leer)" : input;
        }
    }
}
