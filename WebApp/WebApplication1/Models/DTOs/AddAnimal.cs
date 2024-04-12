using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class AddAnimal
{
    //walidacja danych - obowiazkowe pole jak nie ma to blad
    [Required]
    // dlugosc 
    [MinLength(5)]
    public string Name { get; set; }
}