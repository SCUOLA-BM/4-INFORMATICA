using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsCampionato2JsonBM
{
    internal interface IRepository<T>
    {
        IReadOnlyList<T> GetElenco();
        bool Aggiungi(T elemento); //false se elemento già presente
        bool Rimuovi(T elemento); //false se non esiste T nell'elenco
        void Carica();
        void Salva();


    }
}
