
namespace MasGlobalService.DTO
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
        public decimal AnnualSalary { get; set; }

        //private decimal _AnnualSalary = 0;
        //public decimal AnnualSalary
        //{
        //    get
        //    {
        //        if (contractTypeName == "HourlySalaryEmployee")
        //        {
        //            _AnnualSalary = 120 * hourlySalary * 12;
        //        }
        //        else if (contractTypeName == "MonthlySalaryEmployee")
        //        {
        //            _AnnualSalary = monthlySalary * 12;
        //        }
        //        return _AnnualSalary;
        //    }
        //    set { _AnnualSalary = value; }
        //}

    }
}