namespace Kontenery_cw;

public class Gkontener : Kontener
{
    
    public Gkontener(double wysokosc, double wagaWlasna, double glebokosc, double ladownosc, string typ) 
        : base(wysokosc, wagaWlasna, glebokosc, ladownosc, typ)
    {
        MasaLadunku = ladownosc * 0.05f;
    }

    public override void Oproznienie()
    {
        DangerAlert();
    }

    public override void Zaladowanie(double ile)
    {
        if (MasaLadunku + ile > Ladownosc)
        {
            DangerAlert();
            throw new OverfillException("Przekroczono ladownosc!");
        }
        MasaLadunku += ile;
    }
    
    public override string ToString()
    {
        return $"Kontener {NrSeryjny}:\n-> Ladownosc: {Ladownosc};\n-> Masa Ladunku: {MasaLadunku};";
    }

    public override string AllInfo()
    {
        return $"Kontener {NrSeryjny}:\n-> Wysokosc: {Wysokosc};\n-> Glebokosc: {Glebokosc};" +
               $"\n-> Waga Wlasna: {WagaWlasna};\n-> Ladownosc: {Ladownosc};\n-> Masa Ladunku: {MasaLadunku};";
    }

}