using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Task1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Timeout(3000)]
        [TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avinash", DisplayName = "Gültiger Name wird unverändert zurückgegeben")]
        [DataRow("avinash_superstar@theblock.com", DisplayName = "Gültige E-Mail wird unverändert zurückgegeben")]
        public void Test_StringErfolg(string input)
        {
            using KonsolenTest konsole = new KonsolenTest(input);

            string ausgabe = Aufgabe_1.EingabeRoutineString();

            RueckgabePruefung.IstGleich(
                input,
                ausgabe,
                "EingabeRoutineString() soll die eingelesene Zeichenfolge zurückgeben.",
                "Lies die Eingabe mit Console.ReadLine() und gib diesen Wert direkt zurück.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0, "Keine ganze Zahl!", DisplayName = "Text statt Zahl: Meldung und Rückgabe 0")]
        [DataRow("siebzehn", 0, "Keine ganze Zahl!", DisplayName = "Wort 'siebzehn': Meldung und Rückgabe 0")]
        [DataRow("17.5", 0, "Keine ganze Zahl!", DisplayName = "Kommazahl ist keine ganze Zahl")]
        public void Test_GanzeZahl(string input, int ergebnis, string fehler)
        {
            using KonsolenTest konsole = new KonsolenTest(input);

            int ausgabe = Aufgabe_1.EingabeRoutineInt32();

            RueckgabePruefung.IstGleich(
                ergebnis,
                ausgabe,
                $"EingabeRoutineInt32() wurde mit \"{input}\" aufgerufen.",
                "Wenn Convert.ToInt32 fehlschlägt, fange die Exception und gib 0 zurück.");

            konsole.MussZeileEnthalten(
                fehler,
                "Gib die Meldung mit Console.WriteLine genau so aus, wie in der Aufgabenstellung (inkl. Ausrufezeichen).");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        public void Test_GanzeZahlErfolg()
        {
            using KonsolenTest konsole = new KonsolenTest("10");

            int ausgabe = Aufgabe_1.EingabeRoutineInt32();

            RueckgabePruefung.IstGleich(
                10,
                ausgabe,
                "EingabeRoutineInt32() wurde mit der gültigen Eingabe \"10\" aufgerufen.",
                "Wandle die Eingabe mit Convert.ToInt32 (oder int.Parse) um und gib die Zahl zurück.");

            konsole.DarfZeileNichtEnthalten(
                "Keine ganze Zahl!",
                "Die Fehlermeldung darf nur erscheinen, wenn die Eingabe keine ganze Zahl ist.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0.0, "Keine reelle Zahl!", DisplayName = "Text statt Zahl: Meldung und Rückgabe 0.0")]
        [DataRow("1 meter 70", 0.0, "Keine reelle Zahl!", DisplayName = "Text '1 meter 70' ist keine reelle Zahl")]
        public void Test_ReelleZahl(string input, double ergebnis, string fehler)
        {
            using KonsolenTest konsole = new KonsolenTest(input);

            double ausgabe = Aufgabe_1.EingabeRoutineDouble();

            RueckgabePruefung.IstGleich(
                ergebnis,
                ausgabe,
                $"EingabeRoutineDouble() wurde mit \"{input}\" aufgerufen.",
                "Wenn Convert.ToDouble fehlschlägt, fange die Exception und gib 0.0 zurück.");

            konsole.MussZeileEnthalten(
                fehler,
                "Gib genau 'Keine reelle Zahl!' aus. Achte auf die Schreibweise (reelle, nicht reale).");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        public void Test_ReelleZahlErfolg()
        {
            using KonsolenTest konsole = new KonsolenTest("10.23");

            double ausgabe = Aufgabe_1.EingabeRoutineDouble();

            RueckgabePruefung.IstGleich(
                10.23,
                ausgabe,
                "EingabeRoutineDouble() wurde mit der gültigen Eingabe \"10.23\" aufgerufen.",
                "Wandle die Eingabe mit Convert.ToDouble (oder double.Parse) um und gib die Zahl zurück.");

            konsole.DarfZeileNichtEnthalten(
                "Keine reelle Zahl!",
                "Die Fehlermeldung darf nur erscheinen, wenn die Eingabe keine reelle Zahl ist.");
        }
    }
}
