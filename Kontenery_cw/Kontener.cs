namespace Kontenery_cw;

public abstract class Kontener : IHazardNotifier
{
    protected static int NrSeryjnyInt = 0;

    protected double Masa { get; set; }
    protected double Wysokosc { get; set; }
    protected double Glebokosc { get; set; }
    protected double Ladownosc { get; set; }
    public double MasaLadunku { get; set; }
    public double WagaWlasna { get; set; }
    public string NrSeryjny { get; set; }
    
    protected Kontener(double wysokosc, double wagaWlasna, double glebokosc, double ladownosc, string typ)
    {
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        Ladownosc = ladownosc;
        NrSeryjny = $"KON-{typ}-{NrSeryjnyInt}";
        NrSeryjnyInt++;
    }
    public abstract void Oproznienie();
    
    public void Oproznienie(double ile)
    {
        double min;
        if (NrSeryjny[4] == 'G') min = Ladownosc * 0.05f;
        else min = 0;
        
        if (MasaLadunku - ile < min) DangerAlert();
        else
        {
            MasaLadunku -= ile;
            Console.WriteLine($"Masa Ladunku kontenera {NrSeryjny}: {MasaLadunku}");
        }
    }
    public abstract void Zaladowanie(double ile);

    public void DangerAlert()
    {
        Console.WriteLine($"Niebezpieczna sytuacja w kontenerze {NrSeryjny}");
    }

    public abstract string AllInfo();
}