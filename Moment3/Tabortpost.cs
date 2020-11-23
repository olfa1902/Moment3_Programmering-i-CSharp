using System;
using System.Collections.Generic;

namespace Moment3
{
    class TabortpostKlass
    {
        // Klass-variabler instanseras
        SerialiseraKlass serialisera = new SerialiseraKlass();
        AvserialiseraKlass avserialisera = new AvserialiseraKlass();
        public void Tabortpost()
        {
            // En while-loop skapas som körs tills dess att borttagningen lyckats
            bool lyckadborttagning = false;
            while(!lyckadborttagning)
            {
                
                Console.WriteLine("Vänligen se inläggen nedan:");
                Console.WriteLine("");

                // Foreach-loop som avserialiserar och skriver ut varje inlägg i inläggslistan
                avserialisera.Avserialisera(out string jsoninfo, out List<SkrivpostKlass> posterlista);
                int x = 0;
                foreach (var post in posterlista)
                {
                    Console.WriteLine($"[{x}]{post.namn} - {post.post}");
                    x++;
                }
                // Användaren manas välja inlägg och inputen sparas i en variabel
                Console.WriteLine("");
                Console.WriteLine("Vänligen ange det nummer som överensstämmer med inlägget du vill ta bort");
                string nummerinput = Console.ReadLine();

                try
                {
                    // Ifall inga felmeddelanden känns vid konverteras inputen till ett tal som jämförs med listan och tar bort posten som känns vid,
                    // för att sedan rensa skärmen och bryta loopen
                    int konverteradnummerinput = Convert.ToInt32(nummerinput);

                    posterlista.RemoveAt(konverteradnummerinput);
                    serialisera.Serialisera(jsoninfo, posterlista);
                    Console.Clear();
                    lyckadborttagning = true;
                }
                // Ifall ett formateringsfel uppstår så skrivs detta ut för användaren och loopen fortsätter
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    Console.WriteLine("Något gick fel, vänligen se felmeddelandet och försök igen");
                    lyckadborttagning = false;
                }
                // Ifall ett annat fel uppstår så skrivs detta ut för användaren och loopen fortsätter
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Vänligen se feedback och försök igen");
                    lyckadborttagning = false;
                }
            }
            
        }
    }
}
