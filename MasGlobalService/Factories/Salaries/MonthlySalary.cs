using MasGlobalService.Interfaces;

namespace MasGlobalService.Factories.Salaries
{
    public class MonthlySalary : ISalaryFactory
    {
        public decimal calculateSalary(decimal value)
        {
            return value * 12;
        }
    }
}