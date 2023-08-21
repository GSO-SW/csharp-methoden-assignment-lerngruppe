
Hallo,   
wir haben einen Auftrag von der Werner-von-Siemens-Schule in Köln bekommen eine Applikation zu erstellen, mit der die Noten von Lernenden eingetragen und anschließend in einer Tabelle ausgegeben werden können. Die Lehrkraft soll zunächst die Anzahl der Lernenden angeben und anschließend die Note von 1 bis 6 nacheinander eintragen.
   
Unser neuer Mitarbeiter Darius hat bereits mit der Bearbeitung des Auftrags begonnen. Nun hat er aber Schwierigkeiten bei der Umsetzung. Folgenden Code hat er bereits geschrieben: 

        // Deklarieren und Initialisieren einer Variablen zum Zählen der Durchläufe
        int counter = 0;

        // Titel des Programms
        Console.WriteLine("-----Notenliste-----");

        // Den Benutzer auffordern, die Anzahl der Schüler einzugeben
        Console.WriteLine("Bitte geben Sie die Anzahl der Lernenden ein:");


        // Die Eingabe des Benutzers als String
        string anzahl_lernende_str = Console.ReadLine();

        // Der String wird in eine Ganzzahl konvertiert
        int anzahl_schueler_int = Convert.ToInt32(anzahl_lernende_str);

        //Variablen für die Noten der Lernenden deklarieren
        string lernender_1;
        string lernender_2;
        string lernender_3;
        string lernender_4;
        string lernender_5;
        string lernender_6;
        string lernender_7;

        //...


        // Eine Schleife durchlaufen, um die Noten der Schüler einzugeben
        do
        {

            // Den Benutzer auffordern, die Note des ersten Schülers einzugeben
            Console.WriteLine("Bitte geben Sie die Note des ersten lernenden an:");




            // Den Zähler erhöhen
            counter++;
        } while (counter < anzahl_schueler_int);`

Das entsprechende Repository finden sie [hier](https://classroom.github.com/a/65f2U3Yo).
Viele Grüße 
Naser
