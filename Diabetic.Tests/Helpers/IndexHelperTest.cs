using Diabetic.Models;
using Diabetic.Models.DTOs;
using Diabetic.Models.Helpers;
using FluentAssertions;
using JetBrains.Annotations;

namespace Diabetic.Tests.Helpers;

[TestSubject(typeof(IndexHelper))]
public class IndexHelperTest
{
    [Theory]
    [InlineData(4.5, 45, 100, 2)]
    [InlineData(24.7, 70, 100, 17)]
    [InlineData(1.5, 45, 100, 0)]
    [InlineData(0, 70, 100, 0)]
    public void GetGlOnIngredient_WithIngredientDto(float carbs, int gi, int amount, int expectedGl)
    {
        IngredientDto ingredient = new IngredientDto
        {
            Product = new Product
            {
                CarbsPer100G = carbs,
                Gi = gi
            },
            Amount = amount
        };

        int result = IndexHelper.GetGlOnIngredient(ingredient);
        result.Should().Be(expectedGl);
    }

    [Theory]
    [InlineData(4.5, 45, 100, 2)]
    [InlineData(24.7, 70, 100, 17)]
    [InlineData(1.5, 45, 100, 0)]
    [InlineData(0, 70, 100, 0)]
    public void GetGlOnIngredient_WithRecipeDto(float carbs, int gi, int amount, int expectedGl)
    {
        Recipe_Ingredients ingredient = new Recipe_Ingredients
        {
            Product = new Product
            {
                CarbsPer100G = carbs,
                Gi = gi
            },
            Amount = amount
        };

        int result = IndexHelper.GetGlOnIngredient(ingredient);
        result.Should().Be(expectedGl);
    }

    [Theory]
    [InlineData(4.5, 45, 100, 2)]
    [InlineData(24.7, 70, 100, 17)]
    [InlineData(1.5, 45, 100, 0)]
    [InlineData(0, 70, 100, 0)]
    public void GetGlOnProduct(float carbs, int gi, int amount, int expectedGl)
    {
        Product product = new Product
        {
            CarbsPer100G = carbs,
            Gi = gi
        };

        int result = IndexHelper.GetGlOnIngredient(product, amount);
        result.Should().Be(expectedGl);
    }

    [Theory]
    [InlineData(100, 100, 100)]
    [InlineData(100, 200, 200)]
    [InlineData(17, 254, 43)]
    public void GetKcalsForProduct(int kcalPer100G, int amount, int expectedKcal)
    {
        Product product = new Product
        {
            KcalPer100G = kcalPer100G
        };

        int result = IndexHelper.GetKcalsForProduct(product, amount);
        result.Should().Be(expectedKcal);
    }

    [Theory]
    [InlineData(100, 100, 200)]
    [InlineData(47, 85, 80)]
    public void GetKcalsForRecipe(int kcalPer100G, int amount, int expectedKcal)
    {
        Product product = new Product
        {
            KcalPer100G = kcalPer100G
        };

        RecipeDto recipe = new RecipeDto
        {
            Ingredients = new List<IngredientDto>
            {
                new IngredientDto
                {
                    Product = product,
                    Amount = amount
                },
                new IngredientDto
                {
                    Product = product,
                    Amount = amount
                }
            }
        };

        int result = IndexHelper.GetKcalsForRecipe(recipe);
        result.Should().Be(expectedKcal);
    }
    
    [Theory]
    [InlineData(100, 15, 30)]
    [InlineData(0, 15, 0)]
    [InlineData(1, 15, 0)]
    [InlineData(15, 15, 4)]
    public void GetGlForRecipe(int carbsPer100G, int gi, int expectedGl)
    {
        Product product = new Product
        {
            CarbsPer100G = carbsPer100G,
            Gi = gi
        };

        RecipeDto recipe = new RecipeDto
        {
            Ingredients = new List<IngredientDto>
            {
                new IngredientDto
                {
                    Product = product,
                    Amount = 100
                },
                new IngredientDto
                {
                    Product = product,
                    Amount = 100
                }
            }
        };

        int result = IndexHelper.GetGlForRecipe(recipe);
        result.Should().Be(expectedGl);
    }
}