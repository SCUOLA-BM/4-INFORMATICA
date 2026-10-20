using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionatoJsonBM
{
    internal class Program
    {
        static string fileName = "Partite.json";
        static void Main(string[] args)
        {
            List<CPartita> partite = new List<CPartita>();
            string scelta = "";
            do
            {
                CPartita partita = new CPartita(LeggiS("NOME SQUADRA CASA: "), LeggiS("NOME SQUADRA OPITE: "), LeggiN("GOAL SQUADRA CASA: ",0,20), LeggiN("GOAL SQUADRA OSPITE: ",0,20));
                partite.Add(partita);
                Console.WriteLine("Inserire 0 per terminare programma e salvare");
                scelta = Console.ReadLine();
            } while (scelta != "0");
            string jsonString = JsonSerializer.Serialize(partite);
            File.AppendAllText(fileName,jsonString+Environment.NewLine);
            Console.WriteLine(File.ReadAllText(fileName));
        }

        public static string LeggiS(string mess)
        {
            string str = "";

            do
            {
                Console.WriteLine(mess);
                str = Console.ReadLine();
            } while (str == "");
            return str;
        }

        public static int LeggiN(string mess, int min, int max)
        {
            int n = 0;
            do
            {
                Console.WriteLine(mess);
            } while (!int.TryParse(Console.ReadLine(), out n) || n<min || n>max);
            return n;
        }
    }
}
