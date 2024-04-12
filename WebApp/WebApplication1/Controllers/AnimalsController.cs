using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AnimalsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {   
        
        //otwieranie polaczenia --> using to samo co try, zamyka polaczenie 
        using  SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        //definicja commanda 
        using SqlCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "SELECT * FROM Animal;";
        //wykonanie
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        
        // numery kolumn 
        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        
        //odczytywanie z bazy
        while (reader.Read())
        {
            animals.Add(new Animal()
            {
                //Name=reader["IdAnimal"].ToString()
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name=reader.GetString(nameOrdinal)
            });
        }
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal(AddAnimal animal)
    {
         
        //otwieranie polaczenia --> using to samo co try, zamyka polaczenie 
        using  SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        //definicja commanda 
        using SqlCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = "INSERT INTO Animal VALUES(@animalName,'','','')";
        command.Parameters.AddWithValue("@animalName", animal.Name);
        //wykonanie 
        command.ExecuteNonQuery();
        
        return Created("", null);
    }
}