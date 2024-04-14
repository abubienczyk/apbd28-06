using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class DeleteAnimal
{
    [Required]
    public int IdAnimal { get; set; }
    
}