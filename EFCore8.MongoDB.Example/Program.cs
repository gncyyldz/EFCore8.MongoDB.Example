using EFCore8.MongoDB.Example.Entities;
using EFCore8.MongoDB.Example.Modals;
using EFCore8.MongoDB.Example.Services;
using EFCore8.MongoDB.Example.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region MongoDB.Driver
builder.Services.AddSingleton<MongoDBService>();
#endregion

#region MongoDB Entity Framework Core Provider
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMongoDB("mongodb://localhost:27017", "ExampleDB"));
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

#region MongoDB.Driver
//app.MapPost("/create-person", async (PersonVM personVM, MongoDBService mongoDBService) =>
//{
//    IMongoCollection<Person> personCollection = mongoDBService.GetCollection<Person>();
//    await personCollection.InsertOneAsync(new()
//    {
//        Name = personVM.Name,
//        Surname = personVM.Surname,
//        Age = personVM.Age,
//    });
//});
//app.MapGet("/get-persons", async (MongoDBService mongoDBService) =>
//{
//    IMongoCollection<Person> personCollection = mongoDBService.GetCollection<Person>();
//    return await (await personCollection.FindAsync(p => true)).ToListAsync();
//});
#endregion

#region MongoDB Entity Framework Core Provider
app.MapPost("/create-database", async (ApplicationDbContext context) => context.Database.EnsureCreated());
app.MapPost("/create-person", async (PersonVM personVM, ApplicationDbContext context) =>
{
    await context.Persons.AddAsync(personVM);
    await context.SaveChangesAsync();
});
app.MapGet("/get-persons", async (ApplicationDbContext context) => await context.Persons.ToListAsync());
#endregion


app.Run();
