namespace Project1;

public class EditKont
{
    public static void EditKontener(ref List<Kontener> konteners)
    {
        
        while (true)
        {
            var count = 0;
            foreach (var kontener in konteners)
            {
                Console.WriteLine($"Nr {count} -> {kontener.NrSeryjny}");
                count++;
            }
            int index = -1;
            // ==============================================================
            while (index > konteners.Count-1 || index < 0)
            {
                Console.Write("Prosze podac numer kontenerowca do pracy albo 'stop' żeby skończyć pracę: ");
                string s = Console.ReadLine() ?? string.Empty;
                if (s == "stop")
                {
                    index = -2;
                    break;
                }
                index = int.Parse(s);
            }
            if (index == -2) break;

            Console.Clear();
            while (index != -1 && konteners.Count > 0)
            {
                Console.WriteLine($"Nr {index}: {konteners[index].NrSeryjny}");
            
                Console.WriteLine("================================================");
            
                Console.WriteLine("Mozliwe akcje");
                Console.WriteLine("1. Usun kontener (DESTROY IT)");
                Console.WriteLine("2. Oproznij ladunek");
                Console.WriteLine("3. Dodaj ladunek");
                Console.WriteLine("4. Wypisz cala informacje o kontenerze");
                Console.WriteLine("5. Wroc");

                int choice = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (choice)
                {
                    case 1:
                        konteners.Remove(konteners[index]);
                        Console.WriteLine("Kontener wyrzucony"); //sorry kontener T-T
                        index = -1;
                        break;
                    case 2:
                        Console.WriteLine("Podaj ilosc albo 'all' do całego oproznienia: ");
                        string s = Console.ReadLine() ?? string.Empty;
                        if (s == "all") konteners[index].Oproznienie();
                        else konteners[index].Oproznienie(Double.Parse(s));
                        break;
                    case 3:
                        Console.WriteLine("Podaj ilosc do zaladowania: ");
                        try
                        {
                            konteners[index].Zaladowanie(Double.Parse(Console.ReadLine() ?? string.Empty));
                        }
                        catch (OverfillException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine(konteners[index].AllInfo());
                        break;
                    case 5:
                        index = -1;
                        break;
                }
            }
            
            
        }
        Console.Clear();
    }
}