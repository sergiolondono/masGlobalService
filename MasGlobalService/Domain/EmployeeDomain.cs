using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasGlobalService.Models;
using MasGlobalService.DAL;
using AutoMapper;
using MasGlobalService.DTO;

namespace MasGlobalService.Domain
{
    public class EmployeeDomain
    {
        public IEnumerable<EmployeeDTO> getEmployees()
        {
            try
            {
                IEnumerable<EmployeeDTO> employees = getAllEmployees();
                return employees;
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
                var singleEmployee = employees.Where(e => e.id == id).FirstOrDefault();
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