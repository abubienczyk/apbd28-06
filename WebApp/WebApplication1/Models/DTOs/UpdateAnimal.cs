namespace WebApplication1.Models.DTOs;
using System.ComponentModel.DataAnnotations;
public class UpdateAnimal
{
    [MaxLength(200)]
    public string Name { get; set; }
    
    //moze byc null
    [MaxLength(200)]
    public string Description  {get; set; }
    
    [MaxLength(200)]
    public string Category  {get; set; }
    
    [MaxLength(200)]
    public string Area  {get; set; }
}