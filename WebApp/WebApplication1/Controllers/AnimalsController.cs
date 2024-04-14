using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalsController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    [HttpGet]
    public IActionResult GetAnimals(string orderBy="name")
    {
        var animals = _animalRepository.GetAnimals();

        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal(AddAnimal animal)
    {
        _animalRepository.AddAnimal(animal);
        
        return Created("", null);
    }
    //PUT --> aktualizacja
    [HttpPut("{idAnimal}")]
    public IActionResult UpdateAnimal( UpdateAnimal animal)
    {
        _animalRepository.UpdateAnimal(animal);
        return Ok("sucess");
    }

    //DELETE /api/animals/{idAnimal}
    [HttpDelete("{idAnimal}")]
    public IActionResult DeleteAnimal(DeleteAnimal animal)
    {
        _animalRepository.DeleteAnimal(animal);
        return Ok("sucess");
    }
}