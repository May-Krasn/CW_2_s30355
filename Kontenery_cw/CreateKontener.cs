using Kontenery_cw;

public class CreatingKont
{
    public static void CreateKontener(ref List<Kontener> konteners)
    {
        Console.WriteLine("Typy kontenerów:\n-> 'C' - Chlodniczy\n-> 'G' - Gaz\n-> 'L' - Plyny");
        while (true)
        {
            Console.Write("Typ kontenera: ");
            var typ = Console.ReadLine() ?? string.Empty;
            if (!typ.Equals("L") && !typ.Equals("G") && !typ.Equals("C"))
            {
                Console.Clear();
                Console.WriteLine("Typy kontenerów:\n-> 'C' - Chlodniczy\n-> 'G' - Gaz\n-> 'L' - Plyny");
                continue;
            }
            Console.Write("Wysokosc kontenera: ");
            var wysokosc = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Waga wlasna kontenera: ");
            var wagaWlasna = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Glebokosc kontenera: ");
            var glebokosc = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Ladownosc kontenera: ");
            var ladownosc = double.Parse(Console.ReadLine() ?? string.Empty);

            switch (typ)
            {
                case "C":
                    Ckontener.WriteDict();
                    
                    Console.Write("Temperature kontenera: ");
                    var temperature = double.Parse(Console.ReadLine() ?? string.Empty);
                    
                    Console.Write("Produkt kontenera: ");
                    var produkt = Console.ReadLine() ?? string.Empty;
            
                    konteners.Add(new Ckontener(wysokosc, wagaWlasna, glebokosc, ladownosc, typ, temperature, produkt));
                    break;
                case "G":
                    konteners.Add(new Gkontener(wysokosc, wagaWlasna, glebokosc, ladownosc, typ));
                    break;
                case "L":
                    Console.Write("Niebezpieczny ladunek? 'Y' or 'N': ");
                    var niebezpieczny = (Console.ReadLine() ?? string.Empty).Equals("Y");
                    konteners.Add(new Lkontener(wysokosc, wagaWlasna, glebokosc, ladownosc, typ, niebezpieczny));
                    break;
            }
            
            Console.WriteLine($"Kontener {konteners.Last().NrSeryjny} stworzony i dodany do listy");
        
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