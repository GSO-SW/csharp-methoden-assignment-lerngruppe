using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Test_Task1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod, TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0, "Keine ganze Zahl!")]

        public void Test_GanzeZahl(string input, int ergebnis, string fehler)
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"{input}");
            Console.SetIn(textReader);

            // Act
            int ausgabe = Aufgabe_1.EingabeRoutineInt32();

            // Assert
            Assert.AreEqual(ergebnis, ausgabe);
            List<string> lines_list_check = new List<string> { fehler };
            AssertTest(writer, lines_list_check);

            Environment.SetEnvironmentVariable("IsTesting", null);
        }

        [TestMethod, TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        public void Test_GanzeZahlErfolg()
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"10");
            Console.SetIn(textReader);

            // Act
            int ausgabe = Aufgabe_1.EingabeRoutineInt32();

            // Assert
            Assert.AreEqual(10, ausgabe);


            Environment.SetEnvironmentVariable("IsTesting", null);
        }

        [TestMethod, TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]
        [DataRow("test", 0.0, "Keine reelle Zahl!")]

        public void Test_ReelleZahl(string input, double ergebnis, string fehler)
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"{input}");
            Console.SetIn(textReader);

            // Act
            double ausgabe = Aufgabe_1.EingabeRoutineDouble();

            // Assert
            Assert.AreEqual(ergebnis, ausgabe);
            List<string> lines_list_check = new List<string> { fehler };
            AssertTest(writer, lines_list_check);

            Environment.SetEnvironmentVariable("IsTesting", null);
        }

        [TestMethod, TestCategory("Task1")]
        [TestCategory("InOut")]
        [TestProperty("GSO-DevGroup", "Kander")]

        public void Test_ReelleZahlErfolg()
        {
            Environment.SetEnvironmentVariable("IsTesting", "true");

            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var textReader = new StringReader(@$"{10.23}");
            Console.SetIn(textReader);

            // Act
            double ausgabe = Aufgabe_1.EingabeRoutineDouble();

            // Assert
            Assert.AreEqual(10.23, ausgabe);
        }




        public static void AssertTest(StringWriter writer, List<string> lines_list_check)
        {

            // Assert

            var sb = writer.GetStringBuilder();
            var lines = sb.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.TrimEntries);

            List<string> lines_list = new List<string>();

            //Bedingung nötig da 'Enviroment.NewLine' in Git Actions nicht funktioniert.
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