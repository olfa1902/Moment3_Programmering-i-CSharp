using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace Moment3
{
    class AvserialiseraKlass
    {
        // En avserialiseringsklass skapas samt en sträng-variabel innehållande filsökvägen till json-filen
        string jsonurl = @"poster.json";
        public void Avserialisera(out string Jsoninfo, out List<SkrivpostKlass> posterlista)
        {
            // En metod skapas som avserialiserar inläggs-listan i form av en json-fil vid sökvägen som specifieras i filen jsonurl 
            Jsoninfo = File.ReadAllText(jsonurl);
            var lista = JsonConvert.DeserializeObject<List<SkrivpostKlass>>(Jsoninfo) ?? new List<SkrivpostKlass>();
            posterlista = lista;
        }
    }
}
