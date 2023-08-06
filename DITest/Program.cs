var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<Person>();
builder.Services.AddScoped<Taiwanese>();
builder.Services.AddSingleton<PersonOnSingleton>();

var app = builder.Build();

app.MapGet("/person", (Person person) => { });
app.MapGet("/taiwanese", (Taiwanese person) => { });
app.MapGet("/persononsingleton", (PersonOnSingleton person) => { });
app.Run();

class Person
{
    public Person() => Console.WriteLine($"Init Person");
}

class Taiwanese
{
    public Taiwanese() => Console.WriteLine($"Init Taiwanese");
}

class PersonOnSingleton
{
    public PersonOnSingleton()
    {
        Console.WriteLine($"Singleton Init Person");
    }
}