using WebApplication1.Models;
using WebApplication1.Models.DTOs;
namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orederBy="name");
    void AddAnimal(AddAnimal animal);

    void UpdateAnimal( UpdateAnimal animal);
    //void UpdateAnimal(int ID, UpdateAnimal animal);

    void DeleteAnimal(DeleteAnimal animal);
    //void DeleteAnimal(int ID);
}