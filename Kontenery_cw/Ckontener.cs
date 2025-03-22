namespace Kontenery_cw;

public class Ckontener : Kontener
{
    
    private double _temperature;
    private string _produkt;
    private bool _canUse;
    
    public Ckontener(double wysokosc, double wagaWlasna, double glebokosc, double ladownosc, string typ, double temperature, string produkt) 
        : base(wysokosc, wagaWlasna, glebokosc, ladownosc, typ)
    {

        while (!Produkty.ContainsKey(produkt))
        {
            Console.WriteLine("Produkt nie istnieje, prosze podac inny produkt z dostepnych: ");
            WriteDict();
            produkt = Console.ReadLine() ?? string.Empty;
        }
        
        _produkt = produkt;
        _temperature = temperature;
        _canUse = true;
        MasaLadunku = 0;
        CheckTemp(produkt, temperature);
    }

    public void SetProdukt(string produkt)
    {
        if (MasaLadunku != 0)
        {
            DangerAlert();
            Console.WriteLine("Kontener nie jest pusty, nie ma mozliwosci zmiany produktu");
        }
        else
        {
            _produkt = produkt;
            CheckTemp(produkt, _temperature);
        }
        
    }

    public void SetTemp(double temperature)
    {
        if (MasaLadunku != 0)
        {
            DangerAlert();
            Console.WriteLine("Kontener nie jest pusty, nie ma mozliwosci zmiany temperatury");
        }
        else
        {
            _temperature = temperature;
            CheckTemp(_produkt, temperature);
        }
    }
    
    private void CheckTemp(string produkt, double temperature)
    {
        if (Produkty[produkt].CompareTo(temperature) < 0)
        {
            _canUse = false;
            DangerAlert();
            Console.WriteLine("Produkt nie moze byc przechowywany w tym kontenerze, prosze o zmiane ustawien");
            
            Console.Write("Podac nowa temperature teraz? 'Y' or 'N': ");
            if ((Console.ReadLine() ?? string.Empty).Equals("Y"))
            {
                Console.Write("Nowa temperature: ");
                _temperature = Double.Parse(Console.ReadLine() ?? string.Empty);
                CheckTemp(produkt, _temperature);
            }
        }
        else
        {
            _canUse = true;
            Console.WriteLine("Kontener gotowy do pracy");
        }
    }
    
    public override void Oproznienie()
    {
        MasaLadunku = 0;
        Console.WriteLine($"Masa Ladunku kontenera {NrSeryjny}: {MasaLadunku}");
    }

    public void Zaladowanie(double ile, string produkt)
    {
        if (!_canUse)
        {
            Console.WriteLine("Nie moge uzyc tego kontenera");
            return;
        }
        
        if (produkt == _produkt) Zaladowanie(ile);
        else
        {
            DangerAlert();
            Console.WriteLine($"Kontener do produktu {_produkt}");
        }
    }

    public override void Zaladowanie(double ile)
    {
        if (!_canUse)
        {
            Console.WriteLine("Nie moge uzyc tego kontenera");
            return;
        }
        if (MasaLadunku + ile > Ladownosc)
        {
            DangerAlert();
            throw new OverfillException("Przekroczono ladownosc");
        }
        MasaLadunku += ile;
        Console.WriteLine($"Masa Ladunku kontenera {NrSeryjny}: {MasaLadunku}");
    }

    public override string ToString()
    {
        return $"Kontener {NrSeryjny}:\n-> Ladownosc: {Ladownosc};\n-> Masa Ladunku: {MasaLadunku};" +
               $"\n-> Produkt: {_produkt};\n-> Temperature: {_temperature};";
    }


    private static readonly Dictionary<string, double> Produkty = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18.0 },
        { "Fish", 2.0 },
        { "Meat", -15.0 },
        { "Ice cream", -18.0 },
        { "Frozen pizza", -30.0 },
        { "Cheese", 7.2 },
        { "Sausages", 5.0 },
        { "Butter", 20.5 },
        { "Eggs", 19.0 }
    };

    public static void WriteDict()
    {
        foreach (var pr in Produkty) Console.WriteLine($"--> {pr.Key}: {pr.Value}");
    }
    
    public override string AllInfo()
    {
        return $"Kontener {NrSeryjny}:\n-> Wysokosc: {Wysokosc};\n-> Glebokosc: {Glebokosc};" +
               $"\n-> Waga Wlasna: {WagaWlasna};\n-> Ladownosc: {Ladownosc};\n-> Masa Ladunku: {MasaLadunku};" +
               $"\n-> Produkt: {_produkt};\n-> Temperature: {_temperature};";
    }
}