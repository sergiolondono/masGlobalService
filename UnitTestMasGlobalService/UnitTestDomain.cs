using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasGlobalService.DTO;
using MasGlobalService.Domain;
using MasGlobalService.Factories;
using System.Linq;

namespace UnitTestMasGlobalService
{
    [TestClass]
    public class UnitTestDomain
    {
        [TestMethod]
        public void getCalculatedSalaryByEmployee_WithEmployeeHourlySalary_Return120XHourSalaryX12()
        {
            // Arrange
            List<EmployeeDTO> employees = new List<EmployeeDTO>() {
            new EmployeeDTO(){ id = 1, name = "Juan",
                               contractTypeName = "HourlySalaryEmployee",  roleId= 1,
                               roleName= "Administrator", roleDescription= "",
                               hourlySalary= 35000, monthlySalary= 80000 }
            };

            EmployeeDomain domain = new EmployeeDomain();
            SalaryFactory factory = new ConcreteSalaryFactory();

            // Act
            var calculatedEmployeeSalary = domain.getCalculatedSalaryByEmployee(employees, factory).ToList();

            decimal actual = calculatedEmployeeSalary[0].AnnualSalary;

            // Assert
            decimal expected = 50400000;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCalculatedSalaryByEmployee_WithEmployeeMonthlySalary_ReturnMonthlySalaryX12()
        {
            // Arrange
            List<EmployeeDTO> employees = new List<EmployeeDTO>() {
            new EmployeeDTO(){ id = 2, name = "Pedro",
                               contractTypeName = "MonthlySalaryEmployee",  roleId= 1,
                               roleName= "Contractor", roleDescription= "",
                               hourlySalary= 50000, monthlySalary= 400000 }
            };

            EmployeeDomain domain = new EmployeeDomain();
            SalaryFactory factory = new ConcreteSalaryFactory();

            // Act
            var calculatedEmployeeSalary = domain.getCalculatedSalaryByEmployee(employees, factory).ToList();

            decimal actual = calculatedEmployeeSalary[0].AnnualSalary;

            // Assert
            decimal expected = 4800000;
            Assert.AreEqual(expected, actual);
        }

    }
}
