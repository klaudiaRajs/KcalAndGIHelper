namespace Diabetic.Models.DTOs.Interfaces;

public interface IIngredient
{
    public Product Product { get; set; }
    public int Amount { get; set; } 
}