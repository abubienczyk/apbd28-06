using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> SetAnimal();
    void addAnimal(Animal animal);
}