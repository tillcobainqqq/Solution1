using System;

Person person1 = new Person();
Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

Person person2 = new Person(20);
Console.WriteLine("person2 Name = {0} Age = {1}", person2.Name, person2.Age);

Person person3 = new Person("Stamat", 43);
Console.WriteLine("person3 Name = {0} Age = {1}", person3.Name, person3.Age);

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