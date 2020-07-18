using System;
using System.Collections.Generic;
using System.Linq;
using MasGlobalService.Models;
using MasGlobalService.DAL;
using AutoMapper;
using MasGlobalService.DTO;
using MasGlobalService.Interfaces;
using MasGlobalService.Factories;

namespace MasGlobalService.Domain
{
    public class EmployeeDomain 
    {      
        public IEnumerable<EmployeeDTO> getCalculatedSalaryByEmployee(IEnumerable<EmployeeDTO> employees, SalaryFactory factory)
        {
            foreach (var item in employees)
            {
                if (item.contractTypeName == "HourlySalaryEmployee")
                {
                    ISalaryFactory factoryHourly = factory.GetCalculatedSalary(item.contractTypeName);
                    item.AnnualSalary = factoryHourly.calculateSalary(item.hourlySalary);
                }
                else if (item.contractTypeName == "MonthlySalaryEmployee")
                {
                    ISalaryFactory factoryMonthly = factory.GetCalculatedSalary(item.contractTypeName);
                    item.AnnualSalary = factoryMonthly.calculateSalary(item.monthlySalary);
                }
            }

            return employees;
        }

        public IEnumerable<EmployeeDTO> getEmployees()
        {
            try
            {
                IEnumerable<EmployeeDTO> employees = getAllEmployees();

                SalaryFactory factory = new ConcreteSalaryFactory();
                var employeesCalaculatedSalary = getCalculatedSalaryByEmployee(employees, factory);

                return employeesCalaculatedSalary;
            }
            catch (Exception ex)
            {
                throw new Exception($"System Error: {ex.Message}");
            }
        }

        public EmployeeDTO getEmployeeById(int id)
        {
            try
            {
                IEnumerable<EmployeeDTO> employees = getAllEmployees();
                SalaryFactory factory = new ConcreteSalaryFactory();
                var employeesCalaculatedSalary = getCalculatedSalaryByEmployee(employees, factory);

                var singleEmployee = employeesCalaculatedSalary.Where(e => e.id == id).FirstOrDefault();
                return singleEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception($"System Error: {ex.Message}");
            }
        }

        private static IEnumerable<EmployeeDTO> getAllEmployees()
        {
            var employeeDal = new EmployeeDAL();
            var employees = employeeDal.getEmployees();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new Employee();
            var dest = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
            return dest;
        }

    }
}