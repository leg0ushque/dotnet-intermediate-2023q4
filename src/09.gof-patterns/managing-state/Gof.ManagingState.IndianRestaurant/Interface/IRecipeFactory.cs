namespace Gof.ManagingState.IndianRestaurant.Interface
{
    public interface IRecipeFactory
    {
        IRecipe CreateDefaultRecipe();

        IRecipe CreateSummerRecipe();
    }
}
