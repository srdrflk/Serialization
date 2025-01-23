using BinarySerialization;
using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        Department department = new Department("IT Department");
        department.AddEmployee(new Employee("Serdar"));
        department.AddEmployee(new Employee("Azam"));

        string filePath = "department.dat";

        // Serialize 
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, department);
        }
        Console.WriteLine("Serialized to binary and wrote to file.");

        // Deserialize 
        Department deserializedDepartment;
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            deserializedDepartment = (Department)binaryFormatter.Deserialize(fileStream);
        }
        Console.WriteLine("Deserialized from binary.");

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