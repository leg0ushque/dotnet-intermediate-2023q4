using Gof.ManagingState.IndianRestaurant.Interface;
using Gof.ManagingState.IndianRestaurant.Models.Enums;

namespace Gof.ManagingState.IndianRestaurant.Services
{
    public class DefaultCooker : ICooker
    {
        public void FryChicken(int amount, Level level)
        {
            Console.WriteLine($"Frying {amount} grams of chicken. {level} level of frying");
        }

        public void FryRice(int amount, Level level)
        {
            Console.WriteLine($"Frying {amount} grams of rice. {level} level of frying");
        }

        public void PepperChicken(Level level)
        {
            Console.WriteLine($"Peppering chicken. {level} level of peppering");
        }

        public void PepperRice(Level level)
        {
            Console.WriteLine($"Peppering rice. {level} level of peppering");
        }

        public void SaltChicken(Level level)
        {
            Console.WriteLine($"Salting chicken. {level} level of salting");
        }

        public void SaltRice(Level level)
        {
            Console.WriteLine($"Salting rice. {level} level of salting");
        }
    }

}
