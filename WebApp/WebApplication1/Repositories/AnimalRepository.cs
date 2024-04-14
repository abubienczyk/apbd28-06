using System.Security.Cryptography;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy="Name")
    {
        // Otwieramy połączenie do bazy danych
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        // Definicja commanda
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy};";
        //command.Parameters.AddWithValue("@orderBy", orderBy);
        
        // Wykonanie commanda
        var reader = command.ExecuteReader();

        var animals = new List<Animal>();

        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int descriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal=reader.GetOrdinal("Category");
        int areaOrdinal=reader.GetOrdinal("Area");

        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Description=reader.GetString(descriptionOrdinal),
                Category = reader.GetString(categoryOrdinal),
                Area = reader.GetString(areaOrdinal)
            });
        }

        return animals;
    }

    public void AddAnimal(AddAnimal animal)
    {
        // Otwieramy połączenie do bazy danych
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        // Definicja commanda
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES(@animalName, '', '', '')";
        command.Parameters.AddWithValue("@animalName", animal.Name);
        
        // Wykonanie commanda
        command.ExecuteNonQuery();
    }

    public void UpdateAnimal(UpdateAnimal animal)
    {
        // Otwieramy połączenie do bazy danych
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        // Definicja commanda
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "UPDATE Animal SET name=@animalName,description=@animalDescription,category=@animalCategory,area=@animalArea ";
        command.Parameters.AddWithValue("@animalName", animal.Name);
        command.Parameters.AddWithValue("@animalDescription", animal.Description);
        command.Parameters.AddWithValue("@animalCategory", animal.Category);
        command.Parameters.AddWithValue("@animalArea", animal.Area);
        
        // Wykonanie commanda
        command.ExecuteNonQuery();
    }

    public void DeleteAnimal(DeleteAnimal animal)
    {
        // Otwieramy połączenie do bazy danych
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        // Definicja commanda
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Animal WHERE IdAnimal=@animalID ";
        command.Parameters.AddWithValue("@animalID", animal.IdAnimal);
        // Wykonanie commanda
        command.ExecuteNonQuery();

    }
    
}