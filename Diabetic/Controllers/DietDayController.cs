﻿using Diabetic.Data.Repositories;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Diabetic.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; 

namespace Diabetic.Controllers
{
    public class DietDayController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public DietDayController(IDietDayRepository dietDayRepository, IRecipeRepository recipeRepository)
        {
            _dietDayRepository = dietDayRepository;
            this._recipeRepository = recipeRepository;
        }

        private IDietDayRepository _dietDayRepository { get; }

        public IActionResult Index()
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Days = _dietDayRepository.GetAll();
            foreach (DayDietDTO day in viewModel.Days)
            {   
                day.TotalGL = 0;
                if( day.BreakfastId != null)
                {
                    day.Breakfast = _recipeRepository.GetRecipeById((int)day.BreakfastId);
                    day.TotalGL += day.Breakfast.TotalGL;
                }
                if( day.LunchId != null)
                {
                    day.Lunch = _recipeRepository.GetRecipeById((int)day.LunchId);
                    day.TotalGL += day.Lunch.TotalGL;
                }
                if( day.DinnerId != null)
                {
                    day.Dinner = _recipeRepository.GetRecipeById((int)day.DinnerId);
                    day.TotalGL += day.Dinner.TotalGL;
                }
                if( day.SupperId != null)
                {
                    day.Supper = _recipeRepository.GetRecipeById((int)day.SupperId);
                    day.TotalGL += day.Supper.TotalGL;
                }
            }
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.RecipesForDay = _dietDayRepository.GetDay(id);
            if( viewModel.RecipesForDay != null)
            {
                viewModel.RecipesForDay.Breakfast = _recipeRepository.GetRecipeById((int)viewModel.RecipesForDay.BreakfastId);
                viewModel.RecipesForDay.Lunch = _recipeRepository.GetRecipeById((int)viewModel.RecipesForDay.LunchId);
                viewModel.RecipesForDay.Dinner = _recipeRepository.GetRecipeById((int)viewModel.RecipesForDay.DinnerId);
                viewModel.RecipesForDay.Supper = _recipeRepository.GetRecipeById((int)viewModel.RecipesForDay.SupperId);
            }

            return View(viewModel);
        }

        public IActionResult Create(RecipeViewModel model)
        {
            DayDietViewModel viewModel = new DayDietViewModel();
            viewModel.Dinners = _recipeRepository.GetByMeal(3); 
            viewModel.Recipes = _recipeRepository.GetNonDinnerRecipes();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(DayDietViewModel model)
        {

            var result = _dietDayRepository.Create(model.RecipesForDay);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            DayDietDTO day = _dietDayRepository.GetDay(id);
            bool result = _dietDayRepository.Delete(day); 
            return RedirectToAction("Index"); 
        }
    }
}
