using Microsoft.EntityFrameworkCore;
using Diabetic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Diabetic.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Recipe_Ingredients> Recipe_Ingredients { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Day_Recipe> Day_Recipes { get; set; }
        public DbSet<MealRecipe> MealRecipes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient_Meal_Day> Ingredient_Meal_Days { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Warzywa" },
                new Category { Id = 2, Name = "Owoce" },
                new Category { Id = 3, Name = "Produkty zbożowe" },
                new Category { Id = 4, Name = "Orzechy" },
                new Category { Id = 5, Name = "Nabiał" },
                new Category { Id = 6, Name = "Mięso, ryby, jaja" },
                new Category { Id = 7, Name = "Słodycze" },
                new Category { Id = 8, Name = "Sosy" }
            );

            #region Products 
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "marchew", KcalPer100g = 33, GI = 20, CategoryId = 1 },
                new Product { Id = 2, Name = "marchewka gotowana", KcalPer100g = 33, GI = 39, CategoryId = 1 },
                new Product { Id = 3, Name = "groszek zielony", KcalPer100g = 86, GI = 51, CategoryId = 1 },
                new Product { Id = 4, Name = "słodka kukurydza", KcalPer100g = 80, GI = 52, CategoryId = 1 },
                new Product { Id = 5, Name = "ziemniak gotowany", KcalPer100g = 1000, GI = 56, CategoryId = 1 },
                new Product { Id = 6, Name = "bób (surowy)", KcalPer100g = 76, GI = 40, CategoryId = 1 },
                new Product { Id = 7, Name = "Śliwka czerwona", KcalPer100g = 46, GI = 53, CategoryId = 2},
                new Product { Id = 8, Name = "Płatki orkiszowe", KcalPer100g = 330, GI = 45, CategoryId = 3, GramsPerPortion = 50 },
                new Product { Id = 9, Name = "ziemniak pieczony", KcalPer100g = 79, GI = 69, CategoryId = 1 },
                new Product { Id = 10, Name = "bakłażan", KcalPer100g = 26, GI = 20, CategoryId = 1 },
                new Product { Id = 11, Name = "burak", KcalPer100g = 42, GI = 30, CategoryId = 1 },
                new Product { Id = 12, Name = "cebula", KcalPer100g = 33, GI = 15, CategoryId = 1 },
                new Product { Id = 13, Name = "cukinia", KcalPer100g = 17, GI = 15, CategoryId = 1 },
                new Product { Id = 14, Name = "fasola biała ugotowana", KcalPer100g = 315, GI = 33, CategoryId = 1 },
                new Product { Id = 15, Name = "kalafior", KcalPer100g = 27, GI = 15, CategoryId = 1 },
                new Product { Id = 16, Name = "kapusta biała", KcalPer100g = 33, GI = 15, CategoryId = 1 },
                new Product { Id = 17, Name = "kapusta czerwona", KcalPer100g = 31, GI = 15, CategoryId = 1 },
                new Product { Id = 18, Name = "kapusta włoska", KcalPer100g = 43, GI = 15, CategoryId = 1 },
                new Product { Id = 19, Name = "ogórek", KcalPer100g = 14, GI = 15, CategoryId = 1 },
                new Product { Id = 20, Name = "papryka czerwona", KcalPer100g = 32, GI = 15, CategoryId = 1 },
                new Product { Id = 21, Name = "papryka zielona", KcalPer100g = 22, GI = 15, CategoryId = 1 },
                new Product { Id = 22, Name = "pieczarki", KcalPer100g = 21, GI = 10, CategoryId = 1 },
                new Product { Id = 23, Name = "pomidor", KcalPer100g = 19, GI = 19, CategoryId = 1 },
                new Product { Id = 24, Name = "por", KcalPer100g = 29, GI = 15, CategoryId = 1 },
                new Product { Id = 25, Name = "rzepa", KcalPer100g = 33, GI = 72, CategoryId = 1 },
                new Product { Id = 26, Name = "rzodkiewka", KcalPer100g = 18, GI = 15, CategoryId = 1 },
                new Product { Id = 27, Name = "sałata", KcalPer100g = 14, GI = 10, CategoryId = 1 },
                new Product { Id = 28, Name = "sałata lodowa", KcalPer100g = 16, GI = 10, CategoryId = 1 },
                new Product { Id = 29, Name = "seler korzeń", KcalPer100g = 30, GI = 35, CategoryId = 1 },
                new Product { Id = 30, Name = "seler naciowy", KcalPer100g = 17, GI = 15, CategoryId = 1 },
                new Product { Id = 31, Name = "soczewica gotowana", KcalPer100g = 341, GI = 26, CategoryId = 1 },
                new Product { Id = 32, Name = "szpinak", KcalPer100g = 22, GI = 15, CategoryId = 1 },
                new Product { Id = 33, Name = "brokuł", KcalPer100g = 31, GI = 15, CategoryId = 1 },
                new Product { Id = 34, Name = "kapusta kiszona", KcalPer100g = 18, GI = 15, CategoryId = 1 },
                new Product { Id = 35, Name = "pietruszka", KcalPer100g = 49, GI = 52, CategoryId = 1 },
                new Product { Id = 36, Name = "fasolka szparagowa", KcalPer100g = 33, GI = 15, CategoryId = 1 },
                new Product { Id = 37, Name = "suszone pomidory", KcalPer100g = 213, GI = 35, CategoryId = 1 },
                new Product { Id = 38, Name = "pomidory z puszki", KcalPer100g = 23, GI = 35, CategoryId = 1 },
                new Product { Id = 39, Name = "ogórek konserwowy", KcalPer100g = 23, GI = 15, CategoryId = 1 },


                new Product { Id = 40, Name = "ananas", KcalPer100g = 55, GI = 59, CategoryId = 2 },
                new Product { Id = 41, Name = "agrest", KcalPer100g = 46, GI = 15, CategoryId = 2 },
                new Product { Id = 42, Name = "arbuz", KcalPer100g = 36, GI = 72, CategoryId = 2 },
                new Product { Id = 43, Name = "awokado", KcalPer100g = 169, GI = 10, CategoryId = 2 },
                new Product { Id = 44, Name = "banan", KcalPer100g = 97, GI = 52, CategoryId = 2 },
                new Product { Id = 45, Name = "brzoskwinia", KcalPer100g = 50, GI = 30, CategoryId = 2 },
                new Product { Id = 46, Name = "czereśnie", KcalPer100g = 63, GI = 22, CategoryId = 2 },
                new Product { Id = 47, Name = "grejpfrut", KcalPer100g = 40, GI = 25, CategoryId = 2 },
                new Product { Id = 48, Name = "gruszka", KcalPer100g = 58, GI = 38, CategoryId = 2 },
                new Product { Id = 49, Name = "jabłko", KcalPer100g = 50, GI = 37, CategoryId = 2 },
                new Product { Id = 50, Name = "kiwi", KcalPer100g = 60, GI = 53, CategoryId = 2 },
                new Product { Id = 51, Name = "maliny", KcalPer100g = 43, GI = 25, CategoryId = 2 },
                new Product { Id = 52, Name = "mandarynki", KcalPer100g = 45, GI = 30, CategoryId = 2 },
                new Product { Id = 53, Name = "mango", KcalPer100g = 59, GI = 51, CategoryId = 2 },
                new Product { Id = 54, Name = "melon", KcalPer100g = 24, GI = 65, CategoryId = 2 },
                new Product { Id = 55, Name = "morele", KcalPer100g = 50, GI = 57, CategoryId = 2 },
                new Product { Id = 56, Name = "nektarynki", KcalPer100g = 50, GI = 35, CategoryId = 2 },
                new Product { Id = 57, Name = "pomarańcza", KcalPer100g = 47, GI = 42, CategoryId = 2 },
                new Product { Id = 58, Name = "porzeczka czarna", KcalPer100g = 35, GI = 15, CategoryId = 2 },
                new Product { Id = 59, Name = "śliwki", KcalPer100g = 49, GI = 39, CategoryId = 2 },
                new Product { Id = 60, Name = "truskawki", KcalPer100g = 33, GI = 40, CategoryId = 2 },
                new Product { Id = 61, Name = "winogron", KcalPer100g = 71, GI = 46, CategoryId = 2 },
                new Product { Id = 62, Name = "wiśnie", KcalPer100g = 49, GI = 22, CategoryId = 2 },
                new Product { Id = 137, Name = "borówki", KcalPer100g = 57, GI = 55, CategoryId = 2 },


                new Product { Id = 63, Name = "kasza gryczana", KcalPer100g = 334, GI = 54, CategoryId = 3, GramsPerPortion = 50 },
                new Product { Id = 64, Name = "chleb razowy na zakwasie", KcalPer100g = 213, GI = 48, CategoryId = 3, GramsPerPortion = 50 },
                new Product { Id = 65, Name = "pełnoziarniste spaghetti", KcalPer100g = 289, GI = 55, CategoryId = 3 },
                new Product { Id = 66, Name = "kosmosa ryżowa, quinoa", KcalPer100g = 334, GI = 53, CategoryId = 3 },
                new Product { Id = 67, Name = "płatki owsiane", KcalPer100g = 376, GI = 55, CategoryId = 3 },
                new Product { Id = 68, Name = "makaron ryżowy", KcalPer100g = 365, GI = 61, CategoryId = 3 },
                new Product { Id = 69, Name = "ryż brązowy", KcalPer100g = 335, GI = 50, CategoryId = 3 },
                new Product { Id = 70, Name = "biszkopt", KcalPer100g = 379, GI = 54, CategoryId = 3 },
                new Product { Id = 71, Name = "chleb pszenny", KcalPer100g = 258, GI = 70, CategoryId = 3 },
                new Product { Id = 72, Name = "chleb żytni pełnoziarnisty", KcalPer100g = 229, GI = 58, CategoryId = 3 },
                new Product { Id = 73, Name = "chleb żytni razowy", KcalPer100g = 227, GI = 50, CategoryId = 3 },
                new Product { Id = 74, Name = "kajzerka", KcalPer100g = 300, GI = 70, CategoryId = 3 },
                new Product { Id = 75, Name = "kasza jaglana ugotowana", KcalPer100g = 348, GI = 71, CategoryId = 3 },
                new Product { Id = 76, Name = "kasza jęczmienna perłowa gotowana", KcalPer100g = 335, GI = 70, CategoryId = 3 },
                new Product { Id = 77, Name = "kasza jęczmienna pęczak", KcalPer100g = 343, GI = 25, CategoryId = 3 },
                new Product { Id = 78, Name = "kasza manna", KcalPer100g = 352, GI = 55, CategoryId = 3 },
                new Product { Id = 79, Name = "makaron dwujajeczny", KcalPer100g = 340, GI = 55, CategoryId = 3 },
                new Product { Id = 80, Name = "płatki kukurydziane", KcalPer100g = 381, GI = 81, CategoryId = 3 },
                new Product { Id = 81, Name = "chleb orkiszowy", KcalPer100g = 244, GI = 49, CategoryId = 3, GramsPerPortion = 40 },
                new Product { Id = 82, Name = "muslie", KcalPer100g = 357, GI = 57, CategoryId = 3 }, 



                new Product { Id = 83, Name = "migdały", KcalPer100g = 604, GI = 15, CategoryId = 4 }, 
                new Product { Id = 84, Name = "orzechy arachidowe ", KcalPer100g = 610, GI = 14, CategoryId = 4 }, 
                new Product { Id = 85, Name = "orzechy laskowe", KcalPer100g = 666, GI = 15, CategoryId = 4 }, 
                new Product { Id = 86, Name = "pistacje", KcalPer100g = 621, GI = 15, CategoryId = 4 }, 
                new Product { Id = 87, Name = "orzechy włoskie", KcalPer100g = 666, GI = 15, CategoryId = 4 }, 
                new Product { Id = 138, Name = "mieszanka orzechów", KcalPer100g = 630, GI = 15, CategoryId = 4 },



                new Product { Id = 88, Name = "jogurt naturalny 2%", KcalPer100g = 60, GI = 36, CategoryId = 5 },
                new Product { Id = 89, Name = "jogurt naturalny 0%", KcalPer100g = 49, GI = 27, CategoryId = 5 },
                new Product { Id = 90, Name = "kefir 2%", KcalPer100g = 51, GI = 32, CategoryId = 5 },
                new Product { Id = 91, Name = "mleko 0,5%", KcalPer100g = 39, GI = 32, CategoryId = 5 },
                new Product { Id = 92, Name = "mleko 3,2%", KcalPer100g = 61, GI = 55, CategoryId = 5 },
                new Product { Id = 93, Name = "mleko słodzone zagęszczone", KcalPer100g = 326, GI = 61, CategoryId = 5 },
                new Product { Id = 94, Name = "ser kozi miękki", KcalPer100g = 150, GI = 0, CategoryId = 5 },
                new Product { Id = 95, Name = "ser mozarella", KcalPer100g = 254, GI = 0, CategoryId = 5 },
                new Product { Id = 96, Name = "ser twarogowy chudy", KcalPer100g = 68, GI = 30, CategoryId = 5 },
                new Product { Id = 97, Name = "ser feta", KcalPer100g = 260, GI = 0, CategoryId = 5 },
                new Product { Id = 98, Name = "brie pełnotłusty", KcalPer100g = 332, GI = 0, CategoryId = 5 },
                new Product { Id = 99, Name = "ser camembert", KcalPer100g = 293, GI = 0, CategoryId = 5 },
                new Product { Id = 100, Name = "ementaler", KcalPer100g = 383, GI = 0, CategoryId = 5 },
                new Product { Id = 101, Name = "salami", KcalPer100g = 354, GI = 0, CategoryId = 5 },
                new Product { Id = 102, Name = "śmietana 12%", KcalPer100g = 134, GI = 0, CategoryId = 5 },
                new Product { Id = 103, Name = "śmietana 18%", KcalPer100g = 186, GI = 0, CategoryId = 5 },
                new Product { Id = 136, Name = "jajko", KcalPer100g = 140, GI = 0, CategoryId = 5 },



                new Product { Id = 104, Name = "kaczka", KcalPer100g = 217, GI = 0, CategoryId = 6 },
                new Product { Id = 105, Name = "kiełbasa domowa", KcalPer100g = 172, GI = 0, CategoryId = 6 },
                new Product { Id = 106, Name = "kiełbasa żywiecka", KcalPer100g = 213, GI = 0, CategoryId = 6 },
                new Product { Id = 107, Name = "krewetki gotowane", KcalPer100g = 92, GI = 0, CategoryId = 6 },
                new Product { Id = 108, Name = "królik", KcalPer100g = 115, GI = 0, CategoryId = 6 },
                new Product { Id = 109, Name = "kurczak", KcalPer100g = 98, GI = 0, CategoryId = 6 },
                new Product { Id = 110, Name = "łosoś z rusztu", KcalPer100g = 228, GI = 0, CategoryId = 6 },
                new Product { Id = 111, Name = "polędwica sopocka", KcalPer100g = 165, GI = 0, CategoryId = 6 },
                new Product { Id = 112, Name = "salami (kiełbasa)", KcalPer100g = 346, GI = 0, CategoryId = 6 },
                new Product { Id = 113, Name = "szynka z kurczaka", KcalPer100g = 123, GI = 0, CategoryId = 6 },
                new Product { Id = 114, Name = "szynka wołowa", KcalPer100g = 106, GI = 0, CategoryId = 6 },
                new Product { Id = 115, Name = "szynka z indyka", KcalPer100g = 126, GI = 0, CategoryId = 6 },
                new Product { Id = 116, Name = "śledź w oleju", KcalPer100g = 336, GI = 25, CategoryId = 6 },
                new Product { Id = 117, Name = "tuńczyk z rusztu", KcalPer100g = 129, GI = 0, CategoryId = 6 },
                new Product { Id = 118, Name = "tuńczyk w zalewie", KcalPer100g = 252, GI = 0, CategoryId = 6 },
                new Product { Id = 119, Name = "kotlet schabowy", KcalPer100g = 268, GI = 0, CategoryId = 6 },
                new Product { Id = 120, Name = "polędwica wołowa", KcalPer100g = 112, GI = 0, CategoryId = 6 },
                new Product { Id = 121, Name = "kiełbasa domowa", KcalPer100g = 172, GI = 0, CategoryId = 6 },
                new Product { Id = 122, Name = "indyk", KcalPer100g = 84, GI = 0, CategoryId = 6 },
                new Product { Id = 133, Name = "kabanos", KcalPer100g = 480, GI = 0, CategoryId = 6, GramsPerPortion = 45 },
                new Product { Id = 135, Name = "podudzie z kurczaka", KcalPer100g = 161, GI = 0, CategoryId = 6, GramsPerPortion = 90 },
                new Product { Id = 139, Name = "pierś z kurczaka", KcalPer100g = 98, GI = 0, CategoryId = 6, GramsPerPortion = 200 },


                new Product { Id = 123, Name = "ciasteczka owsiane", KcalPer100g = 335, GI = 57, CategoryId = 7 },
                new Product { Id = 124, Name = "czekolada gorzka", KcalPer100g = 645, GI = 22, CategoryId = 7 },
                new Product { Id = 125, Name = "czekolada mleczna", KcalPer100g = 530, GI = 43, CategoryId = 7 },
                new Product { Id = 126, Name = "czekolada biała", KcalPer100g = 564, GI = 44, CategoryId = 7 },
                new Product { Id = 127, Name = "herbatniki ", KcalPer100g = 428, GI = 57, CategoryId = 7 },
                new Product { Id = 128, Name = "baton mars", KcalPer100g = 542, GI = 65, CategoryId = 7 },
                new Product { Id = 129, Name = "twix", KcalPer100g = 493, GI = 44, CategoryId = 7 },
                new Product { Id = 130, Name = "lody", KcalPer100g = 300, GI = 60, CategoryId = 7 },
                new Product { Id = 131, Name = "żelki", KcalPer100g = 306, GI = 78, CategoryId = 7 },


                new Product { Id = 132, Name = "majonez", KcalPer100g = 679, GI = 0, CategoryId = 8 },
                new Product { Id = 134, Name = "hummus", KcalPer100g = 327, GI = 25, GramsPerPortion = 25, CategoryId = 8 }
            );
            #endregion

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 2, Name = "Pieczone podudzia z kurczaka z quinąą i surówką" },
                new Recipe { Id = 4, Name = "Jajka, kabanos" },
                new Recipe { Id = 5, Name = "Owoce, jogurt, orzechy" },
                new Recipe { Id = 8, Name = "Owsianka z owocami i orzechami" },
                new Recipe { Id = 9, Name = "Sałatka Orzo" },
                new Recipe { Id = 10, Name = "Kanapka z szynką i warzywami" },
                new Recipe { Id = 7, Name = "Pieczona pierś z kurczaka z suszonymi pomidorami, fasolką szparagową i ryżem brązowym" },
                new Recipe { Id = 6, Name = "Kanapki z warzywami" }
            );

            modelBuilder.Entity<Meal>().HasData(
                new Meal {  Id = 1, Name = "Breakfast"},    
                new Meal {  Id = 2, Name = "Lunch" },
                new Meal {  Id = 3, Name = "Dinner" },
                new Meal {  Id = 4, Name = "Snack" },
                new Meal {  Id = 5, Name = "Supper" }
            );

            modelBuilder.Entity<MealRecipe>().HasData(
                new MealRecipe { Id = 1, MealsId = 3, RecipesId = 7 },
                new MealRecipe { Id = 2, MealsId = 3, RecipesId = 2 }
            );

            #region Przepisy
            modelBuilder.Entity<Recipe_Ingredients>().HasData(
                //Pieczone podudzia z kurczaka z quinąą i surówką
                new Recipe_Ingredients { Id = 3, RecipeId = 2, ProductId = 135, Amount = 180 }, // podudzie z kurczaka 
                new Recipe_Ingredients { Id = 4, RecipeId = 2, ProductId = 66, Amount = 50 }, // quinoa
                new Recipe_Ingredients { Id = 5, RecipeId = 2, ProductId = 19, Amount = 100 }, // ogórek 

                //Jajka, kabanos	
                new Recipe_Ingredients { Id = 9, RecipeId = 4, ProductId = 136, Amount = 120 }, //jajko
                new Recipe_Ingredients { Id = 10, RecipeId = 4, ProductId = 133, Amount = 45 }, //kabanos

                //Owoce, jogurt, orzechy	
                new Recipe_Ingredients { Id = 11, RecipeId = 5, ProductId = 137, Amount = 100 }, //borówki
                new Recipe_Ingredients { Id = 12, RecipeId = 5, ProductId = 88, Amount = 150 }, //jogurt naturalny
                new Recipe_Ingredients { Id = 13, RecipeId = 5, ProductId = 138, Amount = 30 }, //mieszanka orzechy

                //Pieczona pierś z kurczaka z suszonymi pomidorami, fasolką szparagową i ryżem brązowym
                new Recipe_Ingredients { Id = 14, RecipeId = 7, ProductId = 36, Amount = 200 }, //fasolka szparagowa
                new Recipe_Ingredients { Id = 15, RecipeId = 7, ProductId = 69, Amount = 50 }, //ryż brązowy
                new Recipe_Ingredients { Id = 16, RecipeId = 7, ProductId = 139, Amount = 200 }, //pierś z kurczaka 
                new Recipe_Ingredients { Id = 17, RecipeId = 7, ProductId = 37, Amount = 20 }, //suszone pomidory

                //Owsianka z owocami i orzechami	
                new Recipe_Ingredients { Id = 18, RecipeId = 8, ProductId = 91, Amount = 100 }, // mleko
                new Recipe_Ingredients { Id = 19, RecipeId = 8, ProductId = 67, Amount = 50 }, // płatki owsiane 
                new Recipe_Ingredients { Id = 20, RecipeId = 8, ProductId = 137, Amount = 200 }, //borówki
                new Recipe_Ingredients { Id = 21, RecipeId = 8, ProductId = 138, Amount = 20 }, //mieszanka orzechy

                //Sałatka orzo	
                new Recipe_Ingredients { Id = 30, RecipeId = 9, ProductId = 113, Amount = 50 }, //szynka z kurczaka
                new Recipe_Ingredients { Id = 22, RecipeId = 9, ProductId = 132, Amount = 10 }, //majonez
                new Recipe_Ingredients { Id = 23, RecipeId = 9, ProductId = 19, Amount = 40 }, //ogórek
                new Recipe_Ingredients { Id = 24, RecipeId = 9, ProductId = 134, Amount = 25 }, //hummus
                new Recipe_Ingredients { Id = 25, RecipeId = 9, ProductId = 81, Amount = 40 }, //chleb
                
                //Kanapki z warzywami i szynką
                new Recipe_Ingredients { Id = 26, RecipeId = 10, ProductId = 81, Amount = 40 }, //chleb orkiszowy
                new Recipe_Ingredients { Id = 27, RecipeId = 10, ProductId = 113, Amount = 50 }, //szynka z kurczaka
                new Recipe_Ingredients { Id = 28, RecipeId = 10, ProductId = 134, Amount = 25 }, //hummus
                new Recipe_Ingredients { Id = 29, RecipeId = 10, ProductId = 19, Amount = 40 }, //ogórek


                //Kanapka z warzywami
                new Recipe_Ingredients { Id = 6, RecipeId = 6, ProductId = 81, Amount = 80 }, //chleb orkiszowy
                new Recipe_Ingredients { Id = 7, RecipeId = 6, ProductId = 23, Amount = 50 }, //pomidor
                new Recipe_Ingredients { Id = 8, RecipeId = 6, ProductId = 134, Amount = 25 } //hummus
            );
            #endregion

            modelBuilder.Entity<Day>().HasData(
                new Day { Id = 1, Name = "Day 1"},    
                new Day { Id = 2, Name = "Day 2" }
            );

            modelBuilder.Entity<Day_Recipe>().HasData(
                new Day_Recipe { Id = 1, DayId = 1, BreakfastRecipeId = 6, LunchRecipeId = 4, DinnerRecipeId = 2, SupperRecipeId = 5},    
                new Day_Recipe { Id = 2, DayId = 2, BreakfastRecipeId = 8, LunchRecipeId = 9, DinnerRecipeId = 7, SupperRecipeId = 10 }
            );
        }

    }
}
