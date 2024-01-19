using Gof.ManagingState.IndianRestaurant.Models;
using Gof.ManagingState.IndianRestaurant.Models.Enums;

namespace Gof.ManagingState.IndianRestaurant.Factories.Recipes
{
    public class EnglandRecipeFactory : TemplateRecipeFactory
    {
        public EnglandRecipeFactory()
            : base(Country.England)
        {
        }

        protected override Ingridient CreateChickenForBaseRecipe()
        {
            return new Ingridient
            {
                Name = Chicken,
                Grams = 100,
                FryingLevel = Level.Low,
                PepperinessLevel = Level.None,
                SaltnessLevel = Level.None,
            };
        }

        protected override Ingridient CreateChickenForSummerRecipe()
        {
            return new Ingridient
            {
                Name = Chicken,
                Grams = 50,
                FryingLevel = Level.Low,
                PepperinessLevel = Level.None,
                SaltnessLevel = Level.None,
            };
        }

        protected override Ingridient CreateRiceForBaseRecipe()
        {
            return new Ingridient
            {
                Name = Rice,
                Grams = 100,
                FryingLevel = Level.Low,
                PepperinessLevel = Level.None,
                SaltnessLevel = Level.None,
            };
        }

        protected override Ingridient CreateRiceForSummerRecipe()
        {
            return new Ingridient
            {
                Name = Rice,
                Grams = 50,
                FryingLevel = Level.Low,
                PepperinessLevel = Level.None,
                SaltnessLevel = Level.None,
            };
        }
    }
}
