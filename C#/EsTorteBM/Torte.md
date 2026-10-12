```mermaid
classDiagram

class Program{
    - List<CDolce> dolci
    - bool btorta
    - bool bcrostata
    - string nome
    - int punteggio
    - CTorta t
    - CCrostata t
    - CDolce d

    + Input()
    + AggTorta()
    + AggCrostata()
    + Print()
    + TortePrint()
    + CrostatePrint()
    + CercaCrostata(int id) CCrostata
    + Croccantezza()
    + CercaTorta(int id) CTorta
    + Sofficezza()
    + CercaDolce(int id) CDolce
    + Raffinazione()
    + Finale()
}

class CDolce{
    <<abstract>>
    - id : int
    + Id : int
    - string : nome
    - int : punteggio

    + Raffinare()
    + abstract Print() string 
}

class CTorta{

    + CTorta()
    + Sofficezza()
    + override Print() string
}

class CCrostata{

    + CCrostata()
    + Croccantezza() int
    + override Print() string
}

%%RELAZIONI

CDolce <|-- CTorta
CDolce <|-- CCrostata
Program <|-- CDolce


```mermaid