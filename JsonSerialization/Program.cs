using BinarySerialization;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        Department department = new Department("Software Development");
        department.AddEmployee(new Employee("Serdar"));
        department.AddEmployee(new Employee("Azam"));

        string filePath = "department.json";

        // Serialize to JSON
        string json = JsonConvert.SerializeObject(department, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Serialized to JSON and wrote to file:\n" + json);

        // deserialize from JSON
        string readJson = File.ReadAllText(filePath);
        Department deserializedDepartment = JsonConvert.DeserializeObject<Department>(readJson);
        Console.WriteLine("\nDeserialized from JSON:");

        if (deserializedDepartment != null)
        {
            Console.WriteLine($"Department: {deserializedDepartment.DepartmentName}");

            if (deserializedDepartment.Employees != null)
            {
                foreach (Employee employee in deserializedDepartment.Employees)
                {
                    if (employee != null)
                    {
                        Console.WriteLine($"Employee: {employee.EmployeeName}");
                    }
                    else
                    {
                        Console.WriteLine("Encountered a null employee in the list.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }
        else
        {
            Console.WriteLine("Deserialization resulted in a null department object.");
        }

    }
}