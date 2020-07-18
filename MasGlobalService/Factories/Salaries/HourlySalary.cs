using MasGlobalService.Interfaces;

namespace MasGlobalService.Factories.Salaries
{
    public class HourlySalary : ISalaryFactory
    {
        public decimal calculateSalary(decimal value)
        {
            return 120 * value * 12;
        }
    }
}