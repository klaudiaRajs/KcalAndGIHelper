using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Warzywa" },
                    { 2, "Owoce" },
                    { 3, "Produkty zbożowe" },
                    { 4, "Orzechy" },
                    { 5, "Nabiał" },
                    { 6, "Mięso, ryby, jaja" },
                    { 7, "Słodycze" },
                    { 8, "Sosy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[,]
                {
                    { 1, 1, 20, null, 33, "marchew" },
                    { 2, 1, 39, null, 33, "marchewka gotowana" },
                    { 3, 1, 51, null, 86, "groszek zielony" },
                    { 4, 1, 52, null, 80, "słodka kukurydza" },
                    { 5, 1, 56, null, 1000, "ziemniak gotowany" },
                    { 6, 1, 40, null, 76, "bób (surowy)" },
                    { 7, 2, 53, null, 46, "Śliwka czerwona" },
                    { 8, 3, 45, 50, 330, "Płatki orkiszowe" },
                    { 9, 1, 69, null, 79, "ziemniak pieczony" },
                    { 10, 1, 20, null, 26, "bakłażan" },
                    { 11, 1, 30, null, 42, "burak" },
                    { 12, 1, 15, null, 33, "cebula" },
                    { 13, 1, 15, null, 17, "cukinia" },
                    { 14, 1, 33, null, 315, "fasola biała ugotowana" },
                    { 15, 1, 15, null, 27, "kalafior" },
                    { 16, 1, 15, null, 33, "kapusta biała" },
                    { 17, 1, 15, null, 31, "kapusta czerwona" },
                    { 18, 1, 15, null, 43, "kapusta włoska" },
                    { 19, 1, 15, null, 14, "ogórek" },
                    { 20, 1, 15, null, 32, "papryka czerwona" },
                    { 21, 1, 15, null, 22, "papryka zielona" },
                    { 22, 1, 10, null, 21, "pieczarki" },
                    { 23, 1, 19, null, 19, "pomidor" },
                    { 24, 1, 15, null, 29, "por" },
                    { 25, 1, 72, null, 33, "rzepa" },
                    { 26, 1, 15, null, 18, "rzodkiewka" },
                    { 27, 1, 10, null, 14, "sałata" },
                    { 28, 1, 10, null, 16, "sałata lodowa" },
                    { 29, 1, 35, null, 30, "seler korzeń" },
                    { 30, 1, 15, null, 17, "seler naciowy" },
                    { 31, 1, 26, null, 341, "soczewica gotowana" },
                    { 32, 1, 15, null, 22, "szpinak" },
                    { 33, 1, 15, null, 31, "brokuł" },
                    { 34, 1, 15, null, 18, "kapusta kiszona" },
                    { 35, 1, 52, null, 49, "pietruszka" },
                    { 36, 1, 15, null, 33, "fasolka szparagowa" },
                    { 37, 1, 35, null, 213, "suszone pomidory" },
                    { 38, 1, 35, null, 23, "pomidory z puszki" },
                    { 39, 1, 15, null, 23, "ogórek konserwowy" },
                    { 40, 2, 59, null, 55, "ananas" },
                    { 41, 2, 15, null, 46, "agrest" },
                    { 42, 2, 72, null, 36, "arbuz" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[,]
                {
                    { 43, 2, 10, null, 169, "awokado" },
                    { 44, 2, 52, null, 97, "banan" },
                    { 45, 2, 30, null, 50, "brzoskwinia" },
                    { 46, 2, 22, null, 63, "czereśnie" },
                    { 47, 2, 25, null, 40, "grejpfrut" },
                    { 48, 2, 38, null, 58, "gruszka" },
                    { 49, 2, 37, null, 50, "jabłko" },
                    { 50, 2, 53, null, 60, "kiwi" },
                    { 51, 2, 25, null, 43, "maliny" },
                    { 52, 2, 30, null, 45, "mandarynki" },
                    { 53, 2, 51, null, 59, "mango" },
                    { 54, 2, 65, null, 24, "melon" },
                    { 55, 2, 57, null, 50, "morele" },
                    { 56, 2, 35, null, 50, "nektarynki" },
                    { 57, 2, 42, null, 47, "pomarańcza" },
                    { 58, 2, 15, null, 35, "porzeczka czarna" },
                    { 59, 2, 39, null, 49, "śliwki" },
                    { 60, 2, 40, null, 33, "truskawki" },
                    { 61, 2, 46, null, 71, "winogron" },
                    { 62, 2, 22, null, 49, "wiśnie" },
                    { 63, 3, 54, 50, 334, "kasza gryczana" },
                    { 64, 3, 48, 50, 213, "chleb razowy na zakwasie" },
                    { 65, 3, 55, null, 289, "pełnoziarniste spaghetti" },
                    { 66, 3, 53, null, 334, "kosmosa ryżowa, quinoa" },
                    { 67, 3, 55, null, 376, "płatki owsiane" },
                    { 68, 3, 61, null, 365, "makaron ryżowy" },
                    { 69, 3, 50, null, 335, "ryż brązowy" },
                    { 70, 3, 54, null, 379, "biszkopt" },
                    { 71, 3, 70, null, 258, "chleb pszenny" },
                    { 72, 3, 58, null, 229, "chleb żytni pełnoziarnisty" },
                    { 73, 3, 50, null, 227, "chleb żytni razowy" },
                    { 74, 3, 70, null, 300, "kajzerka" },
                    { 75, 3, 71, null, 348, "kasza jaglana ugotowana" },
                    { 76, 3, 70, null, 335, "kasza jęczmienna perłowa gotowana" },
                    { 77, 3, 25, null, 343, "kasza jęczmienna pęczak" },
                    { 78, 3, 55, null, 352, "kasza manna" },
                    { 79, 3, 55, null, 340, "makaron dwujajeczny" },
                    { 80, 3, 81, null, 381, "płatki kukurydziane" },
                    { 81, 3, 49, 40, 244, "chleb orkiszowy" },
                    { 82, 3, 57, null, 357, "muslie" },
                    { 83, 4, 15, null, 604, "migdały" },
                    { 84, 4, 14, null, 610, "orzechy arachidowe " }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[,]
                {
                    { 85, 4, 15, null, 666, "orzechy laskowe" },
                    { 86, 4, 15, null, 621, "pistacje" },
                    { 87, 4, 15, null, 666, "orzechy włoskie" },
                    { 88, 5, 36, null, 60, "jogurt naturalny 2%" },
                    { 89, 5, 27, null, 49, "jogurt naturalny 0%" },
                    { 90, 5, 32, null, 51, "kefir 2%" },
                    { 91, 5, 32, null, 39, "mleko 0,5%" },
                    { 92, 5, 55, null, 61, "mleko 3,2%" },
                    { 93, 5, 61, null, 326, "mleko słodzone zagęszczone" },
                    { 94, 5, 0, null, 150, "ser kozi miękki" },
                    { 95, 5, 0, null, 254, "ser mozarella" },
                    { 96, 5, 30, null, 68, "ser twarogowy chudy" },
                    { 97, 5, 0, null, 260, "ser feta" },
                    { 98, 5, 0, null, 332, "brie pełnotłusty" },
                    { 99, 5, 0, null, 293, "ser camembert" },
                    { 100, 5, 0, null, 383, "ementaler" },
                    { 101, 5, 0, null, 354, "salami" },
                    { 102, 5, 0, null, 134, "śmietana 12%" },
                    { 103, 5, 0, null, 186, "śmietana 18%" },
                    { 104, 6, 0, null, 217, "kaczka" },
                    { 105, 6, 0, null, 172, "kiełbasa domowa" },
                    { 106, 6, 0, null, 213, "kiełbasa żywiecka" },
                    { 107, 6, 0, null, 92, "krewetki gotowane" },
                    { 108, 6, 0, null, 115, "królik" },
                    { 109, 6, 0, null, 98, "kurczak" },
                    { 110, 6, 0, null, 228, "łosoś z rusztu" },
                    { 111, 6, 0, null, 165, "polędwica sopocka" },
                    { 112, 6, 0, null, 346, "salami (kiełbasa)" },
                    { 113, 6, 0, null, 123, "szynka z kurczaka" },
                    { 114, 6, 0, null, 106, "szynka wołowa" },
                    { 115, 6, 0, null, 126, "szynka z indyka" },
                    { 116, 6, 25, null, 336, "śledź w oleju" },
                    { 117, 6, 0, null, 129, "tuńczyk z rusztu" },
                    { 118, 6, 0, null, 252, "tuńczyk w zalewie" },
                    { 119, 6, 0, null, 268, "kotlet schabowy" },
                    { 120, 6, 0, null, 112, "polędwica wołowa" },
                    { 121, 6, 0, null, 172, "kiełbasa domowa" },
                    { 122, 6, 0, null, 84, "indyk" },
                    { 123, 7, 57, null, 335, "ciasteczka owsiane" },
                    { 124, 7, 22, null, 645, "czekolada gorzka" },
                    { 125, 7, 43, null, 530, "czekolada mleczna" },
                    { 126, 7, 44, null, 564, "czekolada biała" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[,]
                {
                    { 127, 7, 57, null, 428, "herbatniki " },
                    { 128, 7, 65, null, 542, "baton mars" },
                    { 129, 7, 44, null, 493, "twix" },
                    { 130, 7, 60, null, 300, "lody" },
                    { 131, 7, 78, null, 306, "żelki" },
                    { 132, 8, 0, null, 679, "majonez" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
