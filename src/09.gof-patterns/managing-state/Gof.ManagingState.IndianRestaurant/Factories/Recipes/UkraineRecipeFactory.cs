using Gof.ManagingState.IndianRestaurant.Models;
using Gof.ManagingState.IndianRestaurant.Models.Enums;

namespace Gof.ManagingState.IndianRestaurant.Factories.Recipes
{

    public class UkraineRecipeFactory : TemplateRecipeFactory
    {
        public UkraineRecipeFactory()
            : base(Country.Ukraine)
        {
        }

        protected override Ingridient CreateChickenForBaseRecipe()
        {
            return new Ingridient
            {
                Name = Chicken,
                Grams = 300,
                FryingLevel = Level.Medium,
                PepperinessLevel = Level.Low,
                SaltnessLevel = Level.Medium,
            };
        }

        protected override Ingridient CreateChickenForSummerRecipe()
        {
            return new Ingridient
            {
                Name = Chicken,
                Grams = 200,
                FryingLevel = Level.Medium,
                PepperinessLevel = Level.None,
                SaltnessLevel = Level.Low,
            };
        }

        protected override Ingridient CreateRiceForBaseRecipe()
        {
            return new Ingridient
            {
                Name = Rice,
                Grams = 500,
                FryingLevel = Level.High,
                PepperinessLevel = Level.Low,
                SaltnessLevel = Level.High,
            };
        }

        protected override Ingridient CreateRiceForSummerRecipe()
        {
            return new Ingridient
            {
                Name = Rice,
                Grams = 150,
                FryingLevel = Level.Medium,
                PepperinessLevel = Level.None,
                SaltnessLevel = Level.Low,
            };
        }
    }
}
