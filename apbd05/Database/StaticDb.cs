using apbd05.Models;

namespace apbd05.DataBase;

public class StaticDb
{
    public static List<Animal> Animals { get; set; }=new List<Animal>();
    public static List<Visit> Visits { get; set; } = new List<Visit>();
}