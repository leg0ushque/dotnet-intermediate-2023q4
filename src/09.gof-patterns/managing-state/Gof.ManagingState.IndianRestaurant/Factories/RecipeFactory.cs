using Gof.ManagingState.IndianRestaurant.Services;
using Gof.ManagingState.IndianRestaurant.Interface;
using Gof.ManagingState.IndianRestaurant.Models.Enums;
using Gof.ManagingState.IndianRestaurant.Factories.Recipes;

namespace Gof.ManagingState.IndianRestaurant.Factories
{
    public static class RecipeFactory
    {
        private static readonly TemplateRecipeFactory[] _templateRecipeFactories = new TemplateRecipeFactory[]
        {
            new UkraineRecipeFactory(),
            new IndiaRecipeFactory(),
            new EnglandRecipeFactory(),
        };

        public static IRecipeFactory CreateRecipeFactory(Country country)
        {
            var recipeFactory = _templateRecipeFactories
                .SingleOrDefault(factory => factory.Country == country);

            return recipeFactory ?? throw new ArgumentOutOfRangeException(nameof(country));
        }

        public static ICooker CreateDefaultCooker()
        {
            return new DefaultCooker();
        }
    }

}
