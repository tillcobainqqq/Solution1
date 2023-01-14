using System;

Family.value = int.Parse(Console.ReadLine());

for (int i = 0; i < Family.value; i++)
{
    String[] words1 = Console.ReadLine().Split(' ');
    Person person = new Person(words1[0], int.Parse(words1[1]));
    Family.AddMember(person);
}

Person OlderPerson = new Person();
OlderPerson = Family.GetOldestMember();
Console.WriteLine($"{OlderPerson.Name} {OlderPerson.Age}");

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

public class Family
{
    static List<Person> family = new List<Person>();
    public static int value;
    public static void AddMember(Person member)
    {
        family.Add(member);
    }

    public static Person GetOldestMember()
    {
        int max = 0;
        Person maxPerson = null;
        for (int i = 0; i < value; i++)
        {
            if (family[i].Age > max){
                max = family[i].Age;
                maxPerson = family[i];
            }
        }
        return maxPerson;
    }
}