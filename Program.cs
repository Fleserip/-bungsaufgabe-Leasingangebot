using System.ComponentModel.Design;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"________________________________________________________________________________");
            Console.WriteLine(@"_/______\_____________/__|______________/__|____________________________________");
            Console.WriteLine(@"/$$$$$$__|____________$$_|______________$$_|____________________________________");
            Console.WriteLine(@"$$_|__$$_|/__|__/__|/_$$___|___/______\_$$______\__/______\_/__|__/__|_/_______|");
            Console.WriteLine(@"$$____$$_|$$_|__$$_|$$$$$$/___/$$$$$$__|$$$$$$$__|_$$$$$$__|$$_|__$$_|/$$$$$$$/_");
            Console.WriteLine(@"$$$$$$$$_|$$_|__$$_|__$$_|____$$_|__$$_|$$_|__$$_|_/____$$_|$$_|__$$_|$$______\_");
            Console.WriteLine(@"$$_|__$$_|$$_\__$$_|__$$_|/__|$$_\__$$_|$$_|__$$_|/$$$$$$$_|$$_\__$$_|_$$$$$$__|");
            Console.WriteLine(@"$$_|__$$_|$$____$$/___$$__$$/_$$____$$/_$$_|__$$_|$$____$$_|$$____$$/_/_____$$/_");
            Console.WriteLine(@"$$/___$$/__$$$$$$/_____$$$$/___$$$$$$/__$$/___$$/__$$$$$$$/__$$$$$$/__$$$$$$$/__");
            Console.WriteLine(@"/__\_____/__|__/_|/_|__/__|/__|_________________________________________________");
            Console.WriteLine(@"$$__\\__/$$_|__$/_$/___$$_|$$_|_________________________________________________");
            Console.WriteLine(@"$$$__\\/$$$_|/__|__/__|$$_|$$_|_/______\\_/______\______________________________");
            Console.WriteLine(@"$$$$__/$$$$_|$$_|__$$_|$$_|$$_|/$$$$$$__|/$$$$$$__|_____________________________");
            Console.WriteLine(@"$$_$$_$$/$$_|$$_|__$$_|$$_|$$_|$$____$$_|$$_|__$$/______________________________");
            Console.WriteLine(@"$$_|$$$/_$$_|$$_\__$$_|$$_|$$_|$$$$$$$$/_$$_|___________________________________");
            Console.WriteLine(@"$$_|_$/__$$_|$$____$$/_$$_|$$_|$$_______|$$_|___________________________________");
            Console.WriteLine(@"$$/______$$/__$$$$$$/__$$/_$$/__$$$$$$$/_$$/____________________________________");
            Console.WriteLine("\n");



            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool anzahlung = false;
            bool gueltigeA = false;
            string input;
            string antwortAnz;
            double kmLeistung = 0;
            double brtpreis = 0;
            double basisrate = 249;
            double leasingRate;
            double aufpreis;
            double rabatt;
            double gesamtLpreis;
            double Laufzeit = 24;


            Console.WriteLine("Autohaus Müller: Leasing Angebot");

            Console.Write("Möchten Sie eine Anzahlung von 1.500€ leisten? (Ja/Nein): ");

            //Eingaben-Überprüfung (Ja/Nein)
            while (gueltigeA == false)
            {
                antwortAnz = Console.ReadLine()!;

                if (antwortAnz == "ja" || antwortAnz == "Ja" || antwortAnz == "JA")
                {
                    anzahlung = true;
                    gueltigeA = true;
                }
                else if (antwortAnz == "nein" || antwortAnz == "Nein" || antwortAnz == "NEIN")
                {
                    anzahlung = false;
                    gueltigeA = true;
                }
                else
                {
                    Console.Write("Nur Ja/Nein möglich: ");
                }
            }

            //Eingaben-Überprüfung Kilometerzahl
            Console.Write("Bitte geben Sie die geplante jährliche Kilometerleistung in Zahlen ein: ");

            while (gueltigeA == true)
            {
                //(Nur ganze Zahlen zulässig)
                input = Console.ReadLine()!;
                if (double.TryParse(input, out kmLeistung) && kmLeistung % 1 == 0 && kmLeistung > 0)
                {
                    gueltigeA = false;
                }
                else
                {
                    gueltigeA = true;
                    Console.Write("Bitte nur positive ganze Zahlen eingeben: ");
                }
            }
            //Eingaben-Überprüfung  Bruttolistenpreis
            Console.Write("Nennen Sie den Bruttolistenpreis des Fahrzeugs in €: ");
            while (gueltigeA == false)
            {
                input = Console.ReadLine()!;
                if (double.TryParse(input, out brtpreis) && brtpreis >= 0)
                {
                    gueltigeA = true;
                }
                else
                {
                    Console.Write("Bitte geben Sie einen Positiven Zahlenwert ein: ");
                }
                //Rabatt-Verechnung
            }
            if (anzahlung == true && kmLeistung <= 10000)
            {
                rabatt = basisrate * 0.2;
            }
            else if (anzahlung == true && kmLeistung > 10000)
            {
                rabatt = basisrate * 0.1;
            }
            else
            {
                rabatt = basisrate * 0;
            }
            //Aufpreis-Verechnung
            if (kmLeistung > 10000 && kmLeistung < 20000)
            {
                aufpreis = 25.00;
            }
            else if (kmLeistung >= 20000)
            {
                aufpreis = 50.00;
            }
            else
            {
                aufpreis = 0;
            }
            //Berechnung der mtl. Leasingrate und GesamtLpreis
            leasingRate = basisrate + aufpreis - rabatt;
            gesamtLpreis = leasingRate * Laufzeit;

            //Ergebnis-Ausgabe
            Console.WriteLine("--- Leasingangebotsberechnung ---");
            Console.WriteLine($"Basisrate            :  {basisrate:f2}€ (für 24 Monate)");
            Console.WriteLine($"Aufpreis             : + {aufpreis:f2}€ (für {kmLeistung} km/Jahr)");
            Console.WriteLine($"Basisrate            : - {rabatt:f2}€ ({100 * rabatt / basisrate}% Rabatt)");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Leasingrate          :  {leasingRate:f2}€");
            Console.WriteLine($"Gesamtleasingpreis   : {gesamtLpreis:f2}€");

            //Versicherungspauschale

            Console.WriteLine("\nVersicherungsinformationen:");

            if (brtpreis <= 10000)
            {
                Console.WriteLine("Es tritt zusätlich eine jährliche Versicherungspauschale von 100€ bei");
            }
            else if (brtpreis <= 20000)
            {
                Console.WriteLine("Es tritt zusätzlich eine jährliche Versicherungspauschale von 200€ bei");
            }
            else
            {
                Console.WriteLine("Es tritt zusätlich eine jährliche Versicherungspauschale von 300€ bei");
            }
        }
    }
