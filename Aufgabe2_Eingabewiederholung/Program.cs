// IHR NAME
// IHRE KLASSE



using System.Xml.Linq;
/// <summary>
/// SAS statische Methode
/// Arbeitsauftrag 1 - Aufgabe 2
/// Hotel-Reservation
/// </summary>


Aufgabe_2.Aufgabe2();

public static class Aufgabe_2
{
    public static void Aufgabe2()
    {

        Console.WriteLine("Willkommen beim Hotelreservierungssystem!");


        //Eingabe der Informationen
        Console.WriteLine("Bitte geben Sie Ihren Namen ein:");
        string name = EingabeRoutineString("&","!","@","§");

        Console.WriteLine("Bitte geben Sie Ihre E-Mail-Adresse ein:");
        string e_mail = EingabeRoutineString(" ","#");

        Console.WriteLine("Bitte geben Sie Ihr Alter ein:");
        int alter = EingabeRoutineInt32(0,120);

        Console.WriteLine("Bitte geben Sie Ihre Körpergröße in cm ein:");
        double groesse = EingabeRoutineDouble(0, 300);



        //Ausgabe der Informationen
        Console.WriteLine("Vielen Dank für Ihre Eingabe!");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"E-Mail-Adresse: {e_mail}");
        Console.WriteLine($"Alter: {alter} Jahre");
        Console.WriteLine($"Körpergröße: {groesse} cm");


    }

}
