List<Car> cars = new List<Car>();

int carsCount = int.Parse(Console.ReadLine());
for (int i = 0; i < carsCount; i++)
{
    String[] carInfo = Console.ReadLine().Split();
    
    string model = carInfo[0];
    int engineSpeed = int.Parse(carInfo[1]);
    int enginePower = int.Parse(carInfo[2]);
    int cargoWeight = int.Parse(carInfo[3]);
    string cargoType = carInfo[4];
    Tire[] tires = new Tire[4]
    {
        new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
        new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
        new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
        new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12])),
    };
    
    Engine engine = new Engine(engineSpeed, enginePower);
    Cargo cargo = new Cargo(cargoWeight, cargoType);
    Car car = new Car(model, engine, cargo, tires);
    cars.Add(car);
}
string cargoT = Console.ReadLine();

if (cargoT == "fragile")
{
    foreach (Car carr in cars.Where(c => c.Cargo.Type == "fragile" 
                                        && c.Tires.Where(t => t.Pressure < 1)
                                            .FirstOrDefault() != null))
    {
        Console.WriteLine($"{carr.Model}");
    }
}
else if (cargoT == "flamable")
{
    foreach (Car carr in cars.Where(c => c.Cargo.Type == "flamable" 
                                        && c.Engine.Power > 250))
    {
        Console.WriteLine($"{carr.Model}");
    }
}



public class Engine
{
    private int speed;
    private int power;
    
    public int Speed { get { return speed; } set { speed = value; } }
    public int Power { get { return power; } set { power = value; } }
    public Engine(int speed, int power)
    {
        Speed = speed;
        Power = power;
    }
}
public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    public Tire[] tires;
    
    public string Model { get { return model; } set { model = value; } }
    public Engine Engine { get { return engine; } set { engine = value; } }
    public Cargo Cargo { get { return cargo; } set { cargo = value; } }
    public Tire[] Tires { get { return tires; } set { tires = value; } }

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires = tires;
        if (tires.Length != 4)
        {
            throw new InvalidOperationException("Error");
        }
    }
}

public class Cargo
{
    private int weight;
    private string type;

    public int Weight { get { return weight; } set { weight = value; } }

    public string Type { get { return type; } set { type = value; } }

    public Cargo(int weight, string type)
    {
        Weight = weight;
        Type = type;
    }
}

public class Tire
    {
        private double age;
        private double pressure;

        public double Age { get { return age; } set { age = value; } }
        public double Pressure { get { return pressure; } set { pressure = value; } }
        public Tire(double age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }

