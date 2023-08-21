// IHR NAME
// IHRE KLASSE



using System.Xml.Linq;
/// <summary>
/// SAS statische Methode
/// Arbeitsauftrag 1 - Aufgabe 3
/// Hotel-Reservation
/// </summary>


Aufgabe_3.Aufgabe3();

public static class Aufgabe_3
{
    public static void Aufgabe3()
    {

        Console.WriteLine("Willkommen beim Hotelreservierungssystem!");


        //Eingabe der Informationen
        Console.WriteLine("Bitte geben Sie Ihren Namen ein:");
        string name = EingabeRoutine("&", "!", "@", "§");

        Console.WriteLine("Bitte geben Sie Ihre E-Mail-Adresse ein:");
        string e_mail = EingabeRoutine(" ", "#");

        Console.WriteLine("Bitte geben Sie Ihr Alter ein:");
        int alter = EingabeRoutine(0, 120);

        Console.WriteLine("Bitte geben Sie Ihre Körpergröße in cm ein:");
        double groesse = EingabeRoutine(0.0, 300.0);



        //Ausgabe der Informationen
        Console.WriteLine("Vielen Dank für Ihre Eingabe!");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"E-Mail-Adresse: {e_mail}");
        Console.WriteLine($"Alter: {alter} Jahre");
        Console.WriteLine($"Körpergröße: {groesse} cm");


    }
}
