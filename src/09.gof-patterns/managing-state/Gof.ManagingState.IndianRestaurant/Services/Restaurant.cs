using Gof.ManagingState.IndianRestaurant.Factories;
using Gof.ManagingState.IndianRestaurant.Interface;
using Gof.ManagingState.IndianRestaurant.Models.Enums;

namespace Gof.ManagingState.IndianRestaurant.Services
{
    public class Restaurant
    {
        private const int June = 6;
        private const int August = 8;

        private readonly ICooker _cooker;

        public Restaurant(ICooker cooker = null)
        {
            _cooker = cooker ?? RecipeFactory.CreateDefaultCooker();
        }

        public void CookMasala(Country country, DateTime currentDate)
        {
            var recipeFactory = RecipeFactory.CreateRecipeFactory(country);
            var recipe = (currentDate.Month >= June && currentDate.Month <= August)
                ? recipeFactory.CreateSummerRecipe()
                : recipeFactory.CreateDefaultRecipe();

            recipe.CookMasala(_cooker);
        }
    }
}
