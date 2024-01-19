using Gof.ManagingState.IndianRestaurant.Models;
using Gof.ManagingState.IndianRestaurant.Models.Enums;

namespace Gof.ManagingState.IndianRestaurant.Factories.Recipes
{
    public class IndiaRecipeFactory : TemplateRecipeFactory
    {
        public IndiaRecipeFactory()
            : base(Country.India)
        {
        }

        protected override Ingridient CreateChickenForBaseRecipe()
        {
            return new Ingridient
            {
                Name = Chicken,
                Grams = 100,
                FryingLevel = Level.High,
                PepperinessLevel = Level.High,
                SaltnessLevel = Level.High,
            };
        }

        protected override Ingridient CreateChickenForSummerRecipe()
        {
            return new Ingridient
            {
                Name = Chicken,
                Grams = 100,
                FryingLevel = Level.Low,
                PepperinessLevel = Level.Medium,
                SaltnessLevel = Level.None,
            };
        }

        protected override Ingridient CreateRiceForBaseRecipe()
        {
            return new Ingridient
            {
                Name = Rice,
                Grams = 200,
                FryingLevel = Level.High,
                PepperinessLevel = Level.High,
                SaltnessLevel = Level.High,
            };
        }

        protected override Ingridient CreateRiceForSummerRecipe()
        {
            return new Ingridient
            {
                Name = Rice,
                Grams = 100,
                FryingLevel = Level.Low,
                PepperinessLevel = Level.Medium,
                SaltnessLevel = Level.None,
            };
        }
    }

}
