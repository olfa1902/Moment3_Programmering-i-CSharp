using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Moment3
{
    class SerialiseraKlass
    {
        // En serialiseringsklass skapas samt en sträng-variabel innehållande filsökvägen till json-filen
        string jsonurl = @"poster.json";
        public void Serialisera(string Jsoninfo, List<SkrivpostKlass> posterlista)
        {
            // En metod skapas som serialiserar inläggs-listan i form av json-filen vid sökvägen som specifieras i filen jsonurl 
            Jsoninfo = JsonConvert.SerializeObject(posterlista, Formatting.Indented);
            File.WriteAllText(jsonurl, Jsoninfo);
        }
    }
}
