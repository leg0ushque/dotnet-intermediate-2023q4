using Gof.ManagingState.IndianRestaurant.Models;
using Gof.ManagingState.IndianRestaurant.Interface;

namespace Gof.ManagingState.IndianRestaurant.Services
{
    public class MasalaRecipe : IRecipe
    {
        private readonly Ingridient _riceIngridient;
        private readonly Ingridient _chickenIngridient;

        public MasalaRecipe(Ingridient riceIngridient, Ingridient chickenIngridient)
        {
            _riceIngridient = riceIngridient;
            _chickenIngridient = chickenIngridient;
        }

        public void CookMasala(ICooker cooker)
        {
            cooker.FryRice(_riceIngridient.Grams, _riceIngridient.FryingLevel);
            cooker.FryChicken(_chickenIngridient.Grams, _chickenIngridient.FryingLevel);
            cooker.SaltRice(_riceIngridient.SaltnessLevel);
            cooker.PepperRice(_riceIngridient.PepperinessLevel);
            cooker.SaltChicken(_chickenIngridient.SaltnessLevel);
            cooker.PepperChicken(_chickenIngridient.PepperinessLevel);
        }
    }
}
