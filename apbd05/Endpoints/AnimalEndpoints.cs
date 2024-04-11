using apbd05.DataBase;
using apbd05.Models;

namespace apbd05.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", () =>
        {
            return Results.Ok(StaticDb.Animals);
        });
        app.MapPost("/animals", (Animal animal) =>
        {
            StaticDb.Animals.Add(animal);
            return Results.Created("", animal);
        });
        app.MapGet("/animals/{id:int}", (int id) =>
        {
            var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
            return animal==null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
        });
        app.MapPut("/animals/{id:int}", (int id, Animal animal) =>
        {
            var animalToEdit = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
            if (animalToEdit==null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            StaticDb.Animals.Remove(animalToEdit);
            StaticDb.Animals.Add(animal);
            return Results.NoContent();
        });
        app.MapDelete("/animals/{id:int}", (int id) => { 
            var animal = StaticDb.Animals.FirstOrDefault(a => a.Id == id);
            if (animal==null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            StaticDb.Animals.Remove(animal);
            return Results.NoContent();
            
        });
    }
}