using System;

int value = int.Parse(Console.ReadLine());
string str;
List<Person> family = new List<Person>();

for (int i = 0; i < value; i++)
{
    str = Console.ReadLine();
    String[] words1 = str.Split(' ');
    if (int.Parse(words1[1])>30)
    {
        Person person = new Person(words1[0], int.Parse(words1[1]));
        family.Add(person);
    }
}
foreach (var per in family.OrderBy(per => per.Name))
{
    Console.WriteLine($"{per.Name} - {per.Age}");
}
public class Person
{
    private string name;
    private int age;

    public string Name { get { return name; } set { name = value; } }
    public int Age { get { return age; } set { age = value; } }

    public Person()
    {
        Name = "No name";
        Age = 1;
    }
    public Person(int age)
    {
        Name = "No name";
        Age = age;
    }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}