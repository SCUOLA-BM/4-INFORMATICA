using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMacchinari
{
    internal class Program
    {
        public static List<CMacchinario> macchinari;
        static void Main(string[] args)
        {
            Program p = new Program();
            macchinari = new List<CMacchinario>();
            Console.WriteLine("BENVENUTO NEL SOFTWARE GESTIONE MACCHINARI");
            p.Input();
            p.MacchParch();
            p.Macch();
            p.Assegna();
            p.Libera();
            p.Spec();
        }

        public void Input()
        {
            CGru gru;
            CRuspa ruspa;
            CBetoniera betoniera;
            try
            {
                CCantiere cantiere = new CCantiere("Caldogno");
                gru = new CGru("CD345LX", "MERCEDES", 2009, 67, true, 51, 50);
                macchinari.Add(gru);
                cantiere.Assegna(gru);
                gru = new CGru("CD383LX", "BYRDEL", 2011, 67, false, 51, 50);
                macchinari.Add(gru);
                gru = new CGru("AM519UC", "FERRARI", 1999, 67, false, 51, 50);
                macchinari.Add(gru);
                ruspa = new CRuspa("AB123CD", "CAT", 2013, 67, true, Benna._500);
                macchinari.Add(ruspa);
                cantiere.Assegna(ruspa);
                ruspa = new CRuspa("GH450LV", "ASTON MARTIN", 1987, 67, false, Benna._700);
                macchinari.Add(ruspa);
                ruspa = new CRuspa("HX809KH", "SINGAPOR", 2008, 67, true, Benna._1000);
                macchinari.Add(ruspa);
                cantiere.Assegna(ruspa);
                betoniera = new CBetoniera("AS876IL", "CADILAC", 2019, 67, true, 500, 200);
                macchinari.Add(betoniera);
                cantiere.Assegna(betoniera);
                betoniera = new CBetoniera("UM176ER", "WILLLIAMS", 2026, 67, false, 700, 345);
                macchinari.Add(betoniera);
                betoniera = new CBetoniera("RM676RT", "ALPINE", 2014, 67, true, 300, 211);
                macchinari.Add(betoniera);
                cantiere.Assegna(betoniera);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void MacchParch()
        {
            foreach (var m in macchinari)
            {
                if (m is CBetoniera) Console.WriteLine("-BETONIERA");
                else if (m is CGru) Console.WriteLine("-GRU");
                else Console.WriteLine("-RUSPA");
            }
        }

        public void Macch()
        {
            foreach (var m in macchinari) Console.WriteLine(m.Descrizione());
        }

        public void Assegna()
        {
            int id;
            do
            {
                Console.Write("INSERISCI ID DEL MACCHINARIO DA ASSEGNARE AL CANTIERE: ");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id >= macchinari.Count);
            if (macchinari[id].Stato) Console.WriteLine("MACCHINARIO GIA' ASSEGNATO");
            else
            {
                macchinari[id].Stato = true;
                Console.WriteLine("MACCHINARIO ASSEGNATO CORRETTAMANETE");
            }
        }

        public void Libera()
        {
            int id;
            do
            {
                Console.Write("INSERISCI ID DEL MACCHINARIO DA LIBERARE DAL CANTIERE: ");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id >= macchinari.Count);
            if (!macchinari[id - 1].Stato) Console.WriteLine("MACCHINARIO GIA' LIBERO");
            else
            {
                macchinari[id - 1].Stato = true;
                Console.WriteLine("MACCHINARIO LIBERATO CORRETTAMANETE");
            }
        }

        public void Spec()
        {
            int id;
            do
            {
                Console.Write("INSERISCI ID DEL MACCHINARIO PER AZIONE SPECIFICA: ");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id>=macchinari.Count);
            if (macchinari[id] is CBetoniera betoniera)
            {
                try
                {
                    Betoniera(betoniera);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }else if (macchinari[id] is CGru gru)
            {
                try
                {
                    Gru(gru);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
            else if (macchinari[id] is CRuspa ruspa)
            {
                Ruspa(ruspa);
            }
        }

        public void Betoniera(CBetoniera b)
        {
            int numint;
            do
            {
                Console.Write("INSERISCI QUANTITA' DA CARICARE: ");
            } while (!int.TryParse(Console.ReadLine(), out numint) || numint < 0);
            b.Carica(numint);
            do
            {
                Console.Write("INSERISCI QUANTITA' DA VERSARE: ");
            } while (!int.TryParse(Console.ReadLine(), out numint) || numint < 0);
            b.Versa(numint);
        }

        public void Gru(CGru g)
        {
            int numint = -1;
            do
            {
                if (numint == 1)
                {
                    g.Abbassa();
                    Console.WriteLine("ALTEZZA = "+g.Altezza);
                }
                else Console.Write("INSERIRE 1 PER ABBASSARE / 0 PER FERMARSI: ");
            } while (!int.TryParse(Console.ReadLine(), out numint) || numint != 0);
            do
            {
                if (numint == 1)
                {
                    g.Alza();
                    Console.WriteLine("ALTEZZA = " + g.Altezza);
                }
                else Console.Write("INSERIRE 1 PER ALZARE / 0 PER FERMARSI: ");
            } while (!int.TryParse(Console.ReadLine(), out numint) || numint != 0);
        }

        public void Ruspa(CRuspa r)
        {
            string str = "";
            do
            {
                Console.WriteLine("INSERISCI VALORE NUOVA BENNA(300/500/700/1000/1500/2000)");
            } while (!r.CambiaBenna(str));
        }
    }
}
