using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceBus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioSaludo" in both code and config file together.
    public class ServicioSaludo : IServicioSaludo
    {
        private Dictionary<String, string> Saludos = new Dictionary<string, string>()
       {
           {"en", "Good Morning" },
           {"es", "Buenos dias" },
           {"fr", "Bon Jour" },
           {"de", "Guten Morgen" }
       };

        public string GetSaludo(string idioma)
        {
            if (Saludos.ContainsKey(idioma))
                return Saludos[idioma];

            return Saludos["en"];
        }
    }
}
