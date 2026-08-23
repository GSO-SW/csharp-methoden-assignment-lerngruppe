using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Task2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Timeout(3000)]
        [TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avina$h", "@", "$", "Der Input beinhaltet einen ungültigen Charakter: $. Versuchen Sie es erneut.", DisplayName = "Ungültiges Zeichen $ im Namen")]
        [DataRow("Avin@sh", "@", "$", "Der Input beinhaltet einen ungültigen Charakter: @. Versuchen Sie es erneut.", DisplayName = "Ungültiges Zeichen @ im Namen")]
        [DataRow("", "@", "$", "Keine Eingabe registriert. Versuchen Sie es erneut.", DisplayName = "Leere Eingabe wird wiederholt")]
        public void Test_String(string input, string p1, string p2, string fehlermeldung)
        {
            using KonsolenTest konsole = new KonsolenTest(input + Environment.NewLine + "Avinash");

            string ausgabe = Aufgabe_2.EingabeRoutineString(p1, p2);

            RueckgabePruefung.IstGleich(
                "Avinash",
                ausgabe,
                $"EingabeRoutineString(\"{p1}\", \"{p2}\") hat nach \"{BeschreibeEingabe(input)}\" eine gültige Eingabe \"Avinash\" bekommen.",
                "Bei ungültiger oder leerer Eingabe nicht abbrechen: Fehlermeldung ausgeben und erneut Console.ReadLine() aufrufen, bis die Eingabe gültig ist.");

            konsole.MussZeileEnthalten(
                fehlermeldung,
                "Die Fehlermeldung muss das konkrete ungültige Zeichen bzw. den Hinweis auf die leere Eingabe enthalten. Schreibe sie genau wie in der Aufgabenstellung.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        public void Test_StringErfolg()
        {
            using KonsolenTest konsole = new KonsolenTest("Avinash");

            string ausgabe = Aufgabe_2.EingabeRoutineString("@", "$");

            RueckgabePruefung.IstGleich(
                "Avinash",
                ausgabe,
                "EingabeRoutineString(\"@\", \"$\") wurde mit der gültigen Eingabe \"Avinash\" aufgerufen.",
                "Wenn die Eingabe nicht leer ist und keines der verbotenen Zeichen enthält, gib sie sofort zurück.");

            konsole.DarfZeileNichtEnthalten(
                "Keine Eingabe registriert. Versuchen Sie es erneut.",
                "Bei einer gültigen Eingabe darf nicht nach einer Wiederholung gefragt werden.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0, 150, "Keine ganze Zahl! Versuchen Sie es erneut.", DisplayName = "Text statt Alter")]
        [DataRow("-10", 0, 150, "Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.", DisplayName = "Alter unter dem Minimum")]
        [DataRow("121", 0, 120, "Eingabe größer als Grenzwert: 120. Versuchen Sie es erneut.", DisplayName = "Alter über dem Maximum")]
        public void Test_GanzeZahl(string input, int min, int max, string fehler)
        {
            using KonsolenTest konsole = new KonsolenTest(input + Environment.NewLine + "17");

            int ausgabe = Aufgabe_2.EingabeRoutineInt32(min, max);

            RueckgabePruefung.IstGleich(
                17,
                ausgabe,
                $"EingabeRoutineInt32({min}, {max}) hat nach \"{input}\" die gültige Eingabe 17 bekommen.",
                "Bei ungültiger Zahl oder Wert außerhalb von min/max: passende Meldung ausgeben und die Eingabe wiederholen, bis ein Wert im Bereich liegt.");

            konsole.MussZeileEnthalten(
                fehler,
                "Setze min bzw. max in die Meldung ein, z. B. 'Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.'");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        public void Test_GanzeZahlErfolg()
        {
            using KonsolenTest konsole = new KonsolenTest("17");

            int ausgabe = Aufgabe_2.EingabeRoutineInt32(0, 120);

            RueckgabePruefung.IstGleich(
                17,
                ausgabe,
                "EingabeRoutineInt32(0, 120) wurde mit der gültigen Eingabe 17 aufgerufen.",
                "Liegt die Zahl zwischen min und max (einschließlich), gib sie zurück.");

            konsole.DarfZeileNichtEnthalten(
                "Keine ganze Zahl! Versuchen Sie es erneut.",
                "Bei einer gültigen ganzen Zahl im Bereich darf keine Fehlermeldung erscheinen.");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0.0, 300.0, "Keine reelle Zahl! Versuchen Sie es erneut.", DisplayName = "Text statt Körpergröße")]
        [DataRow("-10.23", 0.0, 300.0, "Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.", DisplayName = "Größe unter dem Minimum")]
        [DataRow("301.1", 0.0, 300.0, "Eingabe größer als Grenzwert: 300. Versuchen Sie es erneut.", DisplayName = "Größe über dem Maximum")]
        public void Test_ReelleZahl(string input, double min, double max, string fehler)
        {
            using KonsolenTest konsole = new KonsolenTest(input + Environment.NewLine + "170.12");

            double ausgabe = Aufgabe_2.EingabeRoutineDouble(min, max);

            RueckgabePruefung.IstGleich(
                170.12,
                ausgabe,
                $"EingabeRoutineDouble({min}, {max}) hat nach \"{input}\" die gültige Eingabe 170.12 bekommen.",
                "Bei ungültiger Zahl oder Wert außerhalb von min/max: passende Meldung ausgeben und die Eingabe wiederholen.");

            konsole.MussZeileEnthalten(
                fehler,
                "Die Grenzwerte in der Meldung werden ohne extra Nachkommastellen ausgegeben (0 und 300, nicht 0.0).");
        }

        [TestMethod, Timeout(3000)]
        [TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        public void Test_ReelleZahlErfolg()
        {
            using KonsolenTest konsole = new KonsolenTest("170.12");

            double ausgabe = Aufgabe_2.EingabeRoutineDouble(0, 300);

            RueckgabePruefung.IstGleich(
                170.12,
                ausgabe,
                "EingabeRoutineDouble(0, 300) wurde mit der gültigen Eingabe 170.12 aufgerufen.",
                "Wandle die Eingabe in double um. Liegt der Wert zwischen min und max, gib ihn zurück.");

            konsole.DarfZeileNichtEnthalten(
                "Keine reelle Zahl! Versuchen Sie es erneut.",
                "Bei einer gültigen reellen Zahl im Bereich darf keine Fehlermeldung erscheinen.");
        }

        private static string BeschreibeEingabe(string input)
        {
            return string.IsNullOrEmpty(input) ? "(leer)" : input;
        }
    }
}
