using CloneBinaryFormatter;

class Program
{
    static void Main()
    {
        Department hrDepartment = new Department("Human Resources");
        hrDepartment.AddEmployee(new Employee("FirstEmp", 30));
        hrDepartment.AddEmployee(new Employee("SecondEmp", 29));

        Department hrDepartmentClone = hrDepartment.DeepClone();

        hrDepartment.Name = "HR Department";
        hrDepartment.Employees[0].Name = "FirstEmp Surname";

        Console.WriteLine("Modified Original Department Name: " + hrDepartment.Name);
        Console.WriteLine("Cloned Department Name After Modification: " + hrDepartmentClone.Name);
        Console.WriteLine("Original Employee Name: " + hrDepartment.Employees[0].Name);
        Console.WriteLine("Cloned Employee Name After Original Modification: " + hrDepartmentClone.Employees[0].Name);
    }
}