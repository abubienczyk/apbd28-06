using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class AddAnimal
{
    //walidacja danych - obowiazkowe pole jak nie ma to blad
   
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    //moze byc null
    [MaxLength(200)]
    public string Description  {get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Category  {get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Area  {get; set; }
    
}