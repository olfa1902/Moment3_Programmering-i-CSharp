using System;
using System.Collections.Generic;

namespace Moment3
{
    class SkrivpostKlass
    {
        // Klass-variabler instanseras
        SerialiseraKlass serialisera = new SerialiseraKlass();
        AvserialiseraKlass avserialisera = new AvserialiseraKlass();
        // Strukturen på inlägg med ett namn och inlägg skapas här med två publika strängar
        public string namn 
        { 
            get; set; 
        }
        public string post
        {
            get; set;
        }

        public void Skapapost(string namn, string postcontent)
        {
            // Konsolen rensas vid anrop av metoden Skapapost och inläggslistan avserialiseras för utskrift
            Console.Clear();

            avserialisera.Avserialisera(out string jsonurl, out List<SkrivpostKlass> posterlista);

            // Genom användarinput på namn och inlägg som skickas med läggs detta till i inläggslistan posterlista för att sedan serialiseras och sparas till json-filen
            posterlista.Add(new SkrivpostKlass()
            {
                namn = namn,
                post = postcontent,
            });

            serialisera.Serialisera(jsonurl, posterlista);
        }
    }
}
