using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasGlobalService.Models
{
    public class Employee
    {
        public int id { get; set; }

        private string _name = "";
        public string name 
        {
            get { return _name; }
            set { _name = value != null ? value : ""; }
        }

        private string _contractTypeName = "";
        public string contractTypeName 
        {
            get { return _contractTypeName; }
            set { _contractTypeName = value != null ? value : ""; }
        }
        public int roleId { get; set; }

        private string _roleName = "";
        public string roleName 
        {
            get { return _roleName; }
            set { _roleName = value != null ? value : ""; }
        }

        private string _roleDescription = "";
        public string roleDescription
        {
            get { return _roleDescription; }
            set { _roleDescription = value != null ? value : ""; }
        }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }

    }
}