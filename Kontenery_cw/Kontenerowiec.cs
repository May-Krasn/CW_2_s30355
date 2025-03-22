namespace Kontenery_cw;

public class Kontenerowiec
{
    private static int _iloscTransport = 0;
    public List<Kontener> Kontener = new();
    private double _predkosc, _makswaga, _waga = 0;
    private int _ilosc;
    public string NrSeryjnyTransporta;
    public Kontenerowiec(double predkosc, int ilosc, double waga)
    {
        _iloscTransport++;
        
        _predkosc = predkosc;
        _ilosc = ilosc;
        _makswaga = waga;
        NrSeryjnyTransporta = $"TR-KON-{_iloscTransport}";
    }

    public void AddKontener(Kontener kontener)
    {
        if (Kontener.Contains(kontener))
        {
            Console.WriteLine($"--> Blad. Kontener juz byl dodany: {kontener.NrSeryjny} -> {NrSeryjnyTransporta}");
            return;
        }

        if (Kontener.Count == _ilosc || _waga + kontener.WagaWlasna + kontener.MasaLadunku > _makswaga)
        {
            Console.WriteLine($"--> Odmowa. Kontener {kontener.NrSeryjny} nie moze byc dodany, nie ma miejsca na kontenerze {NrSeryjnyTransporta}");
            return;
        }
        
        Kontener.Add(kontener);
        _waga += kontener.WagaWlasna + kontener.MasaLadunku;
        Console.WriteLine($"--> Kontener {kontener.NrSeryjny} byl dodany na kontenerowiec {NrSeryjnyTransporta}");
    }

    public void AddListKonteners(List<Kontener> list)
    {
        int added = 0, odmowa = 0;
        foreach (var kontener in list)
        {
            AddKontener(kontener);
            if (Kontener.Contains(kontener)) added++;
            else odmowa++;
        }
        
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"{added} byly dodane na kontenerowiec, {odmowa} dostaly odmowe");
    }

    public void DeleteKontener(Kontener kontener)
    {
        if (!Kontener.Contains(kontener))
        {
            Console.WriteLine($"Kontenera {kontener.NrSeryjny} nie ma na transporcie {NrSeryjnyTransporta}");
            return;
        }
        Kontener.Remove(kontener);
        _waga -= kontener.WagaWlasna + kontener.MasaLadunku;
    }

    public void ChangeKontener(Kontener kontener1, Kontener kontener2)
    {
        DeleteKontener(kontener1);
        if (Kontener.Contains(kontener1))
        {
            Console.Write("Blad w trakcie usuniecia kontenera, odmawiam zaladowanie nowego");
            return;
        }
        AddKontener(kontener2);
    }

    public void PrzeniesienieKontenera(Kontener kontener, Kontenerowiec kont1, Kontenerowiec kont2)
    {
        kont1.DeleteKontener(kontener);
        if (kont1.Kontener.Contains(kontener)) return;
        kont2.AddKontener(kontener);
    }

    public Kontener GetKontener(String nrSer)
    {
        return Kontener.Find(x => x.NrSeryjny == nrSer)!;
    }

    public string ToString()
    {
        return $"-> Transport: {NrSeryjnyTransporta};\n-> Ilosc kontenerow zaladowanych: {Kontener.Count}";
    }

    public string KontenersToString()
    {
        return $"Transport {NrSeryjnyTransporta}:\n-> Kontenery na transporcie: " 
               + string.Join(Kontener.Count == 0 ? "Brak" : "\n", Kontener.Select(kontener => kontener.NrSeryjny));
    }
    
    public string AllInfo()
    {
        return
            $"Transport {NrSeryjnyTransporta}:\n-> Predkosc: {_predkosc};\n-> Maksymalna waga: {_makswaga};\n-> Waga: {_waga};" +
            $"\n-> Maksymalna ilosc: {_ilosc};\n-> Kontenery na transporcie: " 
            + string.Join(Kontener.Count == 0 ? "Brak" : "\n", Kontener.Select(kontener => kontener.NrSeryjny));
    }
}