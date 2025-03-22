namespace Kontenery_cw;

public class CreatingTransport
{
    public static void CreateTransport(ref List<Kontenerowiec> transports)
    {
        while (true)
        {
            Console.Write("Maksymalna predkosc transporta: ");
            var predkosc = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Maksymalna ilosc kontenerow: ");
            var ilosc = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Maksymalna waga przeozenia transporta: ");
            var makswaga = double.Parse(Console.ReadLine() ?? string.Empty);
        
            transports.Add(new Kontenerowiec(predkosc, ilosc, makswaga));
            
            Console.WriteLine($"Transport {transports.Last().NrSeryjnyTransporta} stworzony i dodany do listy");
        
            Console.Write("Stop? 'Y' or 'N': ");
            if ((Console.ReadLine() ?? string.Empty).Equals("Y"))
            {
                Console.Clear();
                break;
            }
            Console.WriteLine("===========================");
        }
    }
}