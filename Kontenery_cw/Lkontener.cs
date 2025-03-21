namespace Project1;

public class Lkontener : Kontener
{
    private readonly bool _niebezp;
    
    public Lkontener(double wysokosc, double wagaWlasna, double glebokosc, double ladownosc, string typ, bool niebezpieczny) 
        : base(wysokosc, wagaWlasna, glebokosc, ladownosc, "L")
    {
        _niebezp = niebezpieczny;
        MasaLadunku = 0;
    }

    public override void Oproznienie()
    {
        MasaLadunku = 0;
        Console.WriteLine($"Masa Ladunku kontenera {NrSeryjny}: {MasaLadunku}");
    }

    public override void Zaladowanie(double ile)
    {
        var maksimum = _niebezp ? Ladownosc * 0.5f : Ladownosc * 0.9f;
        if (MasaLadunku + ile > maksimum)
        {
            DangerAlert();
            throw new OverfillException("Przekroczono ladownosc");
        }
        MasaLadunku += ile;
    }

    public override string ToString()
    {
        return $"Kontener {NrSeryjny}:\n-> Ladownosc: {Ladownosc};\n-> Masa Ladunku: {MasaLadunku};" +
               $"\n-> Niebezpieczny: {_niebezp};";
    }    
    
    public override string AllInfo()
    {
        return $"Kontener {NrSeryjny}:\n-> Wysokosc: {Wysokosc};\n-> Glebokosc: {Glebokosc};" +
               $"\n-> Waga Wlasna: {WagaWlasna};\n-> Ladownosc: {Ladownosc};\n-> Masa Ladunku: {MasaLadunku};" +
               $"\n-> Niebezpieczny?: {_niebezp};";
    }
    
}