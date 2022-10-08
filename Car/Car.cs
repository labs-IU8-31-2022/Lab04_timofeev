Car c1 = new("Mercedes", 2015, 320);
Car c2 = new("BMW", 2017, 310);
Car c3 = new("Audi", 2016, 315);
Car c4 = new("Tesla", 2019, 280);
Car c5 = new("Ferrari", 2020, 380);
Car[] cars = { c1, c2, c3, c4, c5 };
foreach (var i in cars)
{
    i.Print();
}
Console.WriteLine("Выберите тип сортировки: \n1 - по имени\n2 - по году выпуска\n3 - по скорости");
int a = Convert.ToInt32(Console.ReadLine());
switch(a)
{
    case 1:
        Car.CompMethod = "name";
        break;
    case 2:
        Car.CompMethod = "year";
        break;
    case 3:
        Car.CompMethod = "speed";
        break;
    default:
        Car.CompMethod = "name";
        break;
}
Array.Sort(cars, new CarComparer());
foreach (var i in cars)
{
    i.Print();
}

public class Car
{
    public string Name { get; }
    public int ProductionYear { get; }
    public int MaxSpeed { get; }

    public static string CompMethod = "";
    public Car(string name, int year, int speed) => (Name, ProductionYear, MaxSpeed) = (name, year, speed);

    public void Print() =>
        Console.WriteLine($"{Name} {ProductionYear} года выпуска с максимальной скоростью {MaxSpeed}");
}

class CarComparer : IComparer<Car>
{
    int IComparer<Car>.Compare(Car? x, Car? y)
    {
        if (x is null || y is null)
        {
            return 0;
        }

        return Car.CompMethod switch
        {
            "name" => x.Name.CompareTo(y.Name),
            "year" => x.ProductionYear.CompareTo(y.ProductionYear),
            "speed" => x.MaxSpeed.CompareTo(y.MaxSpeed),
            _ => x.MaxSpeed.CompareTo(y.MaxSpeed)
        };
    }
}