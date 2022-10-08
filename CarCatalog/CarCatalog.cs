Car c1 = new("Mercedes", 2015, 320);
Car c2 = new("BMW", 2017, 310);
Car c3 = new("Audi", 2016, 315);
Car c4 = new("Tesla", 2019, 280);
Car c5 = new("Ferrari", 2020, 380);
CarCatalog cars = new(c1, c2, c3, c4, c5);
foreach (var car in cars)
{
    car.Print();
}

Console.WriteLine("==========");
foreach (var car in cars.Reverse())
{
    car.Print();
}

Console.WriteLine("==========");
foreach (var car in cars.Year(2017))
{
    car.Print();
}

Console.WriteLine("==========");
foreach (var car in cars.Speed(310))
{
    car.Print();
}

class CarCatalog
{
    private Car[] _cars;

    public CarCatalog(params Car[] cars) => _cars = cars;

    public IEnumerator<Car> GetEnumerator()
    {
        foreach (var car in _cars)
        {
            yield return car;
        }
    }

    public IEnumerable<Car> Reverse()
    {
        for (var i = _cars.Length - 1; i >= 0; --i)
        {
            yield return _cars[i];
        }
    }

    public IEnumerable<Car> Year(int year)
    {
        foreach (var car in _cars)
        {
            if (car.ProductionYear >= year)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> Speed(int speed)
    {
        foreach (var car in _cars)
        {
            if (car.MaxSpeed >= speed)
            {
                yield return car;
            }
        }
    }
}