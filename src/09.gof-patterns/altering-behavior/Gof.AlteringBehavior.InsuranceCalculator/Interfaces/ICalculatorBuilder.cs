namespace Gof.AlteringBehavior.InsuranceCalculator.Interfaces
{
    public interface ICalculatorBuilder
    {
        ICalculatorBuilder AddCaching();

        ICalculatorBuilder AddRounding();
        
        ICalculatorBuilder AddLogging(ILogger logger);

        ICalculator CreateCalculator();
    }
}
