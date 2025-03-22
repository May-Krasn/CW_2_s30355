namespace Kontenery_cw;

public class EditingTransport
{
    public static void EditTransport(ref List<Kontenerowiec> transports, ref List<Kontener> konteners)
    {
        while (true)
        {
            var count = 0;
            foreach (var transport in transports)
            {
                Console.WriteLine($"Nr {count} -> {transport.NrSeryjnyTransporta}");
                count++;
            }

            int index = -1;
            // =============================================
            while (index > transports.Count - 1 || index < 0)
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
            while (index != -1 && transports.Count > 0)
            {
                Console.WriteLine($"Nr {index}: {transports[index].NrSeryjnyTransporta}");
                
                
                Console.WriteLine("================================================");
            
                Console.WriteLine("Mozliwe akcje");
                Console.WriteLine("1. Usun kontenerowiec (DESTROY IT)");
                
                Console.WriteLine("2. Dodaj kontener");
                Console.WriteLine("3. Usun kontener z transportu");
                Console.WriteLine("4. Zastap kontener innym");
                Console.WriteLine("5. Przenies kontener na inny transport");
                
                Console.WriteLine("6. Wypisz cala informacje o kontenerowcu");
                Console.WriteLine("7. Wroc");
                
                int choice = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (choice)
                {
                    case 1:
                        transports.Remove(transports[index]);
                        Console.WriteLine("Transport został wyrzucony"); //znowu? T-T
                        index = -1;
                        break;
                    case 2:
                        Console.Write("'1' jesli chcesz dodac jeden kontener, '2' jesli liste: ");
                        int choice2 = int.Parse(Console.ReadLine() ?? string.Empty);
                        
                        AboutKonteners(ref konteners);
                        
                        switch (choice2)
                        {
                            case 1:
                                var ind = -1;
                                while (ind > konteners.Count-1 || ind < 0)
                                {
                                    Console.Write("Prosze podac numer kontenerowca do pracy albo 'stop' żeby skończyć pracę: ");
                                    string s = Console.ReadLine() ?? string.Empty;
                                    if (s == "stop")
                                    {
                                        ind = -2;
                                        break;
                                    }
                                    ind = int.Parse(s);
                                }
                                if (ind == -2) break;
                                
                                transports[index].AddKontener(konteners[ind]);
                                
                                break;
                            case 2:
                                
                                List<Kontener> list = new();
                                Console.WriteLine("'stop' zeby zakonczyc prace");
                                Console.Write("Prosze podac numery kontenerowcow oddzielone spacja: ");
                                string command = Console.ReadLine() ?? string.Empty;
                                if (command == "stop") break;
                                string[] numery = command.Split(" ");
                                foreach (var num in numery)
                                {
                                    int x = int.Parse(num);
                                    if (x < 0 || x >= transports.Count || list.Contains(konteners[x])) continue;
                                    list.Add(konteners[x]);
                                }
                                
                                transports[index].AddListKonteners(list);
                                break;
                        }
                        break;
                    case 3:
                        transports[index].KontenersToString();
                        Console.Write("\nProsze podac kontener do usuniecia lub 'stop' zeby anulowac: ");
                        string nrser = Console.ReadLine() ?? string.Empty;
                        if (nrser == "stop") break;
                        transports[index].DeleteKontener(transports[index].GetKontener(nrser));
                        break;
                    case 4:

                        if (transports[index].Kontener.Count == 0) break;
                        
                        transports[index].KontenersToString();
                        Console.Write("Prosze podac nr seryjny kontenera do usuniecia: ");
                        string kont1 = Console.ReadLine() ?? string.Empty;
                        AboutKonteners(ref konteners);
                        Console.Write("Prosze podac indeks nowego kontenera: ");
                        int kont2 = int.Parse(Console.ReadLine() ?? string.Empty);
                        if (transports[index].GetKontener(kont1) == konteners[kont2])
                        {
                            Console.WriteLine("Ten sam kontener?");
                            break;
                        }
                        transports[index].ChangeKontener(transports[index].GetKontener(kont1), konteners[kont2]);
                        break;
                    case 5:
                        transports[index].KontenersToString();
                        Console.WriteLine("Prosze podac kontener i indeks nowego transportu oddzielone spacjami");
                        string[] case4 = (Console.ReadLine() ?? string.Empty).Split(" ");
                        transports[index].PrzeniesienieKontenera(transports[index].GetKontener(case4[0]),
                            transports[index], transports[int.Parse(case4[1])]);
                        break;
                    case 6:
                        Console.WriteLine(transports[index].AllInfo());
                        break;
                    case 7:
                        index = -1;
                        break;
                }
            }
        }
    }

    private static void AboutKonteners(ref List<Kontener> konteners)
    {
        Console.WriteLine("-----------------------");
        var count = 0;
        foreach (var kontener in konteners)
        {
            Console.WriteLine($"Nr {count} -> {kontener.NrSeryjny}");
            count++;
        }
        Console.WriteLine("-----------------------");
    }
}