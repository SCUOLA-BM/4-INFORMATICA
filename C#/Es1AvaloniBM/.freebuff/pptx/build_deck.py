"""Genera Laboratorio-XAML.pptx a partire dai contenuti dell'esercizio."""

import os
import sys

from pptx.enum.text import MSO_ANCHOR, PP_ALIGN
from pptx.util import Inches, Pt

from deck_content import SECTIONS
from deck_lib import (
    ACCENT, AMBER, BLUE, BODY, CODE, LINE, MINT, MONO, MUTED,
    SURFACE, SURFACE2, SW, TEXT, WARNINGS, arrow, blank, bullets, chrome,
    code_panel, footer, hline, new_deck, note_slide, rect, shell_panel, text,
    text_width,
)

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.abspath(os.path.join(HERE, "..", ".."))
TOTAL = 40
OUT = os.path.join(ROOT, "Laboratorio-XAML.pptx")
COVER = os.path.join(HERE, "app_cover.png")

TAG_TOTAL = sum(len(s["tags"]) for s in SECTIONS)


# --------------------------------------------------------------------------
# 01 · Copertina
# --------------------------------------------------------------------------
def slide_cover(prs):
    s = blank(prs)
    rect(s, 0, 0, SW, 0.07, fill=ACCENT)
    rect(s, 7.0, 0.07, 6.33, 7.43, fill="111018")
    rect(s, 0.0, 6.62, 6.9, 0.88, fill="10131A")

    text(s, 0.75, 0.92, 6.0, 0.26, "ESERCIZIO DIDATTICO  ·  AVALONIA UI 12",
         10.5, ACCENT, bold=True, spc=150)
    text(s, 0.75, 1.26, 6.5, 1.0, "Laboratorio XAML", 48, TEXT, bold=True)
    rect(s, 0.78, 2.40, 1.15, 0.045, fill=ACCENT)
    text(s, 0.75, 2.64, 6.0, 1.05,
         "Un unico esercizio, tanti tag: per ognuno una spiegazione, "
         "un esempio di codice e il posto in cui vive nell'app.",
         17, BODY, line_spacing=1.14)

    chips = [("Avalonia 12", ACCENT), ("MVVM", MINT), ("30 tag", AMBER), ("4 aree", BLUE)]
    x = 0.75
    for label, color in chips:
        w = 0.34 + text_width(label, 10.4, True) / 72 + 0.28
        rect(s, x, 3.84, w, 0.34, fill="1B1F2A", line="2F3646", radius=0.17)
        text(s, x, 3.905, w, 0.22, label, 10.4, color, bold=True, align=PP_ALIGN.CENTER)
        x += w + 0.14

    hline(s, 0.75, 4.58, 6.05, color="2A3040")
    stats = [("34", "schede nell'app", ACCENT), ("30", "tag spiegati", MINT),
             ("69", "tipi di elemento XAML", AMBER)]
    x = 0.75
    for number, label, color in stats:
        text(s, x, 4.78, 1.55, 0.44, number, 25, color, bold=True)
        text(s, x, 5.22, 1.7, 0.24, label, 9.2, MUTED)
        x += 2.02

    rect(s, 0.75, 5.86, 4.55, 0.36, fill=SURFACE2, line=LINE, radius=0.07)
    text(s, 0.92, 5.945, 4.3, 0.22, "dotnet run --project Es1AvaloniBM",
         9.4, MINT, font=MONO)
    text(s, 0.77, 6.75, 6.1, 0.24, "Corso Avalonia UI · esercizio unico",
         8.6, MUTED)

    # Anteprima reale dell'app
    if os.path.exists(COVER):
        rect(s, 7.16, 1.31, 5.60, 3.05, fill=SURFACE, line="303748", radius=0.10)
        s.shapes.add_picture(COVER, Inches(7.28), Inches(1.43),
                             width=Inches(5.36), height=Inches(2.823))
        text(s, 7.16, 4.46, 5.6, 0.24,
             "La finestra dell'esercizio, scheda Layout", 9.2, MUTED)
        text(s, 7.16, 4.76, 5.6, 0.5,
             "Un solo file XAML per quattro schede: layout, controlli, "
             "dati e stili.", 9.2, MUTED, line_spacing=1.1)

        legend = [("Layout", ACCENT), ("Controlli", MINT),
                  ("Dati e binding", AMBER), ("Stili e grafica", BLUE)]
        for i, (name, color) in enumerate(legend):
            lx = 7.16 + (i % 2) * 2.80
            ly = 5.34 + (i // 2) * 0.36
            rect(s, lx, ly + 0.09, 0.10, 0.10, fill=color, radius=0.05)
            text(s, lx + 0.21, ly, 2.45, 0.24, name, 10, BODY)
        hline(s, 7.16, 6.12, 5.55, color="252C3A")
        text(s, 7.16, 6.26, 5.55, 0.3,
             "Una sola finestra: 34 schede, 30 tag, 4 aree.", 9.4, MUTED)

    text(s, 11.9, 7.16, 0.8, 0.22, "01", 8.4, MUTED, align=PP_ALIGN.RIGHT)


# --------------------------------------------------------------------------
# 02 · Mappa
# --------------------------------------------------------------------------
def slide_map(prs):
    s = blank(prs)
    chrome(s, "Mappa dell'esercizio", "Quattro aree, un solo progetto",
           "Ogni scheda dell'app diventa una sezione: prima la spiegazione, "
           "poi il codice, infine l'esempio vivo.", ACCENT, 2, TOTAL)

    samples = [
        ["DockPanel", "Grid", "Canvas", "UniformGrid"],
        ["TextBox", "Button", "ComboBox", "ListBox"],
        ["DataTemplate", "DataGrid", "ItemsControl", "TreeView"],
        ["Resources", "Styles", "Shapes", "Image"],
    ]
    for i, section in enumerate(SECTIONS):
        x = 0.65 + i * 3.15
        rect(s, x, 1.95, 2.95, 3.52, fill=SURFACE, line=LINE, radius=0.12)
        rect(s, x, 1.95, 2.95, 0.05, fill=section["color"])
        text(s, x + 0.28, 2.18, 2.4, 0.34, section["num"], 18,
             section["color"], bold=True)
        text(s, x + 0.28, 2.56, 2.45, 0.36, section["name"], 18.5, TEXT, bold=True)
        text(s, x + 0.28, 2.99, 2.45, 0.24,
             f"{len(section['tags'])} tag  ·  scheda {int(section['num'])}", 9.2, MUTED)

        y = 3.38
        for name in samples[i]:
            text(s, x + 0.28, y, 2.45, 0.22, name, 9.8, BODY)
            y += 0.245
        text(s, x + 0.28, 4.62, 2.45, 0.22, "→  nei dettagli", 9.0,
             section["color"], bold=True)

    rect(s, 0.65, 5.72, 12.4, 0.98, fill=SURFACE2, line=LINE, radius=0.10)
    text(s, 0.95, 5.98, 1.3, 0.24, "MVVM", 9.6, ACCENT, bold=True, spc=120)
    text(s, 2.05, 5.88, 7.6, 0.3,
         "Window  →  DataContext  →  ViewModel  →  Model", 14, TEXT, bold=True)
    text(s, 8.98, 5.94, 3.85, 0.24,
         "x:DataType abilita i compiled binding", 9.0, MUTED)

    text(s, 0.7, 6.82, 11.9, 0.24,
         "30 slide-tag  ·  4 introduzioni di sezione  ·  2 slide sul flusso MVVM",
         9.4, MUTED)
    footer(s, 2, TOTAL)


# --------------------------------------------------------------------------
# 03 · MVVM: chi fa cosa
# --------------------------------------------------------------------------
def slide_mvvm(prs):
    s = blank(prs)
    chrome(s, "Il ponte tra interfaccia e dati", "MVVM: chi fa cosa",
           "Tre strati con una regola sola: la View conosce il ViewModel, "
           "il ViewModel non conosce la View.", AMBER, 3, TOTAL)

    boxes = [
        ("VIEW", "MainWindow.axaml", "XAML", ACCENT, [
            '{Binding Nome, Mode=TwoWay}',
            'x:DataType="vm:MainWindowViewModel"',
            "DataContext = new MainWindowViewModel()",
        ], "Dichiara la UI e si collega ai dati."),
        ("VIEWMODEL", "MainWindowViewModel", "C#", MINT, [
            "[ObservableProperty] private string _nome",
            "ObservableCollection<Utente> Persone",
            "[RelayCommand] private void Aggiungi()",
        ], "Espone dati notificanti e comandi."),
        ("MODEL", "Utente", "C#", AMBER, [
            "public string Nome { get; set; }",
            "public string Email { get; set; }",
            "public int Eta { get; set; }",
        ], "Dati puri, nessun riferimento alla UI."),
    ]

    for i, (tag, name, lang, color, lines, caption) in enumerate(boxes):
        x = 0.7 + i * 4.25
        rect(s, x, 1.95, 3.62, 3.38, fill=SURFACE, line=LINE, radius=0.12)
        rect(s, x, 1.95, 3.62, 0.05, fill=color)
        text(s, x + 0.27, 2.16, 3.0, 0.22, tag, 8.8, color, bold=True, spc=130)
        text(s, x + 0.27, 2.44, 3.1, 0.28, name, 13.6, TEXT, bold=True, font=MONO)
        text(s, x + 0.27, 2.76, 3.0, 0.2, lang, 8.4, MUTED, font=MONO)
        hline(s, x + 0.27, 3.10, 3.08, color="262D3B")
        y = 3.27
        for line in lines:
            text(s, x + 0.27, y, 3.12, 0.42, line, 8.9, CODE, font=MONO,
                 line_spacing=1.05)
            y += 0.56
        text(s, x + 0.27, 4.90, 3.08, 0.28, caption, 8.9, MUTED)

        if i < 2:
            arrow(s, x + 3.71, 3.42, 0.44, 0.30)
            text(s, x + 3.58, 3.80, 0.72, 0.2, "binding", 7.4, MUTED,
                 align=PP_ALIGN.CENTER)

    rect(s, 0.7, 5.62, 12.1, 0.78, fill=SURFACE2, line=LINE, radius=0.10)
    rect(s, 0.7, 5.62, 0.06, 0.78, fill=AMBER)
    text(s, 0.98, 5.82, 11.5, 0.42,
         "Regola pratica: la View chiede, il ViewModel espone, il Model conserva.",
         12.2, TEXT)
    text(s, 0.7, 6.55, 11.9, 0.24,
         "Nel progetto: DataContext assegnato nel costruttore di MainWindow; "
         "x:CompileBindings controlla i percorsi già in compilazione.", 9.2, MUTED)
    footer(s, 3, TOTAL)


# --------------------------------------------------------------------------
# 04 · Binding e comandi
# --------------------------------------------------------------------------
def slide_binding(prs):
    s = blank(prs)
    chrome(s, "Dal XAML al C#", "Binding e comandi in pratica",
           "Le stesse tre operazioni delle slide: mostrare un valore, "
           "eseguire un comando, osservare una collezione.", AMBER, 4, TOTAL)

    cs = """
public partial class MainWindowViewModel
    : ObservableObject
{
    [ObservableProperty]
    private string _nome = "Giulia";

    public ObservableCollection<Utente> Persone { get; }
        = [ ... ];

    [RelayCommand]
    private void Aggiungi()
        => Persone.Add(new Utente { Nome = Nome });
}"""
    xaml = """
<Window x:DataType="vm:MainWindowViewModel"
        x:CompileBindings="True">

  <TextBox Text="{Binding Nome, Mode=TwoWay}"/>
  <Button Command="{Binding AggiungiCommand}"/>
  <ListBox ItemsSource="{Binding Persone}"/>

</Window>"""

    code_panel(s, 0.7, 1.94, 5.9, 3.62, cs, lang="cs", accent=AMBER,
               label="C#  ·  VIEWMODEL", max_size=11.2)
    code_panel(s, 6.73, 1.94, 5.9, 3.62, xaml, lang="xaml", accent=ACCENT,
               label="XAML  ·  VIEW", max_size=12.4)

    bullets(s, 0.7, 5.72, 5.85, 0.98, [
        "**DataContext** assegnato nel costruttore della Window",
        "**[ObservableProperty]** genera la proprietà che notifica",
        "**Aggiungi → AggiungiCommand**: convenzione dei nomi",
    ], size=9.6, gap=4, bullet_color=AMBER)
    bullets(s, 6.73, 5.72, 5.85, 0.98, [
        "**TwoWay** scrive nel ViewModel a ogni carattere",
        "**Command** esegue il metodo, senza code-behind",
        "**ItemsSource** osserva la ObservableCollection",
    ], size=9.6, gap=4, bullet_color=ACCENT)

    text(s, 0.7, 6.78, 11.9, 0.24,
         "Con x:CompileBindings gli errori di binding si vedono in build, "
         "non a finestra aperta.", 9.2, MUTED)
    footer(s, 4, TOTAL)


# --------------------------------------------------------------------------
# 05, 14, 26, 32 · Divider di sezione
# --------------------------------------------------------------------------
def slide_divider(prs, section, idx, page):
    s = blank(prs)
    color = section["color"]
    rect(s, 0, 0, SW, 0.07, fill=color)
    rect(s, 8.55, 0.07, 4.78, 7.43, fill="111018")

    text(s, 0.78, 0.72, 6.4, 0.24, f"SEZIONE {section['num']}", 10, color,
         bold=True, spc=170)
    text(s, 0.72, 1.15, 3.2, 1.7, section["num"], 96, "1B2232", bold=True)
    text(s, 0.75, 2.52, 7.2, 0.85, section["name"], 46, TEXT, bold=True)
    text(s, 0.75, 3.44, 6.6, 1.0, section["desc"], 14.5, BODY, line_spacing=1.18)
    text(s, 0.75, 4.58, 6.6, 0.3,
         f"{len(section['tags'])} tag  ·  scheda {int(section['num'])} dell'app",
         10, color, bold=True)
    text(s, 0.75, 4.98, 6.5, 0.78, section["intro"], 10.8, MUTED, line_spacing=1.15)

    rect(s, 0.75, 5.98, 5.9, 0.02, fill="2A3040")

    # Elenco dei tag della sezione
    rect(s, 7.55, 1.18, 5.0, 5.02, fill=SURFACE, line=LINE, radius=0.12)
    text(s, 7.83, 1.42, 4.4, 0.24, "IN QUESTA SEZIONE", 8.8, color,
         bold=True, spc=140)
    y = 1.82
    for n, tag in enumerate(section["tags"], start=1):
        text(s, 7.83, y, 0.35, 0.22, f"{n:02d}", 8.4, color, bold=True, font=MONO)
        text(s, 8.22, y - 0.015, 3.95, 0.26, tag["title"], 10.4, BODY)
        hline(s, 7.83, y + 0.245, 4.4, color="232A37")
        y += 0.335

    text(s, 7.83, 5.86, 4.4, 0.24, f"→  apri la scheda “{section['tab']}”",
         9.2, color, bold=True)
    text(s, 11.9, 7.16, 0.8, 0.22, f"{page:02d}", 8.4, MUTED,
         align=PP_ALIGN.RIGHT)


# --------------------------------------------------------------------------
# Slide dei singoli tag
# --------------------------------------------------------------------------
def slide_tag(prs, section, tag, idx, page):
    s = blank(prs)
    color = section["color"]
    chrome(
        s,
        f"{section['num']} · {section['name']}   ·   TAG {idx:02d} / {TAG_TOTAL}",
        tag["title"], tag["subtitle"], color, page, TOTAL,
    )

    # Spiegazione
    rect(s, 0.7, 1.95, 5.05, 3.55, fill=SURFACE, line=LINE, radius=0.12)
    rect(s, 1.00, 2.20, 0.055, 0.20, fill=color, radius=0.027)
    text(s, 1.14, 2.17, 4.2, 0.24, "A COSA SERVE", 8.6, color, bold=True, spc=130)
    bullets(s, 1.00, 2.58, 4.47, 2.72, tag["bullets"], size=11.8,
            bullet_color=color, gap=7)

    # Codice
    code_panel(s, 5.95, 1.95, 6.68, 3.55, tag["code"], lang="xaml",
               accent=color, max_size=12.4)

    # Nota e rimando alla demo
    rect(s, 0.7, 5.72, 11.93, 0.98, fill=SURFACE2, line=LINE, radius=0.10)
    rect(s, 0.7, 5.72, 0.055, 0.98, fill=color)
    text(s, 0.98, 5.91, 1.9, 0.2, "NELL'ESERCIZIO", 8.2, color, bold=True, spc=120)
    text(s, 0.98, 6.14, 8.9, 0.42, tag["note"], 9.8, BODY, line_spacing=1.1)
    text(s, 10.0, 5.95, 2.35, 0.22,
         f"Demo nella scheda “{section['tab']}”", 8.6, MUTED,
         align=PP_ALIGN.RIGHT)
    text(s, 10.0, 6.18, 2.35, 0.22, "dell'app in esecuzione", 8.6, MUTED,
         align=PP_ALIGN.RIGHT)
    footer(s, page, TOTAL)

    notes = [tag["subtitle"], ""]
    notes += ["• " + b.replace("**", "") for b in tag["bullets"]]
    notes += ["", "Nell'esercizio: " + tag["note"]]
    note_slide(s, "\n".join(notes))


# --------------------------------------------------------------------------
# 39 · Avvio e verifica
# --------------------------------------------------------------------------
def slide_run(prs):
    s = blank(prs)
    chrome(s, "Provare l'esercizio", "Compila, avvia, guarda",
           "Il progetto è pronto: si apre in Visual Studio o da terminale, "
           "senza configurazione aggiuntiva.", MINT, 39, TOTAL)

    shell_panel(s, 0.7, 1.95, 6.55, 3.15, [
        "$ dotnet build Es1AvaloniBM/Es1AvaloniBM.csproj",
        "  Build succeeded.",
        "  0 Warning(s)",
        "  0 Error(s)",
        "",
        "$ dotnet run --project Es1AvaloniBM",
        "  La finestra si apre su 1280 × 880",
    ])

    rect(s, 7.55, 1.95, 5.08, 3.15, fill=SURFACE, line=LINE, radius=0.12)
    rect(s, 7.55, 1.95, 0.05, 3.15, fill=MINT)
    text(s, 7.86, 2.17, 4.4, 0.24, "COSA CONTROLLARE", 8.6, MINT,
         bold=True, spc=130)
    bullets(s, 7.86, 2.55, 4.45, 2.35, [
        "**F5** in Visual Studio avvia il progetto",
        "Il tema del **DataGrid** è incluso in App.axaml",
        "**DataGrid** è in sola manutenzione: TableView è l'alternativa",
        "I **binding compilati** segnalano gli errori in build",
    ], size=10.2, gap=6, bullet_color=MINT)

    rect(s, 0.7, 5.42, 11.93, 1.16, fill=SURFACE2, line=LINE, radius=0.10)
    text(s, 0.98, 5.60, 5.0, 0.24, "STACK DEL PROGETTO", 8.4, MUTED,
         bold=True, spc=120)
    text(s, 0.98, 5.88, 11.4, 0.26,
         ".NET 10   ·   Avalonia 12.1.2   ·   CommunityToolkit.Mvvm 8.4.2   ·   "
         "Avalonia.Controls.DataGrid 12.1.2", 10.2, CODE, font=MONO)
    text(s, 0.98, 6.22, 11.4, 0.24,
         "Build verificata: 0 errori, 0 avvisi. L'app si avvia e mostra la finestra.",
         9.2, MINT)

    footer(s, 39, TOTAL)


# --------------------------------------------------------------------------
# 40 · Indice dei tag
# --------------------------------------------------------------------------
def slide_index(prs):
    s = blank(prs)
    chrome(s, "Indice", "Tutti i 30 tag, in quattro colonne",
           "La mappa completa dell'esercizio: ogni voce ha una slide con "
           "spiegazione e codice.", BLUE, 40, TOTAL)

    short = {
        "Grid · ColumnDefinition · RowDefinition": "Grid · Row / Column",
        "TextBlock · Run · Bold · Italic": "TextBlock · Run",
        "Button · Command / Click": "Button · Command",
        "CheckBox · RadioButton · ToggleButton · ToggleSwitch": "CheckBox / Radio / Toggle",
        "ComboBox · ComboBoxItem": "ComboBox",
        "NumericUpDown · DatePicker · TimePicker": "NumericUpDown / DatePicker",
        "Menu · MenuItem · Separator": "Menu · MenuItem",
        "ToolTip · Flyout · ContextMenu": "ToolTip · Flyout",
        "ListBox · ListBoxItem": "ListBox statica",
        "Form · Command · ObservableCollection": "Form · Command · Collection",
        "ListBox · DataTemplate": "ListBox · DataTemplate",
        "DataGrid · DataGridTextColumn": "DataGrid",
        "ItemsControl · ItemTemplate": "ItemsControl",
        "TreeView · TreeViewItem": "TreeView",
        "Window.Resources · Color": "Resources · Color",
        "Window.Styles · Style · Setter": "Styles · Setter",
        "Rectangle · Ellipse · Line · Polygon": "Rectangle / Ellipse / Line",
        "Path · Viewbox": "Path · Viewbox",
        "Image · AvaloniaResource": "Image",
        "BoxShadow · Opacity · RenderTransform": "BoxShadow · Opacity",
    }

    for i, section in enumerate(SECTIONS):
        x = 0.7 + i * 3.12
        w = 2.9
        rect(s, x, 1.95, w, 4.28, fill=SURFACE, line=LINE, radius=0.10)
        rect(s, x, 1.95, w, 0.05, fill=section["color"])
        text(s, x + 0.22, 2.14, w - 0.4, 0.24,
             section["num"], 8.6, section["color"], bold=True, font=MONO)
        text(s, x + 0.22, 2.42, w - 0.4, 0.28, section["name"], 12.8,
             TEXT, bold=True)
        text(s, x + 0.22, 2.72, w - 0.4, 0.2, f"{len(section['tags'])} tag",
             8.2, MUTED)

        y = 3.04
        for n, tag in enumerate(section["tags"], start=1):
            label = short.get(tag["title"], tag["title"])
            text(s, x + 0.22, y, 2.5, 0.3, label, 8.7, BODY)
            y += 0.285

    text(s, 0.7, 6.52, 11.9, 0.24,
         "30 tag  ·  34 schede nell'app  ·  69 tipi di elemento XAML  ·  "
         "una sola finestra", 9.2, MUTED)
    footer(s, 40, TOTAL)


# --------------------------------------------------------------------------
# Assemblaggio
# --------------------------------------------------------------------------
def build():
    prs = new_deck()

    slide_cover(prs)                    # 01
    slide_map(prs)                      # 02
    slide_mvvm(prs)                     # 03
    slide_binding(prs)                  # 04

    page = 5
    tag_counter = 0
    for section in SECTIONS:
        slide_divider(prs, section, section["num"], page)
        page += 1
        for tag in section["tags"]:
            tag_counter += 1
            slide_tag(prs, section, tag, tag_counter, page)
            page += 1

    slide_run(prs)                      # 39
    slide_index(prs)                    # 40

    prs.core_properties.title = "Laboratorio XAML · esercizio unico"
    prs.core_properties.subject = "Avalonia 12 e MVVM: 30 tag spiegati"
    prs.core_properties.author = "Esercizio didattico"
    prs.core_properties.comments = (
        "Deck equivalente all'esercizio Es1AvaloniBM: layout, controlli, "
        "dati e stili."
    )
    prs.save(OUT)
    return prs


if __name__ == "__main__":
    deck = build()
    print(f"Salvate {len(deck.slides)} slide in {os.path.abspath(OUT)}")
    print(f"Tag nelle sezioni: {TAG_TOTAL} (attesi 30)")
    if WARNINGS:
        print(f"\n{len(WARNINGS)} avvisi di impaginazione:")
        for warning in WARNINGS:
            print(" -", warning)
    else:
        print("Nessun avviso di impaginazione.")
