using MasGlobalService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalService.Factories
{
    public abstract class SalaryFactory
    {
        public abstract ISalaryFactory GetCalculatedSalary(string contractTypeName);
    }
}