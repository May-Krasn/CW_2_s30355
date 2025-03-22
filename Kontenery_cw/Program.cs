using Kontenery_cw;

List<Kontener> konteners = new List<Kontener>();
List<Kontenerowiec> transports = new List<Kontenerowiec>();

bool stop = false;

while (!stop) 
{
    Console.WriteLine("Lista Kontenerow: ");
    if (konteners.Count == 0) Console.WriteLine("Brak");
    else foreach (var kontener in konteners) Console.WriteLine(kontener.ToString());
    Console.WriteLine("\nLista Kontenerowcow:");
    if (transports.Count == 0) Console.WriteLine("Brak");
    else foreach (var transport in transports) Console.WriteLine(transport.ToString());
    
    
    Console.WriteLine("\nMozliwe akcje:");
    Console.WriteLine("1. Stworz kontener");
    Console.WriteLine("2. Praca z kontenerem");
    Console.WriteLine("3. Stworz kontenerowiec");
    Console.WriteLine("4. Praca z kontenerowcem");
    Console.WriteLine("5. Skonczyc prace");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            CreatingKont.CreateKontener(ref konteners);
            break;
        case "2":
            if (konteners.Count == 0)
            {
                Console.WriteLine("Najpierw prosze utworzyc kontener");
                break;
            }
            Console.Clear();
            EditKont.EditKontener(ref konteners);
            break;
        case "3":
            Console.Clear();
            CreatingTransport.CreateTransport(ref transports);
            break;
        case "4": 
            EditingTransport.EditTransport(ref transports, ref konteners);
            break;
        case "5":
            Console.WriteLine("Goodbye");
            stop = true;
            break;
    }
}