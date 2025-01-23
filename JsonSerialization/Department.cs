using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinarySerialization
{
    [Serializable]
    public class Department
    {
        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }

        [JsonProperty("staff")]
        public List<Employee> Employees { get; set; }

        public Department() { } // Parameterless constructor for serialization

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }
    }
}
