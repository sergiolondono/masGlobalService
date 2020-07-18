using MasGlobalService.Factories.Salaries;
using MasGlobalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalService.Factories
{
    public class ConcreteSalaryFactory : SalaryFactory
    {
        public override ISalaryFactory GetCalculatedSalary(string contractTypeName)
        {
            switch (contractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlySalary();
                case "MonthlySalaryEmployee":
                    return new MonthlySalary();
                default:
                    throw new ApplicationException(string.Format("Salary '{0}' cannot be created because the type is not implemented", contractTypeName));
            }
        }
    }
}