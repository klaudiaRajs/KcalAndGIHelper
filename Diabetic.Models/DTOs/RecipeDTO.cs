using System.ComponentModel;

namespace Diabetic.Models.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientDTO> Ingredients { get; set; } = new List<IngredientDTO>();
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
        public int _maxGreen { get; set; } = 39;
        public int _maxOrange { get; set; } = 55;
        public bool IsGreen(int gI)
        {
            return gI <= _maxGreen;
        }

        public bool IsOrange(int gI)
        {
            return (gI > _maxGreen && gI <= _maxOrange);
        }

        public bool IsRed(int gI)
        {
            return gI > _maxOrange;
        }
    }
}
