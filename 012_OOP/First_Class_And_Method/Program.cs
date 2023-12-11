using FirstClassAndMethod;

Console.Clear();
Console.WriteLine("Please input some names:");
List<Person> names = new List<Person> ();
for(int i = 0; i < 3; i++) {
    names.Add(new Person(Console.ReadLine()));
}
foreach(Person person in names) {
    Console.WriteLine("Hello! My name is " + person.ToString());
}