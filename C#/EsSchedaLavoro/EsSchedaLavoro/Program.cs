using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsSchedaLavoro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ISwitchable> lista = new List<ISwitchable>();
            CDispositivoSmart lamp = new CLampadina("BELLA", "SOGGIORNO", 23);
            CDispositivoSmart term = new CTermostato("BRUTTO", "BAGNO", 43);
            CAllarme all = new CAllarme();
            lista.Add(all);
            lista.Add(lamp);
            lista.Add(term);
            foreach(var a in lista)
            {
                a.Accendi();
                Console.WriteLine(a.MostraDettagli());
            }
        }
    }
}
