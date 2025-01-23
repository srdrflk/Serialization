using BinarySerialization;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Department department = new Department("Development");
        department.AddEmployee(new Employee("Serdar"));
        department.AddEmployee(new Employee("Azam"));

        string filePath = "department.xml";

        // Serialize to XML
        XmlSerializer serializer = new XmlSerializer(typeof(Department));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, department);
        }
        Console.WriteLine($"Serialized data to XML and wrote to file '{filePath}'.");

        // Deserialize from XML
        Department deserializedDepartment;
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            deserializedDepartment = (Department)serializer.Deserialize(fileStream);
        }
        Console.WriteLine("Deserialized from XML.");


        if (deserializedDepartment != null)
        {
            Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");
            if (deserializedDepartment.Employees != null)
            {
                foreach (Employee emp in deserializedDepartment.Employees)
                {
                    if (emp != null)
                    {
                        Console.WriteLine($"Employee: {emp.EmployeeName}");
                    }
                    else
                    {
                        Console.WriteLine("Encountered a null employee in the list.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No employees found in the department.");
            }
        }
        else
        {
            Console.WriteLine("Deserialization resulted in a null department object.");
        }
    }
}