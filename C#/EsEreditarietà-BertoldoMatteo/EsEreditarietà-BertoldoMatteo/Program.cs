namespace EsEreditarietà_BertoldoMatteo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CAudio mioAudio = new CAudio();
            CVideo mioVideo = new CVideo();
            CImmagine miaImmagine = new CImmagine();

            Console.WriteLine("Audio");
            Console.WriteLine("Estensione: " + mioAudio.Estensione);
            Console.WriteLine("Dimensione: " + mioAudio.Dimensione);
            Console.WriteLine(mioAudio.Riproduci());

            Console.WriteLine("\nVideo");
            Console.WriteLine("Estensione: " + mioVideo.Estensione);
            Console.WriteLine("Dimensione: " + mioVideo.Dimensione);
            Console.WriteLine(mioVideo.Visualizza());

            Console.WriteLine("\nImmagine");
            Console.WriteLine("Estensione: " + miaImmagine.Estensione);
            Console.WriteLine("Dimensione: " + miaImmagine.Dimensione);
            Console.WriteLine(miaImmagine.FiltraBiancoNero());
        }


    }
}

