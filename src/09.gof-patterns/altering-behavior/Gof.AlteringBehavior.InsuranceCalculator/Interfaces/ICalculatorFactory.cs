namespace Gof.AlteringBehavior.InsuranceCalculator.Interfaces
{
    // Declared, but not implemented -> Builder is more appropriate for this application
    public interface ICalculatorFactory
    {
        ICalculator CreateCalculator();

        ICalculator CreateCachedCalculator();

        ICalculator CreateLoggingCalculator();

        ICalculator CreateRoundingCalculator();
    }
}
