// IHR NAME
// IHRE KLASSE



using System.Xml.Linq;
/// <summary>
/// SAS statische Methode
/// Arbeitsauftrag 1 - Aufgabe 1
/// Hotel-Reservation
/// </summary>


Aufgabe_1.Aufgabe1();

public static class Aufgabe_1
{
    public static void Aufgabe1()
    {

        Console.WriteLine("Willkommen beim Hotelreservierungssystem!");


        //Ausgabe der Informationen
        Console.WriteLine("Bitte geben Sie Ihren Namen ein:");
        string name = EingabeRoutineString();

        Console.WriteLine("Bitte geben Sie Ihre E-Mail-Adresse ein:");
        string e_mail = EingabeRoutineString();

        Console.WriteLine("Bitte geben Sie Ihr Alter ein:");
        int alter = EingabeRoutineInt32();

        Console.WriteLine("Bitte geben Sie Ihre Körpergröße in cm ein:");
        double groesse = EingabeRoutineDouble();


        //Ausgabe der Informationen
        Console.WriteLine("Vielen Dank für Ihre Eingabe!");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"E-Mail-Adresse: {e_mail}");
        Console.WriteLine($"Alter: {alter} Jahre");
        Console.WriteLine($"Körpergröße: {groesse} cm");
    }

}
