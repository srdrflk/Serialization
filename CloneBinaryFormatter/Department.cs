using System.Runtime.Serialization.Formatters.Binary;

namespace CloneBinaryFormatter
{
    [Serializable]
    public class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        // Implement deep cloning using binary serialization
        public Department DeepClone()
        {
            using (var memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Position = 0; // reset stream position to the beginning
                return (Department)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
