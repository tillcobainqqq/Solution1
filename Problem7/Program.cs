using System;

int value = int.Parse(Console.ReadLine());
List<Car> carsList = new List<Car>();

string[] words;
for (int i = 0; i < value; i++)
{
    words = Console.ReadLine().Split(' ');
    string model = words[0];
    double fuelAmount = double.Parse(words[1]);
    double fuelConsumptonFor1Km = double.Parse(words[2]);
    Car car = new Car(model, fuelAmount, fuelConsumptonFor1Km, 0);
    carsList.Add(car);
}

words = Console.ReadLine().Split(' ');

while (words[0] != "End")
{
    string carModel = words[1];
    int amountOfKm = int.Parse(words[2]);
    Car currentCar = carsList.FirstOrDefault(c => c.Model == carModel);

    if (currentCar.Model.Length > 0)
    {
        double currentModelFuelConsPerKm = currentCar.FuelConsumptionFor1Km;
        double fuelConsumed = currentCar.Drive(amountOfKm, currentModelFuelConsPerKm);
        double currentModelFuel = currentCar.FuelAmount;

        if (currentModelFuel >= fuelConsumed)
        {
            currentCar.FuelAmount -= fuelConsumed;
            currentCar.DistanceTravelled += amountOfKm;
        }
        else Console.WriteLine("Insufficient fuel for the drive");
    }
    words = Console.ReadLine().Split();
}
foreach (var car in carsList)
{
    Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravelled}");
}
public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionFor1Km;
    private int distanceTravelled;
    public string Model { get { return model; } set { model = value; } }
    public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
    public double FuelConsumptionFor1Km { get { return fuelConsumptionFor1Km; } set { fuelConsumptionFor1Km = value; } }
    public int DistanceTravelled { get { return distanceTravelled; } set { distanceTravelled = value; } }
    public Car (string model, double fuelAmount, double fuelConsumptionFor1Km, int distanceTravelled)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionFor1Km = fuelConsumptionFor1Km;
        DistanceTravelled = distanceTravelled;
    }

    public double Drive(double distanceTravelled, double fuelConsumptionFor1Km)
    {
        return distanceTravelled * fuelConsumptionFor1Km;
    }
}