List<Car> cars = new List<Car>();
List<Engine> engines = new List<Engine>();

int engineCount = int.Parse(Console.ReadLine());
while (engineCount-- > 0)
{
    String[] str = Console.ReadLine().Split(' ');
    string model = str[0];
    int power = int.Parse(str[1]);
    int displacement = -1;

    if (str.Length == 3 && int.TryParse(str[2], out displacement))
    {
        engines.Add(new Engine(model, power, displacement));
    }
    else if (str.Length == 3)
    {
        string efficiency = str[2];
        engines.Add(new Engine(model, power, efficiency));
    }
    else if (str.Length == 4 && int.TryParse(str[2], out displacement))
    {
        string efficiency = str[3];
        engines.Add(new Engine(model, power, displacement, efficiency));
    }
    else
    {
        engines.Add(new Engine(model, power));
    }
}

int carCount = int.Parse(Console.ReadLine());
for (int i = 0; i< carCount; i++)
{ 
    String[] str = Console.ReadLine().Split(' ');
    string model = str[0];
    string engineModel = str[1];
    Engine engine = engines.Where(x => x.Model == engineModel).FirstOrDefault();
    int weight = -1;

    if (str.Length == 3 && int.TryParse(str[2], out weight))
    {
        cars.Add(new Car(model, engine, weight));
    }
    else if (str.Length == 3)
    {
        string color = str[2];
        cars.Add(new Car(model, engine, color));
    }
    else if (str.Length == 4 && int.TryParse(str[2], out weight))
    {
        string color = str[3];
        cars.Add(new Car(model, engine, weight, color));
    }
    else
    {
        cars.Add(new Car(model, engine));
    }
}

foreach (var car in cars)
{
    Console.WriteLine(car.ToString());
}
        
    
public class Engine
{
    private string model;
    private int power;
    private int displacement = -1;
    private string efficiency = "n/a";
    public string Model { get { return model; } set { model = value; } }
    public int Power { get { return power; } set { power = value; } }
    public int Displacement { get { return displacement; } set { displacement = value; } } 
    public string Efficiency { get { return efficiency; } set { efficiency = value; } } 

    public Engine(string model, int power)
    {
        Model = model;
        Power = power;
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {
        Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        Efficiency = efficiency;
    }
    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public override string ToString()
    {
        string? input = $"  {Model}:";
        input = string.Concat(input, Environment.NewLine);
        input = string.Concat(input, $"    Power: {Power}");
        input = string.Concat(input, Environment.NewLine);
        input = string.Concat(input, Displacement == null ? "    Displacement: n/a" : $"    Displacement: {Displacement}");
        input = string.Concat(input, Environment.NewLine);
        input = string.Concat(input, Efficiency == null ? "    Efficiency: n/a" : $"    Efficiency: {Efficiency}");
        input = string.Concat(input, Environment.NewLine);
        
        return input;
    }
}
public class Car
{
    private string model;
    private Engine engine;
    private int weight = -1;
    private string color = "n/a";
    public string Model { get { return model; } set { model = value; } }
    public Engine Engine { get { return engine; } set { engine = value; } }
    public int Weight { get { return weight; } set { weight = value; } } 
    public string Color { get { return color; } set { color = value; } } 
    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        Color = color;
    }
    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {
        Weight = weight;
        Color = color;
    }
    public override string ToString()
    {
        string? input = $"{Model}:";
        input = string.Concat(input, Environment.NewLine);
        input = string.Concat(input, Engine.ToString());
        input = string.Concat(input, Weight == null ? "  Weight: n/a" : $"  Weight: {Weight}");
        input = string.Concat(input, Environment.NewLine);
        input = string.Concat(input, Color == null ? "  Color: n/a" : $"  Color: {Color}");

        return input;
    }
   
}