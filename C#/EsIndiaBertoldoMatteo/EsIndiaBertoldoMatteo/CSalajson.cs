using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EsIndiaBertoldoMatteo
{
    internal class CSalajson
    {
        string FileName = "sala.json";
        public CSalajson() { }

        public void Salva(CSala s)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(s, options);
            File.WriteAllText(FileName, json);
        }

        public CSala Carica()
        {
            CSala sala = new CSala();
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                if (string.IsNullOrWhiteSpace(json)) return new CSala();
                sala = JsonSerializer.Deserialize<CSala>(json);
            }
            return sala;
        }
    }
}
