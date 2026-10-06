```mermaid
classDiagram

    %% CLASSI PRINCIPALI
    
    class Program{
        + Cantieri : List~CCantiere~

        + Input()
        + MacchParch() 
        + Macch()
        + Assegna()
        + Libera()
        + Spec()
        + Betoniera(CBetoniera)
        + Gru(CGru)
        + Ruspa(CRuspa)
    }

    class CCantiere{
        + Macchinari : List~CMacchinaro~
        + Name : string

        + Assegna(CMacchinario)
        + Libera(id) bool
        + PrintMacchinari() string
    }

    class CMacchinario{
        <<abstarct>>
        + Id : int
        + Targa : string
        + Modello : string
        + Anno : int
        + Volume : int
        + Stato : bool 
        %%disponibile o assegnato

        + Descrizione() string

    }

    class CRuspa {
        + Benna : enum~Benna~
        
        + CambiaBenna(string) 
        + Descrizione() string
    }

    class Benna{
        <<enumeration>>
        300
        500
        700
        1000
        1500
        2000
    }

    class CGru {
        + Portata : int
        + Altezza : int

        + Alza()
        + Abbassa()
        + Descrizione() string
    }

    class CBetoniera {
        + Capacità : int
        
        + Carica(int) string
        + Versa(int) string
        + Descrizione() string
    }

    class IAssegnabile{
        <<interface>>
        void Assegna()
        bool Libera()
    }

    

    %% INTERFACCIA
    CCantiere ..|> IAssegnabile

    %%ENUMERAZIONI
    CRuspa --> Benna

    %%ASSOCIAZIONE
    CCantiere "1" o-- "N" CMacchinario

    %% CLASSE ASTRATTA
    CMacchinario <|-- CRuspa
    CMacchinario <|-- CGru
    CMacchinario <|-- CBetoniera

    %% Program usa le classi ma non le possiede
    Program --> CCantiere
```
