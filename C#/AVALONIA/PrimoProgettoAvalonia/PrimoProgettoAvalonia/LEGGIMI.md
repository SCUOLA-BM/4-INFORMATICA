# Il tuo primo progetto Avalonia

Esempio didattico: scrivi il tuo nome, premi **Salutami**, leggi il saluto.
Se il campo è vuoto, l'app ti invita a compilarlo.

## 1. Apri il progetto già pronto

In Visual Studio scegli **File > Apri > Progetto/Soluzione** e seleziona
`PrimoProgettoAvalonia.sln` in questa cartella.
Attendi il ripristino NuGet, poi premi **F5** (debug) oppure **Ctrl+F5** (avvio).
Se richiesto, imposta PrimoProgettoAvalonia come progetto di avvio.

## 2. Come creare da zero un altro progetto

Apri PowerShell nella cartella dove vuoi salvare il nuovo progetto ed esegui
un comando alla volta. Usa un nome diverso per non confonderlo con quello pronto.

```powershell
dotnet new install Avalonia.Templates
dotnet new avalonia.app -n MiaApp -o MiaApp
cd MiaApp
dotnet new sln -n MiaApp --format sln
dotnet sln MiaApp.sln add MiaApp.csproj
dotnet build
dotnet run
```

Sulla tua macchina i template sono già installati: puoi saltare il primo comando.
Il template `avalonia.app` crea un'app desktop semplice in C#.
La soluzione `.sln` serve a raccogliere e aprire il progetto in Visual Studio.
I comandi sopra producono la finestra standard; per ottenere il nostro esempio
personalizza i due file MainWindow come spiegato sotto.

## 3. I file da conoscere

| File | A cosa serve |
| --- | --- |
| MainWindow.axaml | Descrive la finestra: testi, campo nome e pulsante. |
| MainWindow.axaml.cs | Contiene il codice C# eseguito al clic. |
| App.axaml | Imposta il tema dell'applicazione. |
| Program.cs | Avvia Avalonia e la finestra desktop. |
| PrimoProgettoAvalonia.csproj | Indica .NET e i pacchetti NuGet usati. |

## 4. Dal pulsante al codice C#

In `MainWindow.axaml`, lo StackPanel dispone gli elementi uno sotto l'altro.
Il TextBox riceve il nome; il TextBlock mostra il risultato.

```xml
<TextBox x:Name="NomeTextBox" PlaceholderText="Per esempio, Marco" />
<Button Content="Salutami" Click="Saluta_Click" />
<TextBlock x:Name="SalutoTextBlock" Text="Il tuo saluto apparirà qui." />
```

`x:Name` rende accessibile il controllo dal codice C#.
`Click="Saluta_Click"` collega il clic al metodo nel file `.axaml.cs`.
`InitializeComponent()` carica il layout XAML quando si crea la finestra.
Il metodo legge `NomeTextBox.Text`, rimuove gli spazi iniziali e finali e controlla
che il nome sia presente. Infine aggiorna `SalutoTextBlock.Text`.

Per iniziare usiamo un evento nel code-behind. Il pattern MVVM è un passo
successivo, utile per separare maggiormente logica e interfaccia.

## 5. Una prima modifica da provare

1. Cambia `Content="Salutami"` in `Content="Mostra saluto"`.
2. Nel C# cambia `Benvenuto in Avalonia.` in `Questa è la mia prima app!`.
3. Salva, ferma l'app se è aperta e premi F5.
4. Prova prima il campo vuoto, poi `Marco`, poi un nome con spazi ai bordi.

## Versioni e riferimento

Questo progetto è stato generato con Avalonia.Templates 12.1.4 e usa .NET 10.
Visual Studio Enterprise e l'SDK .NET 10 sono già presenti sulla macchina.
L'eventuale estensione Avalonia per Visual Studio aiuta con l'anteprima XAML;
non è necessaria per compilare ed eseguire questo esempio.

Guida ufficiale: https://docs.avaloniaui.net/docs/get-started/install-avalonia
