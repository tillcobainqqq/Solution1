int value = int.Parse(Console.ReadLine()!);
List<Employee> employeesList = new List<Employee>();

for (int i = 0; i < value; i++)
{
    String[] words = Console.ReadLine().Split(' ');
    Employee employee = GetEmployee(words);
    employeesList.Add(employee);
}

PrintResult(employeesList);

Employee GetEmployee(string[] words)
{
    Employee employee = new Employee(words[0], decimal.Parse(words[1]), words[2], words[3]);

    if (words.Length > 4)
    {
        int.TryParse(words[4], out int result);
        if (result == 0) employee.Email = words[4];
        else employee.Age = int.Parse(words[4]);
    }
    if (words.Length > 5) employee.Age = int.Parse(words[5]);
    return employee;
}
void PrintResult(List<Employee> employeesList)
{
    var result = employeesList
        .GroupBy(e => e.Department)
        .Select(e => new
        {
            Department = e.Key,
            AverageSalary = e.Average(emp => emp.Salary),
            Employees = e.OrderByDescending(emp => emp.Salary)
        })
        .OrderByDescending(emp => emp.AverageSalary)
        .FirstOrDefault();

    if (result != null)
    {
        Console.WriteLine($"Highest Average Salary: {result.Department}");

        IOrderedEnumerable<Employee> bestDepartmentEmployees = employeesList
            .Where(emp => emp.Department == result.Department).OrderByDescending(emp => emp.Salary);

        foreach (Employee emp in bestDepartmentEmployees)
        {
            Console.WriteLine((object?)$"{emp.Name} {emp.Salary} {emp.Email} {emp.Age}");
        }
    }
}

public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;
    
    public string Name { get { return name; } set { name = value; } }
    public decimal Salary { get { return salary; } set { salary = value; } }
    public string Position { get { return position; } set { position = value; } }
    public string Department { get { return department; } set { department = value; } }
    public string Email { get { return email; } set { email = value; } }
    public int Age { get { return age; } set { age = value; } }

    public Employee(string name, decimal salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
        Email = "n/a";
        Age = -1;
    }
}
