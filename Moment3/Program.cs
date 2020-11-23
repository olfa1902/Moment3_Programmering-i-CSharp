using System;
using System.Collections.Generic;

namespace Moment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // string-variabler instanseras
            string namn;
            string postcontent;
            // Klass-variabler instanseras
            AvserialiseraKlass avserialisera = new AvserialiseraKlass();
            SkrivpostKlass skrivpost = new SkrivpostKlass();
            TabortpostKlass tabortpost = new TabortpostKlass();

            // While-loop som körs tills dess att programmet avslutas
            bool loopameny = true;
            while (loopameny)
            {
                // Standard-text för programmets början skrivs ut
                Console.WriteLine("Olivers Gästbok");
                Console.WriteLine("-----------------");
                Console.WriteLine("");
                Console.WriteLine("Lägg till inlägg: tryck på 1:an på ditt tangentbord");
                Console.WriteLine("Ta bort inlägg: tryck på 2:an på ditt tangentbord");
                Console.WriteLine("För att avsluta: tryck på bokstaven Q på ditt tangentbord");
                Console.WriteLine("");

                // Foreach-loop som loopar igenom den avserialiserade json-filen och skriver ut alla poster
                 avserialisera.Avserialisera(out string Jsoninfo, out List<SkrivpostKlass> posterlista);
                int x = 0;
                foreach(var post in posterlista)
                {
                    Console.WriteLine($"[{x}] {post.namn} - {post.post}");
                    x++;
                }
                Console.WriteLine("");
                // Input för att se vilken åtgärd användaren väljer
                string input = Console.ReadLine();

                // switch-sats med olika åtgärder beroende på användarens knapptryck
                switch (input)
                {
                    case "1":
                        do
                        {
                            // Ifall 1:an trycks ombes användaren att skriva namn samt inlägg för att sparas i variabler
                            Console.Clear();
                            Console.WriteLine("Vänligen skriv ditt namn (fält obligatoriskt):");
                            namn = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine("Vänligen skriv ditt inlägg (fält obligatoriskt):");
                            postcontent = Console.ReadLine();
                        }
                        // Ifall inputen inte är tom eller ogiltigt körs Skapapost-funktionen, konsolen rensas och meny-loopen bryts
                        while
                        (
                            string.IsNullOrWhiteSpace(namn) ||
                            string.IsNullOrWhiteSpace(postcontent)
                        );

                       skrivpost.Skapapost(namn, postcontent);

                        Console.Clear();
                        loopameny = true;
                        break;
                       
                    case "2":
                        // Ifall 2:an trycks så rensas konsolen, funktionen Tabortpost körs och meny-loopen bryts
                        Console.Clear();
                        tabortpost.Tabortpost();
                        loopameny = true;
                        break;

                    case "q":
                        // Ifall q-knapen trycks så rensas konsolen, en avslutande mening skrivs ut och meny-loopen bryts
                        Console.Clear();
                        Console.WriteLine("Programmet avslutas strax...");
                        loopameny = false;
                        break;

                    default:
                        // Ifall ingen av dessa alternativ trycks och väljs skrivs en uppmaning att kolla alternativen och meny-loopen bryts
                        Console.Clear();
                        Console.WriteLine("Vänligen följ instruktionerna och välj ett av alternativen på skärmen");
                        loopameny = true;
                        break;
                }
            }
        }
    }
}
