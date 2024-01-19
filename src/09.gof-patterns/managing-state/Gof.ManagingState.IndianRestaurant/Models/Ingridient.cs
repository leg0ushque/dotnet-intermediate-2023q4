using Gof.ManagingState.IndianRestaurant.Models.Enums;

namespace Gof.ManagingState.IndianRestaurant.Models
{
    public class Ingridient
    {
        public string Name { get; set; }

        public int Grams { get; set; }

        public Level FryingLevel { get; set; }

        public Level SaltnessLevel { get; set; }

        public Level PepperinessLevel { get; set; }
    }
}
