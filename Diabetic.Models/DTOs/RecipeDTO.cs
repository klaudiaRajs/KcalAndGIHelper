﻿using System.ComponentModel;

namespace Diabetic.Models.DTOs
{
    public class RecipeDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientDTO> Ingredients { get; set; } = new List<IngredientDTO>();
        public IEnumerable<Recipe_Ingredients> Recipe_Ingredients { get; set; } = new List<Recipe_Ingredients>();
        [DisplayName("Selected amount of kcals")]
        public double TotalKcal
        {
            get
            {
                double totalKcal = 0;
                Ingredients.ForEach(item => 
                {
                    totalKcal += item.Kcals; 
                });
                return totalKcal; 
            }
        }
        public double TotalGL
        {
            get
            {
                double totalGL = 0;
                Ingredients.ForEach(item =>
                {
                    totalGL += item.GL;
                });
                return totalGL;
            }
        }

        public bool Green { get; set; }
        public bool Orange { get; set; }
        public bool Red { get; set; }

        public bool IsGreen(int gI)
        {
            return gI <= _maxGreenGI;
        }

        public bool IsOrange(int gI)
        {
            return (gI > _maxGreenGI && gI <= _maxOrangeGI);
        }

        public bool IsRed(int gI)
        {
            return gI > _maxOrangeGI;
        }
    }
}
