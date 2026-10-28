"""Contenuti del deck: 4 sezioni, 30 tag, spiegazioni e snippet."""

from deck_lib import ACCENT, AMBER, BLUE, MINT

SECTIONS = [
    {
        "num": "01",
        "name": "Layout",
        "tab": "1 · Layout",
        "color": ACCENT,
        "title": "Layout",
        "desc": "Sistemare i figli nello spazio: bordi, griglie, pile e coordinate. "
                "Nessun pannello ha un aspetto proprio, tranne Border.",
        "intro": "La finestra dell'esercizio parte da qui: un DockPanel per "
                 "l'intestazione e uno ScrollViewer per ogni scheda.",
        "tags": [
            {
                "title": "DockPanel",
                "subtitle": "Aggancia i figli ai bordi e lascia il centro all'ultimo.",
                "bullets": [
                    "**DockPanel.Dock**: Top, Bottom, Left o Right",
                    "**LastChildFill=True**: l'ultimo figlio prende il resto",
                    "L'ordine dei figli decide chi vince lo spazio",
                ],
                "code": """
<DockPanel LastChildFill="True">
  <Border DockPanel.Dock="Top" Height="40"/>
  <Border DockPanel.Dock="Left" Width="120"/>
  <Border/>   <!-- riempie lo spazio -->
</DockPanel>""",
                "note": "La finestra usa un DockPanel: intestazione in alto, "
                        "TabControl al centro.",
            },
            {
                "title": "Grid · ColumnDefinition · RowDefinition",
                "subtitle": "La griglia a righe e colonne: il pannello più usato.",
                "bullets": [
                    "**Width / Height**: pixel, Auto o stella (proporzione)",
                    "**Grid.Row** e **Grid.Column** scelgono la cella",
                    "**RowSpan / ColumnSpan** occupano più celle",
                ],
                "code": """
<Grid ColumnDefinitions="2*,*,Auto"
      RowDefinitions="*,*">
  <Border Grid.Row="0" Grid.Column="0"/>
  <Border Grid.Row="0" Grid.Column="1"/>
  <Border Grid.Row="1" Grid.Column="0"
          Grid.ColumnSpan="2"/>
</Grid>""",
                "note": "Il form della scheda Dati divide nome, email ed età "
                        "con una Grid.",
            },
            {
                "title": "StackPanel",
                "subtitle": "Impila i figli in verticale o in orizzontale.",
                "bullets": [
                    "**Orientation**: Vertical (default) o Horizontal",
                    "**Spacing** regola la distanza tra i figli",
                    "Non gestisce l'overflow: serve uno ScrollViewer",
                ],
                "code": """
<StackPanel Orientation="Horizontal" Spacing="8">
  <Button Content="Primo"/>
  <Button Content="Secondo"/>
  <Button Content="Terzo"/>
</StackPanel>""",
                "note": "Ogni riquadro dell'esercizio usa uno StackPanel per "
                        "titolo, testo e dimostrazione.",
            },
            {
                "title": "WrapPanel",
                "subtitle": "Va a capo da solo quando finisce lo spazio.",
                "bullets": [
                    "Ideale per chip, etichette e gallerie",
                    "**ItemWidth / ItemHeight**: celle tutte uguali",
                    "**Orientation** cambia la direzione del flusso",
                ],
                "code": """
<WrapPanel ItemWidth="110">
  <Button Content="C#"/>
  <Button Content="XAML"/>
  <Button Content="MVVM"/>
  <Button Content="Binding"/>
</WrapPanel>""",
                "note": "Usato per i chip dei reparti e per la riga dei "
                        "controlli a stati.",
            },
            {
                "title": "Canvas",
                "subtitle": "Posizionamento assoluto con coordinate.",
                "bullets": [
                    "**Canvas.Left / Canvas.Top** (oppure Right / Bottom)",
                    "I figli possono sovrapporsi",
                    "Non ridimensiona i figli: bene per la grafica",
                ],
                "code": """
<Canvas Height="150">
  <Rectangle Canvas.Left="8" Canvas.Top="16"
             Width="150" Height="80"
             Fill="#2A2350"/>
  <Ellipse Canvas.Left="115" Canvas.Top="38"
           Width="90" Height="90"
           Fill="#8B7CFF"/>
</Canvas>""",
                "note": "Le forme delle schede Layout e Stili sono disposte "
                        "su una Canvas.",
            },
            {
                "title": "Border",
                "subtitle": "Un solo figlio, con sfondo, bordo e angoli.",
                "bullets": [
                    "**Background, BorderBrush, BorderThickness**",
                    "**CornerRadius** arrotonda, **Padding** fa respirare",
                    "**BoxShadow** aggiunge profondità",
                ],
                "code": """
<Border Background="#171A21"
        BorderBrush="#8B7CFF" BorderThickness="1"
        CornerRadius="14" Padding="16"
        BoxShadow="0 8 24 0 #40000000">
  <TextBlock Text="Una sola scheda"/>
</Border>""",
                "note": "Le 34 schede dell'esercizio sono Border con "
                        "Classes=\"card\".",
            },
            {
                "title": "UniformGrid",
                "subtitle": "Celle tutte uguali, senza dichiarare righe e colonne.",
                "bullets": [
                    "**Columns** e **Rows** dividono lo spazio in parti uguali",
                    "Più semplice di Grid per dashboard e gallerie",
                    "I figli si distribuiscono in ordine",
                ],
                "code": """
<UniformGrid Columns="3" Rows="2">
  <Border Background="#221F33"/>
  <Border Background="#1E3A44"/>
  <Border Background="#3A2F1A"/>
  <Border Background="#1B2130"/>
  <Border Background="#2A2350"/>
  <Border Background="#243B4A"/>
</UniformGrid>""",
                "note": "La demo mostra sei celle numerate tutte della "
                        "stessa misura.",
            },
            {
                "title": "ScrollViewer",
                "subtitle": "Rende scorrevole un contenuto più grande.",
                "bullets": [
                    "**Vertical / HorizontalScrollBarVisibility**",
                    "**Auto** mostra la barra solo se serve",
                    "Un solo figlio: di solito un pannello",
                ],
                "code": """
<ScrollViewer Height="110"
              VerticalScrollBarVisibility="Auto"
              HorizontalScrollBarVisibility="Disabled">
  <StackPanel Spacing="6">
    <TextBlock Text="Riga 1"/>
    <TextBlock Text="Riga 2"/>
  </StackPanel>
</ScrollViewer>""",
                "note": "Ogni scheda dell'app è avvolta in uno "
                        "ScrollViewer.",
            },
        ],
    },
    {
        "num": "02",
        "name": "Controlli",
        "tab": "2 · Controlli",
        "color": MINT,
        "title": "Controlli",
        "desc": "Ricevere dati e mostrare informazioni: testo, scelte, menu, "
                "liste. Le proprietà ricorrenti sono Content, Text, "
                "ItemsSource, IsChecked e Command.",
        "intro": "La scheda più lunga dell'esercizio: undici gruppi di "
                 "controlli, tutti collegati al ViewModel quando ha senso.",
        "tags": [
            {
                "title": "TextBlock · Run · Bold · Italic",
                "subtitle": "Testo in sola lettura, anche ricco di stili.",
                "bullets": [
                    "**Text** oppure elementi inline",
                    "**Run, Bold, Italic, LineBreak**",
                    "**TextWrapping** gestisce le righe lunghe",
                ],
                "code": """
<TextBlock TextWrapping="Wrap">
  <Run Text="Questo è un "/>
  <Bold>TextBlock</Bold>
  <Run Text=" con "/>
  <Italic>Italic</Italic>
  <LineBreak/>
  <Run Text="e un Run colorato"
       Foreground="#8B7CFF"/>
</TextBlock>""",
                "note": "Titoli, etichette e descrizioni di ogni scheda "
                        "sono TextBlock.",
            },
            {
                "title": "TextBox",
                "subtitle": "Casella di testo modificabile.",
                "bullets": [
                    "**PlaceholderText**: suggerimento quando è vuota",
                    "**MaxLength** limita i caratteri",
                    "**Text** con **Mode=TwoWay** aggiorna il ViewModel",
                ],
                "code": """
<TextBox Text="{Binding Nome, Mode=TwoWay}"
         PlaceholderText="Scrivi un nome..."
         MaxLength="40"/>

<TextBlock Text="{Binding Nome}"/>""",
                "note": "Nome, email e ricerca sono TextBox collegate "
                        "al ViewModel.",
            },
            {
                "title": "Button · Command / Click",
                "subtitle": "Un'azione, dichiarata nel ViewModel o nel code-behind.",
                "bullets": [
                    "**Command** chiama un comando del ViewModel (MVVM)",
                    "**Click** chiama un gestore nel code-behind",
                    "**Content** può essere testo o un altro controllo",
                ],
                "code": """
<Button Content="Command → ViewModel"
        Command="{Binding IncrementaCommand}"/>

<Button Content="Click → code-behind"
        Click="OnClickDemo"/>""",
                "note": "Aggiungi, Rimuovi e Svuota usano solo Command; "
                        "il Click serve da confronto.",
            },
            {
                "title": "CheckBox · RadioButton · ToggleButton · ToggleSwitch",
                "subtitle": "Scelte indipendenti, gruppi esclusivi e interruttori.",
                "bullets": [
                    "**CheckBox**: IsChecked, anche **IsThreeState**",
                    "**RadioButton**: una sola scelta, **GroupName**",
                    "**ToggleButton / ToggleSwitch**: IsChecked di tipo bool?",
                ],
                "code": """
<CheckBox Content="Ricorda"
          IsChecked="{Binding Ricorda}"/>

<RadioButton GroupName="turno"
             Content="Mattina" IsChecked="True"/>

<ToggleSwitch Content="Notifiche"
              IsChecked="{Binding Notifiche}"/>""",
                "note": "Ricorda e Notifiche sono proprietà bool del "
                        "ViewModel.",
            },
            {
                "title": "ComboBox · ComboBoxItem",
                "subtitle": "Menu a tendina, statico o alimentato da una collezione.",
                "bullets": [
                    "**ComboBoxItem**: voci scritte nel XAML",
                    "**ItemsSource**: voci che arrivano dai dati",
                    "**SelectedItem / SelectedIndex** dicono quale è scelta",
                ],
                "code": """
<ComboBox SelectedIndex="0">
  <ComboBoxItem Content="Prima voce"/>
  <ComboBoxItem Content="Seconda voce"/>
</ComboBox>

<ComboBox ItemsSource="{Binding Reparti}"
          SelectedItem="{Binding Reparto}"/>""",
                "note": "I reparti arrivano da un array di stringhe del "
                        "ViewModel.",
            },
            {
                "title": "Slider · ProgressBar",
                "subtitle": "Scegliere un numero e vederlo rappresentato.",
                "bullets": [
                    "**Minimum, Maximum, Value**",
                    "Lo stesso binding muove slider e barra",
                    "**IsIndeterminate** mostra un avanzamento infinito",
                ],
                "code": """
<Slider Minimum="0" Maximum="100"
        Value="{Binding Valore, Mode=TwoWay}"/>

<ProgressBar Minimum="0" Maximum="100"
             Value="{Binding Valore}" Height="8"/>

<ProgressBar IsIndeterminate="True" Height="5"/>""",
                "note": "Muovi lo slider: barra e numero cambiano insieme, "
                        "senza codice.",
            },
            {
                "title": "NumericUpDown · DatePicker · TimePicker",
                "subtitle": "Input specializzati, con limiti e formato.",
                "bullets": [
                    "**NumericUpDown**: pulsanti, min, max, increment",
                    "**DatePicker**: **SelectedDate**",
                    "**TimePicker**: **SelectedTime**",
                ],
                "code": """
<NumericUpDown Value="{Binding Quantita}"
               Minimum="1" Maximum="99"
               Increment="1"/>

<DatePicker SelectedDate="{Binding Data}"/>
<TimePicker SelectedTime="{Binding Ora}"/>""",
                "note": "L'età nel form è un NumericUpDown con intervallo "
                        "14–99.",
            },
            {
                "title": "Expander",
                "subtitle": "Dettagli facoltativi, mostrati su richiesta.",
                "bullets": [
                    "**Header** è sempre visibile",
                    "**IsExpanded** apre o chiude il contenuto",
                    "Il contenuto può essere qualsiasi controllo",
                ],
                "code": """
<Expander Header="Dettagli dell'esercizio"
          IsExpanded="True">
  <StackPanel Spacing="8">
    <TextBlock Text="Contenuto facoltativo"/>
    <ProgressBar IsIndeterminate="True"/>
  </StackPanel>
</Expander>""",
                "note": "Tiene corta la pagina senza perdere informazioni.",
            },
            {
                "title": "Menu · MenuItem · Separator",
                "subtitle": "Barra di voci, anche annidate.",
                "bullets": [
                    "**Menu** contiene **MenuItem**",
                    "MenuItem annidati creano un sottomenu",
                    "**Separator** disegna una linea divisoria",
                ],
                "code": """
<Menu>
  <MenuItem Header="File">
    <MenuItem Header="Nuovo"/>
    <MenuItem Header="Apri..."/>
    <Separator/>
    <MenuItem Header="Esci"/>
  </MenuItem>
  <MenuItem Header="Modifica"/>
</Menu>""",
                "note": "In un'app reale ogni voce avrebbe un Command o "
                        "un Click.",
            },
            {
                "title": "ToolTip · Flyout · ContextMenu",
                "subtitle": "Contenuti che compaiono al momento giusto.",
                "bullets": [
                    "**ToolTip.Tip**: suggerimento al passaggio del mouse",
                    "**Button.Flyout**: pannello ancorato al pulsante",
                    "**ContextMenu**: si apre con il tasto destro",
                ],
                "code": """
<Button Content="ToolTip"
        ToolTip.Tip="Suggerimento"/>

<Button Content="Apri Flyout">
  <Button.Flyout>
    <Flyout Placement="Bottom">
      <TextBlock Text="Contenuto"/>
    </Flyout>
  </Button.Flyout>
</Button>""",
                "note": "Nella demo c'è anche un Border con un menu "
                        "contestuale.",
            },
            {
                "title": "ListBox · ListBoxItem",
                "subtitle": "Elenco con selezione, statico o da collezione.",
                "bullets": [
                    "**ListBoxItem** scritti direttamente nel XAML",
                    "**SelectedIndex / SelectedItem**",
                    "Con ItemsSource e ItemTemplate diventa dinamica",
                ],
                "code": """
<ListBox Height="120" SelectedIndex="0">
  <ListBoxItem Content="Prima voce"/>
  <ListBoxItem Content="Seconda voce"/>
  <ListBoxItem Content="Terza voce"/>
</ListBox>""",
                "note": "Nella scheda Dati la stessa ListBox mostra la "
                        "collezione delle persone.",
            },
        ],
    },
    {
        "num": "03",
        "name": "Dati e binding",
        "tab": "3 · Dati e binding",
        "color": AMBER,
        "title": "Dati e binding",
        "desc": "Il flusso MVVM: form → ViewModel → ObservableCollection → "
                "ListBox e DataGrid. La View non crea i dati, li chiede.",
        "intro": "È la parte delle slide MVVM: dati notificanti, comandi e "
                 "template. Il Model è la classe Utente.",
        "tags": [
            {
                "title": "Form · Command · ObservableCollection",
                "subtitle": "Dal testo nel form alla lista che si aggiorna da sola.",
                "bullets": [
                    "TextBox in **TwoWay** aggiorna Nome, Email ed Età",
                    "**AggiungiCommand** crea un Utente e lo aggiunge",
                    "La collezione notifica ListBox e DataGrid",
                ],
                "code": """
<TextBox Text="{Binding Nome, Mode=TwoWay}"/>
<TextBox Text="{Binding Email, Mode=TwoWay}"/>
<NumericUpDown Value="{Binding Eta}"
               Minimum="14" Maximum="99"/>

<Button Content="Aggiungi"
        Command="{Binding AggiungiCommand}"/>
<Button Content="Rimuovi"
        Command="{Binding RimuoviCommand}"/>""",
                "note": "Aggiungi, Rimuovi e Svuota sono tre RelayCommand "
                        "del ViewModel.",
            },
            {
                "title": "ListBox · DataTemplate",
                "subtitle": "Una lista che riceve i dati e disegna ogni voce.",
                "bullets": [
                    "**ItemsSource** lega la collezione",
                    "**SelectedItem** lega la riga scelta",
                    "**ItemTemplate** descrive una voce (x:DataType)",
                ],
                "code": """
<ListBox ItemsSource="{Binding Persone}"
         SelectedItem="{Binding Selezionata}">
  <ListBox.ItemTemplate>
    <DataTemplate x:DataType="models:Utente">
      <StackPanel>
        <TextBlock Text="{Binding Nome}"/>
        <TextBlock Text="{Binding Email}"/>
      </StackPanel>
    </DataTemplate>
  </ListBox.ItemTemplate>
</ListBox>""",
                "note": "La selezione è condivisa con il DataGrid qui sotto.",
            },
            {
                "title": "DataGrid · DataGridTextColumn",
                "subtitle": "Tabella per dati strutturati, con colonne esplicite.",
                "bullets": [
                    "**AutoGenerateColumns=False**: colonne dichiarate",
                    "Ogni colonna ha **Header** e **Binding**",
                    "**IsReadOnly**, **GridLinesVisibility**, ordinamento",
                ],
                "code": """
<DataGrid ItemsSource="{Binding Persone}"
          SelectedItem="{Binding Selezionata}"
          AutoGenerateColumns="False"
          IsReadOnly="True"
          GridLinesVisibility="Horizontal">
  <DataGrid.Columns>
    <DataGridTextColumn Header="Nome"
                        Binding="{Binding Nome}" Width="2*"/>
    <DataGridTextColumn Header="Email"
                        Binding="{Binding Email}" Width="3*"/>
  </DataGrid.Columns>
</DataGrid>""",
                "note": "In Avalonia 12 è in sola manutenzione; l'alternativa "
                        "consigliata è TableView.",
            },
            {
                "title": "ItemsControl · ItemTemplate",
                "subtitle": "Ripete un template, ma non gestisce la selezione.",
                "bullets": [
                    "**ItemsSource + ItemTemplate**",
                    "**ItemsPanelTemplate** sceglie il pannello",
                    "Più leggero di ListBox e DataGrid",
                ],
                "code": """
<ItemsControl ItemsSource="{Binding Persone}">
  <ItemsControl.ItemsPanel>
    <ItemsPanelTemplate>
      <WrapPanel/>
    </ItemsPanelTemplate>
  </ItemsControl.ItemsPanel>
  <ItemsControl.ItemTemplate>
    <DataTemplate x:DataType="models:Utente">
      <Border Classes="chip">
        <TextBlock Text="{Binding Nome}"/>
      </Border>
    </DataTemplate>
  </ItemsControl.ItemTemplate>
</ItemsControl>""",
                "note": "Mostra le persone come chip che vanno a capo.",
            },
            {
                "title": "TreeView · TreeViewItem",
                "subtitle": "Dati gerarchici ad albero.",
                "bullets": [
                    "Un **TreeViewItem** può contenerne altri",
                    "**Header** è il testo del nodo",
                    "**IsExpanded** apre un ramo",
                ],
                "code": """
<TreeView Height="210">
  <TreeViewItem Header="Scuola" IsExpanded="True">
    <TreeViewItem Header="Informatica"
                  IsExpanded="True">
      <TreeViewItem Header="Avalonia UI"/>
      <TreeViewItem Header="C#"/>
    </TreeViewItem>
    <TreeViewItem Header="Elettronica"/>
  </TreeViewItem>
</TreeView>""",
                "note": "Gerarchia scritta nel XAML; con ItemsSource diventa "
                        "dinamica.",
            },
        ],
    },
    {
        "num": "04",
        "name": "Stili e grafica",
        "tab": "4 · Stili e grafica",
        "color": BLUE,
        "title": "Stili e grafica",
        "desc": "Risorse, stili, forme e immagini: l'identità visiva "
                "dell'esercizio. Non inserisce dati, li rende leggibili.",
        "intro": "Colori definiti una volta, stili applicati per selettore, "
                 "forme vettoriali e un'immagine inclusa nel progetto.",
        "tags": [
            {
                "title": "Window.Resources · Color",
                "subtitle": "Valori definiti una volta e riusati ovunque.",
                "bullets": [
                    "**x:Key** dà un nome alla risorsa",
                    "**{StaticResource chiave}** la richiama",
                    "**DynamicResource** segue i cambi di tema",
                ],
                "code": """
<Window.Resources>
  <Color x:Key="AccentColor">#8B7CFF</Color>
  <SolidColorBrush x:Key="AccentBrush"
                   Color="{StaticResource AccentColor}"/>
</Window.Resources>

<Border Background="{StaticResource AccentBrush}"/>""",
                "note": "Accent, mint, amber e surface sono brush "
                        "condivisi da tutte le schede.",
            },
            {
                "title": "Window.Styles · Style · Setter",
                "subtitle": "Più proprietà insieme, applicate per selettore.",
                "bullets": [
                    "**Style Selector** individua gli elementi",
                    "**Setter** applica una proprietà",
                    "Classi e pseudo-classi: **Button.accent:pointerover**",
                ],
                "code": """
<Style Selector="Button.accent">
  <Setter Property="Background"
          Value="{StaticResource AccentBrush}"/>
  <Setter Property="CornerRadius" Value="8"/>
  <Setter Property="Padding" Value="14,8"/>
</Style>

<Style Selector="Button.accent:pointerover">
  <Setter Property="Opacity" Value="0.85"/>
</Style>""",
                "note": "Tutti i pulsanti viola nascono da questi due stili.",
            },
            {
                "title": "Rectangle · Ellipse · Line · Polygon",
                "subtitle": "Forme vettoriali, nitide a ogni dimensione.",
                "bullets": [
                    "**Fill** riempie, **Stroke** disegna il contorno",
                    "**Rectangle**: RadiusX / RadiusY per gli angoli",
                    "**Polygon**: una lista di **Points**",
                ],
                "code": """
<Rectangle Width="120" Height="70"
           Fill="#2A2350" Stroke="#8B7CFF"
           StrokeThickness="2" RadiusX="10"/>
<Ellipse Width="72" Height="72" Fill="#4CD7B0"/>
<Line StartPoint="18,120" EndPoint="210,120"
      Stroke="#F5B54B" StrokeThickness="3"/>
<Polygon Points="255,115 300,35 345,115"
         Fill="#F5B54B"/>""",
                "note": "Sono disegnate su una Canvas nella scheda Stili.",
            },
            {
                "title": "Path · Viewbox",
                "subtitle": "Geometrie e icone che scalano senza perdere qualità.",
                "bullets": [
                    "**Data** usa i comandi M, L e Z",
                    "**Stroke** e **Fill** colorano il disegno",
                    "**Viewbox** scala mantenendo le proporzioni",
                ],
                "code": """
<Viewbox Width="84" Height="84">
  <Path Data="M 10,50 L 35,20 L 60,50 L 35,80 Z"
        Stroke="#8B7CFF" StrokeThickness="4"
        Fill="Transparent"/>
</Viewbox>""",
                "note": "Lo stesso Path è mostrato a 84, 48 e 28 pixel.",
            },
            {
                "title": "Image · AvaloniaResource",
                "subtitle": "Un file incluso nel progetto e caricato con un URI.",
                "bullets": [
                    "**AvaloniaResource** nel .csproj",
                    "URI **avares://Progetto/percorso.png**",
                    "**Stretch=Uniform** mantiene le proporzioni",
                ],
                "code": """
<Image Source="avares://Es1AvaloniBM/Assets/logo.png"
       Width="72" Height="72"
       Stretch="Uniform"/>

<!-- Es1AvaloniBM.csproj -->
<AvaloniaResource Include="Assets/**"/>""",
                "note": "L'icona in alto a sinistra arriva da "
                        "Assets/logo.png.",
            },
            {
                "title": "BoxShadow · Opacity · RenderTransform",
                "subtitle": "Effetti visivi che non cambiano il layout.",
                "bullets": [
                    "**BoxShadow**: ombra con offset e sfocatura",
                    "**Opacity**: trasparenza, anche sui figli",
                    "**RenderTransform**: ruota, scala, inclina",
                ],
                "code": """
<Border Background="#2A2350" CornerRadius="10"
        BoxShadow="0 10 24 0 #66000000"/>
<Border Background="#8B7CFF" Opacity="0.45"/>
<Border Background="#243B4A">
  <Border.RenderTransform>
    <RotateTransform Angle="10"/>
  </Border.RenderTransform>
</Border>""",
                "note": "Tre riquadri affiancati nella scheda Stili.",
            },
        ],
    },
]
