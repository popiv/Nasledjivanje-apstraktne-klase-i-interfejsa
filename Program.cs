using System;


Employee employee = new Employee("Milovan", 30, 5);

employee.Earn(99990000);
employee.Spend(1000000);
employee.Spend(3000000000);
employee.Spend(-1000000);

public abstract class Person
{
    public string Ime { get; set; }
    public int GodineStarosti { get; set; }


    public Person(string ime, int godineStarosti)
    {
        Ime = ime;
        GodineStarosti = godineStarosti;
    }
}

public interface IPayable
{
    void Earn(double iznos);
    void Spend(double iznos);
}

public class Employee : Person, IPayable



{

    public int Staz { get; set; }


    public double BankovniRacun { get; private set; } = 200000;

    public Employee(string ime, int godineStarosti, int staz)
        : base(ime, godineStarosti)
    {
        Staz = staz;
    }


    public void Earn(double iznos)
    {
        if (iznos > 0)
        {
            BankovniRacun += iznos;
            Console.WriteLine($"{Ime} je zaradio {iznos} dinara. Trenutno stanje: {BankovniRacun} dinara.");
        }
        else
        {
            Console.WriteLine("Iznos mora biti pozitivan.");
        }
    }

    public void Spend(double iznos)
    {
        if (iznos > 0 && iznos <= BankovniRacun)
        {
            BankovniRacun -= iznos;
            Console.WriteLine($"{Ime} je potrošio {iznos} dinara. Trenutno stanje: {BankovniRacun} dinara.");
        }
        else if (iznos > BankovniRacun)
        {
            Console.WriteLine("Transakcija nije moguća. Nemate dovoljno sredstava na računu.");
        }
        else
        {
            Console.WriteLine("Iznos mora biti pozitivan");
        }
    }
}

