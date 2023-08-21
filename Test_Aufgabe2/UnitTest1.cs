using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Test_Task2
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod, TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("Avina$h", "@", "$", "Der Input beinhaltet einen ungültigen Charakter: $. Versuchen Sie es erneut.")]
        [DataRow("Avin@sh", "@", "$", "Der Input beinhaltet einen ungültigen Charakter: @. Versuchen Sie es erneut.")]
        [DataRow("", "@", "$", "Keine Eingabe registriert. Versuchen Sie es erneut.")]

        public void Test_String(string input, string p1, string p2, string fehlermeldung)
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"{input}

Avinash");
            Console.SetIn(textReader);

            // Act
            string ausgabe = Aufgabe_2.EingabeRoutineString(p1, p2);

            // Assert
            Assert.AreEqual("Avinash", ausgabe);
            List<string> lines_list_check = new List<string> { fehlermeldung };
            AssertTest(writer, lines_list_check);

            Environment.SetEnvironmentVariable("IsTesting", null);
        }



        [TestMethod, TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0, 150, "Keine ganze Zahl! Versuchen Sie es erneut.")]
        [DataRow("-10", 0, 150, "Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.")]
        [DataRow("121", 0, 120, "Eingabe größer als Grenzwert: 120. Versuchen Sie es erneut.")]


        public void Test_GanzeZahl(string input, int min, int max, string fehler)
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"{input}

17");
            Console.SetIn(textReader);

            // Act
            int ausgabe = Aufgabe_2.EingabeRoutineInt32(min, max);

            // Assert
            Assert.AreEqual(17, ausgabe);
            List<string> lines_list_check = new List<string> { fehler };
            AssertTest(writer, lines_list_check);

            Environment.SetEnvironmentVariable("IsTesting", null);
        }


        [TestMethod, TestCategory("Task2")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0.0, 300.0, "Keine reelle Zahl! Versuchen Sie es erneut.")]
        [DataRow("-10.23", 0.0, 300.0, "Eingabe kleiner als Grenzwert: 0. Versuchen Sie es erneut.")]
        [DataRow("301.1", 0.0, 300.0, "Eingabe größer als Grenzwert: 300. Versuchen Sie es erneut.")]


        public void Test_ReelleZahl(string input, double min, double max, string fehler)
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"{input}

{170.12}");
            Console.SetIn(textReader);

            // Act
            double ausgabe = Aufgabe_2.EingabeRoutineDouble(min, max);

            // Assert
            Assert.AreEqual(170.12, ausgabe);
            List<string> lines_list_check = new List<string> { fehler };
            AssertTest(writer, lines_list_check);

            Environment.SetEnvironmentVariable("IsTesting", null);
        }




        public static void AssertTest(StringWriter writer, List<string> lines_list_check)
        {

            // Assert

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.TrimEntries);

            List<string> lines_list = new List<string>();

            //Bedingung n�tig da 'Enviroment.NewLine' in Git Actions nicht funktioniert.
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    lines_list.Add(lines[i]);
                    Debug.WriteLine($"{lines[i]}");
                }
            }





            lines_list = lines_list.Intersect(lines_list_check).ToList();



            for (int i = 0; i < lines_list_check.Count; i++)
            {

                try
                {
                    if (lines_list[i] != lines_list_check[i]) Trace.WriteLine($"\nFehler: '{lines_list_check[i]}' nicht gefunden");
                    Assert.AreEqual(lines_list[i], lines_list_check[i]);
                }
                catch
                {
                    Trace.WriteLine($"\n\n");
                    Trace.WriteLine($"Fehler: Zeile fehlt");
                    Trace.WriteLine($"---------------------");
                    Trace.WriteLine($"{lines_list_check[i]}");
                    Trace.WriteLine($"---------------------");
                    Assert.Fail(); ;

                }

            }
        }
    }
}