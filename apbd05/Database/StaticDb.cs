using apbd05.Models;

namespace apbd05.DataBase;

public class StaticDb
{
    public static HashSet<Animal> Animals { get; set; }
    public static HashSet<Visit> Visits { get; set; }
}