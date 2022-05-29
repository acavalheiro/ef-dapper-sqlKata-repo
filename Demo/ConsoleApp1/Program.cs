// See https://aka.ms/new-console-template for more information

using Demo.DapperSqlKata;
using Demo.Domain;
using Demo.EntityFramework;
using Demo.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;


string connectionString = @"Server=VF-PT-023\SQLEXPRESS;Database=Demo;Integrated Security=True;";
Console.WriteLine("Hello, World!");


UsingDapperWithSqlKata();


void UsingEntityFramework()
{
    var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlServer(connectionString)
        .Options;

    using var context = new ApplicationDbContext(contextOptions);

    IManufacturerRepository manufacturerRepository = new ManufacturerRepository(context);

    var allManufacturers = manufacturerRepository.GetAll();

    foreach (var manufactor in allManufacturers)
    {
        Console.WriteLine($"ID: {manufactor.Id} | Name: {manufactor.Name}");
    }


    Console.WriteLine("Please insert your manufactor");
    var newManufactor = Console.ReadLine();


    manufacturerRepository.Add(new Manufacturer() { Name = newManufactor });

    context.SaveChanges();
}


void UsingDapperWithSqlKata()
{
    using var applicationConnection = new ApplicationConnection(connectionString);
    Demo.DapperSqlKata.Repositories.IManufacturerRepository manufacturerRepository = new Demo.DapperSqlKata.Repositories.ManufacturerRepository(applicationConnection);

    var allManufacturers = manufacturerRepository.GetAll();

    foreach (var manufactor in allManufacturers)
    {
        Console.WriteLine($"ID: {manufactor.Id} | Name: {manufactor.Name}");
    }

    Console.ReadLine();
}