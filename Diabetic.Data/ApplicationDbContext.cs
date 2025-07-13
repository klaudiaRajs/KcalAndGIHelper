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
        public DbSet<IngredientMealDay> IngredientMealDays { get; set; }

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
                new Category { Id = 9, Name = "Tłuszcz" },
                new Category { Id = 8, Name = "Sosy" }
            );

            #region Products 
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "marchew", KcalPer100G = 33, Gi = 20, CategoryId = 1, CarbsPer100G = 5.1},
                new Product { Id = 2, Name = "marchewka gotowana", KcalPer100G = 33, Gi = 39, CategoryId = 1, CarbsPer100G = 5.1},
                new Product { Id = 3, Name = "groszek zielony", KcalPer100G = 86, Gi = 51, CategoryId = 1, CarbsPer100G = 11},
                new Product { Id = 4, Name = "słodka kukurydza", KcalPer100G = 80, Gi = 52, CategoryId = 1, CarbsPer100G = 10.8},
                new Product { Id = 5, Name = "ziemniak gotowany", KcalPer100G = 1000, Gi = 56, CategoryId = 1, CarbsPer100G = 15},
                new Product { Id = 6, Name = "bób (surowy)", KcalPer100G = 76, Gi = 40, CategoryId = 1, CarbsPer100G = 8.2, Fat = 0.4, Fibre = 5.8, Protein = 7.1, Sugar = 0 },
                new Product { Id = 7, Name = "Śliwka czerwona", KcalPer100G = 46, Gi = 53, CategoryId = 2, CarbsPer100G = 10.1},
                new Product { Id = 8, Name = "Płatki orkiszowe", KcalPer100G = 330, Gi = 45, CategoryId = 3, GramsPerPortion = 50, CarbsPer100G = 71.4},
                new Product { Id = 9, Name = "ziemniak pieczony", KcalPer100G = 79, Gi = 69, CategoryId = 1, CarbsPer100G = 17},
                new Product { Id = 10, Name = "bakłażan", KcalPer100G = 26, Gi = 20, CategoryId = 1, CarbsPer100G = 3.8},
                new Product { Id = 11, Name = "burak", KcalPer100G = 42, Gi = 30, CategoryId = 1, CarbsPer100G = 7.3},
                new Product { Id = 12, Name = "cebula", KcalPer100G = 33, Gi = 15, CategoryId = 1, CarbsPer100G = 5.2 },
                new Product { Id = 13, Name = "cukinia", KcalPer100G = 17, Gi = 15, CategoryId = 1, CarbsPer100G = 7.3 },
                new Product { Id = 14, Name = "fasola biała ugotowana", KcalPer100G = 315, Gi = 33, CategoryId = 1, CarbsPer100G = 45.9 },
                new Product { Id = 15, Name = "kalafior", KcalPer100G = 27, Gi = 15, CategoryId = 1, CarbsPer100G = 2.6 },
                new Product { Id = 16, Name = "kapusta biała", KcalPer100G = 33, Gi = 15, CategoryId = 1, CarbsPer100G = 4.9 },
                new Product { Id = 17, Name = "kapusta czerwona", KcalPer100G = 31, Gi = 15, CategoryId = 1, CarbsPer100G = 4.2},
                new Product { Id = 18, Name = "kapusta włoska", KcalPer100G = 43, Gi = 15, CategoryId = 1, CarbsPer100G = 5.2 },
                new Product { Id = 19, Name = "ogórek", KcalPer100G = 14, Gi = 15, CategoryId = 1, CarbsPer100G = 2.4 },
                new Product { Id = 20, Name = "papryka czerwona", KcalPer100G = 32, Gi = 15, CategoryId = 1, CarbsPer100G = 4.6 },
                new Product { Id = 21, Name = "papryka zielona", KcalPer100G = 22, Gi = 15, CategoryId = 1, CarbsPer100G = 2.5 },
                new Product { Id = 22, Name = "pieczarki", KcalPer100G = 21, Gi = 10, CategoryId = 1, CarbsPer100G = 2.6 },
                new Product { Id = 23, Name = "pomidor", KcalPer100G = 19, Gi = 19, CategoryId = 1, CarbsPer100G = 2.4 },
                new Product { Id = 24, Name = "por", KcalPer100G = 29, Gi = 15, CategoryId = 1, CarbsPer100G = 3 },
                new Product { Id = 25, Name = "rzepa", KcalPer100G = 33, Gi = 72, CategoryId = 1, CarbsPer100G = 5.2 },
                new Product { Id = 26, Name = "rzodkiewka", KcalPer100G = 18, Gi = 15, CategoryId = 1, CarbsPer100G = 2.1 },
                new Product { Id = 27, Name = "sałata", KcalPer100G = 14, Gi = 10, CategoryId = 1, CarbsPer100G = 1.5 },
                new Product { Id = 28, Name = "sałata lodowa", KcalPer100G = 16, Gi = 10, CategoryId = 1 },
                new Product { Id = 29, Name = "seler korzeń", KcalPer100G = 30, Gi = 35, CategoryId = 1 },
                new Product { Id = 30, Name = "seler naciowy", KcalPer100G = 17, Gi = 15, CategoryId = 1 },
                new Product { Id = 31, Name = "soczewica gotowana", KcalPer100G = 341, Gi = 26, CategoryId = 1 },
                new Product { Id = 32, Name = "szpinak", KcalPer100G = 22, Gi = 15, CategoryId = 1 },
                new Product { Id = 33, Name = "brokuł", KcalPer100G = 31, Gi = 15, CategoryId = 1 },
                new Product { Id = 34, Name = "kapusta kiszona", KcalPer100G = 18, Gi = 15, CategoryId = 1 },
                new Product { Id = 35, Name = "pietruszka", KcalPer100G = 49, Gi = 52, CategoryId = 1 },
                new Product { Id = 36, Name = "fasolka szparagowa", KcalPer100G = 33, Gi = 15, CategoryId = 1 },
                new Product { Id = 37, Name = "suszone pomidory", KcalPer100G = 213, Gi = 35, CategoryId = 1 },
                new Product { Id = 38, Name = "pomidory z puszki", KcalPer100G = 23, Gi = 35, CategoryId = 1 },
                new Product { Id = 39, Name = "ogórek konserwowy", KcalPer100G = 23, Gi = 15, CategoryId = 1, CarbsPer100G = 6.6, Sugar = 5.8, Protein = 0, Fibre = 0, Fat = 0 },


                new Product { Id = 40, Name = "ananas", KcalPer100G = 55, Gi = 59, CategoryId = 2 },
                new Product { Id = 41, Name = "agrest", KcalPer100G = 46, Gi = 15, CategoryId = 2 },
                new Product { Id = 42, Name = "arbuz", KcalPer100G = 36, Gi = 72, CategoryId = 2 },
                new Product { Id = 43, Name = "awokado", KcalPer100G = 169, Gi = 10, CategoryId = 2 },
                new Product { Id = 44, Name = "banan", KcalPer100G = 97, Gi = 52, CategoryId = 2 },
                new Product { Id = 45, Name = "brzoskwinia", KcalPer100G = 50, Gi = 30, CategoryId = 2 },
                new Product { Id = 46, Name = "czereśnie", KcalPer100G = 63, Gi = 22, CategoryId = 2 },
                new Product { Id = 47, Name = "grejpfrut", KcalPer100G = 40, Gi = 25, CategoryId = 2 },
                new Product { Id = 48, Name = "gruszka", KcalPer100G = 58, Gi = 38, CategoryId = 2 },
                new Product { Id = 49, Name = "jabłko", KcalPer100G = 50, Gi = 37, CategoryId = 2 },
                new Product { Id = 50, Name = "kiwi", KcalPer100G = 60, Gi = 53, CategoryId = 2 },
                new Product { Id = 51, Name = "maliny", KcalPer100G = 43, Gi = 25, CategoryId = 2 },
                new Product { Id = 52, Name = "mandarynki", KcalPer100G = 45, Gi = 30, CategoryId = 2 },
                new Product { Id = 53, Name = "mango", KcalPer100G = 59, Gi = 51, CategoryId = 2 },
                new Product { Id = 54, Name = "melon", KcalPer100G = 24, Gi = 65, CategoryId = 2 },
                new Product { Id = 55, Name = "morele", KcalPer100G = 50, Gi = 57, CategoryId = 2 },
                new Product { Id = 56, Name = "nektarynki", KcalPer100G = 50, Gi = 35, CategoryId = 2 },
                new Product { Id = 57, Name = "pomarańcza", KcalPer100G = 47, Gi = 42, CategoryId = 2 },
                new Product { Id = 58, Name = "porzeczka czarna", KcalPer100G = 35, Gi = 15, CategoryId = 2 },
                new Product { Id = 59, Name = "śliwki", KcalPer100G = 49, Gi = 39, CategoryId = 2 },
                new Product { Id = 60, Name = "truskawki", KcalPer100G = 33, Gi = 40, CategoryId = 2 },
                new Product { Id = 61, Name = "winogron", KcalPer100G = 71, Gi = 46, CategoryId = 2 },
                new Product { Id = 62, Name = "wiśnie", KcalPer100G = 49, Gi = 22, CategoryId = 2 },



                new Product { Id = 63, Name = "kasza gryczana", KcalPer100G = 334, Gi = 54, CategoryId = 3, GramsPerPortion = 50 },
                new Product { Id = 64, Name = "chleb razowy na zakwasie", KcalPer100G = 213, Gi = 48, CategoryId = 3, GramsPerPortion = 50 },
                new Product { Id = 65, Name = "pełnoziarniste spaghetti", KcalPer100G = 289, Gi = 55, CategoryId = 3 },
                new Product { Id = 66, Name = "kosmosa ryżowa, quinoa", KcalPer100G = 334, Gi = 53, CategoryId = 3 },
                new Product { Id = 67, Name = "płatki owsiane", KcalPer100G = 376, Gi = 55, CategoryId = 3 },
                new Product { Id = 68, Name = "makaron ryżowy", KcalPer100G = 365, Gi = 61, CategoryId = 3 },
                new Product { Id = 69, Name = "ryż brązowy", KcalPer100G = 335, Gi = 50, CategoryId = 3 },
                new Product { Id = 70, Name = "biszkopt", KcalPer100G = 379, Gi = 54, CategoryId = 3 },
                new Product { Id = 71, Name = "chleb pszenny", KcalPer100G = 258, Gi = 70, CategoryId = 3 },
                new Product { Id = 72, Name = "chleb żytni pełnoziarnisty", KcalPer100G = 229, Gi = 58, CategoryId = 3 },
                new Product { Id = 73, Name = "chleb żytni razowy", KcalPer100G = 227, Gi = 50, CategoryId = 3 },
                new Product { Id = 74, Name = "kajzerka", KcalPer100G = 300, Gi = 70, CategoryId = 3 },
                new Product { Id = 75, Name = "kasza jaglana ugotowana", KcalPer100G = 348, Gi = 71, CategoryId = 3 },
                new Product { Id = 76, Name = "kasza jęczmienna perłowa gotowana", KcalPer100G = 335, Gi = 70, CategoryId = 3 },
                new Product { Id = 77, Name = "kasza jęczmienna pęczak", KcalPer100G = 343, Gi = 25, CategoryId = 3 },
                new Product { Id = 78, Name = "kasza manna", KcalPer100G = 352, Gi = 55, CategoryId = 3 },
                new Product { Id = 79, Name = "makaron dwujajeczny", KcalPer100G = 340, Gi = 55, CategoryId = 3 },
                new Product { Id = 80, Name = "płatki kukurydziane", KcalPer100G = 381, Gi = 81, CategoryId = 3 },
                new Product { Id = 81, Name = "chleb orkiszowy", KcalPer100G = 244, Gi = 49, CategoryId = 3, GramsPerPortion = 40 },
                new Product { Id = 82, Name = "muslie", KcalPer100G = 357, Gi = 57, CategoryId = 3 },



                new Product { Id = 83, Name = "migdały", KcalPer100G = 604, Gi = 15, CategoryId = 4 },
                new Product { Id = 84, Name = "orzechy arachidowe ", KcalPer100G = 610, Gi = 14, CategoryId = 4 },
                new Product { Id = 85, Name = "orzechy laskowe", KcalPer100G = 666, Gi = 15, CategoryId = 4 },
                new Product { Id = 86, Name = "pistacje", KcalPer100G = 621, Gi = 15, CategoryId = 4 },
                new Product { Id = 87, Name = "orzechy włoskie", KcalPer100G = 666, Gi = 15, CategoryId = 4 },



                new Product { Id = 88, Name = "jogurt naturalny 2%", KcalPer100G = 60, Gi = 36, CategoryId = 5 },
                new Product { Id = 89, Name = "jogurt naturalny 0%", KcalPer100G = 49, Gi = 27, CategoryId = 5 },
                new Product { Id = 90, Name = "kefir 2%", KcalPer100G = 51, Gi = 32, CategoryId = 5 },
                new Product { Id = 91, Name = "mleko 0,5%", KcalPer100G = 39, Gi = 32, CategoryId = 5 },
                new Product { Id = 92, Name = "mleko 3,2%", KcalPer100G = 61, Gi = 55, CategoryId = 5 },
                new Product { Id = 93, Name = "mleko słodzone zagęszczone", KcalPer100G = 326, Gi = 61, CategoryId = 5 },
                new Product { Id = 94, Name = "ser kozi miękki", KcalPer100G = 150, Gi = 0, CategoryId = 5 },
                new Product { Id = 95, Name = "ser mozarella", KcalPer100G = 254, Gi = 0, CategoryId = 5 },
                new Product { Id = 96, Name = "ser twarogowy chudy", KcalPer100G = 68, Gi = 30, CategoryId = 5 },
                new Product { Id = 97, Name = "ser feta", KcalPer100G = 260, Gi = 0, CategoryId = 5 },
                new Product { Id = 98, Name = "brie pełnotłusty", KcalPer100G = 332, Gi = 0, CategoryId = 5 },
                new Product { Id = 99, Name = "ser camembert", KcalPer100G = 293, Gi = 0, CategoryId = 5 },
                new Product { Id = 100, Name = "ementaler", KcalPer100G = 383, Gi = 0, CategoryId = 5 },
                new Product { Id = 101, Name = "salami", KcalPer100G = 354, Gi = 0, CategoryId = 5 },
                new Product { Id = 102, Name = "śmietana 12%", KcalPer100G = 134, Gi = 0, CategoryId = 5 },
                new Product { Id = 103, Name = "śmietana 18%", KcalPer100G = 186, Gi = 0, CategoryId = 5 },



                new Product { Id = 104, Name = "kaczka", KcalPer100G = 217, Gi = 0, CategoryId = 6 },
                new Product { Id = 105, Name = "kiełbasa domowa", KcalPer100G = 172, Gi = 0, CategoryId = 6 },
                new Product { Id = 106, Name = "kiełbasa żywiecka", KcalPer100G = 213, Gi = 0, CategoryId = 6 },
                new Product { Id = 107, Name = "krewetki gotowane", KcalPer100G = 92, Gi = 0, CategoryId = 6 },
                new Product { Id = 108, Name = "królik", KcalPer100G = 115, Gi = 0, CategoryId = 6 },
                new Product { Id = 109, Name = "kurczak", KcalPer100G = 98, Gi = 0, CategoryId = 6, Fat = 1, Protein = 22, Fibre = 0, Sugar = 0 },
                new Product { Id = 110, Name = "łosoś z rusztu", KcalPer100G = 228, Gi = 0, CategoryId = 6 },
                new Product { Id = 111, Name = "polędwica sopocka", KcalPer100G = 165, Gi = 0, CategoryId = 6 },
                new Product { Id = 112, Name = "salami (kiełbasa)", KcalPer100G = 346, Gi = 0, CategoryId = 6 },
                new Product { Id = 113, Name = "szynka z kurczaka", KcalPer100G = 123, Gi = 0, CategoryId = 6 },
                new Product { Id = 114, Name = "szynka wołowa", KcalPer100G = 106, Gi = 0, CategoryId = 6 },
                new Product { Id = 115, Name = "szynka z indyka", KcalPer100G = 126, Gi = 0, CategoryId = 6 },
                new Product { Id = 116, Name = "śledź w oleju", KcalPer100G = 336, Gi = 25, CategoryId = 6 },
                new Product { Id = 117, Name = "tuńczyk z rusztu", KcalPer100G = 129, Gi = 0, CategoryId = 6 },
                new Product { Id = 118, Name = "tuńczyk w zalewie", KcalPer100G = 252, Gi = 0, CategoryId = 6 },
                new Product { Id = 119, Name = "kotlet schabowy", KcalPer100G = 268, Gi = 0, CategoryId = 6 },
                new Product { Id = 120, Name = "polędwica wołowa", KcalPer100G = 112, Gi = 0, CategoryId = 6 },
                new Product { Id = 121, Name = "kiełbasa domowa", KcalPer100G = 172, Gi = 0, CategoryId = 6 },
                new Product { Id = 122, Name = "indyk", KcalPer100G = 84, Gi = 0, CategoryId = 6 },



                new Product { Id = 123, Name = "ciasteczka owsiane", KcalPer100G = 335, Gi = 57, CategoryId = 7 },
                new Product { Id = 124, Name = "czekolada gorzka", KcalPer100G = 645, Gi = 22, CategoryId = 7 },
                new Product { Id = 125, Name = "czekolada mleczna", KcalPer100G = 530, Gi = 43, CategoryId = 7 },
                new Product { Id = 126, Name = "czekolada biała", KcalPer100G = 564, Gi = 44, CategoryId = 7 },
                new Product { Id = 127, Name = "herbatniki ", KcalPer100G = 428, Gi = 57, CategoryId = 7 },
                new Product { Id = 128, Name = "baton mars", KcalPer100G = 542, Gi = 65, CategoryId = 7 },
                new Product { Id = 129, Name = "twix", KcalPer100G = 493, Gi = 44, CategoryId = 7 },
                new Product { Id = 130, Name = "lody", KcalPer100G = 300, Gi = 60, CategoryId = 7 },
                new Product { Id = 131, Name = "żelki", KcalPer100G = 306, Gi = 78, CategoryId = 7 },


                new Product { Id = 132, Name = "majonez", KcalPer100G = 679, Gi = 0, CategoryId = 8 },
                new Product { Id = 133, Name = "kabanos", KcalPer100G = 480, Gi = 0, CategoryId = 6, GramsPerPortion = 45 },
                new Product { Id = 134, Name = "hummus", KcalPer100G = 327, Gi = 25, GramsPerPortion = 25, CategoryId = 8 }, 
                new Product { Id = 135, Name = "podudzie z kurczaka", KcalPer100G = 161, Gi = 0, CategoryId = 6, GramsPerPortion = 90 },
                new Product { Id = 136, Name = "jajko", KcalPer100G = 140, Gi = 0, CategoryId = 5 },
                new Product { Id = 137, Name = "borówki", KcalPer100G = 57, Gi = 55, CategoryId = 2 },
                new Product { Id = 138, Name = "olej rzepakowy", KcalPer100G = 884, CarbsPer100G = 0, Protein = 0, Fat = 100, Fibre = 0, Gi = 0, Sugar = 0, CategoryId = 9 },
                new Product { Id = 139, Name = "pierś z kurczaka", KcalPer100G = 98, Gi = 0, CategoryId = 6, GramsPerPortion = 200 },
                new Product { Id = 142, Name = "mieszanka orzechów", KcalPer100G = 630, Gi = 15, CategoryId = 4 },
                new Product { Id = 141, Name = "sos sojowy", KcalPer100G = 27, Gi = 25, GramsPerPortion = 25, CategoryId = 8, CarbsPer100G = 3, Fat = 0, Protein = 4, Sugar = 0, Fibre = 0 }
            ) ;
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
