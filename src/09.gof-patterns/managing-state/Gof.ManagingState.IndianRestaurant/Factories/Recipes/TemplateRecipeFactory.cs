using Gof.ManagingState.IndianRestaurant.Models;
using Gof.ManagingState.IndianRestaurant.Models.Enums;
using Gof.ManagingState.IndianRestaurant.Interface;
using Gof.ManagingState.IndianRestaurant.Services;

namespace Gof.ManagingState.IndianRestaurant.Factories.Recipes
{
    public abstract class TemplateRecipeFactory : IRecipeFactory
    {
        protected const string Rice = nameof(Rice);
        protected const string Chicken = nameof(Chicken);

        public Country Country { get; }

        protected TemplateRecipeFactory(Country country)
        {
            Country = country;
        }

        public IRecipe CreateDefaultRecipe()
        {
            return new MasalaRecipe(
                CreateRiceForBaseRecipe(),
                CreateChickenForBaseRecipe()
            );
        }

        public IRecipe CreateSummerRecipe()
        {
            return new MasalaRecipe(
                CreateRiceForSummerRecipe(),
                CreateChickenForSummerRecipe()
            );
        }

        protected abstract Ingridient CreateRiceForBaseRecipe();

        protected abstract Ingridient CreateChickenForBaseRecipe();

        protected abstract Ingridient CreateRiceForSummerRecipe();

        protected abstract Ingridient CreateChickenForSummerRecipe();
    }
}
