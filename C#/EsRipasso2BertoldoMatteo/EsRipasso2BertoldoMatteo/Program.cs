namespace EsRipasso2BertoldoMatteo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int v, n1, n2= 1, c=0;
            bool Valid;
            do
            {
                Console.WriteLine("Quanti numeri vuoi inserire?");
            } while (!int.TryParse(Console.ReadLine(), out v) || v<0);
            Console.WriteLine("Inserisci i numeri:");
            for(int i = 0; i<v; i++)
            {
                do
                {
                    Valid = int.TryParse(Console.ReadLine(), out n1);
                }
                while (!Valid);
                if (i != 0 && n1!= 0 && n2 != 0 && Math.Sign(n1) != Math.Sign(n2)) c++;
                n2 = n1;
            }
            Console.WriteLine("I cambi sono: "+c);

        }
    }
}
