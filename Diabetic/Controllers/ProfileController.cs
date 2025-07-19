using System.Security.Claims;
using Diabetic.Data.Repositories.Interfaces;
using Diabetic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diabetic.Controllers;

public class ProfileController : BaseController
{
    private readonly IUserRepository _userRepository;

    public ProfileController(IRecipeRepository recipeRepository, IProductRepository productRepository,
        ICategoryRepository categoryRepository, IUserRepository userRepository,
        IMealRepository? mealRepository = null) : base(recipeRepository,
        productRepository, categoryRepository, mealRepository)
    {
        _userRepository = userRepository; 
    }

    public IActionResult Index()
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        UserProfile userProfile = _userRepository.Get(userId); 
        return View(userProfile);
    }
    
    public IActionResult Update(UserProfile profile)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return RedirectToAction("Login", "Account");
        }

        UserProfile userProfile = _userRepository.Get(userId); 
        bool result = _userRepository.Upsert(profile);
        if (!result)
        {
            ModelState.AddModelError("", "Failed to update profile. Please try again.");
            return View("Index", userProfile);
        }
        
        return RedirectToAction(nameof(this.Index));
    }
}